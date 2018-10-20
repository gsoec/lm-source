using System;

// Token: 0x020001BB RID: 443
public abstract class Gameplay : IObserver
{
	// Token: 0x06000769 RID: 1897 RVA: 0x000A2650 File Offset: 0x000A0850
	public Gameplay()
	{
		this.updateDelegates = new Gameplay.UpdateDelegate[2][];
		Array.Clear(this.updateDelegates, 0, this.updateDelegates.Length);
		this.updateDelegates[0] = new Gameplay.UpdateDelegate[4];
		this.updateDelegates[0][0] = new Gameplay.UpdateDelegate(this.UpdateNext);
		this.updateDelegates[0][1] = new Gameplay.UpdateDelegate(this.UpdateLoad);
		this.updateDelegates[0][2] = new Gameplay.UpdateDelegate(this.UpdateReady);
		this.updateDelegates[0][3] = new Gameplay.UpdateDelegate(this.UpdateRun);
		this.updateDelegates[1] = new Gameplay.UpdateDelegate[1];
		this.updateDelegates[1][0] = new Gameplay.UpdateDelegate(this.UpdateNews);
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x000A2714 File Offset: 0x000A0914
	~Gameplay()
	{
		this.ClearUpdateDelegates();
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x000A2750 File Offset: 0x000A0950
	public virtual void Renew(byte[] Subject, byte[] meg)
	{
		this.updateDelegates[(int)Subject[0]][(int)Subject[1]](meg);
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x000A2768 File Offset: 0x000A0968
	protected virtual void ClearUpdateDelegates()
	{
		if (this.updateDelegates != null)
		{
			for (int i = 0; i < this.updateDelegates.Length; i++)
			{
				Array.Clear(this.updateDelegates[i], 0, this.updateDelegates[i].Length);
				this.updateDelegates[i] = null;
			}
			this.updateDelegates = null;
		}
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x000A27C4 File Offset: 0x000A09C4
	protected virtual void UpdateNews(byte[] meg)
	{
	}

	// Token: 0x0600076E RID: 1902
	protected abstract void UpdateNext(byte[] meg);

	// Token: 0x0600076F RID: 1903
	protected abstract void UpdateLoad(byte[] meg);

	// Token: 0x06000770 RID: 1904
	protected abstract void UpdateReady(byte[] meg);

	// Token: 0x06000771 RID: 1905
	protected abstract void UpdateRun(byte[] meg);

	// Token: 0x04001B8E RID: 7054
	protected Gameplay.UpdateDelegate[][] updateDelegates;

	// Token: 0x0200088E RID: 2190
	// (Invoke) Token: 0x06002D80 RID: 11648
	protected delegate void UpdateDelegate(byte[] meg);
}
