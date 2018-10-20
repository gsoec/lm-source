.class public Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatDefaultProxy;
.super Ljava/lang/Object;
.source "IGGAdwordsEventReporterCompatDefaultProxy.java"

# interfaces
.implements Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 11
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 14
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
