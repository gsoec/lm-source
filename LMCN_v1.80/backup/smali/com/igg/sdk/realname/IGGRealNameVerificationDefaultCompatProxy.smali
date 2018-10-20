.class public Lcom/igg/sdk/realname/IGGRealNameVerificationDefaultCompatProxy;
.super Ljava/lang/Object;
.source "IGGRealNameVerificationDefaultCompatProxy.java"

# interfaces
.implements Lcom/igg/sdk/realname/IGGRealNameVerificationCompatProxy;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getAccessKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 26
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 21
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getIGGId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 16
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
