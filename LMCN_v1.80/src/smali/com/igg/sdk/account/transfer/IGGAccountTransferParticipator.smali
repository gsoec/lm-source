.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;
.super Ljava/lang/Object;
.source "IGGAccountTransferParticipator.java"


# instance fields
.field private accessKey:Ljava/lang/String;

.field private compatProxy:Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;

.field private iggId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 13
    new-instance v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgentCompaDefaultProxy;

    invoke-direct {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgentCompaDefaultProxy;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->compatProxy:Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;

    .line 14
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->compatProxy:Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;

    invoke-interface {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;->getIGGId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->iggId:Ljava/lang/String;

    .line 15
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->compatProxy:Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;

    invoke-interface {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferCompatProxy;->getAccessKey()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->accessKey:Ljava/lang/String;

    .line 16
    return-void
.end method


# virtual methods
.method public getAccessKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 23
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->accessKey:Ljava/lang/String;

    return-object v0
.end method

.method public getIGGId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 19
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->iggId:Ljava/lang/String;

    return-object v0
.end method
