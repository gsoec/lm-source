using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SevenZip.Compression.LZMA;
using UnityEngine;

// Token: 0x02000707 RID: 1799
public class DownloadController
{
	// Token: 0x0600228F RID: 8847 RVA: 0x00408778 File Offset: 0x00406978
	public static void Refresh()
	{
		DownloadController.check = true;
	}

	// Token: 0x06002290 RID: 8848 RVA: 0x00408780 File Offset: 0x00406980
	public static void Reset(bool Clear = true)
	{
		if (DownloadController.bundle != null)
		{
			DownloadController.bundle.Dispose();
			DownloadController.bundle = null;
		}
		if (DownloadController.Gamer)
		{
			DownloadController.Extraction = 5000u;
			DownloadController.AssetUpdates = null;
			DownloadController.DownloadUpdates = null;
			DownloadController.refresh = (DownloadController.check = false);
			DownloadController.Gamer.StopAllCoroutines();
			NetworkManager.Instance.RequestTime = (float)(DownloadController.monster = 0L);
		}
		UpdateController.DownloadReset(true);
		DownloadController.check = !Clear;
	}

	// Token: 0x06002291 RID: 8849 RVA: 0x00408804 File Offset: 0x00406A04
	public static void Init(GameManager Gm)
	{
		DownloadController.Prefix = "file://";
		DownloadController.Gamer = Gm;
		DownloadController.CDNRoot = "http://static-lo.igg.com/Global/android";
		DownloadController.Prefix = "http://download-lo-snd.igg.com/android";
	}

	// Token: 0x06002292 RID: 8850 RVA: 0x00408838 File Offset: 0x00406A38
	private static IEnumerator DownloadCheck()
	{
		DownloadController.refresh = true;
		if (DownloadController.DownloadUpdates != null)
		{
			yield return DownloadController.Gamer.StartCoroutine(DownloadController.ProceedDownload());
		}
		else if (DownloadController.bundle == null)
		{
			yield return DownloadController.Gamer.StartCoroutine(DownloadController.StartDownload());
		}
		DownloadController.refresh = false;
		yield break;
	}

	// Token: 0x06002293 RID: 8851 RVA: 0x0040884C File Offset: 0x00406A4C
	private static IEnumerator LoadStreamAssToPersistent(string data, string path, string file, string type, string number, string revision)
	{
		int num = 0;
		DownloadController.Path.Length = num;
		DownloadController.Buffer = (DownloadController.Terminator = (DownloadController.ticker = (float)num));
		string localfile = DownloadController.Path.AppendFormat("{0}/{1}/{2}.pending", AssetManager.persistentDataPath, path, file).ToString();
		Caching.CleanCache();
		WWW bundle = WWW.LoadFromCacheOrDownload(string.Format("{0}/{1}/{2}{3}.assetbundle", new object[]
		{
			data,
			path,
			file,
			revision
		}), 0, 0u);
		bundle.threadPriority = ThreadPriority.Low;
		while (bundle != null && !bundle.isDone)
		{
			yield return bundle;
			if (DownloadController.Buffer != bundle.progress)
			{
				DownloadController.Buffer = bundle.progress;
				DownloadController.Terminator = 0f;
			}
			else if ((DownloadController.Terminator += NetworkManager.DeltaTime) > 15f)
			{
				break;
			}
		}
		if (bundle != null && bundle.isDone && bundle.error == null)
		{
			Stream input = new MemoryStream((bundle.assetBundle.Load(file) as TextAsset).bytes);
			FileStream output = new FileStream(localfile, FileMode.Create);
			input.Read(DownloadController.Properties, 0, 5);
			DownloadController.coder.SetDecoderProperties(DownloadController.Properties);
			input.Read(DownloadController.Properties, 0, 8);
			yield return DownloadController.Gamer.StartCoroutine(DownloadController.coder.Decode(input, output, input.Length, BitConverter.ToInt64(DownloadController.Properties, 0), DownloadController.Extraction, null));
			DownloadController.Path.Length = 0;
			output.Flush();
			output.Close();
			input.Close();
			File.Delete(localfile.Remove(localfile.Length - 8, 8));
			yield return true;
			AssetManager.RefreshAssetBundle(DownloadController.Path.AppendFormat("{0}/{1}", path, file).ToString().ToUpperInvariant().GetHashCode(), false);
			DownloadController.Path.Length = 0;
			File.Delete(data = DownloadController.Path.AppendFormat("{0}/{1}/{2}.unity3d", AssetManager.persistentDataPath, path, file).ToString());
			File.Move(localfile, data);
			File.WriteAllText(localfile.Remove(localfile.Length - 8, 8), (bundle.assetBundle.Load(file + "crc") as TextAsset).text);
			bundle.assetBundle.Unload(true);
			bundle.Dispose();
			DownloadController.found = true;
			DownloadController.stamper = 0L;
		}
		else if (bundle != null)
		{
			bundle.Dispose();
		}
		yield break;
	}

	// Token: 0x06002294 RID: 8852 RVA: 0x0040889C File Offset: 0x00406A9C
	private static IEnumerator StartDownload()
	{
		DownloadController.HappyGo = false;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				if (AssetManager.UpdatePackage[i, j].Count > 0)
				{
					DownloadController.HappyGo = true;
				}
			}
		}
		DownloadController.queue = 0;
		for (int k = 0; k < 2; k++)
		{
			DownloadController.DownloadUpdate[k] = null;
		}
		if (DateTime.Now.Ticks > DownloadController.monster)
		{
			DownloadController.DownloadUpdate[2] = null;
		}
		else if (DownloadController.DownloadUpdate[2] == null)
		{
			DownloadController.monster = 0L;
		}
		NetworkManager.Instance.RequestTime = 15f;
		if (DownloadController.HappyGo)
		{
			DownloadController.bundle = new WWW(DownloadController.Prefix + "/UpdateMall.plist?v=" + DateTime.UtcNow.Ticks);
			DownloadController.bundle.threadPriority = ThreadPriority.Low;
			while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
			{
				yield return false;
			}
			if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null && DownloadController.bundle.responseHeaders != null && DownloadController.bundle.responseHeaders.ContainsKey("LOCATION"))
			{
				NetworkManager.Instance.RequestTime = 15f;
				DownloadController.bundle = new WWW(DownloadController.bundle.responseHeaders["LOCATION"]);
				DownloadController.bundle.threadPriority = ThreadPriority.Low;
				while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
				{
					yield return false;
				}
			}
			if (DownloadController.bundle == null || !DownloadController.bundle.isDone || DownloadController.bundle.error != null)
			{
				NetworkManager.Instance.RequestTime = 15f;
				DownloadController.bundle = new WWW(DownloadController.CDNRoot + "/UpdateMall.plist?v=" + DateTime.UtcNow.Ticks);
				DownloadController.bundle.threadPriority = ThreadPriority.Low;
				while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
				{
					yield return false;
				}
			}
			if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null)
			{
				DownloadController.DownloadUpdate[(int)DownloadController.queue] = Encoding.ASCII.GetString(DownloadController.bundle.bytes).Split(new string[]
				{
					"/",
					"\\",
					"\r",
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				if (DownloadController.DownloadUpdate[(int)DownloadController.queue].Length < 4 || !DownloadController.DownloadUpdate[(int)DownloadController.queue][2].Equals("Updates"))
				{
					DownloadController.DownloadUpdate[(int)DownloadController.queue] = null;
				}
			}
			if (DownloadController.bundle != null)
			{
				DownloadController.bundle.Dispose();
			}
		}
		else
		{
			DownloadController.queue = 2;
			for (int l = 0; l < 2; l++)
			{
				for (int m = 0; m < 2; m++)
				{
					if (AssetManager.AssetPackages[l, m].Count > 0)
					{
						DownloadController.queue = 1;
					}
				}
			}
			if (DownloadController.DownloadUpdate[(int)DownloadController.queue] == null)
			{
				if (DownloadController.queue == 2)
				{
					DownloadController.bundle = new WWW(DownloadController.Prefix + "/UpdateMonster.plist?v=" + DateTime.UtcNow.Ticks);
					DownloadController.bundle.threadPriority = ThreadPriority.Low;
					while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
					{
						yield return false;
					}
					if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null && DownloadController.bundle.responseHeaders != null && DownloadController.bundle.responseHeaders.ContainsKey("LOCATION"))
					{
						NetworkManager.Instance.RequestTime = 15f;
						DownloadController.bundle = new WWW(DownloadController.bundle.responseHeaders["LOCATION"]);
						DownloadController.bundle.threadPriority = ThreadPriority.Low;
						while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
						{
							yield return false;
						}
					}
					if (DownloadController.bundle == null || !DownloadController.bundle.isDone || DownloadController.bundle.error != null)
					{
						NetworkManager.Instance.RequestTime = 15f;
						DownloadController.bundle = new WWW(DownloadController.CDNRoot + "/UpdateMonster.plist?v=" + DateTime.UtcNow.Ticks);
						DownloadController.bundle.threadPriority = ThreadPriority.Low;
						while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
						{
							yield return false;
						}
					}
					if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null)
					{
						DownloadController.DownloadUpdate[(int)DownloadController.queue] = Encoding.ASCII.GetString(DownloadController.bundle.bytes).Split(new string[]
						{
							"/",
							"\\",
							"\r",
							"\n"
						}, StringSplitOptions.RemoveEmptyEntries);
						if (DownloadController.DownloadUpdate[(int)DownloadController.queue].Length < 5 || !DownloadController.DownloadUpdate[(int)DownloadController.queue][4].Equals("Updates"))
						{
							DownloadController.DownloadUpdate[(int)DownloadController.queue] = null;
						}
						else if (DownloadController.Pokedex == null)
						{
							DownloadController.Pokedex = new List<string>(DownloadController.DownloadUpdate[(int)DownloadController.queue].Length / 6);
							ushort n = 5;
							while ((int)n < DownloadController.DownloadUpdate[(int)DownloadController.queue].Length - 5)
							{
								if (long.TryParse(DownloadController.DownloadUpdate[(int)DownloadController.queue][(int)(n + 2)], out DownloadController.stamper) && DownloadController.stamper > 0L)
								{
									for (byte j2 = 0; j2 < 6; j2 += 1)
									{
										DownloadController.Pokedex.Add(DownloadController.DownloadUpdate[(int)DownloadController.queue][(int)(n + (ushort)j2)]);
									}
								}
								n += 6;
							}
						}
					}
				}
				else
				{
					DownloadController.bundle = new WWW(DownloadController.Prefix + "/UpdateActivity.plist?v=" + DateTime.UtcNow.Ticks);
					DownloadController.bundle.threadPriority = ThreadPriority.Low;
					while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
					{
						yield return false;
					}
					if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null && DownloadController.bundle.responseHeaders != null && DownloadController.bundle.responseHeaders.ContainsKey("LOCATION"))
					{
						NetworkManager.Instance.RequestTime = 15f;
						DownloadController.bundle = new WWW(DownloadController.bundle.responseHeaders["LOCATION"]);
						DownloadController.bundle.threadPriority = ThreadPriority.Low;
						while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
						{
							yield return false;
						}
					}
					if (DownloadController.bundle == null || !DownloadController.bundle.isDone || DownloadController.bundle.error != null)
					{
						NetworkManager.Instance.RequestTime = 15f;
						DownloadController.bundle = new WWW(DownloadController.CDNRoot + "/UpdateActivity.plist?v=" + DateTime.UtcNow.Ticks);
						DownloadController.bundle.threadPriority = ThreadPriority.Low;
						while (DownloadController.bundle != null && !DownloadController.bundle.isDone)
						{
							yield return false;
						}
					}
					if (DownloadController.bundle != null && DownloadController.bundle.isDone && DownloadController.bundle.error == null)
					{
						DownloadController.DownloadUpdate[(int)DownloadController.queue] = Encoding.ASCII.GetString(DownloadController.bundle.bytes).Split(new string[]
						{
							"/",
							"\\",
							"\r",
							"\n"
						}, StringSplitOptions.RemoveEmptyEntries);
						if (DownloadController.DownloadUpdate[(int)DownloadController.queue].Length < 4 || !DownloadController.DownloadUpdate[(int)DownloadController.queue][2].Equals("Updates"))
						{
							DownloadController.DownloadUpdate[(int)DownloadController.queue] = null;
						}
					}
				}
			}
			if (DownloadController.bundle != null)
			{
				DownloadController.bundle.Dispose();
			}
		}
		DownloadController.bundle = null;
		NetworkManager.Instance.RequestTime = 0f;
		if ((DownloadController.DownloadUpdates = DownloadController.DownloadUpdate[(int)DownloadController.queue]) == null)
		{
			yield return new WaitForSeconds(15f);
		}
		else if (DownloadController.queue == 2 && DateTime.Now.Ticks > DownloadController.monster)
		{
			DownloadController.monster = DateTime.Now.AddHours(12.0).Ticks;
		}
		yield break;
	}

	// Token: 0x06002295 RID: 8853 RVA: 0x004088B0 File Offset: 0x00406AB0
	private static IEnumerator ProceedDownload()
	{
		DownloadController.Path.Length = 0;
		ushort Package = 0;
		if (DownloadController.found)
		{
			DownloadController.found = false;
			if (AssetManager.UpdatePackage[1, 1].Count > 0)
			{
				if (DownloadController.DownloadUpdates != null)
				{
					ushort i = 3;
					while ((int)i < DownloadController.DownloadUpdates.Length - 7)
					{
						if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(i + 6)], out Package) && AssetManager.UpdatePackage[1, 1][0] == (int)Package && DownloadController.DownloadUpdates[(int)(i + 5)].Equals("1"))
						{
							DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(i + 2)]);
							using (FileStream fs = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)i], DownloadController.DownloadUpdates[(int)(i + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr = new StreamReader(fs))
								{
									if (long.TryParse(sr.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
									{
										DownloadController.found = true;
									}
								}
							}
							if (!DownloadController.found)
							{
								yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)i], DownloadController.DownloadUpdates[(int)(i + 1)], DownloadController.DownloadUpdates[(int)(i + 5)], DownloadController.DownloadUpdates[(int)(i + 6)], (!DownloadController.DownloadUpdates[(int)(i + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(i + 7)]) : string.Empty));
							}
							if (DownloadController.found)
							{
								AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)i] + "/" + DownloadController.DownloadUpdates[(int)(i + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
							}
							break;
						}
						i += 8;
					}
					if (!DownloadController.found)
					{
						DownloadController.DownloadUpdates = null;
						yield return new WaitForSeconds(15f);
					}
					DataManager.msgBuffer[0] = 2;
					DataManager.msgBuffer[1] = 1;
					DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
					GameConstants.GetBytes((ushort)AssetManager.UpdatePackage[1, 1][0], DataManager.msgBuffer, 2);
					AssetManager.UpdatePackage[1, 1].RemoveAt(0);
					GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
				}
			}
			else if (AssetManager.UpdatePackage[0, 1].Count > 0)
			{
				if (DownloadController.DownloadUpdates != null)
				{
					ushort j = 3;
					while ((int)j < DownloadController.DownloadUpdates.Length - 7)
					{
						if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(j + 6)], out Package) && AssetManager.UpdatePackage[0, 1][0] == (int)Package && DownloadController.DownloadUpdates[(int)(j + 5)].Equals("0"))
						{
							DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(j + 2)]);
							using (FileStream fs2 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)j], DownloadController.DownloadUpdates[(int)(j + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr2 = new StreamReader(fs2))
								{
									if (long.TryParse(sr2.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
									{
										DownloadController.found = true;
									}
								}
							}
							if (!DownloadController.found)
							{
								yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)j], DownloadController.DownloadUpdates[(int)(j + 1)], DownloadController.DownloadUpdates[(int)(j + 5)], DownloadController.DownloadUpdates[(int)(j + 6)], (!DownloadController.DownloadUpdates[(int)(j + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(j + 7)]) : string.Empty));
							}
							if (DownloadController.found)
							{
								AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)j] + "/" + DownloadController.DownloadUpdates[(int)(j + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
							}
							break;
						}
						j += 8;
					}
					if (!DownloadController.found)
					{
						DownloadController.DownloadUpdates = null;
						yield return new WaitForSeconds(15f);
					}
					DataManager.msgBuffer[0] = 2;
					DataManager.msgBuffer[1] = 0;
					DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
					GameConstants.GetBytes((ushort)AssetManager.UpdatePackage[0, 1][0], DataManager.msgBuffer, 2);
					AssetManager.UpdatePackage[0, 1].RemoveAt(0);
					GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
				}
			}
			else if (AssetManager.UpdatePackage[0, 0].Count == 0 && AssetManager.UpdatePackage[1, 0].Count == 0)
			{
				if (AssetManager.AssetPackages[1, 1].Count > 0)
				{
					if (DownloadController.DownloadUpdates != null)
					{
						ushort k = 3;
						while ((int)k < DownloadController.DownloadUpdates.Length - 7)
						{
							if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(k + 6)], out Package) && AssetManager.AssetPackages[1, 1][0] == (int)Package && DownloadController.DownloadUpdates[(int)(k + 5)].Equals("1"))
							{
								DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(k + 2)]);
								using (FileStream fs3 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)k], DownloadController.DownloadUpdates[(int)(k + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
								{
									using (StreamReader sr3 = new StreamReader(fs3))
									{
										if (long.TryParse(sr3.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
										{
											DownloadController.found = true;
										}
									}
								}
								if (!DownloadController.found)
								{
									yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)k], DownloadController.DownloadUpdates[(int)(k + 1)], DownloadController.DownloadUpdates[(int)(k + 5)], DownloadController.DownloadUpdates[(int)(k + 6)], (!DownloadController.DownloadUpdates[(int)(k + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(k + 7)]) : string.Empty));
								}
								if (DownloadController.found)
								{
									AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)k] + "/" + DownloadController.DownloadUpdates[(int)(k + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
								}
								break;
							}
							k += 8;
						}
						if (!DownloadController.found)
						{
							DownloadController.DownloadUpdates = null;
							yield return new WaitForSeconds(15f);
						}
						DataManager.msgBuffer[0] = 4;
						DataManager.msgBuffer[1] = 1;
						DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
						GameConstants.GetBytes((ushort)AssetManager.AssetPackages[1, 1][0], DataManager.msgBuffer, 2);
						AssetManager.AssetPackages[1, 1].RemoveAt(0);
						GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
					}
				}
				else if (AssetManager.AssetPackages[0, 1].Count > 0)
				{
					if (DownloadController.DownloadUpdates != null)
					{
						ushort l = 3;
						while ((int)l < DownloadController.DownloadUpdates.Length - 7)
						{
							if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(l + 6)], out Package) && AssetManager.AssetPackages[0, 1][0] == (int)Package && DownloadController.DownloadUpdates[(int)(l + 5)].Equals("0"))
							{
								DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(l + 2)]);
								using (FileStream fs4 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)l], DownloadController.DownloadUpdates[(int)(l + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
								{
									using (StreamReader sr4 = new StreamReader(fs4))
									{
										if (long.TryParse(sr4.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
										{
											DownloadController.found = true;
										}
									}
								}
								if (!DownloadController.found)
								{
									yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)l], DownloadController.DownloadUpdates[(int)(l + 1)], DownloadController.DownloadUpdates[(int)(l + 5)], DownloadController.DownloadUpdates[(int)(l + 6)], (!DownloadController.DownloadUpdates[(int)(l + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(l + 7)]) : string.Empty));
								}
								if (DownloadController.found)
								{
									AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)l] + "/" + DownloadController.DownloadUpdates[(int)(l + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
								}
								break;
							}
							l += 8;
						}
						if (!DownloadController.found)
						{
							DownloadController.DownloadUpdates = null;
							yield return new WaitForSeconds(15f);
						}
						DataManager.msgBuffer[0] = 4;
						DataManager.msgBuffer[1] = 0;
						DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
						GameConstants.GetBytes((ushort)AssetManager.AssetPackages[0, 1][0], DataManager.msgBuffer, 2);
						AssetManager.AssetPackages[0, 1].RemoveAt(0);
						GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
					}
				}
				else if (AssetManager.AssetPackages[0, 0].Count == 0 && AssetManager.AssetPackages[1, 0].Count == 0)
				{
					if (AssetManager.AssetPackage[1].Count > 0)
					{
						DownloadController.HappyGo = false;
						if (DownloadController.DownloadUpdates != null)
						{
							ushort m = 5;
							while ((int)m < DownloadController.DownloadUpdates.Length - 5)
							{
								CString AssetUpdate = StringManager.Instance.StaticString1024();
								AssetUpdate.Append(DownloadController.DownloadUpdates[(int)m] + "/" + DownloadController.DownloadUpdates[(int)(m + 1)]);
								CString AssetBundle = StringManager.Instance.StaticString1024();
								AssetBundle.Append(AssetManager.AssetPackage[1][0].path);
								if (AssetBundle.Length == AssetUpdate.Length)
								{
									DownloadController.stamper = 0L;
									while (DownloadController.stamper < (long)AssetBundle.Length)
									{
										if (AssetUpdate[(int)DownloadController.stamper] != AssetBundle[(int)DownloadController.stamper])
										{
											break;
										}
										DownloadController.stamper += 1L;
									}
									if (DownloadController.stamper == (long)AssetBundle.Length && long.TryParse(DownloadController.DownloadUpdates[(int)(m + 2)], out DownloadController.stamper))
									{
										if (DownloadController.stamper > 0L)
										{
											using (FileStream fs5 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)m], DownloadController.DownloadUpdates[(int)(m + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
											{
												using (StreamReader sr5 = new StreamReader(fs5))
												{
													if (long.TryParse(sr5.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
													{
														DownloadController.found = true;
													}
												}
											}
											if (!DownloadController.found)
											{
												yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)m], DownloadController.DownloadUpdates[(int)(m + 1)], DownloadController.DownloadUpdates[(int)(m + 2)], DownloadController.DownloadUpdates[(int)(m + 3)], (!DownloadController.DownloadUpdates[(int)(m + 5)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(m + 5)]) : string.Empty));
											}
											if (DownloadController.found)
											{
												AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)m] + "/" + DownloadController.DownloadUpdates[(int)(m + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
											}
										}
										else
										{
											DownloadController.found = true;
											DownloadController.stamper = 1L;
										}
										break;
									}
								}
								m += 6;
							}
							if (DownloadController.found)
							{
								if (DownloadController.stamper == 0L)
								{
									DataManager.msgBuffer[0] = AssetManager.AssetPackage[1][0].kind;
									DataManager.msgBuffer[1] = AssetManager.AssetPackage[1][0].type;
									GameConstants.GetBytes((ushort)AssetManager.AssetPackage[1][0].id, DataManager.msgBuffer, 2);
									GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
								}
							}
							else
							{
								AssetManager.AssetPackage[1].Add(AssetManager.AssetPackage[1][0]);
								DownloadController.DownloadUpdates = (DownloadController.DownloadUpdate[2] = null);
								yield return new WaitForSeconds(5f);
							}
							AssetManager.AssetPackage[1].RemoveAt(0);
						}
					}
					else if (AssetManager.AssetPackage[0].Count == 0 && (DownloadController.Pokedex == null || DownloadController.Pokedex.Count == 0))
					{
						DownloadController.check = false;
					}
					else
					{
						DownloadController.HappyGo = false;
					}
				}
			}
		}
		else
		{
			DownloadController.found = false;
			if (AssetManager.UpdatePackage[1, 0].Count > 0)
			{
				if (DownloadController.DownloadUpdate[0] != null)
				{
					ushort n = 3;
					while ((int)n < DownloadController.DownloadUpdates.Length - 7)
					{
						if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(n + 6)], out Package) && AssetManager.UpdatePackage[1, 0][0] == (int)Package && DownloadController.DownloadUpdates[(int)(n + 5)].Equals("1"))
						{
							DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(n + 2)]);
							using (FileStream fs6 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)n], DownloadController.DownloadUpdates[(int)(n + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr6 = new StreamReader(fs6))
								{
									if (long.TryParse(sr6.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
									{
										DownloadController.found = true;
									}
								}
							}
							if (!DownloadController.found)
							{
								yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)n], DownloadController.DownloadUpdates[(int)(n + 1)], DownloadController.DownloadUpdates[(int)(n + 5)], DownloadController.DownloadUpdates[(int)(n + 6)], (!DownloadController.DownloadUpdates[(int)(n + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(n + 7)]) : string.Empty));
							}
							if (DownloadController.found)
							{
								AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)n] + "/" + DownloadController.DownloadUpdates[(int)(n + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
							}
							break;
						}
						n += 8;
					}
					DataManager.msgBuffer[0] = 2;
					DataManager.msgBuffer[1] = 1;
					DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
					GameConstants.GetBytes((ushort)AssetManager.UpdatePackage[1, 0][0], DataManager.msgBuffer, 2);
					AssetManager.UpdatePackage[1, 0].RemoveAt(0);
					GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
				}
				else
				{
					DownloadController.DownloadUpdates = null;
				}
			}
			else if (AssetManager.UpdatePackage[0, 0].Count > 0)
			{
				if (DownloadController.DownloadUpdate[0] != null)
				{
					ushort j2 = 3;
					while ((int)j2 < DownloadController.DownloadUpdates.Length - 7)
					{
						if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(j2 + 6)], out Package) && AssetManager.UpdatePackage[0, 0][0] == (int)Package && DownloadController.DownloadUpdates[(int)(j2 + 5)].Equals("0"))
						{
							DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(j2 + 2)]);
							using (FileStream fs7 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)j2], DownloadController.DownloadUpdates[(int)(j2 + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr7 = new StreamReader(fs7))
								{
									if (long.TryParse(sr7.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
									{
										DownloadController.found = true;
									}
								}
							}
							if (!DownloadController.found)
							{
								yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)j2], DownloadController.DownloadUpdates[(int)(j2 + 1)], DownloadController.DownloadUpdates[(int)(j2 + 5)], DownloadController.DownloadUpdates[(int)(j2 + 6)], (!DownloadController.DownloadUpdates[(int)(j2 + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(j2 + 7)]) : string.Empty));
							}
							if (DownloadController.found)
							{
								AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)j2] + "/" + DownloadController.DownloadUpdates[(int)(j2 + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
							}
							break;
						}
						j2 += 8;
					}
					DataManager.msgBuffer[0] = 2;
					DataManager.msgBuffer[1] = 0;
					DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
					GameConstants.GetBytes((ushort)AssetManager.UpdatePackage[0, 0][0], DataManager.msgBuffer, 2);
					AssetManager.UpdatePackage[0, 0].RemoveAt(0);
					GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
				}
				else
				{
					DownloadController.DownloadUpdates = null;
				}
			}
			else if (AssetManager.UpdatePackage[0, 1].Count == 0 && AssetManager.UpdatePackage[1, 1].Count == 0)
			{
				if (AssetManager.AssetPackages[1, 0].Count > 0)
				{
					if (DownloadController.DownloadUpdate[1] != null)
					{
						ushort j3 = 3;
						while ((int)j3 < DownloadController.DownloadUpdates.Length - 7)
						{
							if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(j3 + 6)], out Package) && AssetManager.AssetPackages[1, 0][0] == (int)Package && DownloadController.DownloadUpdates[(int)(j3 + 5)].Equals("1"))
							{
								DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(j3 + 2)]);
								using (FileStream fs8 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)j3], DownloadController.DownloadUpdates[(int)(j3 + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
								{
									using (StreamReader sr8 = new StreamReader(fs8))
									{
										if (long.TryParse(sr8.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
										{
											DownloadController.found = true;
										}
									}
								}
								if (!DownloadController.found)
								{
									yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)j3], DownloadController.DownloadUpdates[(int)(j3 + 1)], DownloadController.DownloadUpdates[(int)(j3 + 5)], DownloadController.DownloadUpdates[(int)(j3 + 6)], (!DownloadController.DownloadUpdates[(int)(j3 + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(j3 + 7)]) : string.Empty));
								}
								if (DownloadController.found)
								{
									AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)j3] + "/" + DownloadController.DownloadUpdates[(int)(j3 + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
								}
								break;
							}
							j3 += 8;
						}
						DataManager.msgBuffer[0] = 4;
						DataManager.msgBuffer[1] = 1;
						DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
						GameConstants.GetBytes((ushort)AssetManager.AssetPackages[1, 0][0], DataManager.msgBuffer, 2);
						AssetManager.AssetPackages[1, 0].RemoveAt(0);
						GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
					}
					else
					{
						DownloadController.DownloadUpdates = null;
					}
				}
				else if (AssetManager.AssetPackages[0, 0].Count > 0)
				{
					if (DownloadController.DownloadUpdate[1] != null)
					{
						ushort j4 = 3;
						while ((int)j4 < DownloadController.DownloadUpdates.Length - 7)
						{
							if (ushort.TryParse(DownloadController.DownloadUpdates[(int)(j4 + 6)], out Package) && AssetManager.AssetPackages[0, 0][0] == (int)Package && DownloadController.DownloadUpdates[(int)(j4 + 5)].Equals("0"))
							{
								DownloadController.stamper = Convert.ToInt64(DownloadController.DownloadUpdates[(int)(j4 + 2)]);
								using (FileStream fs9 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)j4], DownloadController.DownloadUpdates[(int)(j4 + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
								{
									using (StreamReader sr9 = new StreamReader(fs9))
									{
										if (long.TryParse(sr9.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
										{
											DownloadController.found = true;
										}
									}
								}
								if (!DownloadController.found)
								{
									yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)j4], DownloadController.DownloadUpdates[(int)(j4 + 1)], DownloadController.DownloadUpdates[(int)(j4 + 5)], DownloadController.DownloadUpdates[(int)(j4 + 6)], (!DownloadController.DownloadUpdates[(int)(j4 + 7)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(j4 + 7)]) : string.Empty));
								}
								if (DownloadController.found)
								{
									AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)j4] + "/" + DownloadController.DownloadUpdates[(int)(j4 + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
								}
								break;
							}
							j4 += 8;
						}
						DataManager.msgBuffer[0] = 4;
						DataManager.msgBuffer[1] = 0;
						DataManager.msgBuffer[4] = ((!DownloadController.found) ? 1 : ((DownloadController.stamper <= 0L) ? 0 : 2));
						GameConstants.GetBytes((ushort)AssetManager.AssetPackages[0, 0][0], DataManager.msgBuffer, 2);
						AssetManager.AssetPackages[0, 0].RemoveAt(0);
						GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
					}
					else
					{
						DownloadController.DownloadUpdates = null;
					}
				}
				else if (AssetManager.AssetPackages[0, 1].Count == 0 && AssetManager.AssetPackages[1, 1].Count == 0)
				{
					if (AssetManager.AssetPackage[0].Count > 0)
					{
						DownloadController.HappyGo = false;
						if (DownloadController.DownloadUpdate[0] == null && DownloadController.DownloadUpdate[1] == null && DownloadController.DownloadUpdate[2] != null)
						{
							ushort j5 = 5;
							while ((int)j5 < DownloadController.DownloadUpdates.Length - 5)
							{
								CString AssetUpdate2 = StringManager.Instance.StaticString1024();
								AssetUpdate2.Append(DownloadController.DownloadUpdates[(int)j5] + "/" + DownloadController.DownloadUpdates[(int)(j5 + 1)]);
								CString AssetBundle2 = StringManager.Instance.StaticString1024();
								AssetBundle2.Append(AssetManager.AssetPackage[0][0].path);
								if (AssetBundle2.Length == AssetUpdate2.Length)
								{
									DownloadController.stamper = 0L;
									while (DownloadController.stamper < (long)AssetBundle2.Length)
									{
										if (AssetUpdate2[(int)DownloadController.stamper] != AssetBundle2[(int)DownloadController.stamper])
										{
											break;
										}
										DownloadController.stamper += 1L;
									}
									if (DownloadController.stamper == (long)AssetBundle2.Length && long.TryParse(DownloadController.DownloadUpdates[(int)(j5 + 2)], out DownloadController.stamper))
									{
										if (DownloadController.stamper > 0L)
										{
											using (FileStream fs10 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.DownloadUpdates[(int)j5], DownloadController.DownloadUpdates[(int)(j5 + 1)]).ToString().ToString(), FileMode.OpenOrCreate))
											{
												using (StreamReader sr10 = new StreamReader(fs10))
												{
													if (long.TryParse(sr10.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
													{
														DownloadController.found = true;
													}
												}
											}
											if (!DownloadController.found)
											{
												yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.DownloadUpdates[(int)j5], DownloadController.DownloadUpdates[(int)(j5 + 1)], DownloadController.DownloadUpdates[(int)(j5 + 2)], DownloadController.DownloadUpdates[(int)(j5 + 3)], (!DownloadController.DownloadUpdates[(int)(j5 + 5)].Equals("0")) ? ("@" + DownloadController.DownloadUpdates[(int)(j5 + 5)]) : string.Empty));
											}
											if (DownloadController.found)
											{
												AssetManager.SetAssetBundle((DownloadController.DownloadUpdates[(int)j5] + "/" + DownloadController.DownloadUpdates[(int)(j5 + 1)]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
											}
										}
										else
										{
											DownloadController.found = true;
											DownloadController.stamper = 1L;
										}
										break;
									}
								}
								j5 += 6;
							}
							if (DownloadController.found)
							{
								if (DownloadController.stamper == 0L)
								{
									DataManager.msgBuffer[0] = AssetManager.AssetPackage[0][0].kind;
									DataManager.msgBuffer[1] = AssetManager.AssetPackage[0][0].type;
									GameConstants.GetBytes((ushort)AssetManager.AssetPackage[0][0].id, DataManager.msgBuffer, 2);
									GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
								}
							}
							else
							{
								AssetManager.AssetPackage[1].Add(AssetManager.AssetPackage[0][0]);
							}
							AssetManager.AssetPackage[0].RemoveAt(0);
						}
						else
						{
							DownloadController.DownloadUpdates = null;
						}
					}
					else if (AssetManager.AssetPackage[1].Count == 0)
					{
						if (DownloadController.Pokedex != null && DownloadController.Pokedex.Count >= 6)
						{
							if (long.TryParse(DownloadController.Pokedex[DownloadController.Pokedex.Count - 4], out DownloadController.stamper))
							{
								using (FileStream fs11 = new FileStream(DownloadController.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, DownloadController.Pokedex[DownloadController.Pokedex.Count - 6], DownloadController.Pokedex[DownloadController.Pokedex.Count - 5]).ToString().ToString(), FileMode.OpenOrCreate))
								{
									using (StreamReader sr11 = new StreamReader(fs11))
									{
										if (long.TryParse(sr11.ReadLine(), out DownloadController.insider) && DownloadController.stamper <= DownloadController.insider)
										{
											DownloadController.found = true;
										}
									}
								}
								if (!DownloadController.found)
								{
									yield return DownloadController.Gamer.StartCoroutine(DownloadController.LoadStreamAssToPersistent(DownloadController.CDNRoot, DownloadController.Pokedex[DownloadController.Pokedex.Count - 6], DownloadController.Pokedex[DownloadController.Pokedex.Count - 5], DownloadController.Pokedex[DownloadController.Pokedex.Count - 4], DownloadController.Pokedex[DownloadController.Pokedex.Count - 3], (!DownloadController.Pokedex[DownloadController.Pokedex.Count - 1].Equals("0")) ? ("@" + DownloadController.Pokedex[DownloadController.Pokedex.Count - 1]) : string.Empty));
								}
								if (DownloadController.found)
								{
									AssetManager.SetAssetBundle((DownloadController.Pokedex[DownloadController.Pokedex.Count - 6] + "/" + DownloadController.Pokedex[DownloadController.Pokedex.Count - 5]).ToUpperInvariant().GetHashCode(), DownloadController.stamper, true);
								}
							}
							DownloadController.Pokedex.RemoveRange(DownloadController.Pokedex.Count - 6, 6);
						}
						else
						{
							DownloadController.check = false;
						}
					}
					else
					{
						DownloadController.found = true;
						DownloadController.HappyGo = false;
					}
				}
				else
				{
					DownloadController.HappyGo = (DownloadController.found = true);
				}
			}
			else
			{
				DownloadController.HappyGo = (DownloadController.found = true);
			}
		}
		if (!DownloadController.check)
		{
			if (DownloadController.Pokedex != null)
			{
				DownloadController.Pokedex.Capacity = DownloadController.Pokedex.Count;
			}
			DownloadController.DownloadUpdates = null;
			DownloadController.bundle = null;
		}
		yield break;
	}

	// Token: 0x06002296 RID: 8854 RVA: 0x004088C4 File Offset: 0x00406AC4
	public static void ReloadAssetBundle(string Name)
	{
		AssetManager.RefreshAssetBundle(Name.ToUpperInvariant().GetHashCode(), false);
		GameManager.OnRefresh(NetworkNews.Refresh_Asset, null);
	}

	// Token: 0x06002297 RID: 8855 RVA: 0x004088E0 File Offset: 0x00406AE0
	public static void Fallback()
	{
		DownloadController.bundle = null;
	}

	// Token: 0x06002298 RID: 8856 RVA: 0x004088E8 File Offset: 0x00406AE8
	public static void Check()
	{
		if (DownloadController.check && !DownloadController.refresh && GameManager.ActiveGameplay != null && !(GameManager.ActiveGameplay is UpdateController))
		{
			DownloadController.Gamer.StartCoroutine(DownloadController.DownloadCheck());
		}
	}

	// Token: 0x04006B80 RID: 27520
	private static SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();

	// Token: 0x04006B81 RID: 27521
	private static StringBuilder Path = new StringBuilder();

	// Token: 0x04006B82 RID: 27522
	private static string OSPath = string.Empty;

	// Token: 0x04006B83 RID: 27523
	private static string Prefix = string.Empty;

	// Token: 0x04006B84 RID: 27524
	private static string CDNRoot;

	// Token: 0x04006B85 RID: 27525
	private static string[] DownloadUpdates;

	// Token: 0x04006B86 RID: 27526
	private static string[] AssetUpdates;

	// Token: 0x04006B87 RID: 27527
	private static WWW bundle;

	// Token: 0x04006B88 RID: 27528
	private static WWW doodle;

	// Token: 0x04006B89 RID: 27529
	private static bool found;

	// Token: 0x04006B8A RID: 27530
	private static bool check;

	// Token: 0x04006B8B RID: 27531
	private static byte queue;

	// Token: 0x04006B8C RID: 27532
	private static float timer;

	// Token: 0x04006B8D RID: 27533
	private static float ticker;

	// Token: 0x04006B8E RID: 27534
	private static long insider;

	// Token: 0x04006B8F RID: 27535
	private static long stamper;

	// Token: 0x04006B90 RID: 27536
	private static long monster;

	// Token: 0x04006B91 RID: 27537
	private static bool refresh;

	// Token: 0x04006B92 RID: 27538
	private static bool HappyGo;

	// Token: 0x04006B93 RID: 27539
	private static uint Extraction;

	// Token: 0x04006B94 RID: 27540
	private static GameManager Gamer;

	// Token: 0x04006B95 RID: 27541
	private static float Buffer;

	// Token: 0x04006B96 RID: 27542
	private static float Terminator;

	// Token: 0x04006B97 RID: 27543
	private static byte[] Properties = new byte[8];

	// Token: 0x04006B98 RID: 27544
	private static string[][] DownloadUpdate = new string[3][];

	// Token: 0x04006B99 RID: 27545
	private static List<AssetDownload> AssDownload = new List<AssetDownload>();

	// Token: 0x04006B9A RID: 27546
	private static List<string> Pokedex;

	// Token: 0x04006B9B RID: 27547
	private static List<int> AssList;

	// Token: 0x04006B9C RID: 27548
	private static AssetDownload AssetDownloads;
}
