.class public Lcom/igg/iggsdkbusiness/GCMRegister;
.super Ljava/lang/Object;
.source "GCMRegister.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "GCMRegister"

.field private static instance:Lcom/igg/iggsdkbusiness/GCMRegister;


# instance fields
.field FailedCallBack:Ljava/lang/String;

.field IGGID:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;

.field notification:Lcom/igg/sdk/push/IGGGCMPushNotification;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 37
    const-string v0, "GCMRegisterSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->SuccessfulCallBack:Ljava/lang/String;

    .line 39
    const-string v0, "GCMRegisterFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->FailedCallBack:Ljava/lang/String;

    .line 27
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/GCMRegister;
    .locals 1

    .prologue
    .line 29
    sget-object v0, Lcom/igg/iggsdkbusiness/GCMRegister;->instance:Lcom/igg/iggsdkbusiness/GCMRegister;

    if-nez v0, :cond_0

    .line 30
    new-instance v0, Lcom/igg/iggsdkbusiness/GCMRegister;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/GCMRegister;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/GCMRegister;->instance:Lcom/igg/iggsdkbusiness/GCMRegister;

    .line 33
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/GCMRegister;->instance:Lcom/igg/iggsdkbusiness/GCMRegister;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 43
    const-string v0, "log:"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ":"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 44
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 45
    return-void
.end method

.method public init()V
    .locals 2

    .prologue
    .line 55
    const-string v0, "GCM"

    const-string v1, "GCM\u521d\u59cb\u5316\u6ce8\u518c\u670d\u52a1"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 63
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 64
    :cond_0
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    .line 67
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 68
    :cond_2
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->FailedCallBack:Ljava/lang/String;

    const-string v1, "IGGID doesnot exist"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/GCMRegister;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 96
    :goto_0
    return-void

    .line 75
    :cond_3
    const-string v0, "GCM"

    const-string v1, "init --2"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 76
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->sharedInstance()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->IGGID:Ljava/lang/String;

    invoke-interface {v0, v1}, Lcom/igg/sdk/push/IIGGPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/push/IGGGCMPushNotification;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->notification:Lcom/igg/sdk/push/IGGGCMPushNotification;

    .line 77
    const-string v0, "GCM"

    const-string v1, "init --3"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->notification:Lcom/igg/sdk/push/IGGGCMPushNotification;

    new-instance v1, Lcom/igg/iggsdkbusiness/GCMRegister$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/GCMRegister$1;-><init>(Lcom/igg/iggsdkbusiness/GCMRegister;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->registerReceiver(Landroid/content/BroadcastReceiver;)V

    goto :goto_0
.end method

.method public init(Ljava/lang/String;)V
    .locals 2
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 111
    if-eqz p1, :cond_0

    const-string v0, ""

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 112
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->FailedCallBack:Ljava/lang/String;

    const-string v1, "IGGID doesnot exist"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/GCMRegister;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 118
    :goto_0
    return-void

    .line 116
    :cond_1
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/GCMRegister;->init()V

    goto :goto_0
.end method

.method public onDestroy()V
    .locals 1

    .prologue
    .line 129
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GCMRegister;->notification:Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onDestroy()V

    .line 130
    return-void
.end method
