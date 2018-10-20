.class public Lcom/igg/sdk/push/IGGPushNotification;
.super Ljava/lang/Object;
.source "IGGPushNotification.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getCurrent()Lcom/igg/sdk/push/IIGGPushNotification;
    .locals 1

    .prologue
    .line 25
    invoke-static {}, Lcom/igg/sdk/push/IGGGCMPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGCMPushNotification;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/sdk/push/IIGGPushNotification;
    .locals 1

    .prologue
    .line 18
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->getCurrent()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;
    .locals 1
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 43
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->getCurrent()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/igg/sdk/push/IIGGPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    return-object v0
.end method

.method public isSupported()Z
    .locals 1

    .prologue
    .line 32
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->getCurrent()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    invoke-interface {v0}, Lcom/igg/sdk/push/IIGGPushNotification;->isSupported()Z

    move-result v0

    return v0
.end method

.method public uninitialize()V
    .locals 1

    .prologue
    .line 52
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->getCurrent()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    invoke-interface {v0}, Lcom/igg/sdk/push/IIGGPushNotification;->uninitialize()V

    .line 53
    return-void
.end method
