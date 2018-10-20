.class public Lcom/appsflyer/AppsFlyerProperties;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;
    }
.end annotation


# static fields
.field public static final ADDITIONAL_CUSTOM_DATA:Ljava/lang/String; = "additionalCustomData"

.field public static final AF_KEY:Ljava/lang/String; = "AppsFlyerKey"

.field public static final AF_WAITFOR_CUSTOMERID:Ljava/lang/String; = "waitForCustomerId"

.field public static final APP_ID:Ljava/lang/String; = "appid"

.field public static final APP_USER_ID:Ljava/lang/String; = "AppUserId"

.field public static final CHANNEL:Ljava/lang/String; = "channel"

.field public static final COLLECT_ANDROID_ID:Ljava/lang/String; = "collectAndroidId"

.field public static final COLLECT_ANDROID_ID_FORCE_BY_USER:Ljava/lang/String; = "collectAndroidIdForceByUser"

.field public static final COLLECT_FACEBOOK_ATTR_ID:Ljava/lang/String; = "collectFacebookAttrId"

.field public static final COLLECT_FINGER_PRINT:Ljava/lang/String; = "collectFingerPrint"

.field public static final COLLECT_IMEI:Ljava/lang/String; = "collectIMEI"

.field public static final COLLECT_IMEI_FORCE_BY_USER:Ljava/lang/String; = "collectIMEIForceByUser"

.field public static final COLLECT_MAC:Ljava/lang/String; = "collectMAC"

.field public static final CURRENCY_CODE:Ljava/lang/String; = "currencyCode"

.field public static final DEVICE_TRACKING_DISABLED:Ljava/lang/String; = "deviceTrackingDisabled"

.field public static final DISABLE_KEYSTORE:Ljava/lang/String; = "keyPropDisableAFKeystore"

.field public static final DISABLE_LOGS_COMPLETELY:Ljava/lang/String; = "disableLogs"

.field public static final DISABLE_OTHER_SDK:Ljava/lang/String; = "disableOtherSdk"

.field public static final EMAIL_CRYPT_TYPE:Ljava/lang/String; = "userEmailsCryptType"

.field public static final ENABLE_GPS_FALLBACK:Ljava/lang/String; = "enableGpsFallback"

.field public static final EXTENSION:Ljava/lang/String; = "sdkExtension"

.field public static final IS_MONITOR:Ljava/lang/String; = "shouldMonitor"

.field public static final IS_UPDATE:Ljava/lang/String; = "IS_UPDATE"

.field public static final LAUNCH_PROTECT_ENABLED:Ljava/lang/String; = "launchProtectEnabled"

.field public static final ONELINK_DOMAIN:Ljava/lang/String; = "onelinkDomain"

.field public static final ONELINK_ID:Ljava/lang/String; = "oneLinkSlug"

.field public static final ONELINK_SCHEME:Ljava/lang/String; = "onelinkScheme"

.field public static final USER_EMAIL:Ljava/lang/String; = "userEmail"

.field public static final USER_EMAILS:Ljava/lang/String; = "userEmails"

.field public static final USE_HTTP_FALLBACK:Ljava/lang/String; = "useHttpFallback"

.field private static ˊ:Lcom/appsflyer/AppsFlyerProperties;


# instance fields
.field private ˋ:Z

.field private ˎ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation
.end field

.field private ˏ:Z

.field private ॱ:Ljava/lang/String;

.field private ᐝ:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 70
    new-instance v0, Lcom/appsflyer/AppsFlyerProperties;

    invoke-direct {v0}, Lcom/appsflyer/AppsFlyerProperties;-><init>()V

    sput-object v0, Lcom/appsflyer/AppsFlyerProperties;->ˊ:Lcom/appsflyer/AppsFlyerProperties;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .prologue
    .line 97
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 72
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    .line 76
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ᐝ:Z

    .line 98
    return-void
.end method

.method public static getInstance()Lcom/appsflyer/AppsFlyerProperties;
    .locals 1

    .prologue
    .line 101
    sget-object v0, Lcom/appsflyer/AppsFlyerProperties;->ˊ:Lcom/appsflyer/AppsFlyerProperties;

    return-object v0
.end method


# virtual methods
.method public getBoolean(Ljava/lang/String;Z)Z
    .locals 1

    .prologue
    .line 138
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 139
    if-nez v0, :cond_0

    .line 142
    :goto_0
    return p2

    :cond_0
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p2

    goto :goto_0
.end method

.method public getInt(Ljava/lang/String;I)I
    .locals 1

    .prologue
    .line 154
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 155
    if-nez v0, :cond_0

    .line 158
    :goto_0
    return p2

    :cond_0
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result p2

    goto :goto_0
.end method

.method public getLong(Ljava/lang/String;J)J
    .locals 2

    .prologue
    .line 162
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 163
    if-nez v0, :cond_0

    .line 166
    :goto_0
    return-wide p2

    :cond_0
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide p2

    goto :goto_0
.end method

.method public getObject(Ljava/lang/String;)Ljava/lang/Object;
    .locals 1

    .prologue
    .line 170
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public getReferrer(Landroid/content/Context;)Ljava/lang/String;
    .locals 3

    .prologue
    const/4 v0, 0x0

    .line 199
    iget-object v1, p0, Lcom/appsflyer/AppsFlyerProperties;->ॱ:Ljava/lang/String;

    if-eqz v1, :cond_1

    .line 200
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ॱ:Ljava/lang/String;

    .line 208
    :cond_0
    :goto_0
    return-object v0

    .line 201
    :cond_1
    const-string v1, "AF_REFERRER"

    invoke-virtual {p0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_2

    .line 202
    const-string v0, "AF_REFERRER"

    invoke-virtual {p0, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 204
    :cond_2
    if-eqz p1, :cond_0

    .line 207
    const-string v1, "appsflyer-data"

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    .line 208
    const-string v2, "referrer"

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method public getString(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 134
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    return-object v0
.end method

.method public isEnableLog()Z
    .locals 2

    .prologue
    .line 217
    const-string v0, "shouldLog"

    const/4 v1, 0x1

    invoke-virtual {p0, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    return v0
.end method

.method protected isFirstLaunchCalled()Z
    .locals 1

    .prologue
    .line 183
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˋ:Z

    return v0
.end method

.method public isLogsDisabledCompletely()Z
    .locals 2

    .prologue
    .line 221
    const-string v0, "disableLogs"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    return v0
.end method

.method protected isOnReceiveCalled()Z
    .locals 1

    .prologue
    .line 175
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˏ:Z

    return v0
.end method

.method public isOtherSdkStringDisabled()Z
    .locals 2

    .prologue
    .line 224
    const-string v0, "disableOtherSdk"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    return v0
.end method

.method public loadProperties(Landroid/content/Context;)V
    .locals 5

    .prologue
    .line 244
    .line 3269
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ᐝ:Z

    .line 244
    if-eqz v0, :cond_1

    .line 266
    :cond_0
    :goto_0
    return-void

    .line 247
    :cond_1
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p1, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 248
    const-string v1, "savedProperties"

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 249
    if-eqz v0, :cond_0

    .line 250
    const-string v1, "Loading properties.."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 252
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 253
    invoke-virtual {v1}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v2

    .line 254
    :cond_2
    :goto_1
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    .line 255
    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 256
    iget-object v3, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v3, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    if-nez v3, :cond_2

    .line 257
    iget-object v3, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 261
    :catch_0
    move-exception v0

    .line 262
    const-string v1, "Failed loading properties"

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 264
    :goto_2
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "Done loading properties: "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v1, p0, Lcom/appsflyer/AppsFlyerProperties;->ᐝ:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto :goto_0

    .line 260
    :cond_3
    const/4 v0, 0x1

    :try_start_1
    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ᐝ:Z
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_2
.end method

.method public remove(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 79
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 80
    return-void
.end method

.method public saveProperties(Landroid/content/SharedPreferences;)V
    .locals 3
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "CommitPrefEdits"
        }
    .end annotation

    .prologue
    .line 230
    new-instance v0, Lorg/json/JSONObject;

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-direct {v0, v1}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    .line 232
    invoke-interface {p1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v1

    .line 233
    const-string v2, "savedProperties"

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 235
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x9

    if-lt v0, v2, :cond_0

    .line 236
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V

    .line 240
    :goto_0
    return-void

    .line 238
    :cond_0
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method public set(Ljava/lang/String;I)V
    .locals 2

    .prologue
    .line 113
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-static {p2}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 114
    return-void
.end method

.method public set(Ljava/lang/String;J)V
    .locals 2

    .prologue
    .line 117
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-static {p2, p3}, Ljava/lang/Long;->toString(J)Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 118
    return-void
.end method

.method public set(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 105
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 106
    return-void
.end method

.method public set(Ljava/lang/String;Z)V
    .locals 2

    .prologue
    .line 121
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-static {p2}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 122
    return-void
.end method

.method public set(Ljava/lang/String;[Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 109
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 110
    return-void
.end method

.method public setCustomData(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 125
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    const-string v1, "additionalCustomData"

    invoke-interface {v0, v1, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 126
    return-void
.end method

.method protected setFirstLaunchCalled()V
    .locals 1

    .prologue
    .line 190
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˋ:Z

    .line 191
    return-void
.end method

.method protected setFirstLaunchCalled(Z)V
    .locals 0

    .prologue
    .line 187
    iput-boolean p1, p0, Lcom/appsflyer/AppsFlyerProperties;->ˋ:Z

    .line 188
    return-void
.end method

.method protected setOnReceiveCalled()V
    .locals 1

    .prologue
    .line 179
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˏ:Z

    .line 180
    return-void
.end method

.method protected setReferrer(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 194
    const-string v0, "AF_REFERRER"

    invoke-virtual {p0, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 195
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerProperties;->ॱ:Ljava/lang/String;

    .line 196
    return-void
.end method

.method public setUserEmails(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 129
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerProperties;->ˎ:Ljava/util/Map;

    const-string v1, "userEmails"

    invoke-interface {v0, v1, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 130
    return-void
.end method
