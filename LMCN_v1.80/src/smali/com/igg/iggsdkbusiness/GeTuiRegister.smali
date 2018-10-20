.class public Lcom/igg/iggsdkbusiness/GeTuiRegister;
.super Ljava/lang/Object;
.source "GeTuiRegister.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "GeTuiRegister"

.field private static instance:Lcom/igg/iggsdkbusiness/GeTuiRegister;


# instance fields
.field FailedCallBack:Ljava/lang/String;

.field IGGID:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 33
    const-string v0, "GeTuiRegisterSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->SuccessfulCallBack:Ljava/lang/String;

    .line 35
    const-string v0, "GeTuiRegisterFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->FailedCallBack:Ljava/lang/String;

    .line 22
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/GeTuiRegister;
    .locals 1

    .prologue
    .line 25
    sget-object v0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->instance:Lcom/igg/iggsdkbusiness/GeTuiRegister;

    if-nez v0, :cond_0

    .line 26
    new-instance v0, Lcom/igg/iggsdkbusiness/GeTuiRegister;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/GeTuiRegister;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->instance:Lcom/igg/iggsdkbusiness/GeTuiRegister;

    .line 29
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->instance:Lcom/igg/iggsdkbusiness/GeTuiRegister;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 41
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

    .line 42
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 43
    return-void
.end method

.method public init()V
    .locals 2

    .prologue
    .line 74
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->IGGID:Ljava/lang/String;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->IGGID:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 75
    :cond_0
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->IGGID:Ljava/lang/String;

    .line 78
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->IGGID:Ljava/lang/String;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->IGGID:Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 79
    :cond_2
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->FailedCallBack:Ljava/lang/String;

    const-string v1, "IGGID \u4e0d\u5b58\u5728\u65e0\u6cd5\u6ce8\u518c"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 84
    :goto_0
    return-void

    .line 83
    :cond_3
    invoke-static {}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    goto :goto_0
.end method

.method public init(Ljava/lang/String;)V
    .locals 2
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 54
    if-eqz p1, :cond_0

    const-string v0, ""

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 55
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/GeTuiRegister;->FailedCallBack:Ljava/lang/String;

    const-string v1, "IGGID \u4e0d\u5b58\u5728\u65e0\u6cd5\u6ce8\u518c"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 60
    :goto_0
    return-void

    .line 59
    :cond_1
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->init()V

    goto :goto_0
.end method

.method public uninitialize()V
    .locals 1

    .prologue
    .line 87
    invoke-static {}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->uninitialize()V

    .line 88
    return-void
.end method
