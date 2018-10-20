using System;

// Token: 0x0200057E RID: 1406
public class KingdomSimpleHint : SimpleHintKind
{
	// Token: 0x06001BF9 RID: 7161 RVA: 0x003192F4 File Offset: 0x003174F4
	string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
	{
		Content.ClearString();
		TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort)Parm2);
		Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.StringID));
		Content.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint)Parm1));
		return Content.ToString();
	}
}
