.class public Lcom/igg/sdk/account/IGGAccountSession;
.super Ljava/lang/Object;
.source "IGGAccountSession.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;,
        Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;
    }
.end annotation


# static fields
.field private static final EXTRA_DATA_KEY_PREFIX:Ljava/lang/String; = "com.igg.sdk.account.session.extra."

.field public static final TAG:Ljava/lang/String; = "IGGLoginSession"

.field public static currentSession:Lcom/igg/sdk/account/IGGAccountSession; = null

.field public static final storageName:Ljava/lang/String; = "igg_login_session"


# instance fields
.field private IGGId:Ljava/lang/String;

.field private WeChatName:Ljava/lang/String;

.field private accessKey:Ljava/lang/String;

.field private hasBind:Z

.field private loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

.field private storage:Lcom/igg/util/LocalStorage;

.field private thirdPlatformAccessKey:Ljava/lang/String;

.field private thirdPlatformId:Ljava/lang/String;

.field private timeToVerify:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 175
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 176
    new-instance v0, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v1

    const-string v2, "igg_login_session"

    invoke-direct {v0, v1, v2}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    .line 177
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/account/IGGAccountSession;)Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    return-object v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/account/IGGAccountSession;)Z
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 34
    iget-boolean v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    return v0
.end method

.method static synthetic access$200(Lcom/igg/sdk/account/IGGAccountSession;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic access$300(Lcom/igg/sdk/account/IGGAccountSession;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    return-object v0
.end method

.method public static checkGuestIsBound(Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;)V
    .locals 12
    .param p0, "type"    # Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;
    .param p1, "listener"    # Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    .prologue
    .line 337
    new-instance v2, Lcom/igg/sdk/IGGDeviceStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v8

    invoke-direct {v2, v8}, Lcom/igg/sdk/IGGDeviceStorage;-><init>(Landroid/content/Context;)V

    .line 338
    .local v2, "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    invoke-virtual {v2}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v1

    .line 340
    .local v1, "currentDeviceUID":Ljava/lang/String;
    new-instance v5, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v5}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 343
    .local v5, "logininfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    :try_start_0
    new-instance v8, Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {v8}, Lcom/igg/sdk/account/IGGDeviceGuest;-><init>()V

    invoke-virtual {v8}, Lcom/igg/sdk/account/IGGDeviceGuest;->getIdentifier()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v6

    .line 350
    .local v6, "mGuest":Ljava/lang/String;
    :goto_0
    if-eqz v6, :cond_0

    const-string v8, ""

    invoke-virtual {v6, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    .line 351
    :cond_0
    const-string v8, "loginAsGuest"

    const-string v9, "uuid as deviceid "

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 353
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v8

    invoke-static {v8}, Lcom/igg/util/UUIDUtil;->getUUID(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    .line 354
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "uuid="

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v2, v8}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 355
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "uuid="

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 358
    :cond_1
    invoke-virtual {v5, v6}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGuest(Ljava/lang/String;)V

    .line 360
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v4

    .line 361
    .local v4, "expireTime":Ljava/lang/String;
    const-string v8, "GuestLoginOperation"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "expireTime\uff1a"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 362
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v10

    invoke-virtual {v8, v10, v11}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ""

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v5, v8}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKey(Ljava/lang/String;)V

    .line 363
    sget v8, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v5, v8}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 364
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v5, v8}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 365
    const-string v0, ""

    .line 366
    .local v0, "bindType":Ljava/lang/String;
    sget-object v8, Lcom/igg/sdk/account/IGGAccountSession$3;->$SwitchMap$com$igg$sdk$IGGSDKConstant$ThirdAccountType:[I

    invoke-virtual {p0}, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->ordinal()I

    move-result v9

    aget v8, v8, v9

    packed-switch v8, :pswitch_data_0

    .line 393
    :goto_1
    move-object v7, v0

    .line 394
    .local v7, "typeName":Ljava/lang/String;
    new-instance v8, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v8}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v9, Lcom/igg/sdk/account/IGGAccountSession$2;

    invoke-direct {v9, p1, p0, v7}, Lcom/igg/sdk/account/IGGAccountSession$2;-><init>(Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;Ljava/lang/String;)V

    invoke-virtual {v8, v5, v9}, Lcom/igg/sdk/service/IGGLoginService;->guestLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 433
    return-void

    .line 344
    .end local v0    # "bindType":Ljava/lang/String;
    .end local v4    # "expireTime":Ljava/lang/String;
    .end local v6    # "mGuest":Ljava/lang/String;
    .end local v7    # "typeName":Ljava/lang/String;
    :catch_0
    move-exception v3

    .line 345
    .local v3, "e":Ljava/lang/Exception;
    invoke-virtual {v3}, Ljava/lang/Exception;->printStackTrace()V

    .line 346
    move-object v6, v1

    .restart local v6    # "mGuest":Ljava/lang/String;
    goto/16 :goto_0

    .line 368
    .end local v3    # "e":Ljava/lang/Exception;
    .restart local v0    # "bindType":Ljava/lang/String;
    .restart local v4    # "expireTime":Ljava/lang/String;
    :pswitch_0
    const-string v0, "googleplus"

    .line 369
    invoke-virtual {v5, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setCheckBindType(Ljava/lang/String;)V

    goto :goto_1

    .line 373
    :pswitch_1
    const-string v0, "facebook"

    .line 374
    invoke-virtual {v5, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setCheckBindType(Ljava/lang/String;)V

    goto :goto_1

    .line 378
    :pswitch_2
    const-string v0, "wechat"

    .line 379
    invoke-virtual {v5, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setCheckBindType(Ljava/lang/String;)V

    goto :goto_1

    .line 383
    :pswitch_3
    const-string v0, "amazon"

    .line 384
    invoke-virtual {v5, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setCheckBindType(Ljava/lang/String;)V

    goto :goto_1

    .line 388
    :pswitch_4
    const-string v0, "all_type"

    .line 389
    const-string v8, "1"

    invoke-virtual {v5, v8}, Lcom/igg/sdk/bean/IGGLoginInfo;->setCheckAllBindType(Ljava/lang/String;)V

    goto :goto_1

    .line 366
    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
    .end packed-switch
.end method

.method public static invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;
    .locals 2

    .prologue
    .line 127
    const-string v0, "IGGLoginSession"

    const-string v1, "invalidateCurrentSession"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 128
    const/4 v0, 0x0

    sput-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 129
    sget-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    return-object v0
.end method

.method public static quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;
    .locals 4
    .param p0, "loginType"    # Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .param p1, "IGGId"    # Ljava/lang/String;
    .param p2, "accesskey"    # Ljava/lang/String;
    .param p3, "hasBind"    # Z
    .param p4, "timeToVerify"    # Ljava/lang/String;
    .param p5, "thirdPlatformAccessKey"    # Ljava/lang/String;
    .param p6, "thirdPlatformId"    # Ljava/lang/String;

    .prologue
    .line 95
    new-instance v0, Lcom/igg/sdk/account/IGGAccountSession;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountSession;-><init>()V

    .line 97
    .local v0, "session":Lcom/igg/sdk/account/IGGAccountSession;
    invoke-virtual {v0, p0}, Lcom/igg/sdk/account/IGGAccountSession;->setLoginType(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;)V

    .line 98
    invoke-virtual {v0, p1}, Lcom/igg/sdk/account/IGGAccountSession;->setIGGId(Ljava/lang/String;)V

    .line 99
    invoke-virtual {v0, p2}, Lcom/igg/sdk/account/IGGAccountSession;->setAccesskey(Ljava/lang/String;)V

    .line 100
    invoke-virtual {v0, p3}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 101
    invoke-virtual {v0, p5}, Lcom/igg/sdk/account/IGGAccountSession;->setThirdPlatformAccessKey(Ljava/lang/String;)V

    .line 102
    invoke-virtual {v0, p6}, Lcom/igg/sdk/account/IGGAccountSession;->setThirdPlatformId(Ljava/lang/String;)V

    .line 105
    const-string v1, ""

    invoke-virtual {p4, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 106
    invoke-static {p4}, Lcom/igg/util/DeviceUtil;->localTimeToUTC(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p4

    .line 108
    :cond_0
    invoke-virtual {v0, p4}, Lcom/igg/sdk/account/IGGAccountSession;->setTimeToVerify(Ljava/lang/String;)V

    .line 110
    const-string v1, "IGGLoginSession"

    const-string v2, "if loginType equal FACEBOOK, hasBind is invalid"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 111
    const-string v1, "IGGLoginSession"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "quickCreate => loginType: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p0}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->name()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|IGGId: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|accesskey: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|hasBind: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|timeToVerify(UTC):"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|thirdPlatformAccessKey:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, v0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "|thirdPlatformId:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, v0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 118
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->restoreAsCurrent()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    return-object v1
.end method

.method public static restoreAsCurrent()Lcom/igg/sdk/account/IGGAccountSession;
    .locals 7

    .prologue
    .line 138
    new-instance v3, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    const-string v5, "igg_login_session"

    invoke-direct {v3, v4, v5}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    .line 142
    .local v3, "storage":Lcom/igg/util/LocalStorage;
    :try_start_0
    const-string v4, "loginType"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->valueOf(Ljava/lang/String;)Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 147
    .local v1, "loginType":Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    :goto_0
    new-instance v2, Lcom/igg/sdk/account/IGGAccountSession;

    invoke-direct {v2}, Lcom/igg/sdk/account/IGGAccountSession;-><init>()V

    .line 148
    .local v2, "session":Lcom/igg/sdk/account/IGGAccountSession;
    iput-object v1, v2, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 149
    const-string v4, "IGGId"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;

    .line 150
    const-string v4, "accesskey"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    .line 151
    const-string v4, "hasBind"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v4

    iput-boolean v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    .line 152
    const-string v4, "thirdPlatformAccessKey"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    .line 153
    const-string v4, "thirdPlatformId"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    .line 154
    const-string v4, "WeChatName"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->WeChatName:Ljava/lang/String;

    .line 156
    const-string v4, "timetoverify"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    const-string v5, ""

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 157
    const-string v4, "timetoverify"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/util/DeviceUtil;->UTCTimeToLocal(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    .line 162
    :goto_1
    const-string v4, "IGGLoginSession"

    const-string v5, "if loginType equal FACEBOOK, hasBind is invalid"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 163
    const-string v4, "IGGLoginSession"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "loginType: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->name()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|IGGId: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|accesskey: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|hasBind: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-boolean v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|timeToVerify(local):"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|thirdPlatformAccessKey:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "|thirdPlatformId:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, v2, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 169
    sput-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 171
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    return-object v4

    .line 143
    .end local v1    # "loginType":Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .end local v2    # "session":Lcom/igg/sdk/account/IGGAccountSession;
    :catch_0
    move-exception v0

    .line 144
    .local v0, "e":Ljava/lang/IllegalArgumentException;
    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .restart local v1    # "loginType":Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    goto/16 :goto_0

    .line 159
    .end local v0    # "e":Ljava/lang/IllegalArgumentException;
    .restart local v2    # "session":Lcom/igg/sdk/account/IGGAccountSession;
    :cond_0
    const-string v4, ""

    iput-object v4, v2, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    goto :goto_1
.end method


# virtual methods
.method public declared-synchronized dumpAll()V
    .locals 7

    .prologue
    .line 624
    monitor-enter p0

    :try_start_0
    const-string v1, "IGGLoginSession"

    const-string v2, "dumpAll start"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 626
    iget-object v1, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v1}, Lcom/igg/util/LocalStorage;->getAll()Ljava/util/Map;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 627
    .local v0, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    const-string v2, "IGGLoginSession"

    const-string v3, "%s:%s"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v6

    aput-object v6, v4, v5

    const/4 v5, 0x1

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    aput-object v6, v4, v5

    invoke-static {v3, v4}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    .line 624
    .end local v0    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    :catchall_0
    move-exception v1

    monitor-exit p0

    throw v1

    .line 630
    :cond_0
    :try_start_1
    const-string v1, "IGGLoginSession"

    const-string v2, "dumpAll end"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 631
    monitor-exit p0

    return-void
.end method

.method public declared-synchronized dumpExtra()V
    .locals 8

    .prologue
    .line 639
    monitor-enter p0

    :try_start_0
    const-string v2, "IGGLoginSession"

    const-string v3, "dumpExtra start"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 641
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v2}, Lcom/igg/util/LocalStorage;->getAll()Ljava/util/Map;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 642
    .local v0, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const-string v4, "com.igg.sdk.account.session.extra."

    invoke-virtual {v2, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 643
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const-string v4, "com.igg.sdk.account.session.extra."

    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v4

    invoke-virtual {v2, v4}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v1

    .line 644
    .local v1, "realKey":Ljava/lang/String;
    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v2

    if-eqz v2, :cond_1

    .line 645
    const-string v2, "IGGLoginSession"

    const-string v4, "%s:%s"

    const/4 v5, 0x2

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v6, 0x0

    aput-object v1, v5, v6

    const/4 v6, 0x1

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    aput-object v7, v5, v6

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v2, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    .line 639
    .end local v0    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    .end local v1    # "realKey":Ljava/lang/String;
    :catchall_0
    move-exception v2

    monitor-exit p0

    throw v2

    .line 647
    .restart local v0    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    .restart local v1    # "realKey":Ljava/lang/String;
    :cond_1
    :try_start_1
    const-string v2, "IGGLoginSession"

    const-string v4, "%s:null"

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v6, 0x0

    aput-object v1, v5, v6

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v2, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 653
    .end local v0    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    .end local v1    # "realKey":Ljava/lang/String;
    :cond_2
    const-string v2, "IGGLoginSession"

    const-string v3, "dumpExtra end"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 654
    monitor-exit p0

    return-void
.end method

.method public declared-synchronized dumpToLogCat()V
    .locals 3

    .prologue
    .line 660
    monitor-enter p0

    :try_start_0
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session loginType: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 661
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session IGG Id: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 662
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session accessKey: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 663
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session accessKey timeToVerify: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 664
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session bind state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-boolean v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 665
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session thirdPlatformId: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 666
    const-string v0, "IGGLoginSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Session thirdPlatformAccessKey: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 668
    invoke-virtual {p0}, Lcom/igg/sdk/account/IGGAccountSession;->dumpExtra()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 669
    monitor-exit p0

    return-void

    .line 660
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getAccesskey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 442
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getExtra()Ljava/util/Map;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 591
    monitor-enter p0

    :try_start_0
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 593
    .local v0, "data":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    invoke-virtual {v3}, Lcom/igg/util/LocalStorage;->getAll()Ljava/util/Map;

    move-result-object v3

    invoke-interface {v3}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v3

    invoke-interface {v3}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :cond_0
    :goto_0
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/Map$Entry;

    .line 594
    .local v1, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    invoke-interface {v1}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    const-string v5, "com.igg.sdk.account.session.extra."

    invoke-virtual {v3, v5}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 595
    invoke-interface {v1}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    const-string v5, "com.igg.sdk.account.session.extra."

    invoke-virtual {v5}, Ljava/lang/String;->length()I

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v2

    .line 596
    .local v2, "realKey":Ljava/lang/String;
    invoke-interface {v1}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v0, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    .line 591
    .end local v0    # "data":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v1    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;*>;"
    .end local v2    # "realKey":Ljava/lang/String;
    :catchall_0
    move-exception v3

    monitor-exit p0

    throw v3

    .line 600
    .restart local v0    # "data":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_1
    monitor-exit p0

    return-object v0
.end method

.method public declared-synchronized getIGGId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 520
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    .locals 1

    .prologue
    .line 503
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getThirdPlatformAccessKey()Ljava/lang/String;
    .locals 1

    .prologue
    .line 561
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getThirdPlatformId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 543
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getTimeToVerify()Ljava/lang/String;
    .locals 1

    .prologue
    .line 463
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getWeChatName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 583
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->WeChatName:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized isHasBind()Z
    .locals 1

    .prologue
    .line 484
    monitor-enter p0

    :try_start_0
    iget-boolean v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public isValid()Z
    .locals 3

    .prologue
    .line 289
    const-string v1, "IGGLoginSession"

    const-string v2, "In isValid"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 291
    const/4 v0, 0x1

    .line 295
    .local v0, "retValue":Z
    iget-object v1, p0, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v1, v2, :cond_0

    .line 296
    const/4 v0, 0x0

    .line 303
    :goto_0
    if-eqz v0, :cond_2

    .line 304
    const-string v1, "IGGLoginSession"

    const-string v2, "Session is valid"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 309
    :goto_1
    const-string v1, "IGGLoginSession"

    const-string v2, "Out isValid"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 311
    return v0

    .line 300
    :cond_0
    iget-object v1, p0, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_1

    const/4 v0, 0x1

    :goto_2
    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    goto :goto_2

    .line 306
    :cond_2
    const-string v1, "IGGLoginSession"

    const-string v2, "Session is invalid"

    invoke-static {v1, v2}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method public declared-synchronized setAccesskey(Ljava/lang/String;)V
    .locals 3
    .param p1, "accesskey"    # Ljava/lang/String;

    .prologue
    .line 451
    monitor-enter p0

    if-nez p1, :cond_0

    .line 452
    :try_start_0
    const-string p1, ""

    .line 455
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    .line 456
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "accesskey"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->accessKey:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 457
    monitor-exit p0

    return-void

    .line 451
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setExtra(Ljava/util/Map;)V
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 609
    .local p1, "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    monitor-enter p0

    :try_start_0
    invoke-interface {p1}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 610
    .local v0, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "com.igg.sdk.account.session.extra."

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v3, v4, v1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    .line 609
    .end local v0    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    :catchall_0
    move-exception v1

    monitor-exit p0

    throw v1

    .line 612
    :cond_0
    monitor-exit p0

    return-void
.end method

.method public declared-synchronized setHasBind(Z)V
    .locals 3
    .param p1, "hasBind"    # Z

    .prologue
    .line 493
    monitor-enter p0

    :try_start_0
    iput-boolean p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    .line 494
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "hasBind"

    iget-boolean v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->hasBind:Z

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 495
    monitor-exit p0

    return-void

    .line 493
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setIGGId(Ljava/lang/String;)V
    .locals 3
    .param p1, "IGGId"    # Ljava/lang/String;

    .prologue
    .line 529
    monitor-enter p0

    if-nez p1, :cond_0

    .line 530
    :try_start_0
    const-string p1, ""

    .line 533
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;

    .line 534
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "IGGId"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->IGGId:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 535
    monitor-exit p0

    return-void

    .line 529
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setLoginType(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;)V
    .locals 3
    .param p1, "loginType"    # Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .prologue
    .line 512
    monitor-enter p0

    :try_start_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->loginType:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 513
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "loginType"

    invoke-virtual {p1}, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->name()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 514
    monitor-exit p0

    return-void

    .line 512
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setThirdPlatformAccessKey(Ljava/lang/String;)V
    .locals 3
    .param p1, "thirdPlatformAccessKey"    # Ljava/lang/String;

    .prologue
    .line 565
    monitor-enter p0

    if-nez p1, :cond_0

    .line 566
    :try_start_0
    const-string p1, ""

    .line 569
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    .line 570
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "thirdPlatformAccessKey"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformAccessKey:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 571
    monitor-exit p0

    return-void

    .line 565
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setThirdPlatformId(Ljava/lang/String;)V
    .locals 3
    .param p1, "thirdPlatformId"    # Ljava/lang/String;

    .prologue
    .line 547
    monitor-enter p0

    if-nez p1, :cond_0

    .line 548
    :try_start_0
    const-string p1, ""

    .line 551
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    .line 552
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "thirdPlatformId"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->thirdPlatformId:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 553
    monitor-exit p0

    return-void

    .line 547
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setTimeToVerify(Ljava/lang/String;)V
    .locals 3
    .param p1, "timeToVerify"    # Ljava/lang/String;

    .prologue
    .line 472
    monitor-enter p0

    if-nez p1, :cond_0

    .line 473
    :try_start_0
    const-string p1, ""

    .line 476
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    .line 477
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "timetoverify"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->timeToVerify:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 478
    monitor-exit p0

    return-void

    .line 472
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setWeChatName(Ljava/lang/String;)V
    .locals 3
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 574
    monitor-enter p0

    if-nez p1, :cond_0

    .line 575
    :try_start_0
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->WeChatName:Ljava/lang/String;

    .line 578
    :cond_0
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession;->WeChatName:Ljava/lang/String;

    .line 579
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "WeChatName"

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession;->WeChatName:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 580
    monitor-exit p0

    return-void

    .line 574
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public verifyIfNeed(Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;)V
    .locals 14
    .param p1, "listener"    # Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;

    .prologue
    const/4 v1, 0x0

    .line 187
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->restoreAsCurrent()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v12

    .line 189
    .local v12, "session":Lcom/igg/sdk/account/IGGAccountSession;
    invoke-virtual {v12}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v0

    if-eqz v0, :cond_5

    .line 190
    const-string v0, "IGGLoginSession"

    const-string v1, "Session fetched from local storage is valid:"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 191
    invoke-virtual {v12}, Lcom/igg/sdk/account/IGGAccountSession;->dumpToLogCat()V

    .line 194
    invoke-virtual {v12}, Lcom/igg/sdk/account/IGGAccountSession;->getTimeToVerify()Ljava/lang/String;

    move-result-object v13

    .line 195
    .local v13, "timeToVerifyStr":Ljava/lang/String;
    invoke-virtual {v12}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v7

    .line 198
    .local v7, "accessKey":Ljava/lang/String;
    const-string v10, "0"

    .line 200
    .local v10, "flag":Ljava/lang/String;
    :try_start_0
    const-string v0, ""

    invoke-virtual {v13, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3

    .line 201
    new-instance v11, Ljava/util/Date;

    invoke-direct {v11}, Ljava/util/Date;-><init>()V

    .line 202
    .local v11, "nows":Ljava/util/Date;
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd HH:mm:ss"

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v0, v1, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-virtual {v0, v13}, Ljava/text/SimpleDateFormat;->parse(Ljava/lang/String;)Ljava/util/Date;

    move-result-object v9

    .line 204
    .local v9, "expireTime":Ljava/util/Date;
    invoke-virtual {v11}, Ljava/util/Date;->getTime()J

    move-result-wide v0

    invoke-virtual {v9}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    cmp-long v0, v0, v2

    if-ltz v0, :cond_1

    .line 205
    const-string v0, "IGGLoginSession"

    const-string v1, "The current time is greater than the period of time"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 207
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, ""

    const-string v2, ""

    const/4 v3, 0x0

    const-string v4, ""

    const-string v5, ""

    const-string v6, ""

    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    .line 208
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    .line 209
    const/4 v0, 0x1

    const/4 v1, 0x0

    invoke-interface {p1, v0, v1, v12}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V

    .line 283
    .end local v7    # "accessKey":Ljava/lang/String;
    .end local v9    # "expireTime":Ljava/util/Date;
    .end local v10    # "flag":Ljava/lang/String;
    .end local v11    # "nows":Ljava/util/Date;
    .end local v13    # "timeToVerifyStr":Ljava/lang/String;
    :cond_0
    :goto_0
    return-void

    .line 213
    .restart local v7    # "accessKey":Ljava/lang/String;
    .restart local v9    # "expireTime":Ljava/util/Date;
    .restart local v10    # "flag":Ljava/lang/String;
    .restart local v11    # "nows":Ljava/util/Date;
    .restart local v13    # "timeToVerifyStr":Ljava/lang/String;
    :cond_1
    invoke-virtual {v9}, Ljava/util/Date;->getTime()J

    move-result-wide v0

    invoke-virtual {v11}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    sub-long/2addr v0, v2

    const-wide/32 v2, 0x36ee80

    cmp-long v0, v0, v2

    if-gtz v0, :cond_2

    .line 214
    const-string v0, "IGGLoginSession"

    const-string v1, "The current time period of time of less than One hour away"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 215
    const-string v10, "1"

    .line 232
    .end local v9    # "expireTime":Ljava/util/Date;
    .end local v11    # "nows":Ljava/util/Date;
    :goto_1
    const-string v0, "1"

    invoke-virtual {v10, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 234
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v1, Lcom/igg/sdk/account/IGGAccountSession$1;

    invoke-direct {v1, p0, p1, v12, v7}, Lcom/igg/sdk/account/IGGAccountSession$1;-><init>(Lcom/igg/sdk/account/IGGAccountSession;Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;)V

    invoke-virtual {v0, v7, v1}, Lcom/igg/sdk/service/IGGLoginService;->keyLogin(Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/text/ParseException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 277
    :catch_0
    move-exception v8

    .line 278
    .local v8, "e":Ljava/text/ParseException;
    invoke-virtual {v8}, Ljava/text/ParseException;->printStackTrace()V

    goto :goto_0

    .line 217
    .end local v8    # "e":Ljava/text/ParseException;
    .restart local v9    # "expireTime":Ljava/util/Date;
    .restart local v11    # "nows":Ljava/util/Date;
    :cond_2
    :try_start_1
    const-string v0, "IGGLoginSession"

    const-string v1, "Local seesion normal, not expired"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 218
    const/4 v0, 0x0

    const/4 v1, 0x0

    invoke-interface {p1, v0, v1, v12}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_1

    .line 222
    .end local v9    # "expireTime":Ljava/util/Date;
    .end local v11    # "nows":Ljava/util/Date;
    :cond_3
    const-string v0, ""

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_4

    .line 224
    const-string v0, "IGGLoginSession"

    const-string v1, "Local effective time is empty, Session accessKey is not empty"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 225
    const-string v10, "1"

    goto :goto_1

    .line 227
    :cond_4
    const-string v0, "IGGLoginSession"

    const-string v1, "No Local seesion"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 228
    const/4 v0, 0x0

    const/4 v1, 0x0

    invoke-interface {p1, v0, v1, v12}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V
    :try_end_1
    .catch Ljava/text/ParseException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1

    .line 281
    .end local v7    # "accessKey":Ljava/lang/String;
    .end local v10    # "flag":Ljava/lang/String;
    .end local v13    # "timeToVerifyStr":Ljava/lang/String;
    :cond_5
    invoke-interface {p1, v1, v1, v12}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method
