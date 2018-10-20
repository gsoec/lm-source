.class public Lcom/igg/sdk/account/IGGAccountLogin;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;,
        Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;,
        Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;
    }
.end annotation


# static fields
.field public static ACCESS_KEY_EXPIRED_IN:I = 0x0

.field private static final GOOGLE_TOKEN_NULL_ERROR:I = 0x30d43

.field private static final GUEST_LOGIN_GUSET_ID_EMPTY_ERROR:I = 0x30d42

.field private static final GUEST_LOGIN_RETURN_IGGID_ERROR:I = 0x30d46

.field private static final GUEST_LOGIN_RETURN_LOGIN_ERROR:I = 0x30d45

.field private static final LOGIN_UNKNOWN_ERROR:I = 0x30d4a

.field public static final TAG:Ljava/lang/String; = "IGGLogin"

.field private static final THIRD_LOGIN_RETURN_HANDLE_ERROR:I = 0x30d43

.field private static final THIRD_PLATFORM_PARAMETER_ERROR:I = 0x30d41


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 46
    const v0, 0x278d00

    sput v0, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getExpireTime()Ljava/lang/String;
    .locals 8

    .prologue
    .line 848
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd HH:mm:ss"

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v0, v1, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 849
    .local v0, "df":Ljava/text/SimpleDateFormat;
    new-instance v1, Ljava/util/Date;

    invoke-direct {v1}, Ljava/util/Date;-><init>()V

    invoke-virtual {v1}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    sget v1, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    int-to-long v4, v1

    const-wide/16 v6, 0x3e8

    mul-long/2addr v4, v6

    add-long/2addr v2, v4

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/text/SimpleDateFormat;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    return-object v1
.end method


# virtual methods
.method public login(Lcom/igg/sdk/account/LoginListener;Lcom/igg/sdk/account/LoginDelegate;)V
    .locals 9
    .param p1, "listener"    # Lcom/igg/sdk/account/LoginListener;
    .param p2, "delegate"    # Lcom/igg/sdk/account/LoginDelegate;

    .prologue
    .line 135
    const-string v6, "IGGLogin"

    const-string v7, "Attempt to restore session from local storage"

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 138
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->restoreAsCurrent()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v4

    .line 139
    .local v4, "session":Lcom/igg/sdk/account/IGGAccountSession;
    if-eqz p2, :cond_1

    .line 141
    invoke-interface {p2}, Lcom/igg/sdk/account/LoginDelegate;->thirdPlatformAccessToken()Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;

    move-result-object v0

    .line 142
    .local v0, "accessToken":Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;
    if-eqz v0, :cond_1

    .line 143
    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v6

    sget-object v7, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v6, v7, :cond_0

    .line 144
    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->getUserID()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getThirdPlatformId()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_1

    .line 145
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    .line 147
    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->getUserID()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->getTokenString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {p0, v6, v7, p1}, Lcom/igg/sdk/account/IGGAccountLogin;->loginWithFacebook(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    .line 253
    .end local v0    # "accessToken":Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;
    :goto_0
    return-void

    .line 151
    .restart local v0    # "accessToken":Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;
    :cond_0
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    .line 153
    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->getUserID()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->getTokenString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {p0, v6, v7, p1}, Lcom/igg/sdk/account/IGGAccountLogin;->loginWithFacebook(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    goto :goto_0

    .line 160
    .end local v0    # "accessToken":Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;
    :cond_1
    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v6

    if-eqz v6, :cond_2

    .line 161
    const-string v6, "IGGLogin"

    const-string v7, "Session fetched from local storage is valid:"

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 162
    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->dumpToLogCat()V

    .line 163
    new-instance v6, Lcom/igg/sdk/account/IGGAccountLogin$1;

    invoke-direct {v6, p0, p1}, Lcom/igg/sdk/account/IGGAccountLogin$1;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;)V

    invoke-virtual {v4, v6}, Lcom/igg/sdk/account/IGGAccountSession;->verifyIfNeed(Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;)V

    goto :goto_0

    .line 182
    :cond_2
    const-string v6, "IGGLogin"

    const-string v7, "Session fetched from local storage is valid. Trying to login as guest with device identifier"

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 186
    :try_start_0
    const-string v6, "IGGLogin"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "IGGSDK.sharedInstance().getDeviceRegisterId() device ID:"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 187
    const/4 v3, 0x0

    .line 188
    .local v3, "ifDelayPost":Z
    new-instance v1, Lcom/igg/sdk/IGGDeviceStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v6

    invoke-direct {v1, v6}, Lcom/igg/sdk/IGGDeviceStorage;-><init>(Landroid/content/Context;)V

    .line 189
    .local v1, "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    invoke-virtual {v1}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v5

    .line 190
    .local v5, "stroageDeviceUIDStr":Ljava/lang/String;
    const-string v6, "IGGLogin"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "IGGSDK.sharedInstance().isChinaMainland()====="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->isChinaMainland()Z

    move-result v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 192
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->isChinaMainland()Z

    move-result v6

    if-nez v6, :cond_6

    invoke-virtual {v1}, Lcom/igg/sdk/IGGDeviceStorage;->getEmulatorFlag()Z

    move-result v6

    if-nez v6, :cond_6

    .line 194
    const-string v6, ""

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_3

    const-string v6, "gaid"

    invoke-virtual {v5, v6}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v6

    const/4 v7, -0x1

    if-ne v6, v7, :cond_4

    .line 195
    :cond_3
    const-string v6, "IGGLogin"

    const-string v7, "gaid Delay"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 196
    const/4 v3, 0x1

    .line 199
    :cond_4
    if-eqz v3, :cond_5

    .line 201
    new-instance v6, Lcom/igg/sdk/account/IGGAccountLogin$2;

    invoke-direct {v6, p0, v5, v1, p1}, Lcom/igg/sdk/account/IGGAccountLogin$2;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Lcom/igg/sdk/IGGDeviceStorage;Lcom/igg/sdk/account/LoginListener;)V

    invoke-static {v6}, Lcom/igg/util/DeviceUtil;->getAdvertisingId(Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 250
    .end local v1    # "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    .end local v3    # "ifDelayPost":Z
    .end local v5    # "stroageDeviceUIDStr":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 251
    .local v2, "e":Ljava/lang/Exception;
    const v6, 0x30d4a

    invoke-static {v2, v6}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const/4 v7, 0x0

    invoke-interface {p1, v6, v7}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto/16 :goto_0

    .line 245
    .end local v2    # "e":Ljava/lang/Exception;
    .restart local v1    # "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    .restart local v3    # "ifDelayPost":Z
    .restart local v5    # "stroageDeviceUIDStr":Ljava/lang/String;
    :cond_5
    :try_start_1
    new-instance v6, Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {v6}, Lcom/igg/sdk/account/IGGDeviceGuest;-><init>()V

    invoke-virtual {p0, v6, p1}, Lcom/igg/sdk/account/IGGAccountLogin;->loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V

    goto/16 :goto_0

    .line 248
    :cond_6
    new-instance v6, Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {v6}, Lcom/igg/sdk/account/IGGDeviceGuest;-><init>()V

    invoke-virtual {p0, v6, p1}, Lcom/igg/sdk/account/IGGAccountLogin;->loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method

.method public loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V
    .locals 10
    .param p1, "guest"    # Lcom/igg/sdk/account/IGGGuest;
    .param p2, "listener"    # Lcom/igg/sdk/account/LoginListener;

    .prologue
    .line 267
    new-instance v1, Lcom/igg/sdk/IGGDeviceStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v6

    invoke-direct {v1, v6}, Lcom/igg/sdk/IGGDeviceStorage;-><init>(Landroid/content/Context;)V

    .line 268
    .local v1, "deviceStorageContent":Lcom/igg/sdk/IGGDeviceStorage;
    invoke-virtual {v1}, Lcom/igg/sdk/IGGDeviceStorage;->currentDeviceUID()Ljava/lang/String;

    move-result-object v0

    .line 270
    .local v0, "currentDeviceUID":Ljava/lang/String;
    new-instance v4, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v4}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 273
    .local v4, "logininfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    :try_start_0
    invoke-virtual {p1}, Lcom/igg/sdk/account/IGGGuest;->getIdentifier()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v5

    .line 280
    .local v5, "mGuest":Ljava/lang/String;
    :goto_0
    if-eqz v5, :cond_0

    const-string v6, ""

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 281
    :cond_0
    const-string v6, "loginAsGuest"

    const-string v7, "uuid as deviceid "

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 283
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v6

    invoke-static {v6}, Lcom/igg/util/UUIDUtil;->getUUID(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 284
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "uuid="

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v1, v6}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 285
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "uuid="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 288
    :cond_1
    if-eqz v5, :cond_2

    const-string v6, ""

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_3

    .line 289
    :cond_2
    new-instance v6, Ljava/lang/Exception;

    const-string v7, "DeviceId is null"

    invoke-direct {v6, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v7, 0x30d42

    invoke-static {v6, v7}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const/4 v7, 0x0

    invoke-interface {p2, v6, v7}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 340
    :goto_1
    return-void

    .line 274
    .end local v5    # "mGuest":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 275
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 276
    move-object v5, v0

    .restart local v5    # "mGuest":Ljava/lang/String;
    goto :goto_0

    .line 293
    .end local v2    # "e":Ljava/lang/Exception;
    :cond_3
    invoke-virtual {v4, v5}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGuest(Ljava/lang/String;)V

    .line 295
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v3

    .line 296
    .local v3, "expireTime":Ljava/lang/String;
    const-string v6, "GuestLoginOperation"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "expireTime\uff1a"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 297
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    invoke-virtual {v6, v8, v9}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, ""

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v6}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKey(Ljava/lang/String;)V

    .line 298
    sget v6, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v4, v6}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 299
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v6}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 301
    new-instance v6, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v6}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v7, Lcom/igg/sdk/account/IGGAccountLogin$3;

    invoke-direct {v7, p0, p2, v3, v1}, Lcom/igg/sdk/account/IGGAccountLogin$3;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;Ljava/lang/String;Lcom/igg/sdk/IGGDeviceStorage;)V

    invoke-virtual {v6, v4, v7}, Lcom/igg/sdk/service/IGGLoginService;->guestLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    goto :goto_1
.end method

.method public loginVKAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 5
    .param p1, "platformKey"    # Ljava/lang/String;
    .param p2, "platformId"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/LoginListener;

    .prologue
    const/4 v4, 0x0

    const v3, 0x30d41

    .line 486
    if-eqz p1, :cond_0

    const-string v1, ""

    invoke-virtual {p1, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 487
    :cond_0
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "platformKey is empty"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v1, v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-interface {p3, v1, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 553
    :goto_0
    return-void

    .line 491
    :cond_1
    if-eqz p2, :cond_2

    const-string v1, ""

    invoke-virtual {p2, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_3

    .line 492
    :cond_2
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "platformId is empty"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v1, v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-interface {p3, v1, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0

    .line 496
    :cond_3
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 497
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "access_key"

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 498
    const-string v1, "platform_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 499
    const-string v1, "platform_id"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 500
    const-string v1, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 502
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "/vk/connect"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/account/IGGAccountLogin$7;

    invoke-direct {v3, p0, p3, p1}, Lcom/igg/sdk/account/IGGAccountLogin$7;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;Ljava/lang/String;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->CGIGeneralGetRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    goto :goto_0
.end method

.method public loginWithAmazon(Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 6
    .param p1, "amazonAccessToken"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/LoginListener;

    .prologue
    .line 440
    new-instance v2, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v2}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 441
    .local v2, "logininfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 442
    const-string v3, "Amazon"

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setType(Ljava/lang/String;)V

    .line 443
    invoke-virtual {v2, p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->setAuthCode(Ljava/lang/String;)V

    .line 444
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v1

    .line 445
    .local v1, "expireTime":Ljava/lang/String;
    const-string v3, "loginWithAmazon"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "expireTime\uff1a"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 446
    sget v3, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 448
    :try_start_0
    new-instance v3, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v4, Lcom/igg/sdk/account/IGGAccountLogin$6;

    invoke-direct {v4, p0, v1, p2}, Lcom/igg/sdk/account/IGGAccountLogin$6;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/service/IGGLoginService;->thirdAmazonAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 476
    :goto_0
    return-void

    .line 473
    :catch_0
    move-exception v0

    .line 474
    .local v0, "e":Ljava/lang/Exception;
    const v3, 0x30d41

    invoke-static {v0, v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    const/4 v4, 0x0

    invoke-interface {p2, v3, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method

.method public loginWithFacebook(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 9
    .param p1, "platform_id"    # Ljava/lang/String;
    .param p2, "platform_key"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/LoginListener;

    .prologue
    .line 351
    new-instance v7, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v7}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 352
    .local v7, "logininfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v2

    .line 353
    .local v2, "expireTime":Ljava/lang/String;
    const-string v0, "GuestLoginOperation"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "expireTime\uff1a"

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 354
    sget v0, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 355
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 356
    invoke-virtual {v7, p2}, Lcom/igg/sdk/bean/IGGLoginInfo;->setRd_access_key(Ljava/lang/String;)V

    .line 357
    invoke-virtual {v7, p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->setPlatformId(Ljava/lang/String;)V

    .line 358
    const-string v0, "Facebook"

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setType(Ljava/lang/String;)V

    .line 359
    const/4 v0, 0x1

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setFlag(I)V

    .line 361
    :try_start_0
    new-instance v8, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v8}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v0, Lcom/igg/sdk/account/IGGAccountLogin$4;

    move-object v1, p0

    move-object v3, p2

    move-object v4, p1

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/account/IGGAccountLogin$4;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    invoke-virtual {v8, v7, v0}, Lcom/igg/sdk/service/IGGLoginService;->thirdFacebookAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 385
    :goto_0
    return-void

    .line 382
    :catch_0
    move-exception v6

    .line 383
    .local v6, "e":Ljava/lang/Exception;
    const v0, 0x30d41

    invoke-static {v6, v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v0

    const/4 v1, 0x0

    invoke-interface {p3, v0, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method

.method public loginWithIGGAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;)V
    .locals 5
    .param p1, "username"    # Ljava/lang/String;
    .param p2, "password"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;

    .prologue
    .line 679
    const-string v3, "/public/igg_login"

    invoke-static {v3}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 681
    .local v0, "API":Ljava/lang/String;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 682
    .local v2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 683
    const-string v3, "m_name"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 684
    const-string v3, "m_pass"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 685
    const-string v3, "m_keeptime"

    sget v4, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-static {v4}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 686
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v1

    .line 688
    .local v1, "expireTime":Ljava/lang/String;
    new-instance v3, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v4, Lcom/igg/sdk/account/IGGAccountLogin$9;

    invoke-direct {v4, p0, p3, v1}, Lcom/igg/sdk/account/IGGAccountLogin$9;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/IGGAccountLogin$IGGLoginListener;Ljava/lang/String;)V

    invoke-virtual {v3, v0, v2, v4}, Lcom/igg/sdk/service/IGGService;->CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 739
    return-void
.end method

.method public loginWithWeChat(Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
    .locals 6
    .param p1, "weChatAuthCode"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/account/LoginListener;

    .prologue
    .line 394
    new-instance v2, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v2}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 395
    .local v2, "logininfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 396
    const-string v3, "WeChat"

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setType(Ljava/lang/String;)V

    .line 397
    invoke-virtual {v2, p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->setAuthCode(Ljava/lang/String;)V

    .line 398
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v1

    .line 399
    .local v1, "expireTime":Ljava/lang/String;
    const-string v3, "loginWithWeChat"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "expireTime\uff1a"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 400
    sget v3, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 402
    :try_start_0
    new-instance v3, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v4, Lcom/igg/sdk/account/IGGAccountLogin$5;

    invoke-direct {v4, p0, v1, p2}, Lcom/igg/sdk/account/IGGAccountLogin$5;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/service/IGGLoginService;->thirdWechatAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 431
    :goto_0
    return-void

    .line 427
    :catch_0
    move-exception v0

    .line 428
    .local v0, "e":Ljava/lang/Exception;
    const v3, 0x30d41

    invoke-static {v0, v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    const/4 v4, 0x0

    invoke-interface {p2, v3, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0
.end method

.method public registerIGGAccount(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;)V
    .locals 6
    .param p1, "username"    # Ljava/lang/String;
    .param p2, "password"    # Ljava/lang/String;
    .param p3, "email"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    .prologue
    .line 747
    const/4 v4, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v5, p4

    invoke-virtual/range {v0 .. v5}, Lcom/igg/sdk/account/IGGAccountLogin;->registerIGGAccount(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;)V

    .line 748
    return-void
.end method

.method public registerIGGAccount(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;)V
    .locals 5
    .param p1, "username"    # Ljava/lang/String;
    .param p2, "password"    # Ljava/lang/String;
    .param p3, "email"    # Ljava/lang/String;
    .param p4, "loginAtSameTime"    # Z
    .param p5, "listener"    # Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;

    .prologue
    .line 762
    const-string v3, "/public/igg_register"

    invoke-static {v3}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 764
    .local v0, "API":Ljava/lang/String;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 765
    .local v2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v3, "m_game_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 766
    const-string v3, "m_name"

    invoke-virtual {v2, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 767
    const-string v3, "m_pass"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 768
    const-string v3, "m_pass2"

    invoke-virtual {v2, v3, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 769
    const-string v3, "email"

    invoke-virtual {v2, v3, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 771
    const-string v3, "m_keeptime"

    sget v4, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-static {v4}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 772
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v1

    .line 774
    .local v1, "expireTime":Ljava/lang/String;
    new-instance v3, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v4, Lcom/igg/sdk/account/IGGAccountLogin$10;

    invoke-direct {v4, p0, p5, p4, v1}, Lcom/igg/sdk/account/IGGAccountLogin$10;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/IGGAccountLogin$IGGRegisterListener;ZLjava/lang/String;)V

    invoke-virtual {v3, v0, v2, v4}, Lcom/igg/sdk/service/IGGService;->CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 840
    return-void
.end method

.method public switchAccount(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
    .locals 4
    .param p1, "email"    # Ljava/lang/String;
    .param p2, "activity"    # Landroid/app/Activity;
    .param p3, "listener"    # Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    .prologue
    .line 564
    new-instance v0, Lcom/igg/sdk/account/IGGAccountLogin$8;

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/igg/sdk/account/IGGAccountLogin$8;-><init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V

    .line 668
    .local v0, "task":Landroid/os/AsyncTask;, "Landroid/os/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    const/4 v1, 0x1

    new-array v2, v1, [Ljava/lang/Object;

    const/4 v3, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v2, v3

    invoke-virtual {v0, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    .line 669
    return-void
.end method
