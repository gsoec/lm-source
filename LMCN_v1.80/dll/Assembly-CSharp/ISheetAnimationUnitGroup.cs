using System;

// Token: 0x02000256 RID: 598
public class ISheetAnimationUnitGroup
{
	// Token: 0x06000A94 RID: 2708 RVA: 0x000E43E0 File Offset: 0x000E25E0
	public virtual int Update(float deltaTime)
	{
		return 0;
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x000E43E4 File Offset: 0x000E25E4
	public virtual void RecoverUnit()
	{
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x000E43E8 File Offset: 0x000E25E8
	public virtual void setupAnimUnit(byte Side, byte lineFlag, float angle, byte setupFlag = 0)
	{
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x000E43EC File Offset: 0x000E25EC
	public virtual bool HasSpecialSimu()
	{
		return false;
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x000E43F0 File Offset: 0x000E25F0
	public virtual void RunSpecialSimuMode(LineNode node)
	{
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x000E43F4 File Offset: 0x000E25F4
	public virtual void SampleAnimation(int UnitIndex, float AnimTime)
	{
	}
}
