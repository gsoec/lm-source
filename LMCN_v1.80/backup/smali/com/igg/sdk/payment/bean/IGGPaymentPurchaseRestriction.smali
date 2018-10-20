.class public Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;
.super Ljava/lang/Object;
.source "IGGPaymentPurchaseRestriction.java"

# interfaces
.implements Ljava/io/Serializable;


# instance fields
.field private antiAddictionEnable:Z

.field private antiAddictionPeriodCostQuota:F


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getAntiAddictionPeriodCostQuota()F
    .locals 1

    .prologue
    .line 25
    iget v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->antiAddictionPeriodCostQuota:F

    return v0
.end method

.method public isAntiAddictionEnable()Z
    .locals 1

    .prologue
    .line 17
    iget-boolean v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->antiAddictionEnable:Z

    return v0
.end method

.method public setAntiAddictionEnable(Z)V
    .locals 0
    .param p1, "antiAddictionEnable"    # Z

    .prologue
    .line 21
    iput-boolean p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->antiAddictionEnable:Z

    .line 22
    return-void
.end method

.method public setAntiAddictionPeriodCostQuota(F)V
    .locals 0
    .param p1, "antiAddictionPeriodCostQuota"    # F

    .prologue
    .line 29
    iput p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;->antiAddictionPeriodCostQuota:F

    .line 30
    return-void
.end method
