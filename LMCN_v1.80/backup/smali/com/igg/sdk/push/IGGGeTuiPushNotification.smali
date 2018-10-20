.class public Lcom/igg/sdk/push/IGGGeTuiPushNotification;
.super Ljava/lang/Object;
.source "IGGGeTuiPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/push/IIGGPushNotification;
.implements Lcom/igg/sdk/IGGSDKObservior;


# static fields
.field protected static final TAG:Ljava/lang/String; = "GeTuiPush"

.field private static instance:Lcom/igg/sdk/push/IGGGeTuiPushNotification;


# instance fields
.field private isInitialized:Z

.field private isReRegistration:Z

.field private isSupported:Z


# direct methods
.method private constructor <init>()V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 36
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 21
    iput-boolean v1, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    .line 22
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isSupported:Z

    .line 23
    iput-boolean v1, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isReRegistration:Z

    .line 37
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0, p0}, Lcom/igg/sdk/IGGSDK;->addValueObservor(Lcom/igg/sdk/IGGSDKObservior;)V

    .line 38
    return-void
.end method

.method public static sharedInstance()Lcom/igg/sdk/push/IGGGeTuiPushNotification;
    .locals 1

    .prologue
    .line 29
    sget-object v0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->instance:Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    if-nez v0, :cond_0

    .line 30
    new-instance v0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    invoke-direct {v0}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;-><init>()V

    sput-object v0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->instance:Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    .line 33
    :cond_0
    sget-object v0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->instance:Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    return-object v0
.end method


# virtual methods
.method public SDKValueChanged(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "value"    # Ljava/lang/String;

    .prologue
    .line 42
    const-string v0, "GeTuiPush"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "=>"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 44
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    .line 45
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isReRegistration:Z

    .line 46
    invoke-virtual {p0}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->uninitialize()V

    .line 47
    invoke-static {}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGeTuiPushNotification;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    .line 48
    return-void
.end method

.method public initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;
    .locals 5
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 58
    iget-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    if-nez v2, :cond_2

    .line 59
    const/4 v2, 0x1

    iput-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    .line 60
    new-instance v1, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    invoke-direct {v1, v2}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;-><init>(Landroid/content/Context;)V

    .line 61
    .local v1, "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    invoke-virtual {v1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->currentIGGId()Ljava/lang/String;

    move-result-object v0

    .line 62
    .local v0, "currentSaveIGGId":Ljava/lang/String;
    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 63
    invoke-virtual {v1, p1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setIGGId(Ljava/lang/String;)V

    .line 66
    :cond_0
    iget-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isReRegistration:Z

    if-eqz v2, :cond_1

    .line 67
    const/4 v2, 0x0

    iput-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isReRegistration:Z

    .line 68
    const-string v2, ""

    invoke-virtual {v1, v2}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setRegId(Ljava/lang/String;)V

    .line 72
    :cond_1
    invoke-static {}, Lcom/igexin/sdk/PushManager;->getInstance()Lcom/igexin/sdk/PushManager;

    move-result-object v2

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Lcom/igexin/sdk/PushManager;->initialize(Landroid/content/Context;Ljava/lang/Class;)V

    .line 73
    const-string v2, "GeTuiPush"

    const-string v3, "GeTui server has registered"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 76
    .end local v0    # "currentSaveIGGId":Ljava/lang/String;
    .end local v1    # "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    :cond_2
    return-object p0
.end method

.method public isSupported()Z
    .locals 1

    .prologue
    .line 51
    iget-boolean v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isSupported:Z

    return v0
.end method

.method public onDestroy()V
    .locals 0

    .prologue
    .line 108
    return-void
.end method

.method public uninitialize()V
    .locals 4

    .prologue
    .line 80
    iget-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    if-eqz v2, :cond_0

    .line 81
    new-instance v0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    invoke-direct {v0, v2}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;-><init>(Landroid/content/Context;)V

    .line 82
    .local v0, "TuiPushStorageSerivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->currentRegId()Ljava/lang/String;

    move-result-object v1

    .line 83
    .local v1, "registrationId":Ljava/lang/String;
    new-instance v2, Lcom/igg/sdk/service/IGGMobileDeviceService;

    invoke-direct {v2}, Lcom/igg/sdk/service/IGGMobileDeviceService;-><init>()V

    new-instance v3, Lcom/igg/sdk/push/IGGGeTuiPushNotification$1;

    invoke-direct {v3, p0}, Lcom/igg/sdk/push/IGGGeTuiPushNotification$1;-><init>(Lcom/igg/sdk/push/IGGGeTuiPushNotification;)V

    invoke-virtual {v2, v1, v3}, Lcom/igg/sdk/service/IGGMobileDeviceService;->unregisterDevice(Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V

    .line 97
    const-string v2, ""

    invoke-virtual {v0, v2}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setIGGId(Ljava/lang/String;)V

    .line 98
    const-string v2, ""

    invoke-virtual {v0, v2}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setRegId(Ljava/lang/String;)V

    .line 101
    invoke-static {}, Lcom/igexin/sdk/PushManager;->getInstance()Lcom/igexin/sdk/PushManager;

    move-result-object v2

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igexin/sdk/PushManager;->stopService(Landroid/content/Context;)V

    .line 102
    const/4 v2, 0x0

    iput-boolean v2, p0, Lcom/igg/sdk/push/IGGGeTuiPushNotification;->isInitialized:Z

    .line 104
    .end local v0    # "TuiPushStorageSerivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    .end local v1    # "registrationId":Ljava/lang/String;
    :cond_0
    return-void
.end method
