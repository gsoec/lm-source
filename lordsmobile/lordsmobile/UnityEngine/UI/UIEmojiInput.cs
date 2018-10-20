using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	// Token: 0x0200086E RID: 2158
	public class UIEmojiInput : Selectable, IBeginDragHandler, IDragHandler, ISubmitHandler, IUpdateSelectedHandler, IPointerClickHandler, IEndDragHandler, ICanvasElement, IEventSystemHandler
	{
		// Token: 0x06002C76 RID: 11382 RVA: 0x0048AFE8 File Offset: 0x004891E8
		protected UIEmojiInput()
		{
		}

		// Token: 0x06002C78 RID: 11384 RVA: 0x0048B08C File Offset: 0x0048928C
		protected override void Awake()
		{
			base.Awake();
			if (this.textComponent != null)
			{
				this.textComponent.SetCheckArabic(true);
			}
		}

		// Token: 0x06002C79 RID: 11385 RVA: 0x0048B0BC File Offset: 0x004892BC
		public void InitSet(bool mbOneLine, float mTextWidthMax)
		{
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06002C7A RID: 11386 RVA: 0x0048B0C0 File Offset: 0x004892C0
		protected TextGenerator cachedInputTextGenerator
		{
			get
			{
				if (this.m_InputTextCache == null)
				{
					this.m_InputTextCache = new TextGenerator();
				}
				return this.m_InputTextCache;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06002C7C RID: 11388 RVA: 0x0048B0F0 File Offset: 0x004892F0
		// (set) Token: 0x06002C7B RID: 11387 RVA: 0x0048B0E0 File Offset: 0x004892E0
		public bool shouldHideMobileInput
		{
			get
			{
				RuntimePlatform platform = Application.platform;
				switch (platform)
				{
				case RuntimePlatform.IPhonePlayer:
				case RuntimePlatform.Android:
					break;
				default:
					if (platform != RuntimePlatform.BB10Player)
					{
						return true;
					}
					break;
				}
				return this.m_HideMobileInput;
			}
			set
			{
				SetPropertyUtility.SetStruct<bool>(ref this.m_HideMobileInput, value);
			}
		}

		// Token: 0x06002C7D RID: 11389 RVA: 0x0048B130 File Offset: 0x00489330
		public void GetText(out string str, out eTextCheck textState)
		{
			if (UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.active && !this.InPlaceEditing() && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				str = this.MaskEmoticon(UIEmojiInput.m_Keyboard.text);
				if (ArabicTransfer.Instance.IsArabicStr(str))
				{
					textState = eTextCheck.Text_Arabic;
				}
				else
				{
					textState = eTextCheck.Text_NonArabic;
				}
			}
			if (this.m_TextComponent != null)
			{
				str = this.m_Text;
				textState = this.m_TextComponent.GetTextState();
			}
			else
			{
				str = string.Empty;
				textState = eTextCheck.Text_None;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06002C7E RID: 11390 RVA: 0x0048B1E0 File Offset: 0x004893E0
		// (set) Token: 0x06002C7F RID: 11391 RVA: 0x0048B244 File Offset: 0x00489444
		public string text
		{
			get
			{
				if (UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.active && !this.InPlaceEditing() && EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					return this.MaskEmoticon(UIEmojiInput.m_Keyboard.text);
				}
				return this.m_Text;
			}
			set
			{
				if (this.text == value)
				{
					return;
				}
				this.m_Text = value;
				if (UIEmojiInput.m_Keyboard != null)
				{
					UIEmojiInput.m_Keyboard.text = this.m_Text;
				}
				if (this.m_CaretPosition > this.m_Text.Length)
				{
					this.m_CaretPosition = (this.m_CaretSelectPosition = this.m_Text.Length);
				}
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x06002C80 RID: 11392 RVA: 0x0048B2BC File Offset: 0x004894BC
		public unsafe string MaskEmoticon(string str)
		{
			DataManager instance = DataManager.Instance;
			fixed (string text = str)
			{
				fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
				{
					for (int i = 0; i < str.Length; i++)
					{
						if (ptr[i] == '\0')
						{
							break;
						}
						if (char.GetUnicodeCategory(ptr[i]) == UnicodeCategory.Surrogate)
						{
							ptr[i] = ' ';
						}
					}
					text = null;
					return str;
				}
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06002C81 RID: 11393 RVA: 0x0048B320 File Offset: 0x00489520
		public bool isFocused
		{
			get
			{
				return this.m_AllowInput;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06002C82 RID: 11394 RVA: 0x0048B328 File Offset: 0x00489528
		// (set) Token: 0x06002C83 RID: 11395 RVA: 0x0048B330 File Offset: 0x00489530
		public float caretBlinkRate
		{
			get
			{
				return this.m_CaretBlinkRate;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<float>(ref this.m_CaretBlinkRate, value) && this.m_AllowInput)
				{
					this.SetCaretActive();
				}
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06002C84 RID: 11396 RVA: 0x0048B360 File Offset: 0x00489560
		// (set) Token: 0x06002C85 RID: 11397 RVA: 0x0048B368 File Offset: 0x00489568
		public UIText textComponent
		{
			get
			{
				return this.m_TextComponent;
			}
			set
			{
				SetPropertyUtility.SetClass<UIText>(ref this.m_TextComponent, value);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06002C86 RID: 11398 RVA: 0x0048B378 File Offset: 0x00489578
		// (set) Token: 0x06002C87 RID: 11399 RVA: 0x0048B380 File Offset: 0x00489580
		public Graphic placeholder
		{
			get
			{
				return this.m_Placeholder;
			}
			set
			{
				SetPropertyUtility.SetClass<Graphic>(ref this.m_Placeholder, value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06002C88 RID: 11400 RVA: 0x0048B390 File Offset: 0x00489590
		// (set) Token: 0x06002C89 RID: 11401 RVA: 0x0048B398 File Offset: 0x00489598
		public Color selectionColor
		{
			get
			{
				return this.m_SelectionColor;
			}
			set
			{
				SetPropertyUtility.SetColor(ref this.m_SelectionColor, value);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06002C8A RID: 11402 RVA: 0x0048B3A8 File Offset: 0x004895A8
		// (set) Token: 0x06002C8B RID: 11403 RVA: 0x0048B3B0 File Offset: 0x004895B0
		public UIEmojiInput.SubmitEvent onEndEdit
		{
			get
			{
				return this.m_EndEdit;
			}
			set
			{
				SetPropertyUtility.SetClass<UIEmojiInput.SubmitEvent>(ref this.m_EndEdit, value);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06002C8C RID: 11404 RVA: 0x0048B3C0 File Offset: 0x004895C0
		// (set) Token: 0x06002C8D RID: 11405 RVA: 0x0048B3C8 File Offset: 0x004895C8
		public UIEmojiInput.OnChangeEvent onValueChange
		{
			get
			{
				return this.m_OnValueChange;
			}
			set
			{
				SetPropertyUtility.SetClass<UIEmojiInput.OnChangeEvent>(ref this.m_OnValueChange, value);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06002C8E RID: 11406 RVA: 0x0048B3D8 File Offset: 0x004895D8
		// (set) Token: 0x06002C8F RID: 11407 RVA: 0x0048B3E0 File Offset: 0x004895E0
		public UIEmojiInput.OnValidateInput onValidateInput
		{
			get
			{
				return this.m_OnValidateInput;
			}
			set
			{
				SetPropertyUtility.SetClass<UIEmojiInput.OnValidateInput>(ref this.m_OnValidateInput, value);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06002C90 RID: 11408 RVA: 0x0048B3F0 File Offset: 0x004895F0
		// (set) Token: 0x06002C91 RID: 11409 RVA: 0x0048B3F8 File Offset: 0x004895F8
		public int characterLimit
		{
			get
			{
				return this.m_CharacterLimit;
			}
			set
			{
				SetPropertyUtility.SetStruct<int>(ref this.m_CharacterLimit, value);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06002C92 RID: 11410 RVA: 0x0048B408 File Offset: 0x00489608
		// (set) Token: 0x06002C93 RID: 11411 RVA: 0x0048B410 File Offset: 0x00489610
		public UIEmojiInput.ContentType contentType
		{
			get
			{
				return this.m_ContentType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UIEmojiInput.ContentType>(ref this.m_ContentType, value))
				{
					this.EnforceContentType();
				}
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06002C94 RID: 11412 RVA: 0x0048B42C File Offset: 0x0048962C
		// (set) Token: 0x06002C95 RID: 11413 RVA: 0x0048B434 File Offset: 0x00489634
		public UIEmojiInput.LineType lineType
		{
			get
			{
				return this.m_LineType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UIEmojiInput.LineType>(ref this.m_LineType, value))
				{
					this.SetToCustomIfContentTypeIsNot(new UIEmojiInput.ContentType[]
					{
						UIEmojiInput.ContentType.Standard,
						UIEmojiInput.ContentType.Autocorrected
					});
				}
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06002C96 RID: 11414 RVA: 0x0048B458 File Offset: 0x00489658
		// (set) Token: 0x06002C97 RID: 11415 RVA: 0x0048B460 File Offset: 0x00489660
		public UIEmojiInput.InputType inputType
		{
			get
			{
				return this.m_InputType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UIEmojiInput.InputType>(ref this.m_InputType, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06002C98 RID: 11416 RVA: 0x0048B47C File Offset: 0x0048967C
		// (set) Token: 0x06002C99 RID: 11417 RVA: 0x0048B484 File Offset: 0x00489684
		public TouchScreenKeyboardType keyboardType
		{
			get
			{
				return this.m_KeyboardType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TouchScreenKeyboardType>(ref this.m_KeyboardType, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06002C9A RID: 11418 RVA: 0x0048B4A0 File Offset: 0x004896A0
		// (set) Token: 0x06002C9B RID: 11419 RVA: 0x0048B4A8 File Offset: 0x004896A8
		public UIEmojiInput.CharacterValidation characterValidation
		{
			get
			{
				return this.m_CharacterValidation;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UIEmojiInput.CharacterValidation>(ref this.m_CharacterValidation, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06002C9C RID: 11420 RVA: 0x0048B4C4 File Offset: 0x004896C4
		public bool multiLine
		{
			get
			{
				return this.m_LineType == UIEmojiInput.LineType.MultiLineNewline || this.lineType == UIEmojiInput.LineType.MultiLineSubmit;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06002C9D RID: 11421 RVA: 0x0048B4E0 File Offset: 0x004896E0
		// (set) Token: 0x06002C9E RID: 11422 RVA: 0x0048B4E8 File Offset: 0x004896E8
		public char asteriskChar
		{
			get
			{
				return this.m_AsteriskChar;
			}
			set
			{
				SetPropertyUtility.SetStruct<char>(ref this.m_AsteriskChar, value);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06002C9F RID: 11423 RVA: 0x0048B4F8 File Offset: 0x004896F8
		public bool wasCanceled
		{
			get
			{
				return this.m_WasCanceled;
			}
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x0048B500 File Offset: 0x00489700
		protected void ClampPos(ref int pos)
		{
			if (pos < 0)
			{
				pos = 0;
			}
			else if (pos > this.text.Length)
			{
				pos = this.text.Length;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06002CA1 RID: 11425 RVA: 0x0048B53C File Offset: 0x0048973C
		// (set) Token: 0x06002CA2 RID: 11426 RVA: 0x0048B550 File Offset: 0x00489750
		protected int caretPositionInternal
		{
			get
			{
				return this.m_CaretPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_CaretPosition = value;
				this.ClampPos(ref this.m_CaretPosition);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06002CA3 RID: 11427 RVA: 0x0048B568 File Offset: 0x00489768
		// (set) Token: 0x06002CA4 RID: 11428 RVA: 0x0048B57C File Offset: 0x0048977C
		protected int caretSelectPositionInternal
		{
			get
			{
				return this.m_CaretSelectPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_CaretSelectPosition = value;
				this.ClampPos(ref this.m_CaretSelectPosition);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06002CA5 RID: 11429 RVA: 0x0048B594 File Offset: 0x00489794
		private bool hasSelection
		{
			get
			{
				return this.caretPositionInternal != this.caretSelectPositionInternal;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06002CA6 RID: 11430 RVA: 0x0048B5A8 File Offset: 0x004897A8
		// (set) Token: 0x06002CA7 RID: 11431 RVA: 0x0048B5BC File Offset: 0x004897BC
		public int caretPosition
		{
			get
			{
				return this.m_CaretSelectPosition + Input.compositionString.Length;
			}
			set
			{
				this.selectionAnchorPosition = value;
				this.selectionFocusPosition = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06002CA8 RID: 11432 RVA: 0x0048B5CC File Offset: 0x004897CC
		// (set) Token: 0x06002CA9 RID: 11433 RVA: 0x0048B5E0 File Offset: 0x004897E0
		public int selectionAnchorPosition
		{
			get
			{
				return this.m_CaretPosition + Input.compositionString.Length;
			}
			set
			{
				if (Input.compositionString.Length != 0)
				{
					return;
				}
				this.m_CaretPosition = value;
				this.ClampPos(ref this.m_CaretPosition);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06002CAA RID: 11434 RVA: 0x0048B608 File Offset: 0x00489808
		// (set) Token: 0x06002CAB RID: 11435 RVA: 0x0048B61C File Offset: 0x0048981C
		public int selectionFocusPosition
		{
			get
			{
				return this.m_CaretSelectPosition + Input.compositionString.Length;
			}
			set
			{
				if (Input.compositionString.Length != 0)
				{
					return;
				}
				this.m_CaretSelectPosition = value;
				this.ClampPos(ref this.m_CaretSelectPosition);
			}
		}

		// Token: 0x06002CAC RID: 11436 RVA: 0x0048B644 File Offset: 0x00489844
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.m_Text == null)
			{
				this.m_Text = string.Empty;
			}
			this.m_DrawStart = 0;
			this.m_DrawEnd = this.m_Text.Length;
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.RegisterDirtyVerticesCallback(new UnityAction(this.MarkGeometryAsDirty));
				this.m_TextComponent.RegisterDirtyVerticesCallback(new UnityAction(this.UpdateLabel));
				this.UpdateLabel();
			}
		}

		// Token: 0x06002CAD RID: 11437 RVA: 0x0048B6CC File Offset: 0x004898CC
		protected override void OnDisable()
		{
			this.m_BlinkCoroutine = null;
			this.DeactivateInputField();
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.UnregisterDirtyVerticesCallback(new UnityAction(this.MarkGeometryAsDirty));
				this.m_TextComponent.UnregisterDirtyVerticesCallback(new UnityAction(this.UpdateLabel));
			}
			CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(this);
			if (this.m_CachedInputRenderer)
			{
				this.m_CachedInputRenderer.SetVertices(null, 0);
			}
			base.OnDisable();
		}

		// Token: 0x06002CAE RID: 11438 RVA: 0x0048B750 File Offset: 0x00489950
		private IEnumerator CaretBlink()
		{
			this.m_CaretVisible = true;
			yield return null;
			while (this.isFocused && this.m_CaretBlinkRate > 0f)
			{
				float blinkPeriod = 1f / this.m_CaretBlinkRate;
				bool blinkState = (Time.unscaledTime - this.m_BlinkStartTime) % blinkPeriod < blinkPeriod / 2f;
				if (this.m_CaretVisible != blinkState)
				{
					this.m_CaretVisible = blinkState;
					this.UpdateGeometry();
				}
				yield return null;
			}
			this.m_BlinkCoroutine = null;
			yield break;
		}

		// Token: 0x06002CAF RID: 11439 RVA: 0x0048B76C File Offset: 0x0048996C
		private void SetCaretVisible()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			this.m_CaretVisible = true;
			this.m_BlinkStartTime = Time.unscaledTime;
			this.SetCaretActive();
		}

		// Token: 0x06002CB0 RID: 11440 RVA: 0x0048B7A0 File Offset: 0x004899A0
		private void SetCaretActive()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			if (this.m_CaretBlinkRate > 0f)
			{
				if (this.m_BlinkCoroutine == null)
				{
					this.m_BlinkCoroutine = base.StartCoroutine(this.CaretBlink());
				}
			}
			else
			{
				this.m_CaretVisible = true;
			}
		}

		// Token: 0x06002CB1 RID: 11441 RVA: 0x0048B7F4 File Offset: 0x004899F4
		protected void OnFocus()
		{
			this.SelectAll();
		}

		// Token: 0x06002CB2 RID: 11442 RVA: 0x0048B7FC File Offset: 0x004899FC
		protected void SelectAll()
		{
			this.caretPositionInternal = this.text.Length;
			this.caretSelectPositionInternal = 0;
		}

		// Token: 0x06002CB3 RID: 11443 RVA: 0x0048B824 File Offset: 0x00489A24
		public void MoveTextEnd(bool shift)
		{
			int length = this.text.Length;
			if (shift)
			{
				this.caretSelectPositionInternal = length;
			}
			else
			{
				this.caretPositionInternal = length;
				this.caretSelectPositionInternal = this.caretPositionInternal;
			}
			this.UpdateLabel();
		}

		// Token: 0x06002CB4 RID: 11444 RVA: 0x0048B868 File Offset: 0x00489A68
		public void MoveTextStart(bool shift)
		{
			int num = 0;
			if (shift)
			{
				this.caretSelectPositionInternal = num;
			}
			else
			{
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = this.caretPositionInternal;
			}
			this.UpdateLabel();
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06002CB5 RID: 11445 RVA: 0x0048B8A4 File Offset: 0x00489AA4
		// (set) Token: 0x06002CB6 RID: 11446 RVA: 0x0048B8CC File Offset: 0x00489ACC
		private static string clipboard
		{
			get
			{
				TextEditor textEditor = new TextEditor();
				textEditor.Paste();
				return textEditor.content.text;
			}
			set
			{
				TextEditor textEditor = new TextEditor();
				textEditor.content = new GUIContent(value);
				textEditor.OnFocus();
				textEditor.Copy();
			}
		}

		// Token: 0x06002CB7 RID: 11447 RVA: 0x0048B8F8 File Offset: 0x00489AF8
		private bool InPlaceEditing()
		{
			return !TouchScreenKeyboard.isSupported;
		}

		// Token: 0x06002CB8 RID: 11448 RVA: 0x0048B904 File Offset: 0x00489B04
		protected virtual void LateUpdate()
		{
			if (this.m_ShouldActivateNextUpdate)
			{
				if (!this.isFocused)
				{
					this.ActivateInputFieldInternal();
					this.m_ShouldActivateNextUpdate = false;
					return;
				}
				this.m_ShouldActivateNextUpdate = false;
			}
			if (this.InPlaceEditing() || !this.isFocused)
			{
				return;
			}
			this.AssignPositioningIfNeeded();
			if (UIEmojiInput.m_Keyboard == null || !UIEmojiInput.m_Keyboard.active)
			{
				if (UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.wasCanceled)
				{
					this.m_WasCanceled = true;
				}
				this.OnDeselect(null);
				return;
			}
			string text = this.MaskEmoticon(UIEmojiInput.m_Keyboard.text);
			if (this.m_Text != text)
			{
				this.m_Text = string.Empty;
				foreach (char c in text)
				{
					if (c == '\r' || c == '\u0003')
					{
						c = '\n';
					}
					if (this.onValidateInput != null)
					{
						c = this.onValidateInput(this.m_Text, this.m_Text.Length, c);
					}
					else if (this.characterValidation != UIEmojiInput.CharacterValidation.None)
					{
						c = this.Validate(this.m_Text, this.m_Text.Length, c);
					}
					if (this.lineType == UIEmojiInput.LineType.MultiLineSubmit && c == '\n')
					{
						UIEmojiInput.m_Keyboard.text = this.m_Text;
						this.OnDeselect(null);
						return;
					}
					if (c != '\0')
					{
						this.m_Text += c;
					}
				}
				if (this.characterLimit > 0 && this.m_Text.Length > this.characterLimit)
				{
					this.m_Text = this.m_Text.Substring(0, this.characterLimit);
				}
				int length = this.m_Text.Length;
				this.caretSelectPositionInternal = length;
				this.caretPositionInternal = length;
				if (this.m_Text != text)
				{
					UIEmojiInput.m_Keyboard.text = this.m_Text;
				}
				this.SendOnValueChangedAndUpdateLabel();
			}
			if (UIEmojiInput.m_Keyboard.done)
			{
				if (UIEmojiInput.m_Keyboard.wasCanceled)
				{
					this.m_WasCanceled = true;
				}
				this.OnDeselect(null);
			}
		}

		// Token: 0x06002CB9 RID: 11449 RVA: 0x0048BB3C File Offset: 0x00489D3C
		public Vector2 ScreenToLocal(Vector2 screen)
		{
			Canvas canvas = this.m_TextComponent.canvas;
			if (canvas == null)
			{
				return screen;
			}
			Vector3 vector = Vector3.zero;
			if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				vector = this.m_TextComponent.transform.InverseTransformPoint(screen);
			}
			else if (canvas.worldCamera != null)
			{
				Ray ray = canvas.worldCamera.ScreenPointToRay(screen);
				Plane plane = new Plane(this.m_TextComponent.transform.forward, this.m_TextComponent.transform.position);
				float distance;
				plane.Raycast(ray, out distance);
				vector = this.m_TextComponent.transform.InverseTransformPoint(ray.GetPoint(distance));
			}
			return new Vector2(vector.x, vector.y);
		}

		// Token: 0x06002CBA RID: 11450 RVA: 0x0048BC14 File Offset: 0x00489E14
		private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator)
		{
			if (!this.multiLine)
			{
				return 0;
			}
			float num = this.m_TextComponent.rectTransform.rect.yMax;
			if (pos.y > num)
			{
				return -1;
			}
			for (int i = 0; i < generator.lineCount; i++)
			{
				float num2 = (float)generator.lines[i].height / this.m_TextComponent.pixelsPerUnit;
				if (pos.y <= num && pos.y > num - num2)
				{
					return i;
				}
				num -= num2;
			}
			return generator.lineCount;
		}

		// Token: 0x06002CBB RID: 11451 RVA: 0x0048BCB8 File Offset: 0x00489EB8
		protected int GetCharacterIndexFromPosition(Vector2 pos)
		{
			TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
			if (cachedTextGenerator.lineCount == 0)
			{
				return 0;
			}
			int unclampedCharacterLineFromPosition = this.GetUnclampedCharacterLineFromPosition(pos, cachedTextGenerator);
			if (unclampedCharacterLineFromPosition < 0)
			{
				return 0;
			}
			if (unclampedCharacterLineFromPosition >= cachedTextGenerator.lineCount)
			{
				return cachedTextGenerator.characterCountVisible;
			}
			int startCharIdx = cachedTextGenerator.lines[unclampedCharacterLineFromPosition].startCharIdx;
			int lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, unclampedCharacterLineFromPosition);
			for (int i = startCharIdx; i < lineEndPosition; i++)
			{
				if (i >= cachedTextGenerator.characterCountVisible)
				{
					break;
				}
				UICharInfo uicharInfo = cachedTextGenerator.characters[i];
				Vector2 vector = uicharInfo.cursorPos / this.m_TextComponent.pixelsPerUnit;
				float num = pos.x - vector.x;
				float num2 = vector.x + uicharInfo.charWidth / this.m_TextComponent.pixelsPerUnit - pos.x;
				if (num < num2)
				{
					return i;
				}
			}
			return lineEndPosition;
		}

		// Token: 0x06002CBC RID: 11452 RVA: 0x0048BDB4 File Offset: 0x00489FB4
		private bool MayDrag(PointerEventData eventData)
		{
			return this.IsActive() && this.IsInteractable() && eventData.button == PointerEventData.InputButton.Left && this.m_TextComponent != null && UIEmojiInput.m_Keyboard == null;
		}

		// Token: 0x06002CBD RID: 11453 RVA: 0x0048BE00 File Offset: 0x0048A000
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			this.m_UpdateDrag = true;
		}

		// Token: 0x06002CBE RID: 11454 RVA: 0x0048BE18 File Offset: 0x0048A018
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			Vector2 pos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.textComponent.rectTransform, eventData.position, eventData.pressEventCamera, out pos);
			this.caretSelectPositionInternal = this.GetCharacterIndexFromPosition(pos) + this.m_DrawStart;
			this.MarkGeometryAsDirty();
			this.m_DragPositionOutOfBounds = !RectTransformUtility.RectangleContainsScreenPoint(this.textComponent.rectTransform, eventData.position, eventData.pressEventCamera);
			if (this.m_DragPositionOutOfBounds && this.m_DragCoroutine == null)
			{
				this.m_DragCoroutine = base.StartCoroutine(this.MouseDragOutsideRect(eventData));
			}
			eventData.Use();
		}

		// Token: 0x06002CBF RID: 11455 RVA: 0x0048BEC0 File Offset: 0x0048A0C0
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			while (this.m_UpdateDrag && this.m_DragPositionOutOfBounds)
			{
				Vector2 localMousePos;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(this.textComponent.rectTransform, eventData.position, eventData.pressEventCamera, out localMousePos);
				Rect rect = this.textComponent.rectTransform.rect;
				if (this.multiLine)
				{
					if (localMousePos.y > rect.yMax)
					{
						this.MoveUp(true, true);
					}
					else if (localMousePos.y < rect.yMin)
					{
						this.MoveDown(true, true);
					}
				}
				else if (localMousePos.x < rect.xMin)
				{
					this.MoveLeft(true, false);
				}
				else if (localMousePos.x > rect.xMax)
				{
					this.MoveRight(true, false);
				}
				this.UpdateLabel();
				float delay = (!this.multiLine) ? 0.05f : 0.1f;
				yield return new WaitForSeconds(delay);
			}
			this.m_DragCoroutine = null;
			yield break;
		}

		// Token: 0x06002CC0 RID: 11456 RVA: 0x0048BEEC File Offset: 0x0048A0EC
		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			this.m_UpdateDrag = false;
		}

		// Token: 0x06002CC1 RID: 11457 RVA: 0x0048BF04 File Offset: 0x0048A104
		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			EventSystem.current.SetSelectedGameObject(base.gameObject, eventData);
			bool allowInput = this.m_AllowInput;
			base.OnPointerDown(eventData);
			if (!this.InPlaceEditing() && (UIEmojiInput.m_Keyboard == null || !UIEmojiInput.m_Keyboard.active))
			{
				this.OnSelect(eventData);
				return;
			}
			if (allowInput)
			{
				Vector2 pos = this.ScreenToLocal(eventData.position);
				int num = this.GetCharacterIndexFromPosition(pos) + this.m_DrawStart;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
			this.UpdateLabel();
			eventData.Use();
		}

		// Token: 0x06002CC2 RID: 11458 RVA: 0x0048BFA8 File Offset: 0x0048A1A8
		protected UIEmojiInput.EditState KeyPressed(Event evt)
		{
			EventModifiers modifiers = evt.modifiers;
			RuntimePlatform platform = Application.platform;
			bool flag = platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer || platform == RuntimePlatform.OSXWebPlayer;
			bool flag2 = (!flag) ? ((modifiers & EventModifiers.Control) != EventModifiers.None) : ((modifiers & EventModifiers.Command) != EventModifiers.None);
			bool flag3 = (modifiers & EventModifiers.Shift) != EventModifiers.None;
			bool flag4 = (modifiers & EventModifiers.Alt) != EventModifiers.None;
			bool flag5 = flag2 && !flag4 && !flag3;
			KeyCode keyCode = evt.keyCode;
			switch (keyCode)
			{
			case KeyCode.KeypadEnter:
				break;
			default:
				switch (keyCode)
				{
				case KeyCode.A:
					if (flag5)
					{
						this.SelectAll();
						return UIEmojiInput.EditState.Continue;
					}
					goto IL_1CF;
				default:
					switch (keyCode)
					{
					case KeyCode.V:
						if (flag5)
						{
							this.Append(UIEmojiInput.clipboard);
							return UIEmojiInput.EditState.Continue;
						}
						goto IL_1CF;
					default:
						if (keyCode == KeyCode.Backspace)
						{
							this.Backspace();
							return UIEmojiInput.EditState.Continue;
						}
						if (keyCode != KeyCode.Return)
						{
							if (keyCode == KeyCode.Escape)
							{
								this.m_WasCanceled = true;
								return UIEmojiInput.EditState.Finish;
							}
							if (keyCode != KeyCode.Delete)
							{
								goto IL_1CF;
							}
							this.ForwardSpace();
							return UIEmojiInput.EditState.Continue;
						}
						break;
					case KeyCode.X:
						if (flag5)
						{
							UIEmojiInput.clipboard = this.GetSelectedString();
							this.Delete();
							this.SendOnValueChangedAndUpdateLabel();
							return UIEmojiInput.EditState.Continue;
						}
						goto IL_1CF;
					}
					break;
				case KeyCode.C:
					if (flag5)
					{
						UIEmojiInput.clipboard = this.GetSelectedString();
						return UIEmojiInput.EditState.Continue;
					}
					goto IL_1CF;
				}
				break;
			case KeyCode.UpArrow:
				this.MoveUp(flag3);
				return UIEmojiInput.EditState.Continue;
			case KeyCode.DownArrow:
				this.MoveDown(flag3);
				return UIEmojiInput.EditState.Continue;
			case KeyCode.RightArrow:
				this.MoveRight(flag3, flag2);
				return UIEmojiInput.EditState.Continue;
			case KeyCode.LeftArrow:
				this.MoveLeft(flag3, flag2);
				return UIEmojiInput.EditState.Continue;
			case KeyCode.Home:
				this.MoveTextStart(flag3);
				return UIEmojiInput.EditState.Continue;
			case KeyCode.End:
				this.MoveTextEnd(flag3);
				return UIEmojiInput.EditState.Continue;
			}
			if (this.lineType != UIEmojiInput.LineType.MultiLineNewline)
			{
				return UIEmojiInput.EditState.Finish;
			}
			IL_1CF:
			if (!this.multiLine && evt.character == '\t')
			{
				return UIEmojiInput.EditState.Continue;
			}
			char c = evt.character;
			if (c == '\r' || c == '\u0003')
			{
				c = '\n';
			}
			if (this.IsValidChar(c))
			{
				this.Append(c);
			}
			if (c == '\0' && Input.compositionString.Length > 0)
			{
				this.UpdateLabel();
			}
			return UIEmojiInput.EditState.Continue;
		}

		// Token: 0x06002CC3 RID: 11459 RVA: 0x0048C1F0 File Offset: 0x0048A3F0
		private bool IsValidChar(char c)
		{
			return c != '\u007f' && (c == '\t' || c == '\n' || this.m_TextComponent.font.HasCharacter(c));
		}

		// Token: 0x06002CC4 RID: 11460 RVA: 0x0048C220 File Offset: 0x0048A420
		public void ProcessEvent(Event e)
		{
			this.KeyPressed(e);
		}

		// Token: 0x06002CC5 RID: 11461 RVA: 0x0048C22C File Offset: 0x0048A42C
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
			if (!this.isFocused)
			{
				return;
			}
			bool flag = false;
			while (Event.PopEvent(this.m_ProcessingEvent))
			{
				if (this.m_ProcessingEvent.rawType == EventType.KeyDown)
				{
					flag = true;
					UIEmojiInput.EditState editState = this.KeyPressed(this.m_ProcessingEvent);
					if (editState == UIEmojiInput.EditState.Finish)
					{
						this.DeactivateInputField();
						break;
					}
				}
			}
			if (flag)
			{
				this.UpdateLabel();
			}
			eventData.Use();
		}

		// Token: 0x06002CC6 RID: 11462 RVA: 0x0048C2A0 File Offset: 0x0048A4A0
		private string GetSelectedString()
		{
			if (!this.hasSelection)
			{
				return string.Empty;
			}
			int num = this.caretPositionInternal;
			int num2 = this.caretSelectPositionInternal;
			if (num > num2)
			{
				int num3 = num;
				num = num2;
				num2 = num3;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = num; i < num2; i++)
			{
				stringBuilder.Append(this.text[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06002CC7 RID: 11463 RVA: 0x0048C310 File Offset: 0x0048A510
		private int FindtNextWordBegin()
		{
			if (this.caretSelectPositionInternal + 1 >= this.text.Length)
			{
				return this.text.Length;
			}
			int num = this.text.IndexOfAny(UIEmojiInput.kSeparators, this.caretSelectPositionInternal + 1);
			if (num == -1)
			{
				num = this.text.Length;
			}
			else
			{
				num++;
			}
			return num;
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x0048C378 File Offset: 0x0048A578
		private void MoveRight(bool shift, bool ctrl)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Max(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
				return;
			}
			int num2;
			if (ctrl)
			{
				num2 = this.FindtNextWordBegin();
			}
			else
			{
				num2 = this.caretSelectPositionInternal + 1;
			}
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
			}
			else
			{
				int num = num2;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
		}

		// Token: 0x06002CC9 RID: 11465 RVA: 0x0048C3F4 File Offset: 0x0048A5F4
		private int FindtPrevWordBegin()
		{
			if (this.caretSelectPositionInternal - 2 < 0)
			{
				return 0;
			}
			int num = this.text.LastIndexOfAny(UIEmojiInput.kSeparators, this.caretSelectPositionInternal - 2);
			if (num == -1)
			{
				num = 0;
			}
			else
			{
				num++;
			}
			return num;
		}

		// Token: 0x06002CCA RID: 11466 RVA: 0x0048C440 File Offset: 0x0048A640
		private void MoveLeft(bool shift, bool ctrl)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Min(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
				return;
			}
			int num2;
			if (ctrl)
			{
				num2 = this.FindtPrevWordBegin();
			}
			else
			{
				num2 = this.caretSelectPositionInternal - 1;
			}
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
			}
			else
			{
				int num = num2;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x0048C4BC File Offset: 0x0048A6BC
		private int DetermineCharacterLine(int charPos, TextGenerator generator)
		{
			if (!this.multiLine)
			{
				return 0;
			}
			for (int i = 0; i < generator.lineCount - 1; i++)
			{
				if (generator.lines[i + 1].startCharIdx > charPos)
				{
					return i;
				}
			}
			return generator.lineCount - 1;
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x0048C518 File Offset: 0x0048A718
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			if (originalPos >= this.cachedInputTextGenerator.characterCountVisible)
			{
				return 0;
			}
			UICharInfo uicharInfo = this.cachedInputTextGenerator.characters[originalPos];
			int num = this.DetermineCharacterLine(originalPos, this.cachedInputTextGenerator);
			if (num - 1 < 0)
			{
				return (!goToFirstChar) ? originalPos : 0;
			}
			int num2 = this.cachedInputTextGenerator.lines[num].startCharIdx - 1;
			for (int i = this.cachedInputTextGenerator.lines[num - 1].startCharIdx; i < num2; i++)
			{
				if (this.cachedInputTextGenerator.characters[i].cursorPos.x >= uicharInfo.cursorPos.x)
				{
					return i;
				}
			}
			return num2;
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x0048C5EC File Offset: 0x0048A7EC
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			if (originalPos >= this.cachedInputTextGenerator.characterCountVisible)
			{
				return this.text.Length;
			}
			UICharInfo uicharInfo = this.cachedInputTextGenerator.characters[originalPos];
			int num = this.DetermineCharacterLine(originalPos, this.cachedInputTextGenerator);
			if (num + 1 >= this.cachedInputTextGenerator.lineCount)
			{
				return (!goToLastChar) ? originalPos : this.text.Length;
			}
			int lineEndPosition = UIEmojiInput.GetLineEndPosition(this.cachedInputTextGenerator, num + 1);
			for (int i = this.cachedInputTextGenerator.lines[num + 1].startCharIdx; i < lineEndPosition; i++)
			{
				if (this.cachedInputTextGenerator.characters[i].cursorPos.x >= uicharInfo.cursorPos.x)
				{
					return i;
				}
			}
			return lineEndPosition;
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x0048C6D0 File Offset: 0x0048A8D0
		private void MoveDown(bool shift)
		{
			this.MoveDown(shift, true);
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x0048C6DC File Offset: 0x0048A8DC
		private void MoveDown(bool shift, bool goToLastChar)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Max(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
			int num2 = (!this.multiLine) ? this.text.Length : this.LineDownCharacterPosition(this.caretSelectPositionInternal, goToLastChar);
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
			}
			else
			{
				int num = num2;
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x0048C768 File Offset: 0x0048A968
		private void MoveUp(bool shift)
		{
			this.MoveUp(shift, true);
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x0048C774 File Offset: 0x0048A974
		private void MoveUp(bool shift, bool goToFirstChar)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Min(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
			int num2 = (!this.multiLine) ? 0 : this.LineUpCharacterPosition(this.caretSelectPositionInternal, goToFirstChar);
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
			}
			else
			{
				int num = num2;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
		}

		// Token: 0x06002CD2 RID: 11474 RVA: 0x0048C7F4 File Offset: 0x0048A9F4
		private void Delete()
		{
			if (this.caretPositionInternal == this.caretSelectPositionInternal)
			{
				return;
			}
			if (this.caretPositionInternal < this.caretSelectPositionInternal)
			{
				this.m_Text = this.text.Substring(0, this.caretPositionInternal) + this.text.Substring(this.caretSelectPositionInternal, this.text.Length - this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = this.caretPositionInternal;
			}
			else
			{
				this.m_Text = this.text.Substring(0, this.caretSelectPositionInternal) + this.text.Substring(this.caretPositionInternal, this.text.Length - this.caretPositionInternal);
				this.caretPositionInternal = this.caretSelectPositionInternal;
			}
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x0048C8C4 File Offset: 0x0048AAC4
		private void ForwardSpace()
		{
			if (this.hasSelection)
			{
				this.Delete();
				this.SendOnValueChangedAndUpdateLabel();
			}
			else if (this.caretPositionInternal < this.text.Length)
			{
				this.m_Text = this.text.Remove(this.caretPositionInternal, 1);
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x0048C924 File Offset: 0x0048AB24
		private void Backspace()
		{
			if (this.hasSelection)
			{
				this.Delete();
				this.SendOnValueChangedAndUpdateLabel();
			}
			else if (this.caretPositionInternal > 0)
			{
				this.m_Text = this.text.Remove(this.caretPositionInternal - 1, 1);
				int num = this.caretPositionInternal - 1;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x06002CD5 RID: 11477 RVA: 0x0048C990 File Offset: 0x0048AB90
		private void Insert(char c)
		{
			string text = c.ToString();
			this.Delete();
			if (this.characterLimit > 0 && this.text.Length >= this.characterLimit)
			{
				return;
			}
			this.m_Text = this.text.Insert(this.m_CaretPosition, text);
			this.caretSelectPositionInternal = (this.caretPositionInternal += text.Length);
			this.SendOnValueChanged();
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x0048CA08 File Offset: 0x0048AC08
		private void SendOnValueChangedAndUpdateLabel()
		{
			this.SendOnValueChanged();
			this.UpdateLabel();
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x0048CA18 File Offset: 0x0048AC18
		private void SendOnValueChanged()
		{
			if (this.onValueChange != null)
			{
				this.onValueChange.Invoke(this.text);
			}
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x0048CA44 File Offset: 0x0048AC44
		protected void SendOnSubmit()
		{
			if (this.onEndEdit != null)
			{
				this.onEndEdit.Invoke(this.m_Text);
			}
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x0048CA64 File Offset: 0x0048AC64
		protected virtual void Append(string input)
		{
			if (!this.InPlaceEditing())
			{
				return;
			}
			int i = 0;
			int length = input.Length;
			while (i < length)
			{
				char c = input[i];
				if (c >= ' ')
				{
					this.Append(c);
				}
				i++;
			}
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x0048CAB0 File Offset: 0x0048ACB0
		protected virtual void Append(char input)
		{
			if (!this.InPlaceEditing())
			{
				return;
			}
			if (this.onValidateInput != null)
			{
				input = this.onValidateInput(this.text, this.caretPositionInternal, input);
			}
			else if (this.characterValidation != UIEmojiInput.CharacterValidation.None)
			{
				input = this.Validate(this.text, this.caretPositionInternal, input);
			}
			if (input == '\0')
			{
				return;
			}
			this.Insert(input);
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x0048CB24 File Offset: 0x0048AD24
		protected void UpdateLabel()
		{
			if (this.m_TextComponent != null && this.m_TextComponent.font != null && !this.m_PreventFontCallback)
			{
				string text;
				if (Input.compositionString.Length > 0)
				{
					text = this.text.Substring(0, this.m_CaretPosition) + Input.compositionString + this.text.Substring(this.m_CaretPosition);
				}
				else
				{
					text = this.text;
				}
				string text2;
				if (this.inputType == UIEmojiInput.InputType.Password)
				{
					text2 = new string(this.asteriskChar, text.Length);
				}
				else
				{
					text2 = text;
				}
				bool flag = string.IsNullOrEmpty(text);
				if (this.m_Placeholder != null)
				{
					this.m_Placeholder.enabled = flag;
				}
				if (!this.m_AllowInput)
				{
					this.m_DrawStart = 0;
					this.m_DrawEnd = this.m_Text.Length;
				}
				bool flag2 = ArabicTransfer.Instance.IsArabicStr(text2);
				if (!flag)
				{
					Vector2 size = this.m_TextComponent.rectTransform.rect.size;
					TextGenerationSettings generationSettings = this.m_TextComponent.GetGenerationSettings(size);
					generationSettings.generateOutOfBounds = true;
					this.m_PreventFontCallback = true;
					if (flag2)
					{
						this.m_TextComponent.text = text2;
						this.cachedInputTextGenerator.Populate(this.m_TextComponent.text, generationSettings);
					}
					else
					{
						this.cachedInputTextGenerator.Populate(text2, generationSettings);
					}
					this.m_PreventFontCallback = false;
					this.cachedInputTextGenerator.Invalidate();
					this.SetDrawRangeToContainCaretPosition(this.cachedInputTextGenerator, this.caretSelectPositionInternal, ref this.m_DrawStart, ref this.m_DrawEnd);
					text2 = text2.Substring(this.m_DrawStart, Mathf.Min(this.m_DrawEnd, text2.Length) - this.m_DrawStart);
					this.SetCaretVisible();
				}
				else
				{
					this.m_TextComponent.text = string.Empty;
				}
				if (!flag2)
				{
					this.m_TextComponent.text = text2;
				}
				this.MarkGeometryAsDirty();
			}
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x0048CD2C File Offset: 0x0048AF2C
		private bool IsSelectionVisible()
		{
			return this.m_DrawStart <= this.caretPositionInternal && this.m_DrawStart <= this.caretSelectPositionInternal && this.m_DrawEnd >= this.caretPositionInternal && this.m_DrawEnd >= this.caretSelectPositionInternal;
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x0048CD84 File Offset: 0x0048AF84
		private static int GetLineStartPosition(TextGenerator gen, int line)
		{
			line = Mathf.Clamp(line, 0, gen.lines.Count - 1);
			return gen.lines[line].startCharIdx;
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x0048CDBC File Offset: 0x0048AFBC
		private static int GetLineEndPosition(TextGenerator gen, int line)
		{
			line = Mathf.Max(line, 0);
			if (line + 1 < gen.lines.Count)
			{
				return gen.lines[line + 1].startCharIdx;
			}
			return gen.characterCountVisible;
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x0048CE04 File Offset: 0x0048B004
		private void SetDrawRangeToContainCaretPosition(TextGenerator gen, int caretPos, ref int drawStart, ref int drawEnd)
		{
			Vector2 size = gen.rectExtents.size;
			if (this.multiLine)
			{
				IList<UILineInfo> lines = gen.lines;
				int num = this.DetermineCharacterLine(caretPos, gen);
				int num2 = (int)size.y;
				if (drawEnd <= caretPos)
				{
					drawEnd = UIEmojiInput.GetLineEndPosition(gen, num);
					int num3 = num;
					while (num3 >= 0 && num3 < lines.Count)
					{
						num2 -= lines[num3].height;
						if (num2 < 0)
						{
							break;
						}
						drawStart = UIEmojiInput.GetLineStartPosition(gen, num3);
						num3--;
					}
				}
				else
				{
					if (drawStart > caretPos)
					{
						drawStart = UIEmojiInput.GetLineStartPosition(gen, num);
					}
					int num4 = this.DetermineCharacterLine(drawStart, gen);
					int num5 = num4;
					drawEnd = UIEmojiInput.GetLineEndPosition(gen, num5);
					num2 -= lines[num5].height;
					for (;;)
					{
						if (num5 < lines.Count - 1)
						{
							num5++;
							if (num2 < lines[num5].height)
							{
								break;
							}
							drawEnd = UIEmojiInput.GetLineEndPosition(gen, num5);
							num2 -= lines[num5].height;
						}
						else
						{
							if (num4 <= 0)
							{
								break;
							}
							num4--;
							if (num2 < lines[num4].height)
							{
								break;
							}
							drawStart = UIEmojiInput.GetLineStartPosition(gen, num4);
							num2 -= lines[num4].height;
						}
					}
				}
			}
			else
			{
				float num6 = size.x;
				IList<UICharInfo> characters = gen.characters;
				if (drawEnd <= caretPos)
				{
					drawEnd = Mathf.Min(caretPos, gen.characterCountVisible);
					drawStart = 0;
					for (int i = drawEnd; i > 0; i--)
					{
						num6 -= characters[i - 1].charWidth;
						if (num6 < 0f)
						{
							drawStart = i;
							break;
						}
					}
				}
				else
				{
					if (drawStart > caretPos)
					{
						drawStart = caretPos;
					}
					drawEnd = gen.characterCountVisible;
					for (int j = drawStart; j < gen.characterCountVisible; j++)
					{
						num6 -= characters[j].charWidth;
						if (num6 < 0f)
						{
							drawEnd = j;
							break;
						}
					}
				}
			}
		}

		// Token: 0x06002CE0 RID: 11488 RVA: 0x0048D070 File Offset: 0x0048B270
		private void MarkGeometryAsDirty()
		{
			CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(this);
		}

		// Token: 0x06002CE1 RID: 11489 RVA: 0x0048D078 File Offset: 0x0048B278
		public virtual void Rebuild(CanvasUpdate update)
		{
			if (update == CanvasUpdate.LatePreRender)
			{
				this.UpdateGeometry();
			}
		}

		// Token: 0x06002CE2 RID: 11490 RVA: 0x0048D0A0 File Offset: 0x0048B2A0
		private void UpdateGeometry()
		{
			if (!this.shouldHideMobileInput)
			{
				return;
			}
			if (this.m_CachedInputRenderer == null && this.m_TextComponent != null)
			{
				GameObject gameObject = new GameObject(base.transform.name + " Input Caret");
				gameObject.hideFlags = HideFlags.DontSave;
				gameObject.transform.SetParent(this.m_TextComponent.transform.parent);
				gameObject.transform.SetAsFirstSibling();
				gameObject.layer = base.gameObject.layer;
				this.caretRectTrans = gameObject.AddComponent<RectTransform>();
				this.m_CachedInputRenderer = gameObject.AddComponent<CanvasRenderer>();
				this.m_CachedInputRenderer.SetMaterial(Graphic.defaultGraphicMaterial, null);
				gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
				this.AssignPositioningIfNeeded();
			}
			if (this.m_CachedInputRenderer == null)
			{
				return;
			}
			this.OnFillVBO(this.m_Vbo);
			if (this.m_Vbo.Count == 0)
			{
				this.m_CachedInputRenderer.SetVertices(null, 0);
			}
			else
			{
				this.m_CachedInputRenderer.SetVertices(this.m_Vbo.ToArray(), this.m_Vbo.Count);
			}
			this.m_Vbo.Clear();
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x0048D1DC File Offset: 0x0048B3DC
		private void AssignPositioningIfNeeded()
		{
			if (this.m_TextComponent != null && this.caretRectTrans != null && (this.caretRectTrans.localPosition != this.m_TextComponent.rectTransform.localPosition || this.caretRectTrans.localRotation != this.m_TextComponent.rectTransform.localRotation || this.caretRectTrans.localScale != this.m_TextComponent.rectTransform.localScale || this.caretRectTrans.anchorMin != this.m_TextComponent.rectTransform.anchorMin || this.caretRectTrans.anchorMax != this.m_TextComponent.rectTransform.anchorMax || this.caretRectTrans.anchoredPosition != this.m_TextComponent.rectTransform.anchoredPosition || this.caretRectTrans.sizeDelta != this.m_TextComponent.rectTransform.sizeDelta || this.caretRectTrans.pivot != this.m_TextComponent.rectTransform.pivot))
			{
				this.caretRectTrans.localPosition = this.m_TextComponent.rectTransform.localPosition;
				this.caretRectTrans.localRotation = this.m_TextComponent.rectTransform.localRotation;
				this.caretRectTrans.localScale = this.m_TextComponent.rectTransform.localScale;
				this.caretRectTrans.anchorMin = this.m_TextComponent.rectTransform.anchorMin;
				this.caretRectTrans.anchorMax = this.m_TextComponent.rectTransform.anchorMax;
				this.caretRectTrans.anchoredPosition = this.m_TextComponent.rectTransform.anchoredPosition;
				this.caretRectTrans.sizeDelta = this.m_TextComponent.rectTransform.sizeDelta;
				this.caretRectTrans.pivot = this.m_TextComponent.rectTransform.pivot;
			}
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x0048D40C File Offset: 0x0048B60C
		private void OnFillVBO(List<UIVertex> vbo)
		{
			if (!this.isFocused)
			{
				return;
			}
			Rect rect = this.m_TextComponent.rectTransform.rect;
			Vector2 size = rect.size;
			Vector2 textAnchorPivot = Text.GetTextAnchorPivot(this.m_TextComponent.alignment);
			Vector2 zero = Vector2.zero;
			zero.x = Mathf.Lerp(rect.xMin, rect.xMax, textAnchorPivot.x);
			zero.y = Mathf.Lerp(rect.yMin, rect.yMax, textAnchorPivot.y);
			Vector2 a = this.m_TextComponent.PixelAdjustPoint(zero);
			Vector2 roundingOffset = a - zero + Vector2.Scale(size, textAnchorPivot);
			roundingOffset.x -= Mathf.Floor(0.5f + roundingOffset.x);
			roundingOffset.y -= Mathf.Floor(0.5f + roundingOffset.y);
			if (!this.hasSelection)
			{
				this.GenerateCursor(vbo, roundingOffset);
			}
			else
			{
				this.GenerateHightlight(vbo, roundingOffset);
			}
		}

		// Token: 0x06002CE5 RID: 11493 RVA: 0x0048D520 File Offset: 0x0048B720
		private void GenerateCursor(List<UIVertex> vbo, Vector2 roundingOffset)
		{
			if (!this.m_CaretVisible)
			{
				return;
			}
			if (this.m_CursorVerts == null)
			{
				this.CreateCursorVerts();
			}
			float num = 1f;
			float num2 = (float)this.m_TextComponent.fontSize;
			int num3 = Mathf.Max(0, this.caretPositionInternal - this.m_DrawStart);
			TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
			if (cachedTextGenerator == null)
			{
				return;
			}
			if (this.m_TextComponent.resizeTextForBestFit)
			{
				num2 = (float)cachedTextGenerator.fontSizeUsedForBestFit / this.m_TextComponent.pixelsPerUnit;
			}
			Vector2 zero = Vector2.zero;
			if (cachedTextGenerator.characterCountVisible + 1 > num3 || num3 == 0)
			{
				UICharInfo uicharInfo = cachedTextGenerator.characters[num3];
				zero.x = uicharInfo.cursorPos.x;
				zero.y = uicharInfo.cursorPos.y;
			}
			zero.x /= this.m_TextComponent.pixelsPerUnit;
			if (zero.x > this.m_TextComponent.rectTransform.rect.xMax)
			{
				zero.x = this.m_TextComponent.rectTransform.rect.xMax;
			}
			this.m_CursorVerts[0].position = new Vector3(zero.x, zero.y - num2, 0f);
			this.m_CursorVerts[1].position = new Vector3(zero.x + num, zero.y - num2, 0f);
			this.m_CursorVerts[2].position = new Vector3(zero.x + num, zero.y, 0f);
			this.m_CursorVerts[3].position = new Vector3(zero.x, zero.y, 0f);
			if (roundingOffset != Vector2.zero)
			{
				for (int i = 0; i < this.m_CursorVerts.Length; i++)
				{
					UIVertex item = this.m_CursorVerts[i];
					item.position.x = item.position.x + roundingOffset.x;
					item.position.y = item.position.y + roundingOffset.y;
					vbo.Add(item);
				}
			}
			else
			{
				for (int j = 0; j < this.m_CursorVerts.Length; j++)
				{
					vbo.Add(this.m_CursorVerts[j]);
				}
			}
			zero.y = (float)Screen.height - zero.y;
			Input.compositionCursorPos = zero;
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x0048D7D4 File Offset: 0x0048B9D4
		private void CreateCursorVerts()
		{
			this.m_CursorVerts = new UIVertex[4];
			for (int i = 0; i < this.m_CursorVerts.Length; i++)
			{
				this.m_CursorVerts[i] = UIVertex.simpleVert;
				this.m_CursorVerts[i].color = this.m_TextComponent.color;
				this.m_CursorVerts[i].uv0 = Vector2.zero;
			}
		}

		// Token: 0x06002CE7 RID: 11495 RVA: 0x0048D854 File Offset: 0x0048BA54
		private float SumLineHeights(int endLine, TextGenerator generator)
		{
			float num = 0f;
			for (int i = 0; i < endLine; i++)
			{
				num += (float)generator.lines[i].height;
			}
			return num;
		}

		// Token: 0x06002CE8 RID: 11496 RVA: 0x0048D894 File Offset: 0x0048BA94
		private void GenerateHightlight(List<UIVertex> vbo, Vector2 roundingOffset)
		{
			int num = Mathf.Max(0, this.caretPositionInternal - this.m_DrawStart);
			int num2 = Mathf.Max(0, this.caretSelectPositionInternal - this.m_DrawStart);
			if (num > num2)
			{
				int num3 = num;
				num = num2;
				num2 = num3;
			}
			num2--;
			TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
			int num4 = this.DetermineCharacterLine(num, cachedTextGenerator);
			float num5 = (float)this.m_TextComponent.fontSize;
			if (this.m_TextComponent.resizeTextForBestFit)
			{
				num5 = (float)cachedTextGenerator.fontSizeUsedForBestFit / this.m_TextComponent.pixelsPerUnit;
			}
			if (this.cachedInputTextGenerator != null && this.cachedInputTextGenerator.lines.Count > 0)
			{
				num5 = (float)this.cachedInputTextGenerator.lines[0].height;
			}
			if (this.m_TextComponent.resizeTextForBestFit && this.cachedInputTextGenerator != null)
			{
				num5 = (float)this.cachedInputTextGenerator.fontSizeUsedForBestFit;
			}
			int lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, num4);
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.uv0 = Vector2.zero;
			simpleVert.color = this.selectionColor;
			int num6 = num;
			while (num6 <= num2 && num6 < cachedTextGenerator.characterCountVisible)
			{
				if (num6 + 1 == lineEndPosition || num6 == num2)
				{
					UICharInfo uicharInfo = cachedTextGenerator.characters[num];
					UICharInfo uicharInfo2 = cachedTextGenerator.characters[num6];
					Vector2 vector = new Vector2(uicharInfo.cursorPos.x / this.m_TextComponent.pixelsPerUnit, uicharInfo.cursorPos.y);
					Vector2 vector2 = new Vector2((uicharInfo2.cursorPos.x + uicharInfo2.charWidth) / this.m_TextComponent.pixelsPerUnit, vector.y - num5 / this.m_TextComponent.pixelsPerUnit);
					if (vector2.x > this.m_TextComponent.rectTransform.rect.xMax || vector2.x < this.m_TextComponent.rectTransform.rect.xMin)
					{
						vector2.x = this.m_TextComponent.rectTransform.rect.xMax;
					}
					simpleVert.position = new Vector3(vector.x, vector2.y, 0f) + roundingOffset;
					vbo.Add(simpleVert);
					simpleVert.position = new Vector3(vector2.x, vector2.y, 0f) + roundingOffset;
					vbo.Add(simpleVert);
					simpleVert.position = new Vector3(vector2.x, vector.y, 0f) + roundingOffset;
					vbo.Add(simpleVert);
					simpleVert.position = new Vector3(vector.x, vector.y, 0f) + roundingOffset;
					vbo.Add(simpleVert);
					num = num6 + 1;
					num4++;
					lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, num4);
				}
				num6++;
			}
		}

		// Token: 0x06002CE9 RID: 11497 RVA: 0x0048DBBC File Offset: 0x0048BDBC
		protected char Validate(string text, int pos, char ch)
		{
			if (this.characterValidation == UIEmojiInput.CharacterValidation.None || !base.enabled)
			{
				return ch;
			}
			if (this.characterValidation == UIEmojiInput.CharacterValidation.Integer || this.characterValidation == UIEmojiInput.CharacterValidation.Decimal)
			{
				if (pos != 0 || text.Length <= 0 || text[0] != '-')
				{
					if (ch >= '0' && ch <= '9')
					{
						return ch;
					}
					if (ch == '-' && pos == 0)
					{
						return ch;
					}
					if (ch == '.' && this.characterValidation == UIEmojiInput.CharacterValidation.Decimal && !text.Contains("."))
					{
						return ch;
					}
				}
			}
			else if (this.characterValidation == UIEmojiInput.CharacterValidation.Alphanumeric)
			{
				if (ch >= 'A' && ch <= 'Z')
				{
					return ch;
				}
				if (ch >= 'a' && ch <= 'z')
				{
					return ch;
				}
				if (ch >= '0' && ch <= '9')
				{
					return ch;
				}
			}
			else if (this.characterValidation == UIEmojiInput.CharacterValidation.Name)
			{
				char c = (text.Length <= 0) ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)];
				char c2 = (text.Length <= 0) ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)];
				if (char.IsLetter(ch))
				{
					if (char.IsLower(ch) && c == ' ')
					{
						return char.ToUpper(ch);
					}
					if (char.IsUpper(ch) && c != ' ' && c != '\'')
					{
						return char.ToLower(ch);
					}
					return ch;
				}
				else if (ch == '\'')
				{
					if (c != ' ' && c != '\'' && c2 != '\'' && !text.Contains("'"))
					{
						return ch;
					}
				}
				else if (ch == ' ' && c != ' ' && c != '\'' && c2 != ' ' && c2 != '\'')
				{
					return ch;
				}
			}
			else if (this.characterValidation == UIEmojiInput.CharacterValidation.EmailAddress)
			{
				if (ch >= 'A' && ch <= 'Z')
				{
					return ch;
				}
				if (ch >= 'a' && ch <= 'z')
				{
					return ch;
				}
				if (ch >= '0' && ch <= '9')
				{
					return ch;
				}
				if (ch == '@' && text.IndexOf('@') == -1)
				{
					return ch;
				}
				if ("!#$%&'*+-/=?^_`{|}~".IndexOf(ch) != -1)
				{
					return ch;
				}
				if (ch == '.')
				{
					char c3 = (text.Length <= 0) ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)];
					char c4 = (text.Length <= 0) ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)];
					if (c3 != '.' && c4 != '.')
					{
						return ch;
					}
				}
			}
			return '\0';
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x0048DEA4 File Offset: 0x0048C0A4
		public void ActivateInputField()
		{
			if (this.m_TextComponent == null || this.m_TextComponent.font == null || !this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			if (this.isFocused && UIEmojiInput.m_Keyboard != null && !UIEmojiInput.m_Keyboard.active)
			{
				UIEmojiInput.m_Keyboard.active = true;
				UIEmojiInput.m_Keyboard.text = this.m_Text;
			}
			this.m_ShouldActivateNextUpdate = true;
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x0048DF38 File Offset: 0x0048C138
		private void ActivateInputFieldInternal()
		{
			if (EventSystem.current.currentSelectedGameObject != base.gameObject)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}
			if (TouchScreenKeyboard.isSupported)
			{
				if (Input.touchSupported)
				{
					TouchScreenKeyboard.hideInput = this.shouldHideMobileInput;
				}
				UIEmojiInput.m_Keyboard = ((this.inputType != UIEmojiInput.InputType.Password) ? TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, this.inputType == UIEmojiInput.InputType.AutoCorrect, this.multiLine) : TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, false, this.multiLine, true));
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.On;
				this.OnFocus();
			}
			this.m_AllowInput = true;
			this.m_OriginalText = this.text;
			this.m_WasCanceled = false;
			this.SetCaretVisible();
			this.UpdateLabel();
		}

		// Token: 0x06002CEC RID: 11500 RVA: 0x0048E014 File Offset: 0x0048C214
		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			this.ActivateInputField();
		}

		// Token: 0x06002CED RID: 11501 RVA: 0x0048E024 File Offset: 0x0048C224
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			this.ActivateInputField();
		}

		// Token: 0x06002CEE RID: 11502 RVA: 0x0048E038 File Offset: 0x0048C238
		public void DeactivateInputField()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			this.m_HasDoneFocusTransition = false;
			this.m_AllowInput = false;
			if (this.m_TextComponent != null && this.IsInteractable())
			{
				if (this.m_WasCanceled)
				{
					this.text = this.m_OriginalText;
				}
				if (UIEmojiInput.m_Keyboard != null)
				{
					UIEmojiInput.m_Keyboard.active = false;
					UIEmojiInput.m_Keyboard = null;
				}
				this.m_CaretPosition = (this.m_CaretSelectPosition = 0);
				this.SendOnSubmit();
				Input.imeCompositionMode = IMECompositionMode.Auto;
			}
			this.MarkGeometryAsDirty();
		}

		// Token: 0x06002CEF RID: 11503 RVA: 0x0048E0D0 File Offset: 0x0048C2D0
		public override void OnDeselect(BaseEventData eventData)
		{
			this.DeactivateInputField();
			base.OnDeselect(eventData);
		}

		// Token: 0x06002CF0 RID: 11504 RVA: 0x0048E0E0 File Offset: 0x0048C2E0
		public virtual void OnSubmit(BaseEventData eventData)
		{
			if (!this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			if (!this.isFocused)
			{
				this.m_ShouldActivateNextUpdate = true;
			}
		}

		// Token: 0x06002CF1 RID: 11505 RVA: 0x0048E10C File Offset: 0x0048C30C
		private void EnforceContentType()
		{
			switch (this.contentType)
			{
			case UIEmojiInput.ContentType.Standard:
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
				return;
			case UIEmojiInput.ContentType.Autocorrected:
				this.m_InputType = UIEmojiInput.InputType.AutoCorrect;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
				return;
			case UIEmojiInput.ContentType.IntegerNumber:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Integer;
				return;
			case UIEmojiInput.ContentType.DecimalNumber:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.NumbersAndPunctuation;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Decimal;
				return;
			case UIEmojiInput.ContentType.Alphanumeric:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.ASCIICapable;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Alphanumeric;
				return;
			case UIEmojiInput.ContentType.Name:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Name;
				return;
			case UIEmojiInput.ContentType.EmailAddress:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.EmailAddress;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.EmailAddress;
				return;
			case UIEmojiInput.ContentType.Password:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Password;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
				return;
			case UIEmojiInput.ContentType.Pin:
				this.m_LineType = UIEmojiInput.LineType.SingleLine;
				this.m_InputType = UIEmojiInput.InputType.Password;
				this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
				this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Integer;
				return;
			default:
				return;
			}
		}

		// Token: 0x06002CF2 RID: 11506 RVA: 0x0048E248 File Offset: 0x0048C448
		private void SetToCustomIfContentTypeIsNot(params UIEmojiInput.ContentType[] allowedContentTypes)
		{
			if (this.contentType == UIEmojiInput.ContentType.Custom)
			{
				return;
			}
			for (int i = 0; i < allowedContentTypes.Length; i++)
			{
				if (this.contentType == allowedContentTypes[i])
				{
					return;
				}
			}
			this.contentType = UIEmojiInput.ContentType.Custom;
		}

		// Token: 0x06002CF3 RID: 11507 RVA: 0x0048E290 File Offset: 0x0048C490
		private void SetToCustom()
		{
			if (this.contentType == UIEmojiInput.ContentType.Custom)
			{
				return;
			}
			this.contentType = UIEmojiInput.ContentType.Custom;
		}

		// Token: 0x06002CF4 RID: 11508 RVA: 0x0048E2A8 File Offset: 0x0048C4A8
		protected override void DoStateTransition(Selectable.SelectionState state, bool instant)
		{
			if (this.m_HasDoneFocusTransition)
			{
				state = Selectable.SelectionState.Highlighted;
			}
			else if (state == Selectable.SelectionState.Pressed)
			{
				this.m_HasDoneFocusTransition = true;
			}
			base.DoStateTransition(state, instant);
		}

		// Token: 0x06002CF5 RID: 11509 RVA: 0x0048E2D4 File Offset: 0x0048C4D4
		virtual Transform get_transform()
		{
			return base.transform;
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x0048E2DC File Offset: 0x0048C4DC
		virtual bool IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x0400794E RID: 31054
		private const float kHScrollSpeed = 0.05f;

		// Token: 0x0400794F RID: 31055
		private const float kVScrollSpeed = 0.1f;

		// Token: 0x04007950 RID: 31056
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		// Token: 0x04007951 RID: 31057
		protected static TouchScreenKeyboard m_Keyboard;

		// Token: 0x04007952 RID: 31058
		private static readonly char[] kSeparators = new char[]
		{
			' ',
			'.',
			','
		};

		// Token: 0x04007953 RID: 31059
		[FormerlySerializedAs("text")]
		[SerializeField]
		protected UIText m_TextComponent;

		// Token: 0x04007954 RID: 31060
		[SerializeField]
		protected Graphic m_Placeholder;

		// Token: 0x04007955 RID: 31061
		[SerializeField]
		private UIEmojiInput.ContentType m_ContentType;

		// Token: 0x04007956 RID: 31062
		[FormerlySerializedAs("inputType")]
		[SerializeField]
		private UIEmojiInput.InputType m_InputType;

		// Token: 0x04007957 RID: 31063
		[FormerlySerializedAs("asteriskChar")]
		[SerializeField]
		private char m_AsteriskChar = '*';

		// Token: 0x04007958 RID: 31064
		[FormerlySerializedAs("keyboardType")]
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType;

		// Token: 0x04007959 RID: 31065
		[SerializeField]
		private UIEmojiInput.LineType m_LineType;

		// Token: 0x0400795A RID: 31066
		[SerializeField]
		[FormerlySerializedAs("hideMobileInput")]
		private bool m_HideMobileInput;

		// Token: 0x0400795B RID: 31067
		[SerializeField]
		[FormerlySerializedAs("validation")]
		private UIEmojiInput.CharacterValidation m_CharacterValidation;

		// Token: 0x0400795C RID: 31068
		[SerializeField]
		[FormerlySerializedAs("characterLimit")]
		private int m_CharacterLimit;

		// Token: 0x0400795D RID: 31069
		[FormerlySerializedAs("onSubmit")]
		[SerializeField]
		[FormerlySerializedAs("m_OnSubmit")]
		private UIEmojiInput.SubmitEvent m_EndEdit = new UIEmojiInput.SubmitEvent();

		// Token: 0x0400795E RID: 31070
		[SerializeField]
		[FormerlySerializedAs("onValueChange")]
		private UIEmojiInput.OnChangeEvent m_OnValueChange = new UIEmojiInput.OnChangeEvent();

		// Token: 0x0400795F RID: 31071
		[FormerlySerializedAs("onValidateInput")]
		[SerializeField]
		private UIEmojiInput.OnValidateInput m_OnValidateInput;

		// Token: 0x04007960 RID: 31072
		[SerializeField]
		[FormerlySerializedAs("selectionColor")]
		private Color m_SelectionColor = new Color(0.65882355f, 0.807843149f, 1f, 0.7529412f);

		// Token: 0x04007961 RID: 31073
		[SerializeField]
		[FormerlySerializedAs("mValue")]
		protected string m_Text = string.Empty;

		// Token: 0x04007962 RID: 31074
		[Range(0f, 8f)]
		[SerializeField]
		private float m_CaretBlinkRate = 1.7f;

		// Token: 0x04007963 RID: 31075
		protected int m_CaretPosition;

		// Token: 0x04007964 RID: 31076
		protected int m_CaretSelectPosition;

		// Token: 0x04007965 RID: 31077
		private RectTransform caretRectTrans;

		// Token: 0x04007966 RID: 31078
		protected UIVertex[] m_CursorVerts;

		// Token: 0x04007967 RID: 31079
		private TextGenerator m_InputTextCache;

		// Token: 0x04007968 RID: 31080
		private CanvasRenderer m_CachedInputRenderer;

		// Token: 0x04007969 RID: 31081
		private bool m_PreventFontCallback;

		// Token: 0x0400796A RID: 31082
		private readonly List<UIVertex> m_Vbo = new List<UIVertex>();

		// Token: 0x0400796B RID: 31083
		private bool m_AllowInput;

		// Token: 0x0400796C RID: 31084
		private bool m_ShouldActivateNextUpdate;

		// Token: 0x0400796D RID: 31085
		private bool m_UpdateDrag;

		// Token: 0x0400796E RID: 31086
		private bool m_DragPositionOutOfBounds;

		// Token: 0x0400796F RID: 31087
		protected bool m_CaretVisible;

		// Token: 0x04007970 RID: 31088
		private Coroutine m_BlinkCoroutine;

		// Token: 0x04007971 RID: 31089
		private float m_BlinkStartTime;

		// Token: 0x04007972 RID: 31090
		protected int m_DrawStart;

		// Token: 0x04007973 RID: 31091
		protected int m_DrawEnd;

		// Token: 0x04007974 RID: 31092
		private Coroutine m_DragCoroutine;

		// Token: 0x04007975 RID: 31093
		private string m_OriginalText = string.Empty;

		// Token: 0x04007976 RID: 31094
		private bool m_WasCanceled;

		// Token: 0x04007977 RID: 31095
		private bool m_HasDoneFocusTransition;

		// Token: 0x04007978 RID: 31096
		private Event m_ProcessingEvent = new Event();

		// Token: 0x0200086F RID: 2159
		public enum ContentType
		{
			// Token: 0x0400797A RID: 31098
			Standard,
			// Token: 0x0400797B RID: 31099
			Autocorrected,
			// Token: 0x0400797C RID: 31100
			IntegerNumber,
			// Token: 0x0400797D RID: 31101
			DecimalNumber,
			// Token: 0x0400797E RID: 31102
			Alphanumeric,
			// Token: 0x0400797F RID: 31103
			Name,
			// Token: 0x04007980 RID: 31104
			EmailAddress,
			// Token: 0x04007981 RID: 31105
			Password,
			// Token: 0x04007982 RID: 31106
			Pin,
			// Token: 0x04007983 RID: 31107
			Custom
		}

		// Token: 0x02000870 RID: 2160
		public enum InputType
		{
			// Token: 0x04007985 RID: 31109
			Standard,
			// Token: 0x04007986 RID: 31110
			AutoCorrect,
			// Token: 0x04007987 RID: 31111
			Password
		}

		// Token: 0x02000871 RID: 2161
		public enum CharacterValidation
		{
			// Token: 0x04007989 RID: 31113
			None,
			// Token: 0x0400798A RID: 31114
			Integer,
			// Token: 0x0400798B RID: 31115
			Decimal,
			// Token: 0x0400798C RID: 31116
			Alphanumeric,
			// Token: 0x0400798D RID: 31117
			Name,
			// Token: 0x0400798E RID: 31118
			EmailAddress
		}

		// Token: 0x02000872 RID: 2162
		public enum LineType
		{
			// Token: 0x04007990 RID: 31120
			SingleLine,
			// Token: 0x04007991 RID: 31121
			MultiLineSubmit,
			// Token: 0x04007992 RID: 31122
			MultiLineNewline
		}

		// Token: 0x02000873 RID: 2163
		[Serializable]
		public class SubmitEvent : UnityEvent<string>
		{
		}

		// Token: 0x02000874 RID: 2164
		[Serializable]
		public class OnChangeEvent : UnityEvent<string>
		{
		}

		// Token: 0x02000875 RID: 2165
		protected enum EditState
		{
			// Token: 0x04007994 RID: 31124
			Continue,
			// Token: 0x04007995 RID: 31125
			Finish
		}

		// Token: 0x02000899 RID: 2201
		// (Invoke) Token: 0x06002DAC RID: 11692
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);
	}
}
