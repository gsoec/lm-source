using System;

// Token: 0x0200057D RID: 1405
public class NormalSimpleHint : SimpleHintKind
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x003192D8 File Offset: 0x003174D8
	string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
	{
		return DataManager.Instance.mStringTable.GetStringByID((uint)Parm1);
	}
}
