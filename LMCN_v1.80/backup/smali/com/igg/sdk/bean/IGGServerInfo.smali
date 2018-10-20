.class public Lcom/igg/sdk/bean/IGGServerInfo;
.super Ljava/lang/Object;
.source "IGGServerInfo.java"


# instance fields
.field private lineId:Ljava/lang/String;

.field private serverId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 3
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getLineId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 16
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGServerInfo;->lineId:Ljava/lang/String;

    return-object v0
.end method

.method public getServerId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 8
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGServerInfo;->serverId:Ljava/lang/String;

    return-object v0
.end method

.method public setLineId(Ljava/lang/String;)V
    .locals 0
    .param p1, "lineId"    # Ljava/lang/String;

    .prologue
    .line 20
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGServerInfo;->lineId:Ljava/lang/String;

    .line 21
    return-void
.end method

.method public setServerId(Ljava/lang/String;)V
    .locals 0
    .param p1, "serverId"    # Ljava/lang/String;

    .prologue
    .line 12
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGServerInfo;->serverId:Ljava/lang/String;

    .line 13
    return-void
.end method
