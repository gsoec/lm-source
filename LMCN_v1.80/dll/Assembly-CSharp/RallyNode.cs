using System;

// Token: 0x02000250 RID: 592
public struct RallyNode : IEquatable<RallyNode>
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x000DE778 File Offset: 0x000DC978
	public bool Equals(RallyNode other)
	{
		return object.Equals(other, this);
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x000DE790 File Offset: 0x000DC990
	public override bool Equals(object obj)
	{
		if (obj == null || base.GetType() != obj.GetType())
		{
			return false;
		}
		RallyNode rallyNode = (RallyNode)obj;
		return this.BeginTime == rallyNode.BeginTime && this.Point.pointID == rallyNode.Point.pointID && this.Point.zoneID == rallyNode.Point.zoneID;
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x000DE814 File Offset: 0x000DCA14
	public override int GetHashCode()
	{
		return (this.BeginTime + (ulong)this.Point.pointID + (ulong)this.Point.zoneID).GetHashCode();
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x000DE84C File Offset: 0x000DCA4C
	public static bool operator ==(RallyNode c1, RallyNode c2)
	{
		return c1.Equals(c2);
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x000DE858 File Offset: 0x000DCA58
	public static bool operator !=(RallyNode c1, RallyNode c2)
	{
		return !c1.Equals(c2);
	}

	// Token: 0x040023C8 RID: 9160
	public ulong BeginTime;

	// Token: 0x040023C9 RID: 9161
	public PointCode Point;
}
