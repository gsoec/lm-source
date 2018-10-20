using System;

// Token: 0x020001BD RID: 445
public interface IObservable
{
	// Token: 0x06000773 RID: 1907
	void RegisterObserver(byte[] Subject, IObserver pObserver);

	// Token: 0x06000774 RID: 1908
	void RemoveObserver(byte[] Subject);

	// Token: 0x06000775 RID: 1909
	void notifyObservers(byte[] Subject, byte[] meg = null);

	// Token: 0x06000776 RID: 1910
	void ClearObservers();
}
