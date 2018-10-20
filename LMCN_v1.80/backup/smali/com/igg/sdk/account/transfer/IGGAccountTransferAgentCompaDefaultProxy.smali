.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferAgentCompaDefaultProxy;
.super Ljava/lang/Object;
.source "IGGAccountTransferAgentCompaDefaultProxy.java"

# interfaces
.implements Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getAccessKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 17
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getIGGId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 12
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
