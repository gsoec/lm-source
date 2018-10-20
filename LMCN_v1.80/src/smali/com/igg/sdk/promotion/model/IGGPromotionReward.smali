.class public Lcom/igg/sdk/promotion/model/IGGPromotionReward;
.super Ljava/lang/Object;
.source "IGGPromotionReward.java"


# instance fields
.field private pointsAwarded:I

.field private rewardName:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getFormattedPointsAwarded()Ljava/lang/String;
    .locals 4

    .prologue
    .line 31
    invoke-static {}, Ljava/text/NumberFormat;->getNumberInstance()Ljava/text/NumberFormat;

    move-result-object v0

    iget v1, p0, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->pointsAwarded:I

    int-to-long v2, v1

    invoke-virtual {v0, v2, v3}, Ljava/text/NumberFormat;->format(J)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getPointsAwarded()I
    .locals 1

    .prologue
    .line 47
    iget v0, p0, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->pointsAwarded:I

    return v0
.end method

.method public getRewardDisplay()Ljava/lang/String;
    .locals 4

    .prologue
    .line 40
    const-string v0, "%s %s"

    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    invoke-virtual {p0}, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->getFormattedPointsAwarded()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v2

    const/4 v2, 0x1

    invoke-virtual {p0}, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->getRewardName()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getRewardName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 61
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->rewardName:Ljava/lang/String;

    return-object v0
.end method

.method public setPointsAwarded(I)V
    .locals 0
    .param p1, "pointsAwarded"    # I

    .prologue
    .line 54
    iput p1, p0, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->pointsAwarded:I

    .line 55
    return-void
.end method

.method public setRewardName(Ljava/lang/String;)V
    .locals 0
    .param p1, "rewardName"    # Ljava/lang/String;

    .prologue
    .line 68
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->rewardName:Ljava/lang/String;

    .line 69
    return-void
.end method
