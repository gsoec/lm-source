using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiniJSON
{
	// Token: 0x02000774 RID: 1908
	public static class Json
	{
		// Token: 0x06002539 RID: 9529 RVA: 0x0042A318 File Offset: 0x00428518
		public static object Deserialize(string json)
		{
			if (json == null)
			{
				return null;
			}
			return Json.Parser.Parse(json);
		}

		// Token: 0x0600253A RID: 9530 RVA: 0x0042A328 File Offset: 0x00428528
		public static string Serialize(object obj)
		{
			return Json.Serializer.Serialize(obj);
		}

		// Token: 0x02000775 RID: 1909
		private sealed class Parser : IDisposable
		{
			// Token: 0x0600253B RID: 9531 RVA: 0x0042A330 File Offset: 0x00428530
			private Parser(string jsonString)
			{
				this.json = new StringReader(jsonString);
			}

			// Token: 0x0600253C RID: 9532 RVA: 0x0042A344 File Offset: 0x00428544
			public static bool IsWordBreak(char c)
			{
				return char.IsWhiteSpace(c) || "{}[],:\"".IndexOf(c) != -1;
			}

			// Token: 0x0600253D RID: 9533 RVA: 0x0042A368 File Offset: 0x00428568
			public static object Parse(string jsonString)
			{
				object result;
				using (Json.Parser parser = new Json.Parser(jsonString))
				{
					result = parser.ParseValue();
				}
				return result;
			}

			// Token: 0x0600253E RID: 9534 RVA: 0x0042A3B8 File Offset: 0x004285B8
			public void Dispose()
			{
				this.json.Dispose();
				this.json = null;
			}

			// Token: 0x0600253F RID: 9535 RVA: 0x0042A3CC File Offset: 0x004285CC
			private Dictionary<string, object> ParseObject()
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				this.json.Read();
				for (;;)
				{
					Json.Parser.TOKEN nextToken = this.NextToken;
					switch (nextToken)
					{
					case Json.Parser.TOKEN.NONE:
						goto IL_37;
					default:
						if (nextToken != Json.Parser.TOKEN.COMMA)
						{
							string text = this.ParseString();
							if (text == null)
							{
								goto Block_2;
							}
							if (this.NextToken != Json.Parser.TOKEN.COLON)
							{
								goto Block_3;
							}
							this.json.Read();
							dictionary[text] = this.ParseValue();
						}
						break;
					case Json.Parser.TOKEN.CURLY_CLOSE:
						return dictionary;
					}
				}
				IL_37:
				return null;
				Block_2:
				return null;
				Block_3:
				return null;
			}

			// Token: 0x06002540 RID: 9536 RVA: 0x0042A458 File Offset: 0x00428658
			private List<object> ParseArray()
			{
				List<object> list = new List<object>();
				this.json.Read();
				bool flag = true;
				while (flag)
				{
					Json.Parser.TOKEN nextToken = this.NextToken;
					Json.Parser.TOKEN token = nextToken;
					switch (token)
					{
					case Json.Parser.TOKEN.SQUARED_CLOSE:
						flag = false;
						break;
					default:
					{
						if (token == Json.Parser.TOKEN.NONE)
						{
							return null;
						}
						object item = this.ParseByToken(nextToken);
						list.Add(item);
						break;
					}
					case Json.Parser.TOKEN.COMMA:
						break;
					}
				}
				return list;
			}

			// Token: 0x06002541 RID: 9537 RVA: 0x0042A4D4 File Offset: 0x004286D4
			private object ParseValue()
			{
				Json.Parser.TOKEN nextToken = this.NextToken;
				return this.ParseByToken(nextToken);
			}

			// Token: 0x06002542 RID: 9538 RVA: 0x0042A4F0 File Offset: 0x004286F0
			private object ParseByToken(Json.Parser.TOKEN token)
			{
				switch (token)
				{
				case Json.Parser.TOKEN.CURLY_OPEN:
					return this.ParseObject();
				case Json.Parser.TOKEN.SQUARED_OPEN:
					return this.ParseArray();
				case Json.Parser.TOKEN.STRING:
					return this.ParseString();
				case Json.Parser.TOKEN.NUMBER:
					return this.ParseNumber();
				case Json.Parser.TOKEN.TRUE:
					return true;
				case Json.Parser.TOKEN.FALSE:
					return false;
				case Json.Parser.TOKEN.NULL:
					return null;
				}
				return null;
			}

			// Token: 0x06002543 RID: 9539 RVA: 0x0042A568 File Offset: 0x00428768
			private string ParseString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				this.json.Read();
				bool flag = true;
				while (flag)
				{
					if (this.json.Peek() == -1)
					{
						break;
					}
					char nextChar = this.NextChar;
					char c = nextChar;
					if (c != '"')
					{
						if (c != '\\')
						{
							stringBuilder.Append(nextChar);
						}
						else if (this.json.Peek() == -1)
						{
							flag = false;
						}
						else
						{
							nextChar = this.NextChar;
							char c2 = nextChar;
							switch (c2)
							{
							case 'n':
								stringBuilder.Append('\n');
								break;
							default:
								if (c2 != '"' && c2 != '/' && c2 != '\\')
								{
									if (c2 != 'b')
									{
										if (c2 == 'f')
										{
											stringBuilder.Append('\f');
										}
									}
									else
									{
										stringBuilder.Append('\b');
									}
								}
								else
								{
									stringBuilder.Append(nextChar);
								}
								break;
							case 'r':
								stringBuilder.Append('\r');
								break;
							case 't':
								stringBuilder.Append('\t');
								break;
							case 'u':
							{
								char[] array = new char[4];
								for (int i = 0; i < 4; i++)
								{
									array[i] = this.NextChar;
								}
								stringBuilder.Append((char)Convert.ToInt32(new string(array), 16));
								break;
							}
							}
						}
					}
					else
					{
						flag = false;
					}
				}
				return stringBuilder.ToString();
			}

			// Token: 0x06002544 RID: 9540 RVA: 0x0042A700 File Offset: 0x00428900
			private object ParseNumber()
			{
				string nextWord = this.NextWord;
				if (nextWord.IndexOf('.') == -1)
				{
					long num;
					long.TryParse(nextWord, out num);
					return num;
				}
				double num2;
				double.TryParse(nextWord, out num2);
				return num2;
			}

			// Token: 0x06002545 RID: 9541 RVA: 0x0042A744 File Offset: 0x00428944
			private void EatWhitespace()
			{
				while (char.IsWhiteSpace(this.PeekChar))
				{
					this.json.Read();
					if (this.json.Peek() == -1)
					{
						break;
					}
				}
			}

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x06002546 RID: 9542 RVA: 0x0042A780 File Offset: 0x00428980
			private char PeekChar
			{
				get
				{
					return Convert.ToChar(this.json.Peek());
				}
			}

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x06002547 RID: 9543 RVA: 0x0042A794 File Offset: 0x00428994
			private char NextChar
			{
				get
				{
					return Convert.ToChar(this.json.Read());
				}
			}

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x06002548 RID: 9544 RVA: 0x0042A7A8 File Offset: 0x004289A8
			private string NextWord
			{
				get
				{
					StringBuilder stringBuilder = new StringBuilder();
					while (!Json.Parser.IsWordBreak(this.PeekChar))
					{
						stringBuilder.Append(this.NextChar);
						if (this.json.Peek() == -1)
						{
							break;
						}
					}
					return stringBuilder.ToString();
				}
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x06002549 RID: 9545 RVA: 0x0042A7FC File Offset: 0x004289FC
			private Json.Parser.TOKEN NextToken
			{
				get
				{
					this.EatWhitespace();
					if (this.json.Peek() == -1)
					{
						return Json.Parser.TOKEN.NONE;
					}
					char peekChar = this.PeekChar;
					switch (peekChar)
					{
					case '"':
						return Json.Parser.TOKEN.STRING;
					default:
						switch (peekChar)
						{
						case '[':
							return Json.Parser.TOKEN.SQUARED_OPEN;
						default:
						{
							switch (peekChar)
							{
							case '{':
								return Json.Parser.TOKEN.CURLY_OPEN;
							case '}':
								this.json.Read();
								return Json.Parser.TOKEN.CURLY_CLOSE;
							}
							string nextWord = this.NextWord;
							switch (nextWord)
							{
							case "false":
								return Json.Parser.TOKEN.FALSE;
							case "true":
								return Json.Parser.TOKEN.TRUE;
							case "null":
								return Json.Parser.TOKEN.NULL;
							}
							return Json.Parser.TOKEN.NONE;
						}
						case ']':
							this.json.Read();
							return Json.Parser.TOKEN.SQUARED_CLOSE;
						}
						break;
					case ',':
						this.json.Read();
						return Json.Parser.TOKEN.COMMA;
					case '-':
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						return Json.Parser.TOKEN.NUMBER;
					case ':':
						return Json.Parser.TOKEN.COLON;
					}
				}
			}

			// Token: 0x04006FCA RID: 28618
			private const string WORD_BREAK = "{}[],:\"";

			// Token: 0x04006FCB RID: 28619
			private StringReader json;

			// Token: 0x02000776 RID: 1910
			private enum TOKEN
			{
				// Token: 0x04006FCE RID: 28622
				NONE,
				// Token: 0x04006FCF RID: 28623
				CURLY_OPEN,
				// Token: 0x04006FD0 RID: 28624
				CURLY_CLOSE,
				// Token: 0x04006FD1 RID: 28625
				SQUARED_OPEN,
				// Token: 0x04006FD2 RID: 28626
				SQUARED_CLOSE,
				// Token: 0x04006FD3 RID: 28627
				COLON,
				// Token: 0x04006FD4 RID: 28628
				COMMA,
				// Token: 0x04006FD5 RID: 28629
				STRING,
				// Token: 0x04006FD6 RID: 28630
				NUMBER,
				// Token: 0x04006FD7 RID: 28631
				TRUE,
				// Token: 0x04006FD8 RID: 28632
				FALSE,
				// Token: 0x04006FD9 RID: 28633
				NULL
			}
		}

		// Token: 0x02000777 RID: 1911
		private sealed class Serializer
		{
			// Token: 0x0600254A RID: 9546 RVA: 0x0042A974 File Offset: 0x00428B74
			private Serializer()
			{
				this.builder = new StringBuilder();
			}

			// Token: 0x0600254B RID: 9547 RVA: 0x0042A988 File Offset: 0x00428B88
			public static string Serialize(object obj)
			{
				Json.Serializer serializer = new Json.Serializer();
				serializer.SerializeValue(obj);
				return serializer.builder.ToString();
			}

			// Token: 0x0600254C RID: 9548 RVA: 0x0042A9B0 File Offset: 0x00428BB0
			private void SerializeValue(object value)
			{
				string str;
				IList anArray;
				IDictionary obj;
				if (value == null)
				{
					this.builder.Append("null");
				}
				else if ((str = (value as string)) != null)
				{
					this.SerializeString(str);
				}
				else if (value is bool)
				{
					this.builder.Append((!(bool)value) ? "false" : "true");
				}
				else if ((anArray = (value as IList)) != null)
				{
					this.SerializeArray(anArray);
				}
				else if ((obj = (value as IDictionary)) != null)
				{
					this.SerializeObject(obj);
				}
				else if (value is char)
				{
					this.SerializeString(new string((char)value, 1));
				}
				else
				{
					this.SerializeOther(value);
				}
			}

			// Token: 0x0600254D RID: 9549 RVA: 0x0042AA84 File Offset: 0x00428C84
			private void SerializeObject(IDictionary obj)
			{
				bool flag = true;
				this.builder.Append('{');
				foreach (object obj2 in obj.Keys)
				{
					if (!flag)
					{
						this.builder.Append(',');
					}
					this.SerializeString(obj2.ToString());
					this.builder.Append(':');
					this.SerializeValue(obj[obj2]);
					flag = false;
				}
				this.builder.Append('}');
			}

			// Token: 0x0600254E RID: 9550 RVA: 0x0042AB44 File Offset: 0x00428D44
			private void SerializeArray(IList anArray)
			{
				this.builder.Append('[');
				bool flag = true;
				foreach (object value in anArray)
				{
					if (!flag)
					{
						this.builder.Append(',');
					}
					this.SerializeValue(value);
					flag = false;
				}
				this.builder.Append(']');
			}

			// Token: 0x0600254F RID: 9551 RVA: 0x0042ABE0 File Offset: 0x00428DE0
			private void SerializeString(string str)
			{
				this.builder.Append('"');
				char[] array = str.ToCharArray();
				foreach (char c in array)
				{
					char c2 = c;
					switch (c2)
					{
					case '\b':
						this.builder.Append("\\b");
						break;
					case '\t':
						this.builder.Append("\\t");
						break;
					case '\n':
						this.builder.Append("\\n");
						break;
					default:
						if (c2 != '"')
						{
							if (c2 != '\\')
							{
								int num = Convert.ToInt32(c);
								if (num >= 32 && num <= 126)
								{
									this.builder.Append(c);
								}
								else
								{
									this.builder.Append("\\u");
									this.builder.Append(num.ToString("x4"));
								}
							}
							else
							{
								this.builder.Append("\\\\");
							}
						}
						else
						{
							this.builder.Append("\\\"");
						}
						break;
					case '\f':
						this.builder.Append("\\f");
						break;
					case '\r':
						this.builder.Append("\\r");
						break;
					}
				}
				this.builder.Append('"');
			}

			// Token: 0x06002550 RID: 9552 RVA: 0x0042AD5C File Offset: 0x00428F5C
			private void SerializeOther(object value)
			{
				if (value is float)
				{
					this.builder.Append(((float)value).ToString("R"));
				}
				else if (value is int || value is uint || value is long || value is sbyte || value is byte || value is short || value is ushort || value is ulong)
				{
					this.builder.Append(value);
				}
				else if (value is double || value is decimal)
				{
					this.builder.Append(Convert.ToDouble(value).ToString("R"));
				}
				else
				{
					this.SerializeString(value.ToString());
				}
			}

			// Token: 0x04006FDA RID: 28634
			private StringBuilder builder;
		}
	}
}
