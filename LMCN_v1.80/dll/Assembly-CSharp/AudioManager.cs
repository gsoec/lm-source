using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class AudioManager
{
	// Token: 0x0600017D RID: 381 RVA: 0x00017B7C File Offset: 0x00015D7C
	private AudioManager()
	{
		this.AudioController = new GameObject("AudioController");
		UnityEngine.Object.DontDestroyOnLoad(this.AudioController);
		for (int i = 0; i < 2; i++)
		{
			this.BGMSource[i] = this.AudioController.AddComponent<AudioSource>();
		}
		for (int j = 0; j < this.CloseQueue.Length; j++)
		{
			this.CloseQueue[j] = new AudioCloseQueue();
		}
		this.Initial();
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600017F RID: 383 RVA: 0x00017CD8 File Offset: 0x00015ED8
	public static AudioManager Instance
	{
		get
		{
			if (AudioManager.instance == null)
			{
				AudioManager.instance = new AudioManager();
			}
			return AudioManager.instance;
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00017CF4 File Offset: 0x00015EF4
	private void Initial()
	{
		this.poolIndex = 0;
		this.MarkSFXBundleKey = -1;
		GameConstants.ArrayFill<int>(this.SFXBundleKey, 0);
		this.BaseVol = 1f;
		this.MuteSFXVol = false;
		this.www = null;
		this.bCrossfade = false;
		this.BGMmainIndex = 0;
		this.SpeechSoundPrev = 0;
		this.DuckVolDecrease = 0f;
		this.DuckDeltaTime = 0f;
		this.DuckVolDecrease = 0.2921f;
		this.DuckDeltaTime = 0f;
		this.duckingstate = AudioManager.DuckingState.None;
		this.MusicVol = 1f;
		this.TmpVol = 0f;
		this.FireKey = 0;
		this.CloseQueueIndex = 0;
		GameConstants.ArrayFill<byte>(this.PauseKey, 0);
		this.MP3Key = 0;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00017DB4 File Offset: 0x00015FB4
	public void LoadSFXObj()
	{
		if (this.AudioAssetBundleKey != 0)
		{
			return;
		}
		this.AudioAssetBundle = AssetManager.GetAssetBundle("UI/AudioAsset", out this.AudioAssetBundleKey, false);
		GameObject original = this.AudioAssetBundle.Load("SFX") as GameObject;
		byte b = 0;
		GameObject gameObject;
		while ((int)b < this.SFXSource.Length)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			this.SFXSource[(int)b] = gameObject.GetComponent<AudioSource>();
			this.SFXSource[(int)b].transform.SetParent(this.AudioController.transform);
			b += 1;
		}
		gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		this.MP3Source = gameObject.GetComponent<AudioSource>();
		this.MP3Source.transform.SetParent(this.AudioController.transform);
		original = (this.AudioAssetBundle.Load("SFXFire") as GameObject);
		gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		this.FireSFXSource = gameObject.GetComponent<AudioSource>();
		this.FireHighPass = gameObject.GetComponent<AudioHighPassFilter>();
		gameObject.transform.SetParent(this.AudioController.transform);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00017EE0 File Offset: 0x000160E0
	public void SetSFXEnvironment(SFXKind Kind)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		if (Kind == SFXKind.Normal)
		{
			cstring.Append("SFX");
		}
		else
		{
			cstring.Append("SFXLegion");
		}
		GameObject original = this.AudioAssetBundle.Load(cstring.ToString(), typeof(GameObject)) as GameObject;
		byte b = 0;
		while ((int)b < this.SFXSource.Length)
		{
			UnityEngine.Object.Destroy(this.SFXSource[(int)b].gameObject);
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
			this.SFXSource[(int)b] = gameObject.GetComponent<AudioSource>();
			this.SFXSource[(int)b].transform.SetParent(this.AudioController.transform);
			b += 1;
		}
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00017FA0 File Offset: 0x000161A0
	public BGMType GetCurMusic()
	{
		return this.CurMusicType;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00017FA8 File Offset: 0x000161A8
	public void LoadAndPlayBGM(BGMType Type, byte Loop = 1, bool Force = false)
	{
		if (this.www != null)
		{
			if (this.CurMusicType == Type)
			{
				return;
			}
			this.www.Dispose();
			this.www = null;
			Resources.UnloadUnusedAssets();
		}
		this.CurMusicType = Type;
		if (!DataManager.Instance.MySysSetting.bMusic && !Force)
		{
			if (this.BGMSource[this.BGMmainIndex].clip != null)
			{
				UnityEngine.Object.Destroy(this.BGMSource[this.BGMmainIndex].clip);
				this.BGMSource[this.BGMmainIndex].clip = null;
				this.BGMClip.clip = null;
				this.BGMassetBundle[this.BGMmainIndex].Unload(true);
				this.BGMassetBundle[this.BGMmainIndex] = null;
				this.NowPlayBGMName = 0;
			}
			return;
		}
		if (this.bCrossfade)
		{
			this.FadeTime = this.FadeTimeMax + 1f;
			this.UpdateCrossfade();
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		CString tmpS = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.StringToFormat(tmpS);
		cstring2.StringToFormat(Application.streamingAssetsPath);
		switch (this.CurMusicType)
		{
		case BGMType.Main:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM10");
			break;
		case BGMType.Legion:
			if (DataManager.Instance.MySysSetting.mMusicSelect == 0)
			{
				cstring2.StringToFormat(this.Path);
				cstring.Append("BGM02");
			}
			else
			{
				cstring2.StringToFormat(this.Path);
				cstring.Append("BGM07");
			}
			break;
		case BGMType.WarVictory:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM03");
			break;
		case BGMType.WarDefeat:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM04");
			break;
		case BGMType.War:
			cstring2.StringToFormat(this.Path);
			cstring.Append("War01");
			break;
		case BGMType.LegionWar:
		case BGMType.Login:
			cstring2.StringToFormat("Loading/");
			cstring.Append("War02");
			break;
		case BGMType.LegionVictory:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM05");
			break;
		case BGMType.LegionDefeat:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM06");
			break;
		case BGMType.Master:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM10");
			break;
		case BGMType.Newie:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM02");
			break;
		}
		cstring2.StringToFormat(cstring);
		cstring2.AppendFormat("{0}{1}/{2}{3}.unity3d");
		this.BGMLoop = Loop;
		if (this.NowPlayBGMName == cstring2.GetHashCode(false))
		{
			if (!this.BGMSource[this.BGMmainIndex].isPlaying)
			{
				this.BGMSource[this.BGMmainIndex].loop = (this.BGMLoop == 1);
				this.BGMSource[this.BGMmainIndex].Play();
				this.BGMSource[this.BGMmainIndex].volume = this.BaseVol;
			}
			return;
		}
		this.www = new WWW(cstring2.ToString());
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00018318 File Offset: 0x00016518
	public void UnLoadBGM()
	{
		for (int i = 0; i < 2; i++)
		{
			if (this.BGMSource[i])
			{
				this.BGMSource[i].Stop();
				UnityEngine.Object.Destroy(this.BGMSource[i].clip);
			}
			if (this.BGMassetBundle[i])
			{
				this.BGMassetBundle[i].Unload(true);
			}
		}
		if (this.www != null)
		{
			this.www.assetBundle.Unload(true);
			this.www.Dispose();
			this.www = null;
		}
		Resources.UnloadUnusedAssets();
		this.NowPlayBGMName = 0;
		this.bCrossfade = false;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x000183CC File Offset: 0x000165CC
	public void PlayUISFXIndex(UIClickSoundIndex EnumSoundIndex)
	{
		switch (EnumSoundIndex)
		{
		case UIClickSoundIndex.Normal:
			this.PlayUISFX(UIKind.Normal);
			break;
		case UIClickSoundIndex.Parameter:
			this.PlayUISFX(UIKind.Tag);
			break;
		case UIClickSoundIndex.Dynamic:
			this.PlayUISFX(UIKind.Tag);
			break;
		case UIClickSoundIndex.Catagory:
			this.PlayUISFX(UIKind.Tag);
			break;
		}
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0001843C File Offset: 0x0001663C
	public void PlayUISFX(ref AudioSourceController controller, UIKind Kind = UIKind.Normal)
	{
		if (!this.PlayUISFX(Kind))
		{
			return;
		}
		int num = (int)this.poolIndex;
		if (num == 0)
		{
			num = 19;
		}
		controller = this.SourceController;
		controller.Set(this.SFXSource[num - 1]);
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00018480 File Offset: 0x00016680
	public bool PlayUISFX(UIKind Kind = UIKind.Normal)
	{
		if (this.MuteSFXVol || Kind == UIKind.None || this.AudioAssetBundleKey == 0)
		{
			return false;
		}
		this.GetEmptyIndex();
		CString cstring = StringManager.Instance.StaticString1024();
		ushort num = (ushort)Kind;
		if (num == 0)
		{
			return false;
		}
		int num2 = (int)(num / 100);
		cstring.StringToFormat(this.Path);
		cstring.IntToFormat((long)num2, 3, false);
		cstring.AppendFormat("{0}{1}");
		if (num == 40030 && this.bPlayOnlyOneClip >= 0)
		{
			return false;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.SFXBundleKey[(int)this.poolIndex]);
		if (assetBundle)
		{
			if (num == 40030)
			{
				this.bPlayOnlyOneClip = (short)this.poolIndex;
			}
			cstring.ClearString();
			cstring.IntToFormat((long)num, 1, false);
			cstring.AppendFormat("{0}");
			this.SFXClip.clip = (assetBundle.Load(cstring.ToString(), typeof(AudioClip)) as AudioClip);
			if (this.SFXClip.clip == null)
			{
				AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
				this.SFXBundleKey[(int)this.poolIndex] = 0;
				return false;
			}
			this.SFXClip.DelaySecond = null;
			if (num2 == 300 && num != 30005)
			{
				this.SFXClip.Pitch = 0.8909f + 0.553f * UnityEngine.Random.value;
			}
			else
			{
				this.SFXClip.Pitch = 1f;
			}
			this.SFXClip.PanLevel = 0f;
			this.SFXClip.Loop = false;
			this.SFXClip.Volume = 1f;
			AudioSource[] sfxsource = this.SFXSource;
			byte b;
			this.poolIndex = (b = this.poolIndex) + 1;
			this.PlayAudio(sfxsource[(int)b], this.SFXClip);
			this.ChangeDuckingState(AudioManager.DuckingState.Start);
			if (this.poolIndex >= 20)
			{
				this.poolIndex = 0;
			}
		}
		else
		{
			AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
			this.SFXBundleKey[(int)this.poolIndex] = 0;
		}
		return true;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x000186B4 File Offset: 0x000168B4
	public void PlaySFXCloseBGM(ushort NameID, float delay = 0f, PitchKind pitchkind = PitchKind.NoPitch, Transform PlayObj = null)
	{
		if (this.MuteSFXVol)
		{
			return;
		}
		this.AddCloseQueue(100);
		this.PlaySFX(NameID, delay, pitchkind, PlayObj, null);
		if (this.poolIndex == 0)
		{
			this.poolIndex = 19;
		}
		this.CurUseIndex = this.poolIndex - 1;
		this.PauseSFX(this.CurUseIndex);
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00018718 File Offset: 0x00016918
	public void PlaySFX(ushort NameID, float delay = 0f, PitchKind pitchkind = PitchKind.NoPitch, Transform PlayObj = null, Vector3? Position = null)
	{
		if (this.MuteSFXVol || NameID == 0)
		{
			return;
		}
		int num = (int)(NameID / 100);
		if (num == 37 || num == 77)
		{
			PlayObj = null;
		}
		this.GetEmptyIndex();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(this.Path);
		cstring.IntToFormat((long)num, 3, true);
		cstring.AppendFormat("{0}{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.SFXBundleKey[(int)this.poolIndex]);
		if (assetBundle)
		{
			cstring.ClearString();
			cstring.IntToFormat((long)NameID, 1, false);
			cstring.AppendFormat("{0}");
			this.SFXClip.clip = (assetBundle.Load(cstring.ToString(), typeof(AudioClip)) as AudioClip);
			if (this.SFXClip.clip == null)
			{
				AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
				this.SFXBundleKey[(int)this.poolIndex] = 0;
				return;
			}
			this.SFXClip.DelaySecond = new float?(delay);
			if (pitchkind != PitchKind.SpeechSound)
			{
				if (pitchkind != PitchKind.Hit)
				{
					this.SFXClip.Pitch = 1f;
				}
				else
				{
					this.SFXClip.Pitch = 0.8909f + 0.2316f * UnityEngine.Random.value;
				}
			}
			else
			{
				byte b = (byte)Mathf.Max(0f, 30f * UnityEngine.Random.value / 10f);
				if (b == this.SpeechSoundPrev)
				{
					b += 1;
					if (b >= 3)
					{
						b = 0;
					}
				}
				this.SpeechSoundPrev = b;
				this.SFXClip.Pitch = this.SpeechSoundPitchVal[(int)this.SpeechSoundPrev];
			}
			if (PlayObj != null)
			{
				this.AttachAudioSound(this.poolIndex, PlayObj);
				this.SFXClip.PanLevel = 1f;
			}
			else if (Position != null)
			{
				this.AttachAudioSound(this.poolIndex, Position.Value);
				this.SFXClip.PanLevel = 1f;
			}
			else
			{
				this.SFXClip.PanLevel = 0f;
			}
			this.SFXClip.Volume = 1f;
			this.SFXClip.Loop = false;
			AudioSource[] sfxsource = this.SFXSource;
			byte b2;
			this.poolIndex = (b2 = this.poolIndex) + 1;
			this.PlayAudio(sfxsource[(int)b2], this.SFXClip);
			this.ChangeDuckingState(AudioManager.DuckingState.Start);
			if (this.poolIndex >= 20)
			{
				this.poolIndex = 0;
			}
		}
		else
		{
			if (this.SFXSource[(int)this.poolIndex] == null)
			{
				Debug.LogWarning(string.Format("bundle_AbName({0}Null)", NameID));
			}
			AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
			this.SFXBundleKey[(int)this.poolIndex] = 0;
		}
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00018A00 File Offset: 0x00016C00
	private void GetEmptyIndex()
	{
		float num = 0f;
		byte index = 0;
		while (this.SFXBundleKey[(int)this.poolIndex] != 0)
		{
			if ((short)this.poolIndex == this.MarkSFXBundleKey)
			{
				this.DelSFXClip(index);
				this.poolIndex = index;
				break;
			}
			if (this.MarkSFXBundleKey == -1)
			{
				this.MarkSFXBundleKey = (short)this.poolIndex;
			}
			if (this.SFXSource[(int)this.poolIndex] == null)
			{
				Debug.LogWarning(string.Format("AudioSourceIndex({0}Null)", this.poolIndex));
			}
			if (num < this.SFXSource[(int)this.poolIndex].time)
			{
				num = this.SFXSource[(int)this.poolIndex].time;
				index = this.poolIndex;
			}
			this.poolIndex += 1;
			if (this.poolIndex >= 20)
			{
				this.poolIndex = 0;
			}
		}
		this.MarkSFXBundleKey = -1;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00018AF8 File Offset: 0x00016CF8
	public bool PlaySFXLoop(ushort NameID, out byte Key, Transform PlayObj = null, SFXEffect Effect = SFXEffect.Normal, float delay = 0f)
	{
		Key = 0;
		if (this.MuteSFXVol || NameID == 0)
		{
			return false;
		}
		int num = (int)(NameID / 100);
		this.GetEmptyIndex();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(this.Path);
		cstring.IntToFormat((long)num, 3, true);
		cstring.AppendFormat("{0}{1}");
		if (Effect == SFXEffect.HighPassFilter)
		{
			return this.PlaySFXLoopHighPass(NameID, out Key, PlayObj);
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.SFXBundleKey[(int)this.poolIndex]);
		if (!assetBundle)
		{
			AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
			this.SFXBundleKey[(int)this.poolIndex] = 0;
			return false;
		}
		cstring.ClearString();
		cstring.IntToFormat((long)NameID, 1, false);
		cstring.AppendFormat("{0}");
		this.SFXClip.clip = (assetBundle.Load(cstring.ToString(), typeof(AudioClip)) as AudioClip);
		if (this.SFXClip.clip == null)
		{
			AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)this.poolIndex], true);
			this.SFXBundleKey[(int)this.poolIndex] = 0;
			return false;
		}
		if (PlayObj != null)
		{
			this.AttachAudioSound(this.poolIndex, PlayObj);
			this.SFXClip.PanLevel = 1f;
		}
		else
		{
			this.SFXClip.PanLevel = 0f;
		}
		this.SFXClip.Loop = true;
		this.SFXClip.Volume = 1f;
		this.SFXClip.Pitch = 1f;
		this.SFXClip.DelaySecond = new float?(delay);
		Key = this.poolIndex;
		AudioSource[] sfxsource = this.SFXSource;
		byte b;
		this.poolIndex = (b = this.poolIndex) + 1;
		this.PlayAudio(sfxsource[(int)b], this.SFXClip);
		this.ChangeDuckingState(AudioManager.DuckingState.Start);
		if (this.poolIndex >= 20)
		{
			this.poolIndex = 0;
		}
		return true;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00018CEC File Offset: 0x00016EEC
	private bool PlaySFXLoopHighPass(ushort NameID, out byte Key, Transform PlayObj = null)
	{
		Key = 0;
		if (this.FireKey != 0)
		{
			return false;
		}
		int num = (int)(NameID / 100);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(this.Path);
		cstring.IntToFormat((long)num, 3, true);
		cstring.AppendFormat("{0}{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.FireKey);
		if (!assetBundle)
		{
			AssetManager.UnloadAssetBundle(this.FireKey, true);
			this.FireKey = 0;
			return false;
		}
		if (this.FireSFXSource.clip != null)
		{
			this.FireSFXSource.Stop();
		}
		cstring.ClearString();
		cstring.IntToFormat((long)NameID, 1, false);
		cstring.AppendFormat("{0}");
		this.SFXClip.clip = (assetBundle.Load(cstring.ToString(), typeof(AudioClip)) as AudioClip);
		if (this.SFXClip.clip == null)
		{
			AssetManager.UnloadAssetBundle(this.FireKey, true);
			this.FireKey = 0;
			return false;
		}
		if (PlayObj != null)
		{
			this.FireSFXSource.transform.position = PlayObj.position;
			this.SFXClip.PanLevel = 1f;
		}
		else
		{
			this.SFXClip.PanLevel = 0f;
		}
		this.SFXClip.Loop = true;
		this.SFXClip.Volume = 1f;
		this.SFXClip.Pitch = 1f;
		Key = 20;
		this.PlayAudio(this.FireSFXSource, this.SFXClip);
		this.ChangeDuckingState(AudioManager.DuckingState.Start);
		return true;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00018E88 File Offset: 0x00017088
	private void ChangeDuckingState(AudioManager.DuckingState State)
	{
		if (State == this.duckingstate)
		{
			return;
		}
		if (State == AudioManager.DuckingState.Start && this.duckingstate == AudioManager.DuckingState.Extend)
		{
			return;
		}
		this.duckingstate = State;
		this.DuckDeltaTime = 0f;
		this.TmpVol = 0f;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00018EC8 File Offset: 0x000170C8
	public void SwitchMusic(bool TurnOn)
	{
		if (TurnOn)
		{
			if (this.BGMSource[this.BGMmainIndex].clip != null)
			{
				this.BGMSource[this.BGMmainIndex].Play();
			}
			else
			{
				this.LoadAndPlayBGM(this.CurMusicType, 1, false);
			}
		}
		else
		{
			this.BGMSource[this.BGMmainIndex].Stop();
		}
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00018F34 File Offset: 0x00017134
	public void StopSFX(byte Key, bool bFadeOut = true)
	{
		if (Key < 20)
		{
			if (this.SFXSource[(int)Key].clip == null)
			{
				return;
			}
			if (!bFadeOut)
			{
				this.SFXSource[(int)Key].Stop();
			}
		}
		else if (this.FireSFXSource.clip == null)
		{
			return;
		}
		this.AddCloseQueue(Key);
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00018F98 File Offset: 0x00017198
	public void AddCloseQueue(byte Key)
	{
		int num = ++this.CloseQueueIndex & 3;
		if (Key < 20)
		{
			this.CloseQueue[num].SetAudio(this.SFXSource[(int)Key], Key, 1.5f);
		}
		else if (Key == 100)
		{
			this.CloseQueue[num].SetAudio(this.BGMSource[this.BGMmainIndex], Key, 0.75f);
		}
		else
		{
			this.CloseQueue[num].SetAudio(this.FireSFXSource, Key, 1.5f);
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00019028 File Offset: 0x00017228
	public void PauseSFX(byte Key)
	{
		if (Key < 20)
		{
			if (this.SFXSource[(int)Key] == null)
			{
				return;
			}
			this.SFXSource[(int)Key].Pause();
			this.PauseKey[(int)Key] = 1;
		}
		else if (this.FireSFXSource)
		{
			this.FireSFXSource.Pause();
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00019088 File Offset: 0x00017288
	public void PlaySFX(byte Key)
	{
		if (Key < 20)
		{
			if (this.SFXSource[(int)Key].clip == null)
			{
				return;
			}
			this.PauseKey[(int)Key] = 0;
			this.SFXSource[(int)Key].Play();
		}
		else if (this.FireSFXSource)
		{
			this.FireSFXSource.Play();
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x000190EC File Offset: 0x000172EC
	public void SetFireSize(float Size)
	{
		this.FireSFXSource.volume = Size * 0.5f * this.BaseVol;
		this.FireHighPass.cutoffFrequency = 220f - Size * 220f;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00019120 File Offset: 0x00017320
	public void PlayMP3SFX(ushort NameID, float delay = 0f)
	{
		if (this.MuteSFXVol || NameID == 0)
		{
			return;
		}
		if (this.MP3Key != 0)
		{
			if (NameID == this.MP3ABName)
			{
				return;
			}
			this.MP3Source.Stop();
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
		}
		this.MP3ABName = NameID;
		int num = (int)(NameID / 100);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(this.Path);
		cstring.IntToFormat((long)num, 3, true);
		cstring.AppendFormat("{0}{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.MP3Key);
		if (assetBundle)
		{
			cstring.ClearString();
			cstring.IntToFormat((long)NameID, 1, false);
			cstring.AppendFormat("{0}");
			this.SFXClip.clip = (assetBundle.Load(cstring.ToString(), typeof(AudioClip)) as AudioClip);
			if (this.SFXClip.clip == null)
			{
				AssetManager.UnloadAssetBundle(this.MP3Key, true);
				this.MP3Key = 0;
				this.MP3ABName = 0;
				return;
			}
			this.SFXClip.DelaySecond = new float?(delay);
			this.SFXClip.Pitch = 1f;
			this.SFXClip.PanLevel = 0f;
			this.SFXClip.Volume = 1f;
			this.SFXClip.Loop = false;
			this.PlayAudio(this.MP3Source, this.SFXClip);
			this.ChangeDuckingState(AudioManager.DuckingState.Start);
			if (this.poolIndex >= 20)
			{
				this.poolIndex = 0;
			}
		}
		else
		{
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
			this.MP3ABName = 0;
		}
	}

	// Token: 0x06000196 RID: 406 RVA: 0x000192D8 File Offset: 0x000174D8
	public void PlayMP3SFX(BGMType Type, bool bLoop = true, float Vol = 1f)
	{
		if (!DataManager.Instance.MySysSetting.bMusic)
		{
			return;
		}
		if (this.MP3Key != 0)
		{
			if ((ushort)Type == this.MP3ABName)
			{
				return;
			}
			this.MP3Source.Stop();
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
		}
		if (this.bCrossfade)
		{
			this.FadeTime = this.FadeTimeMax + 1f;
			this.UpdateCrossfade();
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		CString cstring2 = StringManager.Instance.StaticString1024();
		switch (Type)
		{
		case BGMType.Main:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM10");
			break;
		case BGMType.Legion:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM02");
			break;
		case BGMType.WarVictory:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM03");
			break;
		case BGMType.WarDefeat:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM04");
			break;
		case BGMType.War:
			cstring2.StringToFormat(this.Path);
			cstring.Append("War01");
			break;
		case BGMType.LegionWar:
			cstring2.StringToFormat("Loading/");
			cstring.Append("War02");
			break;
		case BGMType.LegionVictory:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM05");
			break;
		case BGMType.LegionDefeat:
			cstring2.StringToFormat(this.Path);
			cstring.Append("BGM06");
			break;
		}
		cstring2.StringToFormat(cstring);
		cstring2.AppendFormat("{0}{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring2, out this.MP3Key);
		if (assetBundle)
		{
			this.SFXClip.clip = (assetBundle.mainAsset as AudioClip);
			if (this.SFXClip.clip == null)
			{
				AssetManager.UnloadAssetBundle(this.MP3Key, true);
				this.MP3Key = 0;
				this.MP3ABName = 0;
				return;
			}
			this.BGMSource[this.BGMmainIndex].Stop();
			this.MP3ABName = (ushort)Type;
			this.SFXClip.Pitch = 1f;
			this.SFXClip.PanLevel = 0f;
			this.SFXClip.Volume = Vol;
			this.SFXClip.Loop = bLoop;
			this.PlayAudio(this.MP3Source, this.SFXClip);
			if (this.poolIndex >= 20)
			{
				this.poolIndex = 0;
			}
		}
		else
		{
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
			this.MP3ABName = 0;
		}
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00019598 File Offset: 0x00017798
	public void StopMP3AndPlayBGM()
	{
		this.MP3Source.Stop();
		if (this.MP3Key != 0)
		{
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
			this.MP3ABName = 0;
		}
		if (DataManager.Instance.MySysSetting.bMusic)
		{
			this.BGMSource[this.BGMmainIndex].Play();
		}
	}

	// Token: 0x06000198 RID: 408 RVA: 0x000195FC File Offset: 0x000177FC
	public void Update()
	{
		if (this.www != null && this.www.isDone)
		{
			if (this.BGMSource[this.BGMmainIndex].clip == null)
			{
				this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
				this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
				this.BGMClip.Loop = (this.BGMLoop == 1);
				this.BGMClip.Volume = this.BaseVol;
				this.BGMClip.PanLevel = 0f;
				this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
			}
			else if (!this.BGMSource[this.BGMmainIndex].isPlaying)
			{
				UnityEngine.Object.Destroy(this.BGMSource[this.BGMmainIndex].clip);
				this.BGMSource[this.BGMmainIndex].clip = null;
				if (this.BGMassetBundle[this.BGMmainIndex] != null)
				{
					this.BGMassetBundle[this.BGMmainIndex].Unload(true);
				}
				this.BGMassetBundle[this.BGMmainIndex] = null;
				this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
				this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
				this.BGMClip.Loop = (this.BGMLoop == 1);
				this.BGMClip.Volume = this.BaseVol;
				this.BGMClip.PanLevel = 0f;
				this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
			}
			else if (!this.bCrossfade)
			{
				this.BGMmainIndex = (++this.BGMmainIndex & 1);
				this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
				this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
				this.BGMClip.Loop = (this.BGMLoop == 1);
				this.BGMClip.Volume = 0f;
				this.BGMClip.PanLevel = 0f;
				this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
				this.bCrossfade = true;
			}
			this.NowPlayBGMName = this.www.url.GetHashCode();
			this.www.Dispose();
			this.www = null;
			Resources.UnloadUnusedAssets();
		}
		if (this.bCrossfade)
		{
			this.UpdateCrossfade();
		}
		this.PlaySFXCount = 0;
		byte b = 0;
		while ((int)b < this.SFXSource.Length)
		{
			if (this.SFXSource[(int)b] == null)
			{
				break;
			}
			if (!(this.SFXSource[(int)b].clip == null))
			{
				if (!this.SFXSource[(int)b].isPlaying && this.PauseKey[(int)b] == 0)
				{
					this.SourceController.CheckValid(this.SFXSource[(int)b]);
					this.DelSFXClip(b);
				}
				else
				{
					if (this.PlaySFXTrans[(int)b])
					{
						this.SFXSource[(int)b].transform.position = this.PlaySFXTrans[(int)b].position;
					}
					this.PlaySFXCount += 1;
				}
			}
			b += 1;
		}
		if (this.MP3Source != null && !this.MP3Source.isPlaying && this.MP3Key != 0)
		{
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
			this.MP3Key = 0;
			this.MP3ABName = 0;
		}
		this.UpdateDucking();
		this.UpdateCloseFadeOut();
	}

	// Token: 0x06000199 RID: 409 RVA: 0x000199F4 File Offset: 0x00017BF4
	private void UpdateCrossfade()
	{
		int num = this.BGMmainIndex + 1 & 1;
		this.BGMSource[num].volume = this.OutQuintic(this.FadeTime, 1f, -1f, this.FadeTimeMax);
		this.BGMSource[this.BGMmainIndex].volume = 1f - this.BGMSource[num].volume;
		if (this.FadeTime > this.FadeTimeMax)
		{
			this.BGMSource[num].Stop();
			if (this.BGMSource[num].clip != null)
			{
				UnityEngine.Object.Destroy(this.BGMSource[num].clip);
			}
			this.BGMSource[num].clip = null;
			this.BGMClip.clip = null;
			if (this.BGMassetBundle[num] != null)
			{
				this.BGMassetBundle[num].Unload(true);
			}
			this.BGMassetBundle[num] = null;
			this.bCrossfade = false;
			this.FadeTime = 0f;
		}
		else
		{
			this.FadeTime += Time.deltaTime;
		}
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00019B10 File Offset: 0x00017D10
	public float OutQuintic(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (-1f * num * num + 4f * num2 + -6f * num + 4f * t);
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00019B50 File Offset: 0x00017D50
	public void DelSFXClip(byte Index)
	{
		this.PlaySFXTrans[(int)Index] = null;
		this.SFXSource[(int)Index].clip = null;
		AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)Index], true);
		this.SFXBundleKey[(int)Index] = 0;
		if (this.bPlayOnlyOneClip == (short)Index)
		{
			this.bPlayOnlyOneClip = -1;
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00019BA0 File Offset: 0x00017DA0
	public void DelFireClip()
	{
		this.FireSFXSource.clip = null;
		AssetManager.UnloadAssetBundle(this.FireKey, true);
		this.FireKey = 0;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00019BC4 File Offset: 0x00017DC4
	private void UpdateDucking()
	{
		if (this.bCrossfade)
		{
			return;
		}
		switch (this.duckingstate)
		{
		case AudioManager.DuckingState.Start:
		{
			float num = this.DuckVolDecrease * (this.DuckDeltaTime / 1f);
			this.BGMSource[this.BGMmainIndex].volume = (this.BGMSource[this.BGMmainIndex].volume - (num - this.TmpVol)) * this.BaseVol * this.MusicVol;
			this.TmpVol = num;
			this.DuckDeltaTime += Time.deltaTime;
			if (this.DuckDeltaTime > 1f)
			{
				this.DuckVolDecrease = 0f;
				this.ChangeDuckingState(AudioManager.DuckingState.Extend);
			}
			break;
		}
		case AudioManager.DuckingState.Extend:
			if (this.PlaySFXCount == 0)
			{
				this.DuckDeltaTime += Time.deltaTime;
			}
			else
			{
				this.DuckDeltaTime = 0f;
			}
			if (this.DuckDeltaTime > 1f)
			{
				this.ChangeDuckingState(AudioManager.DuckingState.Cancel);
			}
			break;
		case AudioManager.DuckingState.Cancel:
		{
			float num2 = 0.2921f * (this.DuckDeltaTime / 1f);
			this.BGMSource[this.BGMmainIndex].volume = (this.BGMSource[this.BGMmainIndex].volume + (num2 - this.DuckVolDecrease)) * this.BaseVol * this.MusicVol;
			this.DuckVolDecrease = num2;
			this.DuckDeltaTime += Time.deltaTime;
			if (this.DuckDeltaTime > 1f)
			{
				this.ChangeDuckingState(AudioManager.DuckingState.None);
				this.BGMSource[this.BGMmainIndex].volume = this.MusicVol * this.BaseVol;
			}
			break;
		}
		}
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00019D78 File Offset: 0x00017F78
	private void UpdateCloseFadeOut()
	{
		for (int i = 0; i < this.CloseQueue.Length; i++)
		{
			this.CloseQueue[i].Update();
		}
	}

	// Token: 0x0600019F RID: 415 RVA: 0x00019DAC File Offset: 0x00017FAC
	public void NotifyCloseSFX(byte Key)
	{
		if (Key == 100)
		{
			this.PlaySFX(this.CurUseIndex);
		}
		else if (Key < 20)
		{
			this.DelSFXClip(Key);
		}
		else
		{
			this.DelFireClip();
		}
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00019DE4 File Offset: 0x00017FE4
	private void PlayAudio(AudioSource au, ClipInfo clipInfo)
	{
		if (au.isPlaying)
		{
			au.Stop();
		}
		au.loop = clipInfo.Loop;
		au.volume = clipInfo.Volume * this.BaseVol;
		au.pitch = clipInfo.Pitch;
		au.clip = clipInfo.clip;
		au.panLevel = clipInfo.PanLevel;
		au.enabled = true;
		float? delaySecond = clipInfo.DelaySecond;
		if (delaySecond == null)
		{
			au.Play();
		}
		else
		{
			au.PlayDelayed(clipInfo.DelaySecond.Value);
		}
		clipInfo.clear();
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00019E84 File Offset: 0x00018084
	public void Destroy()
	{
		this.UnLoadBGM();
		this.ChangeDuckingState(AudioManager.DuckingState.None);
		byte b = 0;
		while ((int)b < this.SFXBundleKey.Length)
		{
			if (this.SFXBundleKey[(int)b] != 0)
			{
				if (this.SFXSource[(int)b])
				{
					this.SFXSource[(int)b].Stop();
					this.SFXSource[(int)b].clip = null;
				}
				AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int)b], true);
			}
			b += 1;
		}
		if (this.MP3Key != 0)
		{
			if (this.MP3Source)
			{
				this.MP3Source.Stop();
				this.MP3Source.clip = null;
			}
			AssetManager.UnloadAssetBundle(this.MP3Key, true);
		}
		if (this.AudioAssetBundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AudioAssetBundleKey, true);
		}
		this.AudioAssetBundle = null;
		UnityEngine.Object.Destroy(this.AudioController);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00019F68 File Offset: 0x00018168
	public void RetrieveSFX()
	{
		byte b = 0;
		while ((int)b < this.SFXSource.Length)
		{
			if (this.SFXSource[(int)b].isPlaying || this.PauseKey[(int)b] == 1)
			{
				this.SFXSource[(int)b].Stop();
				this.DelSFXClip(b);
			}
			b += 1;
		}
		if (this.FireSFXSource.clip)
		{
			this.FireSFXSource.Stop();
			this.DelFireClip();
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00019FEC File Offset: 0x000181EC
	private void AttachAudioSound(byte sourceIndex, Transform transform)
	{
		this.SFXSource[(int)sourceIndex].transform.position = transform.position;
		this.PlaySFXTrans[(int)sourceIndex] = transform;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0001A01C File Offset: 0x0001821C
	private void AttachAudioSound(byte sourceIndex, Vector3 position)
	{
		this.SFXSource[(int)sourceIndex].transform.position = position;
	}

	// Token: 0x04000381 RID: 897
	private const byte MaxSourceNum = 20;

	// Token: 0x04000382 RID: 898
	private const byte BGMSourceCount = 2;

	// Token: 0x04000383 RID: 899
	private const float DuckVolDecreaseNum = 0.2921f;

	// Token: 0x04000384 RID: 900
	private const float DuckExtendTime = 1f;

	// Token: 0x04000385 RID: 901
	private const float DuckCancelTime = 1f;

	// Token: 0x04000386 RID: 902
	private const ushort MP3PriName = 700;

	// Token: 0x04000387 RID: 903
	private GameObject AudioController;

	// Token: 0x04000388 RID: 904
	private static AudioManager instance;

	// Token: 0x04000389 RID: 905
	private AudioSource[] SFXSource = new AudioSource[20];

	// Token: 0x0400038A RID: 906
	private int[] SFXBundleKey = new int[20];

	// Token: 0x0400038B RID: 907
	private Transform[] PlaySFXTrans = new Transform[20];

	// Token: 0x0400038C RID: 908
	private short MarkSFXBundleKey;

	// Token: 0x0400038D RID: 909
	private byte SpeechSoundPrev;

	// Token: 0x0400038E RID: 910
	private float[] SpeechSoundPitchVal = new float[]
	{
		1f,
		1.11225f,
		0.8909f
	};

	// Token: 0x0400038F RID: 911
	private ClipInfo SFXClip = new ClipInfo();

	// Token: 0x04000390 RID: 912
	private byte poolIndex;

	// Token: 0x04000391 RID: 913
	private int FireKey;

	// Token: 0x04000392 RID: 914
	private AudioSource FireSFXSource;

	// Token: 0x04000393 RID: 915
	private AudioHighPassFilter FireHighPass;

	// Token: 0x04000394 RID: 916
	private AudioCloseQueue[] CloseQueue = new AudioCloseQueue[4];

	// Token: 0x04000395 RID: 917
	private int CloseQueueIndex;

	// Token: 0x04000396 RID: 918
	private int NowPlayBGMName;

	// Token: 0x04000397 RID: 919
	private WWW www;

	// Token: 0x04000398 RID: 920
	private AudioSource[] BGMSource = new AudioSource[2];

	// Token: 0x04000399 RID: 921
	private byte BGMLoop;

	// Token: 0x0400039A RID: 922
	private ClipInfo BGMClip = new ClipInfo();

	// Token: 0x0400039B RID: 923
	private AssetBundle[] BGMassetBundle = new AssetBundle[2];

	// Token: 0x0400039C RID: 924
	private int BGMmainIndex;

	// Token: 0x0400039D RID: 925
	private bool bCrossfade;

	// Token: 0x0400039E RID: 926
	private float FadeTime;

	// Token: 0x0400039F RID: 927
	private float FadeTimeMax = 3f;

	// Token: 0x040003A0 RID: 928
	public float MusicVol = 1f;

	// Token: 0x040003A1 RID: 929
	public float TmpVol;

	// Token: 0x040003A2 RID: 930
	private BGMType CurMusicType;

	// Token: 0x040003A3 RID: 931
	private float DuckVolDecrease;

	// Token: 0x040003A4 RID: 932
	private float DuckDeltaTime;

	// Token: 0x040003A5 RID: 933
	private byte PlaySFXCount;

	// Token: 0x040003A6 RID: 934
	public bool BlockNormalSFX = true;

	// Token: 0x040003A7 RID: 935
	private AudioManager.DuckingState duckingstate;

	// Token: 0x040003A8 RID: 936
	private ushort MP3ABName;

	// Token: 0x040003A9 RID: 937
	private int MP3Key;

	// Token: 0x040003AA RID: 938
	private AudioSource MP3Source;

	// Token: 0x040003AB RID: 939
	private string Path = "Role/";

	// Token: 0x040003AC RID: 940
	private string Music = "Music/";

	// Token: 0x040003AD RID: 941
	public float BaseVol;

	// Token: 0x040003AE RID: 942
	public bool MuteSFXVol;

	// Token: 0x040003AF RID: 943
	public byte[] PauseKey = new byte[20];

	// Token: 0x040003B0 RID: 944
	private byte CurUseIndex;

	// Token: 0x040003B1 RID: 945
	private short bPlayOnlyOneClip = -1;

	// Token: 0x040003B2 RID: 946
	private AudioSourceController SourceController = new AudioSourceController();

	// Token: 0x040003B3 RID: 947
	private AssetBundle AudioAssetBundle;

	// Token: 0x040003B4 RID: 948
	private int AudioAssetBundleKey;

	// Token: 0x02000042 RID: 66
	private enum DuckingState
	{
		// Token: 0x040003B6 RID: 950
		Start,
		// Token: 0x040003B7 RID: 951
		Extend,
		// Token: 0x040003B8 RID: 952
		Cancel,
		// Token: 0x040003B9 RID: 953
		None
	}
}
