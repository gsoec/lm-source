using System;

// Token: 0x0200057F RID: 1407
public class CastleSkinHint : SimpleHintKind
{
	// Token: 0x06001BFA RID: 7162 RVA: 0x00319354 File Offset: 0x00317554
	public CastleSkinHint()
	{
		for (int i = 0; i < this.EffectStr.Length; i++)
		{
			this.EffectStr[i] = new CString(128);
		}
	}

	// Token: 0x06001BFB RID: 7163 RVA: 0x003193A0 File Offset: 0x003175A0
	string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
	{
		Content.ClearString();
		CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
		DataManager instance = DataManager.Instance;
		CastleEnhanceTbl castleEnhanceData = castleSkin.GetCastleEnhanceData((byte)Parm1, 0);
		CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey((ushort)((byte)Parm1));
		bool flag = false;
		for (int i = 0; i < 2; i++)
		{
			Effect recordByKey2 = instance.EffectData.GetRecordByKey(recordByKey.Effect[i]);
			if (recordByKey2.ValueID == 4378)
			{
				flag = true;
			}
			this.EffectStr[i].ClearString();
			this.EffectStr[i].StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.String_infoID));
			if (flag)
			{
				this.EffectStr[i].DoubleToFormat((double)castleEnhanceData.Value[i] / 100.0, 2, false);
				this.EffectStr[i].AppendFormat("{0}{1}%");
			}
			else
			{
				this.EffectStr[i].IntToFormat((long)castleEnhanceData.Value[i], 1, false);
				this.EffectStr[i].AppendFormat("{0}{1}");
			}
		}
		if (castleSkin.CheckUnlock((byte)Parm1))
		{
			Content.StringToFormat(instance.mStringTable.GetStringByID(9688u));
		}
		else
		{
			Content.StringToFormat(instance.mStringTable.GetStringByID(9687u));
		}
		Content.StringToFormat(this.EffectStr[0]);
		Content.StringToFormat(this.EffectStr[1]);
		Content.StringToFormat(instance.mStringTable.GetStringByID(9689u));
		Content.AppendFormat("{0}\n{1}\n{2}\n{3}");
		return Content.ToString();
	}

	// Token: 0x040054C8 RID: 21704
	private CString[] EffectStr = new CString[2];
}
