using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000253 RID: 595
public class LineContainer
{
	// Token: 0x06000A55 RID: 2645 RVA: 0x000DE8D0 File Offset: 0x000DCAD0
	public LineContainer()
	{
		this.m_List.Clear();
		Dictionary<int, LineNode> item = new Dictionary<int, LineNode>(512);
		this.m_List.Add(item);
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x000DE910 File Offset: 0x000DCB10
	public void Insert(int key, LineNode line)
	{
		for (int i = 0; i < this.m_List.Count; i++)
		{
			if (this.m_List[i].Count != 512)
			{
				this.m_List[i][key] = line;
				return;
			}
		}
		Dictionary<int, LineNode> dictionary = new Dictionary<int, LineNode>(512);
		dictionary[key] = line;
		this.m_List.Add(dictionary);
		Debug.Log("New Line Container : " + this.m_List.Count.ToString());
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x000DE9AC File Offset: 0x000DCBAC
	public bool TryGetValue(int key, out LineNode line)
	{
		line = null;
		LineNode lineNode = null;
		for (int i = 0; i < this.m_List.Count; i++)
		{
			if (this.m_List[i].TryGetValue(key, out lineNode))
			{
				line = lineNode;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x000DE9FC File Offset: 0x000DCBFC
	public void Clear()
	{
		for (int i = 0; i < this.m_List.Count; i++)
		{
			this.m_List[i].Clear();
		}
		this.m_List.Clear();
	}

	// Token: 0x040023D5 RID: 9173
	private const int MAX_LINESIZE = 512;

	// Token: 0x040023D6 RID: 9174
	private List<Dictionary<int, LineNode>> m_List = new List<Dictionary<int, LineNode>>();
}
