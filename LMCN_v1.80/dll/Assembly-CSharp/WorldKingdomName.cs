using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000287 RID: 647
public class WorldKingdomName
{
	// Token: 0x06000C7C RID: 3196 RVA: 0x00123400 File Offset: 0x00121600
	public WorldKingdomName(Transform parentLayout, Vector2 inipos, Vector2 testsize)
	{
		GameObject gameObject = new GameObject("name");
		this.NameRectTransform = gameObject.AddComponent<RectTransform>();
		Vector3 one = Vector3.one;
		if (GUIManager.Instance.IsArabic)
		{
			one.x = -1f;
		}
		this.NameRectTransform.localScale = one;
		this.NameRectTransform.SetParent(parentLayout, false);
		this.NameRectTransform.localPosition = inipos;
		this.NameGameObject = gameObject;
		gameObject = new GameObject("nameText");
		this.NameText = gameObject.AddComponent<WorldMapText>();
		gameObject.AddComponent<Outline>();
		this.NameText.font = GUIManager.Instance.GetTTFFont();
		this.NameText.fontSize = 30;
		this.NameText.alignment = TextAnchor.MiddleLeft;
		this.NameText.resizeTextForBestFit = true;
		this.NameText.resizeTextMaxSize = 30;
		this.TitleString = new CString(148);
		this.textrtf = (gameObject.transform as RectTransform);
		this.textrtf.sizeDelta = testsize;
		this.textrtf.anchoredPosition = new Vector2(128f, -20f);
		this.textrtf.SetParent(this.NameRectTransform, false);
		gameObject = new GameObject("TextInfo");
		this.text_Info = gameObject.AddComponent<UIText>();
		gameObject.AddComponent<Outline>();
		this.text_Info.font = GUIManager.Instance.GetTTFFont();
		this.text_Info.fontSize = 24;
		this.text_Info.alignment = TextAnchor.UpperLeft;
		this.text_Info.resizeTextForBestFit = true;
		this.text_Info.resizeTextMaxSize = 24;
		this.text_Info.color = new Color(1f, 0.984f, 0.576f);
		this.InfoString = new CString(264);
		this.textrtf_Info = (gameObject.transform as RectTransform);
		this.textrtf_Info.anchorMax = new Vector2(0f, 1f);
		this.textrtf_Info.anchorMin = new Vector2(0f, 1f);
		this.textrtf_Info.pivot = new Vector2(0f, 1f);
		this.textrtf_Info.sizeDelta = testsize;
		this.textrtf_Info.anchoredPosition = new Vector2(-78f, -95f);
		this.textrtf_Info.SetParent(this.NameRectTransform, false);
		this.NameGameObject.SetActive(false);
		this.NamePosImage = null;
		this.WorldKingdomTableID = 0;
		this.WorldKingdomTime = 0L;
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x00123688 File Offset: 0x00121888
	public void Release()
	{
		this.NameGameObject = null;
		this.NameRectTransform = null;
		this.NameText = null;
		this.text_Info = null;
		this.TitleString = null;
		this.InfoString = null;
	}

	// Token: 0x06000C7E RID: 3198 RVA: 0x001236C0 File Offset: 0x001218C0
	public void updateName(byte SetKingdomTableID, Image NamePos, Color textcolor, Vector2 pos)
	{
		this.updateName(SetKingdomTableID, NamePos, textcolor);
		this.updateName(pos);
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x001236D4 File Offset: 0x001218D4
	public void updateName(byte SetKingdomTableID, Image NamePos, Color textcolor)
	{
		this.updateName(textcolor);
		this.updateName(SetKingdomTableID, NamePos);
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x001236E8 File Offset: 0x001218E8
	public void updateName(byte SetKingdomTableID, Image NamePos)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		if (NamePos == null)
		{
			if (this.NamePosImage != null)
			{
				this.NamePosImage.gameObject.SetActive(false);
				this.NamePosImage.transform.SetParent(this.NameRectTransform.parent, false);
			}
		}
		else if (this.NamePosImage == null)
		{
			NamePos.transform.SetParent(this.NameRectTransform, false);
		}
		this.NamePosImage = NamePos;
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomID);
		int num = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX + 1);
		int num2 = (int)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX) + (int)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY) * num;
		this.WorldKingdomTableID = (ushort)num2;
		this.TitleString.ClearString();
		if (this.NamePosImage != null)
		{
			this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8246u));
			this.textrtf.sizeDelta = new Vector2(512f, 215f);
			this.textrtf.anchoredPosition = new Vector2(128f, 0f);
		}
		else
		{
			this.textrtf.sizeDelta = new Vector2(512f, 178f);
			this.textrtf.anchoredPosition = new Vector2(128f, -20f);
		}
		if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomName);
			if (this.NamePosImage == null)
			{
				this.TitleString.AppendFormat("{0}");
			}
			else
			{
				this.TitleString.AppendFormat("        {0}\n{1}");
			}
		}
		else
		{
			this.TitleString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomID, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8247u));
				this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomName);
			}
			else
			{
				this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomName);
				this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8247u));
			}
			if (this.NamePosImage == null)
			{
				this.TitleString.AppendFormat("#{0} {1} {2}");
			}
			else
			{
				this.TitleString.AppendFormat("        {0}\n#{1} {2} {3}");
			}
		}
		this.NameText.text = this.TitleString.ToString();
		this.NameText.SetAllDirty();
		this.NameText.cachedTextGenerator.Invalidate();
		this.InfoString.ClearString();
		if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11038u));
			if (ActivityManager.Instance.IsKOWRunning(false) || DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName == null || DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName[0] == '\0')
			{
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334u));
				this.InfoString.AppendFormat("{0}{1}");
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID == 0)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					this.InfoString.AppendFormat("{0}{1}");
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					this.InfoString.AppendFormat("{0}{1}");
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.AppendFormat("{0}{1}[{2}]");
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					this.InfoString.AppendFormat("{0}[{1}]{2}");
				}
			}
			else if (GUIManager.Instance.IsArabic)
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
				this.InfoString.AppendFormat("{0}#{1} {2} [{3}]");
			}
			else
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
				this.InfoString.AppendFormat("{0}#{1} [{2}]{3}");
			}
		}
		else
		{
			byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag >> 3);
			if (b > 0)
			{
				TitleData recordByKey2 = DataManager.Instance.TitleDataN.GetRecordByKey((ushort)b);
				this.InfoString.StringToFormat("<color=#FFFF00>");
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.StringID));
				this.InfoString.StringToFormat("</color>");
			}
			this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(676u));
			if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag == null || DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag[0] == '\0')
			{
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334u));
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334u));
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}\n{5}{6}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}{1}\n{2}{3}");
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID == DataManager.Instance.RoleAlliance.KingdomID && DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}{7}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}{4}");
					}
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}{7}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}{4}");
					}
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID == DataManager.Instance.RoleAlliance.KingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}#{7} {8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}#{4} {5}");
					}
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}#{7} {8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}#{4} {5}");
					}
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID, 1, false);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{6} {4}[{5}]\n{7}{8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}#{3} {1}[{2}]\n{4}{5}");
					}
				}
				else
				{
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}{8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}{5}");
					}
				}
			}
			else if (GUIManager.Instance.IsArabic)
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
				if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
				}
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} {5}[{6}]\n{7}#{8} {9}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}#{1} {2}[{3}]\n{4}#{5} {6}");
				}
			}
			else
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceTag);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].allianceName);
				if ((DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomFlag & 1) == 0)
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
				}
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingName);
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}#{8} {9}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}#{5} {6}");
				}
			}
			long num3 = this.WorldKingdomTime = (long)(DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomTime + 7776000UL - (ulong)DataManager.Instance.ServerTime);
			if (num3 > 0L)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				CString cstring2 = StringManager.Instance.StaticString1024();
				CString cstring3 = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				if (num3 > 86400L)
				{
					cstring3.IntToFormat(num3 / 86400L, 1, false);
					cstring3.AppendFormat("{0}d");
				}
				else if (num3 / 3600L > 0L)
				{
					cstring3.IntToFormat(num3 / 3600L, 1, false);
					num3 %= 3600L;
					cstring3.IntToFormat(num3 / 60L, 2, false);
					num3 %= 60L;
					cstring3.IntToFormat(num3, 2, false);
					cstring3.AppendFormat("{0}:{1}:{2}");
				}
				else
				{
					cstring3.IntToFormat(num3 / 60L, 2, false);
					num3 %= 60L;
					cstring3.IntToFormat(num3, 2, false);
					cstring3.AppendFormat("{0}:{1}");
				}
				cstring2.StringToFormat(cstring3);
				cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(948u));
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat("\n<color=#B8D9F3>{0}");
				if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomTime > DataManager.MapDataController.kingdomData.kingdomTime && !DataManager.Instance.IsNewbie())
				{
					cstring.Append("\n");
					cstring.Append(DataManager.Instance.mStringTable.GetStringByID(947u));
				}
				cstring.Append("</color>");
				this.InfoString.Append(cstring);
			}
		}
		this.text_Info.text = this.InfoString.ToString();
		this.text_Info.SetAllDirty();
		this.text_Info.cachedTextGenerator.Invalidate();
		this.text_Info.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Info.preferredHeight > this.text_Info.rectTransform.sizeDelta.y)
		{
			this.text_Info.rectTransform.sizeDelta = new Vector2(this.text_Info.rectTransform.sizeDelta.x, this.text_Info.preferredHeight + 1f);
		}
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x00124B58 File Offset: 0x00122D58
	public void updateName(Color textcolor)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		this.NameText.color = textcolor;
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x00124B90 File Offset: 0x00122D90
	public void updateName(Vector2 pos)
	{
		if (!this.NameGameObject.activeSelf)
		{
			return;
		}
		this.NameRectTransform.anchoredPosition = pos;
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x00124BB0 File Offset: 0x00122DB0
	public void updateNamePos(Vector2 pos)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		Vector2 vector = pos - this.NameRectTransform.anchoredPosition;
		if (Mathf.Abs(vector.x) > 8f || Mathf.Abs(vector.y) > 8f)
		{
			this.NameRectTransform.anchoredPosition = pos;
		}
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x00124C28 File Offset: 0x00122E28
	public void SetActive(bool active)
	{
		this.NameGameObject.SetActive(active);
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x00124C38 File Offset: 0x00122E38
	public void SetNameText(int row, int col)
	{
		this.NameText.row = row;
		this.NameText.col = col;
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x00124C54 File Offset: 0x00122E54
	public void NameTextRebuilt()
	{
		if (this.NameGameObject.activeSelf)
		{
			if (this.NameText != null && this.NameText.enabled)
			{
				this.NameText.enabled = false;
				this.NameText.enabled = true;
			}
			if (this.text_Info != null && this.text_Info.enabled)
			{
				this.text_Info.enabled = false;
				this.text_Info.enabled = true;
			}
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x00124CE4 File Offset: 0x00122EE4
	public void SetTimeText()
	{
		byte tableID = DataManager.MapDataController.TileMapKingdomID[(int)this.WorldKingdomTableID].tableID;
		if ((int)tableID >= DataManager.MapDataController.WorldKingdomTable.Length || DataManager.MapDataController.TileMapKingdomID[(int)this.WorldKingdomTableID].KingdomID != DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomID || DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			return;
		}
		long num = (long)(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomTime + 7776000UL - (ulong)DataManager.Instance.ServerTime);
		if (num > 0L)
		{
			if (num == this.WorldKingdomTime)
			{
				return;
			}
			CString cstring;
			CString cstring2;
			CString cstring3;
			if (num > 86400L)
			{
				long num2 = num / 86400L;
				if (this.WorldKingdomTime / 86400L == num2)
				{
					return;
				}
				this.WorldKingdomTime = num;
				cstring = StringManager.Instance.StaticString1024();
				cstring2 = StringManager.Instance.StaticString1024();
				cstring3 = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				cstring3.IntToFormat(num2, 1, false);
				cstring3.AppendFormat("{0}d");
			}
			else
			{
				this.WorldKingdomTime = num;
				cstring = StringManager.Instance.StaticString1024();
				cstring2 = StringManager.Instance.StaticString1024();
				cstring3 = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				if (num / 3600L > 0L)
				{
					cstring3.IntToFormat(num / 3600L, 1, false);
					num %= 3600L;
					cstring3.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					cstring3.IntToFormat(num, 2, false);
					cstring3.AppendFormat("{0}:{1}:{2}");
				}
				else
				{
					cstring3.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					cstring3.IntToFormat(num, 2, false);
					cstring3.AppendFormat("{0}:{1}");
				}
			}
			this.InfoString.ClearString();
			byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag >> 3);
			if (b > 0)
			{
				TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort)b);
				this.InfoString.StringToFormat("<color=#FFFF00>");
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.StringID));
				this.InfoString.StringToFormat("</color>");
			}
			this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(676u));
			if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag == null || DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag[0] == '\0')
			{
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334u));
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334u));
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}\n{5}{6}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}{1}\n{2}{3}");
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID == DataManager.Instance.RoleAlliance.KingdomID && DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}{7}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}{4}");
					}
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}{7}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}{4}");
					}
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID == DataManager.Instance.RoleAlliance.KingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}#{7} {8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}#{4} {5}");
					}
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}#{7} {8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}#{4} {5}");
					}
				}
			}
			else if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID, 1, false);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{6} {4}[{5}]\n{7}{8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}#{3} {1}[{2}]\n{4}{5}");
					}
				}
				else
				{
					this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID, 1, false);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
					if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
					}
					else
					{
						this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
					}
					this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
					if (b > 0)
					{
						this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}{8}");
					}
					else
					{
						this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}{5}");
					}
				}
			}
			else if (GUIManager.Instance.IsArabic)
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
				if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
				}
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} {5}[{6}]\n{7}#{8} {9}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}#{1} {2}[{3}]\n{4}#{5} {6}");
				}
			}
			else
			{
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceTag);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].allianceName);
				if ((DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 1) == 0)
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677u));
				}
				else
				{
					this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372u));
				}
				this.InfoString.IntToFormat((long)DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingKingdomID, 1, false);
				this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingName);
				if (b > 0)
				{
					this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}#{8} {9}");
				}
				else
				{
					this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}#{5} {6}");
				}
			}
			cstring2.StringToFormat(cstring3);
			cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(948u));
			cstring.StringToFormat(cstring2);
			cstring.AppendFormat("\n<color=#B8D9F3>{0}");
			if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomTime > DataManager.MapDataController.kingdomData.kingdomTime && !DataManager.Instance.IsNewbie())
			{
				cstring.Append("\n");
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(947u));
			}
			cstring.Append("</color>");
			this.InfoString.Append(cstring);
			this.text_Info.text = this.InfoString.ToString();
			this.text_Info.SetAllDirty();
			this.text_Info.cachedTextGenerator.Invalidate();
			this.text_Info.cachedTextGeneratorForLayout.Invalidate();
			if (this.text_Info.preferredHeight > this.text_Info.rectTransform.sizeDelta.y)
			{
				this.text_Info.rectTransform.sizeDelta = new Vector2(this.text_Info.rectTransform.sizeDelta.x, this.text_Info.preferredHeight + 1f);
			}
		}
	}

	// Token: 0x040028D1 RID: 10449
	private GameObject NameGameObject;

	// Token: 0x040028D2 RID: 10450
	private RectTransform NameRectTransform;

	// Token: 0x040028D3 RID: 10451
	private WorldMapText NameText;

	// Token: 0x040028D4 RID: 10452
	private UIText text_Info;

	// Token: 0x040028D5 RID: 10453
	private CString TitleString;

	// Token: 0x040028D6 RID: 10454
	private CString InfoString;

	// Token: 0x040028D7 RID: 10455
	private Image NamePosImage;

	// Token: 0x040028D8 RID: 10456
	private RectTransform textrtf;

	// Token: 0x040028D9 RID: 10457
	private RectTransform textrtf_Info;

	// Token: 0x040028DA RID: 10458
	private ushort WorldKingdomTableID;

	// Token: 0x040028DB RID: 10459
	private long WorldKingdomTime;
}
