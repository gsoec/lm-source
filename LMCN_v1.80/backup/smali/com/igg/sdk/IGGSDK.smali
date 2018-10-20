.class public Lcom/igg/sdk/IGGSDK;
.super Ljava/lang/Object;
.source "IGGSDK.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;,
        Lcom/igg/sdk/IGGSDK$Notification;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGSDK"

.field private static instance:Lcom/igg/sdk/IGGSDK;


# instance fields
.field private GCMSenderId:Ljava/lang/String;

.field private appId:Ljava/lang/String;

.field private application:Landroid/app/Application;

.field private chinaMainland:Z

.field private dataCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private devicePermissionsDelegate:Lcom/igg/sdk/IGGDevicePermissionsDelegate;

.field private deviceRegisterId:Ljava/lang/String;

.field private enhancedSecretKey:Ljava/lang/String;

.field private family:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

.field private gameDelegate:Lcom/igg/sdk/IGGGameDelegate;

.field private gameId:Ljava/lang/String;

.field private iggSdkObserversList:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/IGGSDKObservior;",
            ">;"
        }
    .end annotation
.end field

.field private paymentKey:Ljava/lang/String;

.field private regionalCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private secretKey:Ljava/lang/String;

.field private switchHttps:Z

.field private useExternalStorage:Z


# direct methods
.method private constructor <init>()V
    .locals 1

    .prologue
    .line 148
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 53
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/IGGSDK;->iggSdkObserversList:Ljava/util/List;

    .line 150
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/IGGSDK;)Landroid/app/Application;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/IGGSDK;

    .prologue
    .line 30
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    return-object v0
.end method

.method private detectDeviceRegisterId(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V
    .locals 6
    .param p1, "listener"    # Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    .prologue
    const/4 v4, -0x1

    .line 465
    new-instance v0, Lcom/igg/sdk/IGGDeviceStorage;

    iget-object v3, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    invoke-direct {v0, v3}, Lcom/igg/sdk/IGGDeviceStorage;-><init>(Landroid/content/Context;)V

    .line 466
    .local v0, "deviceStorage":Lcom/igg/sdk/IGGDeviceStorage;
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->restoreAsCurrent()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    .line 468
    .local v1, "session":Lcom/igg/sdk/account/IGGAccountSession;
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v3

    if-nez v3, :cond_0

    .line 471
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-static {v3}, Lcom/igg/util/EmulatorDetector;->with(Landroid/content/Context;)Lcom/igg/util/EmulatorDetector;

    move-result-object v3

    const-string v4, "com.bluestacks"

    .line 473
    invoke-virtual {v3, v4}, Lcom/igg/util/EmulatorDetector;->addPackageName(Ljava/lang/String;)Lcom/igg/util/EmulatorDetector;

    move-result-object v3

    const/4 v4, 0x1

    .line 474
    invoke-virtual {v3, v4}, Lcom/igg/util/EmulatorDetector;->setDebug(Z)Lcom/igg/util/EmulatorDetector;

    move-result-object v3

    new-instance v4, Lcom/igg/sdk/IGGSDK$1;

    invoke-direct {v4, p0, v0, p1}, Lcom/igg/sdk/IGGSDK$1;-><init>(Lcom/igg/sdk/IGGSDK;Lcom/igg/sdk/IGGDeviceStorage;Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V

    .line 475
    invoke-virtual {v3, v4}, Lcom/igg/util/EmulatorDetector;->detect(Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;)V

    .line 642
    :goto_0
    return-void

    .line 619
    :cond_0
    invoke-virtual {v0}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v2

    .line 620
    .local v2, "stroageDeviceUIDStr":Ljava/lang/String;
    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_3

    const-string v3, ","

    invoke-virtual {v2, v3}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v3

    if-ne v3, v4, :cond_3

    const-string v3, "="

    invoke-virtual {v2, v3}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v3

    if-ne v3, v4, :cond_3

    .line 622
    invoke-static {v2}, Lcom/igg/util/FilterMacAddress;->filterIsInvalidMacAdress(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 623
    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_1

    .line 624
    const-string v3, "mac="

    invoke-virtual {v2, v3}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v3

    if-ne v3, v4, :cond_2

    .line 625
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "mac="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 626
    invoke-virtual {v0, v2}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 627
    invoke-virtual {p0, v2}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 638
    :cond_1
    :goto_1
    invoke-interface {p1}, Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;->finish()V

    .line 639
    const-string v3, "IGGSDK"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "IGGSDK.sharedInstance().getDeviceRegisterId():"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 640
    const-string v3, "IGGSDK"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "auto login currentDeviceUID:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v0}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 629
    :cond_2
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "mac="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "mac="

    const-string v5, ""

    invoke-virtual {v2, v4, v5}, Ljava/lang/String;->replaceAll(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 630
    invoke-virtual {v0, v2}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 631
    invoke-virtual {p0, v2}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    goto :goto_1

    .line 635
    :cond_3
    invoke-virtual {p0, v2}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    goto :goto_1
.end method

.method private onValueChanged(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "newValue"    # Ljava/lang/String;

    .prologue
    .line 215
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    iget-object v2, p0, Lcom/igg/sdk/IGGSDK;->iggSdkObserversList:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-ge v0, v2, :cond_0

    .line 216
    iget-object v2, p0, Lcom/igg/sdk/IGGSDK;->iggSdkObserversList:Ljava/util/List;

    invoke-interface {v2, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igg/sdk/IGGSDKObservior;

    .line 217
    .local v1, "observer":Lcom/igg/sdk/IGGSDKObservior;
    invoke-interface {v1, p1, p2}, Lcom/igg/sdk/IGGSDKObservior;->SDKValueChanged(Ljava/lang/String;Ljava/lang/String;)V

    .line 215
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 219
    .end local v1    # "observer":Lcom/igg/sdk/IGGSDKObservior;
    :cond_0
    return-void
.end method

.method public static declared-synchronized sharedInstance()Lcom/igg/sdk/IGGSDK;
    .locals 2

    .prologue
    .line 153
    const-class v1, Lcom/igg/sdk/IGGSDK;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igg/sdk/IGGSDK;->instance:Lcom/igg/sdk/IGGSDK;

    if-nez v0, :cond_0

    .line 154
    new-instance v0, Lcom/igg/sdk/IGGSDK;

    invoke-direct {v0}, Lcom/igg/sdk/IGGSDK;-><init>()V

    sput-object v0, Lcom/igg/sdk/IGGSDK;->instance:Lcom/igg/sdk/IGGSDK;

    .line 157
    :cond_0
    sget-object v0, Lcom/igg/sdk/IGGSDK;->instance:Lcom/igg/sdk/IGGSDK;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    .line 153
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method


# virtual methods
.method public addValueObservor(Lcom/igg/sdk/IGGSDKObservior;)V
    .locals 1
    .param p1, "observor"    # Lcom/igg/sdk/IGGSDKObservior;

    .prologue
    .line 222
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->iggSdkObserversList:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 223
    return-void
.end method

.method public getAppId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 185
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->appId:Ljava/lang/String;

    return-object v0
.end method

.method public getApplication()Landroid/app/Application;
    .locals 1

    .prologue
    .line 264
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    return-object v0
.end method

.method public getDataCenter()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 334
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->dataCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method public getDevicePermissionsDelegate()Lcom/igg/sdk/IGGDevicePermissionsDelegate;
    .locals 1

    .prologue
    .line 439
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->devicePermissionsDelegate:Lcom/igg/sdk/IGGDevicePermissionsDelegate;

    return-object v0
.end method

.method public getDeviceRegisterId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 229
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->deviceRegisterId:Ljava/lang/String;

    return-object v0
.end method

.method public getEnhancedSecretKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 392
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->enhancedSecretKey:Ljava/lang/String;

    return-object v0
.end method

.method public getFamily()Lcom/igg/sdk/IGGSDKConstant$IGGFamily;
    .locals 1

    .prologue
    .line 370
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->family:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    if-nez v0, :cond_0

    .line 371
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    .line 374
    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->family:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    goto :goto_0
.end method

.method public getGCMSenderId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 297
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->GCMSenderId:Ljava/lang/String;

    return-object v0
.end method

.method public getGameDelegate()Lcom/igg/sdk/IGGGameDelegate;
    .locals 1

    .prologue
    .line 431
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->gameDelegate:Lcom/igg/sdk/IGGGameDelegate;

    return-object v0
.end method

.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 192
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getPaymentKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 313
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->paymentKey:Ljava/lang/String;

    return-object v0
.end method

.method public getRegionalCenter()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 352
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->regionalCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method public getSecretKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 245
    iget-object v0, p0, Lcom/igg/sdk/IGGSDK;->secretKey:Ljava/lang/String;

    return-object v0
.end method

.method public initialize(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V
    .locals 2
    .param p1, "listener"    # Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;

    .prologue
    .line 161
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->initialize()V

    .line 163
    invoke-static {}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->init(Landroid/content/Context;)V

    .line 165
    invoke-direct {p0, p1}, Lcom/igg/sdk/IGGSDK;->detectDeviceRegisterId(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V

    .line 166
    return-void
.end method

.method public isChinaMainland()Z
    .locals 1

    .prologue
    .line 410
    iget-boolean v0, p0, Lcom/igg/sdk/IGGSDK;->chinaMainland:Z

    return v0
.end method

.method public isSwitchHttps()Z
    .locals 1

    .prologue
    .line 321
    iget-boolean v0, p0, Lcom/igg/sdk/IGGSDK;->switchHttps:Z

    return v0
.end method

.method public isUseExternalStorage()Z
    .locals 1

    .prologue
    .line 423
    iget-boolean v0, p0, Lcom/igg/sdk/IGGSDK;->useExternalStorage:Z

    return v0
.end method

.method public setAppId(Ljava/lang/String;)V
    .locals 0
    .param p1, "appId"    # Ljava/lang/String;

    .prologue
    .line 178
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->appId:Ljava/lang/String;

    .line 179
    return-void
.end method

.method public setApplication(Landroid/app/Application;)V
    .locals 2
    .param p1, "application"    # Landroid/app/Application;

    .prologue
    .line 273
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    .line 275
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK;->gameId:Ljava/lang/String;

    if-eqz v1, :cond_0

    .line 277
    new-instance v0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;

    invoke-direct {v0, p1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;-><init>(Landroid/content/Context;)V

    .line 278
    .local v0, "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setGameId(Ljava/lang/String;)V

    .line 281
    .end local v0    # "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    :cond_0
    invoke-virtual {p1}, Landroid/app/Application;->getPackageName()Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/sdk/IGGSDK;->appId:Ljava/lang/String;

    .line 282
    return-void
.end method

.method public setChinaMainland(Z)V
    .locals 0
    .param p1, "chinaMainland"    # Z

    .prologue
    .line 419
    iput-boolean p1, p0, Lcom/igg/sdk/IGGSDK;->chinaMainland:Z

    .line 420
    return-void
.end method

.method public setDataCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 0
    .param p1, "dataCenter"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 343
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->dataCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 344
    return-void
.end method

.method public setDevicePermissionsDelegate(Lcom/igg/sdk/IGGDevicePermissionsDelegate;)V
    .locals 0
    .param p1, "devicePermissionsDelegate"    # Lcom/igg/sdk/IGGDevicePermissionsDelegate;

    .prologue
    .line 443
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->devicePermissionsDelegate:Lcom/igg/sdk/IGGDevicePermissionsDelegate;

    .line 444
    return-void
.end method

.method public setDeviceRegisterId(Ljava/lang/String;)V
    .locals 0
    .param p1, "deviceRegisterId"    # Ljava/lang/String;

    .prologue
    .line 238
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->deviceRegisterId:Ljava/lang/String;

    .line 239
    return-void
.end method

.method public setEnhancedSecretKey(Ljava/lang/String;)V
    .locals 0
    .param p1, "enhancedSecretKey"    # Ljava/lang/String;

    .prologue
    .line 401
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->enhancedSecretKey:Ljava/lang/String;

    .line 402
    return-void
.end method

.method public setFamily(Lcom/igg/sdk/IGGSDKConstant$IGGFamily;)V
    .locals 0
    .param p1, "family"    # Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    .prologue
    .line 383
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->family:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    .line 384
    return-void
.end method

.method public setGCMSenderId(Ljava/lang/String;)V
    .locals 0
    .param p1, "GCMSenderId"    # Ljava/lang/String;

    .prologue
    .line 306
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->GCMSenderId:Ljava/lang/String;

    .line 307
    return-void
.end method

.method public setGameDelegate(Lcom/igg/sdk/IGGGameDelegate;)V
    .locals 0
    .param p1, "gameDelegate"    # Lcom/igg/sdk/IGGGameDelegate;

    .prologue
    .line 435
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->gameDelegate:Lcom/igg/sdk/IGGGameDelegate;

    .line 436
    return-void
.end method

.method public setGameId(Ljava/lang/String;)V
    .locals 2
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 201
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->gameId:Ljava/lang/String;

    .line 203
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    if-eqz v1, :cond_0

    .line 205
    new-instance v0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;

    iget-object v1, p0, Lcom/igg/sdk/IGGSDK;->application:Landroid/app/Application;

    invoke-direct {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;-><init>(Landroid/content/Context;)V

    .line 206
    .local v0, "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    iget-object v1, p0, Lcom/igg/sdk/IGGSDK;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->setGameId(Ljava/lang/String;)V

    .line 210
    .end local v0    # "serivce":Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
    :cond_0
    const-string v1, "gameId"

    invoke-direct {p0, v1, p1}, Lcom/igg/sdk/IGGSDK;->onValueChanged(Ljava/lang/String;Ljava/lang/String;)V

    .line 211
    return-void
.end method

.method public setPaymentKey(Ljava/lang/String;)V
    .locals 0
    .param p1, "paymentKey"    # Ljava/lang/String;

    .prologue
    .line 317
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->paymentKey:Ljava/lang/String;

    .line 318
    return-void
.end method

.method public setPushMessageCustomHandle(Landroid/content/Context;Z)V
    .locals 1
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "PushMessageCustomHandle"    # Z

    .prologue
    .line 290
    invoke-static {}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->getConfig()Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/sdk/push/IGGNotificationMessageCenter$Config;->setCustomHandle(Landroid/content/Context;Z)V

    .line 291
    return-void
.end method

.method public setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 0
    .param p1, "regionalCenter"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 361
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->regionalCenter:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 362
    return-void
.end method

.method public setSecretKey(Ljava/lang/String;)V
    .locals 1
    .param p1, "secretKey"    # Ljava/lang/String;

    .prologue
    .line 254
    iput-object p1, p0, Lcom/igg/sdk/IGGSDK;->secretKey:Ljava/lang/String;

    .line 255
    invoke-virtual {p0}, Lcom/igg/sdk/IGGSDK;->getEnhancedSecretKey()Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_0

    .line 256
    invoke-virtual {p0, p1}, Lcom/igg/sdk/IGGSDK;->setEnhancedSecretKey(Ljava/lang/String;)V

    .line 258
    :cond_0
    return-void
.end method

.method public setSwitchHttps(Z)V
    .locals 0
    .param p1, "switchHttps"    # Z

    .prologue
    .line 325
    iput-boolean p1, p0, Lcom/igg/sdk/IGGSDK;->switchHttps:Z

    .line 326
    return-void
.end method

.method public setUseExternalStorage(Z)V
    .locals 0
    .param p1, "useExternalStorage"    # Z

    .prologue
    .line 427
    iput-boolean p1, p0, Lcom/igg/sdk/IGGSDK;->useExternalStorage:Z

    .line 428
    return-void
.end method
