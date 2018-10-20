using System;

// Token: 0x02000254 RID: 596
public struct SoccerGoalCache
{
	// Token: 0x06000A59 RID: 2649 RVA: 0x000DEA44 File Offset: 0x000DCC44
	public SoccerGoalCache(bool b)
	{
		this.goal1 = null;
		this.goal2 = null;
		this.goal3 = null;
		this.goal4 = null;
		this.goal5 = null;
		this.goal6 = null;
		this.goal7 = null;
		this.goal8 = null;
		this.goal9 = null;
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x000DEAE0 File Offset: 0x000DCCE0
	public void SetValue(int idx, int val)
	{
		switch (idx)
		{
		case 0:
			this.goal1 = new int?(val);
			break;
		case 1:
			this.goal2 = new int?(val);
			break;
		case 2:
			this.goal3 = new int?(val);
			break;
		case 3:
			this.goal4 = new int?(val);
			break;
		case 4:
			this.goal5 = new int?(val);
			break;
		case 5:
			this.goal6 = new int?(val);
			break;
		case 6:
			this.goal7 = new int?(val);
			break;
		case 7:
			this.goal8 = new int?(val);
			break;
		case 8:
			this.goal9 = new int?(val);
			break;
		}
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x000DEBB8 File Offset: 0x000DCDB8
	public bool HasValue()
	{
		int? num = this.goal1;
		if (num == null)
		{
			int? num2 = this.goal2;
			if (num2 == null)
			{
				int? num3 = this.goal3;
				if (num3 == null)
				{
					int? num4 = this.goal4;
					if (num4 == null)
					{
						int? num5 = this.goal5;
						if (num5 == null)
						{
							int? num6 = this.goal6;
							if (num6 == null)
							{
								int? num7 = this.goal7;
								if (num7 == null)
								{
									int? num8 = this.goal8;
									if (num8 == null)
									{
										int? num9 = this.goal9;
										return num9 != null;
									}
								}
							}
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x040023D7 RID: 9175
	public int? goal1;

	// Token: 0x040023D8 RID: 9176
	public int? goal2;

	// Token: 0x040023D9 RID: 9177
	public int? goal3;

	// Token: 0x040023DA RID: 9178
	public int? goal4;

	// Token: 0x040023DB RID: 9179
	public int? goal5;

	// Token: 0x040023DC RID: 9180
	public int? goal6;

	// Token: 0x040023DD RID: 9181
	public int? goal7;

	// Token: 0x040023DE RID: 9182
	public int? goal8;

	// Token: 0x040023DF RID: 9183
	public int? goal9;
}
