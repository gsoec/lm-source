using System;

// Token: 0x02000580 RID: 1408
public class ArmyKindHint : SimpleHintKind
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x00319558 File Offset: 0x00317758
	string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
	{
		Content.ClearString();
		DataManager instance = DataManager.Instance;
		Content.Append("<color=#FFF799FF>");
		Content.Append(instance.mStringTable.GetStringByID((uint)instance.SoldierDataTable.GetRecordByKey((ushort)(Parm1 + 1)).Name));
		Content.Append("</color>");
		Content.Append('\n');
		Content.IntToFormat((long)((Parm1 & 3) + 1), 1, false);
		if (Parm1 < 16)
		{
			Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)(3841 + (Parm1 >> 2))));
		}
		else
		{
			Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)(12079 + (Parm1 - 16 >> 2))));
		}
		Content.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12078u));
		return Content.ToString();
	}
}
