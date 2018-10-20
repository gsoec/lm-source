using System;
using UnityEngine;

// Token: 0x02000763 RID: 1891
public class ImmersiveModeEnabler : MonoBehaviour
{
	// Token: 0x060024AD RID: 9389 RVA: 0x00422E80 File Offset: 0x00421080
	private void Awake()
	{
		if (!Application.isEditor)
		{
			this.HideNavigationBar();
		}
		if (!ImmersiveModeEnabler.created)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			ImmersiveModeEnabler.created = true;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060024AE RID: 9390 RVA: 0x00422EC8 File Offset: 0x004210C8
	private void HideNavigationBar()
	{
		lock (this)
		{
			using (this.javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				this.unityActivity = this.javaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			if (this.unityActivity != null)
			{
				using (this.javaClass = new AndroidJavaClass("com.rak24.androidimmersivemode.Main"))
				{
					if (this.javaClass != null)
					{
						this.javaObj = this.javaClass.CallStatic<AndroidJavaObject>("instance", new object[0]);
						if (this.javaObj != null)
						{
							this.unityActivity.Call("runOnUiThread", new object[]
							{
								new AndroidJavaRunnable(delegate()
								{
									this.javaObj.Call("EnableImmersiveMode", new object[]
									{
										this.unityActivity
									});
								})
							});
						}
					}
				}
			}
		}
	}

	// Token: 0x060024AF RID: 9391 RVA: 0x00423008 File Offset: 0x00421208
	private void OnApplicationPause(bool pausedState)
	{
		this.paused = pausedState;
	}

	// Token: 0x060024B0 RID: 9392 RVA: 0x00423014 File Offset: 0x00421214
	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus && this.javaObj != null && !this.paused)
		{
			this.unityActivity.Call("runOnUiThread", new object[]
			{
				new AndroidJavaRunnable(delegate()
				{
					this.javaObj.CallStatic("ImmersiveModeFromCache", new object[]
					{
						this.unityActivity
					});
				})
			});
		}
	}

	// Token: 0x060024B1 RID: 9393 RVA: 0x00423064 File Offset: 0x00421264
	public void PinThisApp()
	{
		if (this.javaObj != null)
		{
			this.javaObj.CallStatic("EnableAppPin", new object[]
			{
				this.unityActivity
			});
		}
	}

	// Token: 0x060024B2 RID: 9394 RVA: 0x0042309C File Offset: 0x0042129C
	public void UnPinThisApp()
	{
		if (this.javaObj != null)
		{
			this.javaObj.CallStatic("DisableAppPin", new object[]
			{
				this.unityActivity
			});
		}
	}

	// Token: 0x04006F09 RID: 28425
	private AndroidJavaObject unityActivity;

	// Token: 0x04006F0A RID: 28426
	private AndroidJavaObject javaObj;

	// Token: 0x04006F0B RID: 28427
	private AndroidJavaClass javaClass;

	// Token: 0x04006F0C RID: 28428
	private bool paused;

	// Token: 0x04006F0D RID: 28429
	private static bool created;
}
