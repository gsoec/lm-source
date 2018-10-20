.class public Lcom/igg/sdk/bean/PushCommonMessageInfo;
.super Ljava/lang/Object;
.source "PushCommonMessageInfo.java"

# interfaces
.implements Ljava/io/Serializable;


# static fields
.field private static final serialVersionUID:J = -0x50fea4e972b1fea1L


# instance fields
.field private display:Ljava/lang/String;

.field private message:Ljava/lang/String;

.field private messageState:Ljava/lang/String;

.field private mqId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getDisplay()Ljava/lang/String;
    .locals 1

    .prologue
    .line 36
    iget-object v0, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->display:Ljava/lang/String;

    return-object v0
.end method

.method public getMessage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 20
    iget-object v0, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->message:Ljava/lang/String;

    return-object v0
.end method

.method public getMessageState()Ljava/lang/String;
    .locals 1

    .prologue
    .line 44
    iget-object v0, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->messageState:Ljava/lang/String;

    return-object v0
.end method

.method public getMqId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 28
    iget-object v0, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->mqId:Ljava/lang/String;

    return-object v0
.end method

.method public setDisplay(Ljava/lang/String;)V
    .locals 0
    .param p1, "display"    # Ljava/lang/String;

    .prologue
    .line 40
    iput-object p1, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->display:Ljava/lang/String;

    .line 41
    return-void
.end method

.method public setMessage(Ljava/lang/String;)V
    .locals 0
    .param p1, "message"    # Ljava/lang/String;

    .prologue
    .line 24
    iput-object p1, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->message:Ljava/lang/String;

    .line 25
    return-void
.end method

.method public setMessageState(Ljava/lang/String;)V
    .locals 0
    .param p1, "messageState"    # Ljava/lang/String;

    .prologue
    .line 48
    iput-object p1, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->messageState:Ljava/lang/String;

    .line 49
    return-void
.end method

.method public setMqId(Ljava/lang/String;)V
    .locals 0
    .param p1, "mqId"    # Ljava/lang/String;

    .prologue
    .line 32
    iput-object p1, p0, Lcom/igg/sdk/bean/PushCommonMessageInfo;->mqId:Ljava/lang/String;

    .line 33
    return-void
.end method
