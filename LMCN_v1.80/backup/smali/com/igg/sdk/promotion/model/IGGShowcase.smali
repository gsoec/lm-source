.class public Lcom/igg/sdk/promotion/model/IGGShowcase;
.super Ljava/lang/Object;
.source "IGGShowcase.java"


# instance fields
.field private bannerImageURL:Ljava/lang/String;

.field private content:Ljava/lang/String;

.field private id:I

.field private reward:Lcom/igg/sdk/promotion/model/IGGPromotionReward;

.field private targetApp:Ljava/lang/String;

.field private targetURL:Ljava/lang/String;

.field private title:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getBannerImageURL()Ljava/lang/String;
    .locals 1

    .prologue
    .line 99
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->bannerImageURL:Ljava/lang/String;

    return-object v0
.end method

.method public getContent()Ljava/lang/String;
    .locals 1

    .prologue
    .line 85
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->content:Ljava/lang/String;

    return-object v0
.end method

.method public getId()I
    .locals 1

    .prologue
    .line 57
    iget v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->id:I

    return v0
.end method

.method public getReward()Lcom/igg/sdk/promotion/model/IGGPromotionReward;
    .locals 1

    .prologue
    .line 113
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->reward:Lcom/igg/sdk/promotion/model/IGGPromotionReward;

    return-object v0
.end method

.method public getTargetApp()Ljava/lang/String;
    .locals 1

    .prologue
    .line 127
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->targetApp:Ljava/lang/String;

    return-object v0
.end method

.method public getTargetURL()Ljava/lang/String;
    .locals 1

    .prologue
    .line 141
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->targetURL:Ljava/lang/String;

    return-object v0
.end method

.method public getTitle()Ljava/lang/String;
    .locals 1

    .prologue
    .line 71
    iget-object v0, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->title:Ljava/lang/String;

    return-object v0
.end method

.method public setBannerImageURL(Ljava/lang/String;)V
    .locals 0
    .param p1, "bannerImageURL"    # Ljava/lang/String;

    .prologue
    .line 106
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->bannerImageURL:Ljava/lang/String;

    .line 107
    return-void
.end method

.method public setContent(Ljava/lang/String;)V
    .locals 0
    .param p1, "content"    # Ljava/lang/String;

    .prologue
    .line 92
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->content:Ljava/lang/String;

    .line 93
    return-void
.end method

.method public setId(I)V
    .locals 0
    .param p1, "id"    # I

    .prologue
    .line 64
    iput p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->id:I

    .line 65
    return-void
.end method

.method public setReward(Lcom/igg/sdk/promotion/model/IGGPromotionReward;)V
    .locals 0
    .param p1, "reward"    # Lcom/igg/sdk/promotion/model/IGGPromotionReward;

    .prologue
    .line 120
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->reward:Lcom/igg/sdk/promotion/model/IGGPromotionReward;

    .line 121
    return-void
.end method

.method public setTargetApp(Ljava/lang/String;)V
    .locals 0
    .param p1, "targetApp"    # Ljava/lang/String;

    .prologue
    .line 134
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->targetApp:Ljava/lang/String;

    .line 135
    return-void
.end method

.method public setTargetURL(Ljava/lang/String;)V
    .locals 0
    .param p1, "targetURL"    # Ljava/lang/String;

    .prologue
    .line 148
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->targetURL:Ljava/lang/String;

    .line 149
    return-void
.end method

.method public setTitle(Ljava/lang/String;)V
    .locals 0
    .param p1, "title"    # Ljava/lang/String;

    .prologue
    .line 78
    iput-object p1, p0, Lcom/igg/sdk/promotion/model/IGGShowcase;->title:Ljava/lang/String;

    .line 79
    return-void
.end method
