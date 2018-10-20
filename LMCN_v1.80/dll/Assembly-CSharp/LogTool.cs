using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x0200076A RID: 1898
public class LogTool : MonoBehaviour
{
	// Token: 0x060024D8 RID: 9432 RVA: 0x004240DC File Offset: 0x004222DC
	private void Start()
	{
		this.outpath = Application.persistentDataPath + "/outLog.txt";
		if (File.Exists(this.outpath))
		{
			File.Delete(this.outpath);
		}
		Application.RegisterLogCallback(new Application.LogCallback(this.HandleLog));
	}

	// Token: 0x060024D9 RID: 9433 RVA: 0x0042412C File Offset: 0x0042232C
	private void Update()
	{
		if (LogTool.mWriteTxt.Count > 0)
		{
			string[] array = LogTool.mWriteTxt.ToArray();
			foreach (string text in array)
			{
				using (StreamWriter streamWriter = new StreamWriter(this.outpath, true, Encoding.UTF8))
				{
					streamWriter.WriteLine(text);
				}
				LogTool.mWriteTxt.Remove(text);
			}
		}
	}

	// Token: 0x060024DA RID: 9434 RVA: 0x004241C8 File Offset: 0x004223C8
	private void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (type == LogType.Log || LogTool.bIgnore)
		{
			return;
		}
		LogTool.mWriteTxt.Add(logString);
		if (type == LogType.Error || type == LogType.Exception)
		{
			LogTool.mWriteTxt.Add(stackTrace);
			LogTool.Log(new object[]
			{
				logString
			});
			if (logString.Substring(0, 1) != "@")
			{
				LogTool.Log(new object[]
				{
					stackTrace
				});
			}
		}
	}

	// Token: 0x060024DB RID: 9435 RVA: 0x00424240 File Offset: 0x00422440
	public static void Log(params object[] objs)
	{
		string text = string.Empty;
		for (int i = 0; i < objs.Length; i++)
		{
			if (i == 0)
			{
				text += objs[i].ToString();
			}
			else
			{
				text = text + ", " + objs[i].ToString();
			}
		}
		if (Application.isPlaying)
		{
			if (LogTool.mLines.Count > 20)
			{
				LogTool.mLines.RemoveAt(0);
			}
			LogTool.mLines.Add(text);
		}
	}

	// Token: 0x060024DC RID: 9436 RVA: 0x004242C8 File Offset: 0x004224C8
	private void OnGUI()
	{
		GUI.color = Color.red;
		int i = 0;
		int count = LogTool.mLines.Count;
		while (i < count)
		{
			GUILayout.Label(LogTool.mLines[i], new GUILayoutOption[0]);
			i++;
		}
	}

	// Token: 0x060024DD RID: 9437 RVA: 0x00424314 File Offset: 0x00422514
	public static void Clear()
	{
		if (LogTool.mLines != null && LogTool.mLines.Count > 0)
		{
			LogTool.mLines.Clear();
		}
	}

	// Token: 0x04006F36 RID: 28470
	private static List<string> mLines = new List<string>();

	// Token: 0x04006F37 RID: 28471
	private static List<string> mWriteTxt = new List<string>();

	// Token: 0x04006F38 RID: 28472
	public static bool bIgnore;

	// Token: 0x04006F39 RID: 28473
	private string outpath;
}
