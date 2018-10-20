.class public Lcom/igg/sdk/service/IGGAppConfig;
.super Ljava/lang/Object;
.source "IGGAppConfig.java"

# interfaces
.implements Ljava/io/Serializable;


# static fields
.field private static final serialVersionUID:J = 0x3bef98e0deddfe1aL


# instance fields
.field private clientIp:Ljava/lang/String;

.field private id:I

.field private node:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private protocolNumber:Ljava/lang/String;

.field private rawString:Ljava/lang/String;

.field private serverTimestamp:J

.field private source:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

.field private updateAt:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getClientIp()Ljava/lang/String;
    .locals 1

    .prologue
    .line 97
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->clientIp:Ljava/lang/String;

    return-object v0
.end method

.method public getId()I
    .locals 1

    .prologue
    .line 57
    iget v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->id:I

    return v0
.end method

.method public getNode()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 113
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->node:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method public getProtocolNumber()Ljava/lang/String;
    .locals 1

    .prologue
    .line 105
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->protocolNumber:Ljava/lang/String;

    return-object v0
.end method

.method public getRawString()Ljava/lang/String;
    .locals 1

    .prologue
    .line 73
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->rawString:Ljava/lang/String;

    return-object v0
.end method

.method public getServerTimestamp()J
    .locals 2

    .prologue
    .line 89
    iget-wide v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->serverTimestamp:J

    return-wide v0
.end method

.method public getSource()Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;
    .locals 1

    .prologue
    .line 81
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->source:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    return-object v0
.end method

.method public getUpdateAt()Ljava/lang/String;
    .locals 1

    .prologue
    .line 65
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfig;->updateAt:Ljava/lang/String;

    return-object v0
.end method

.method public setClientIp(Ljava/lang/String;)V
    .locals 0
    .param p1, "clientIp"    # Ljava/lang/String;

    .prologue
    .line 101
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->clientIp:Ljava/lang/String;

    .line 102
    return-void
.end method

.method public setId(I)V
    .locals 0
    .param p1, "id"    # I

    .prologue
    .line 61
    iput p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->id:I

    .line 62
    return-void
.end method

.method public setNode(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 0
    .param p1, "node"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 117
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->node:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 118
    return-void
.end method

.method public setProtocolNumber(Ljava/lang/String;)V
    .locals 0
    .param p1, "protocolNumber"    # Ljava/lang/String;

    .prologue
    .line 109
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->protocolNumber:Ljava/lang/String;

    .line 110
    return-void
.end method

.method public setRawString(Ljava/lang/String;)V
    .locals 0
    .param p1, "rawString"    # Ljava/lang/String;

    .prologue
    .line 77
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->rawString:Ljava/lang/String;

    .line 78
    return-void
.end method

.method public setServerTimestamp(J)V
    .locals 1
    .param p1, "serverTimestamp"    # J

    .prologue
    .line 93
    iput-wide p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->serverTimestamp:J

    .line 94
    return-void
.end method

.method public setSource(Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;)V
    .locals 0
    .param p1, "source"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    .prologue
    .line 85
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->source:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    .line 86
    return-void
.end method

.method public setUpdateAt(Ljava/lang/String;)V
    .locals 0
    .param p1, "updateAt"    # Ljava/lang/String;

    .prologue
    .line 69
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfig;->updateAt:Ljava/lang/String;

    .line 70
    return-void
.end method
