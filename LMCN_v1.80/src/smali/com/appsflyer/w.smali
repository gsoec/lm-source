.class final Lcom/appsflyer/w;
.super Ljava/lang/Object;
.source ""


# static fields
.field private static ˎ:Lcom/appsflyer/w;


# instance fields
.field private final ʻ:Ljava/lang/String;

.field private final ʻॱ:Ljava/lang/String;

.field private final ʼ:Ljava/lang/String;

.field private final ʼॱ:Ljava/lang/String;

.field private final ʽ:Ljava/lang/String;

.field private final ʽॱ:Ljava/lang/String;

.field private final ʾ:Ljava/lang/String;

.field private final ʿ:Ljava/lang/String;

.field private final ˈ:Ljava/lang/String;

.field private ˉ:Lorg/json/JSONArray;

.field private final ˊ:Ljava/lang/String;

.field private final ˊˊ:Ljava/lang/String;

.field private ˊˋ:Lorg/json/JSONObject;

.field private final ˊॱ:Ljava/lang/String;

.field private final ˊᐝ:Ljava/lang/String;

.field private ˋ:Z

.field private ˋˊ:I

.field private final ˋॱ:Ljava/lang/String;

.field private ˌ:Z

.field private ˍ:Ljava/lang/String;

.field private ˏ:Z

.field private final ˏॱ:Ljava/lang/String;

.field private final ͺ:Ljava/lang/String;

.field private final ॱ:Ljava/lang/String;

.field private final ॱˊ:Ljava/lang/String;

.field private final ॱˋ:Ljava/lang/String;

.field private final ॱˎ:Ljava/lang/String;

.field private final ॱॱ:Ljava/lang/String;

.field private final ॱᐝ:Ljava/lang/String;

.field private final ᐝ:Ljava/lang/String;

.field private final ᐝॱ:Ljava/lang/String;


# direct methods
.method private constructor <init>()V
    .locals 2

    .prologue
    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 57
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    iput-boolean v0, p0, Lcom/appsflyer/w;->ˋ:Z

    .line 23
    iput-boolean v0, p0, Lcom/appsflyer/w;->ˏ:Z

    .line 24
    const-string v0, "brand"

    iput-object v0, p0, Lcom/appsflyer/w;->ˊ:Ljava/lang/String;

    .line 25
    const-string v0, "model"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱ:Ljava/lang/String;

    .line 26
    const-string v0, "platform"

    iput-object v0, p0, Lcom/appsflyer/w;->ʼ:Ljava/lang/String;

    .line 27
    const-string v0, "platform_version"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱॱ:Ljava/lang/String;

    .line 28
    const-string v0, "advertiserId"

    iput-object v0, p0, Lcom/appsflyer/w;->ʻ:Ljava/lang/String;

    .line 29
    const-string v0, "imei"

    iput-object v0, p0, Lcom/appsflyer/w;->ʽ:Ljava/lang/String;

    .line 30
    const-string v0, "android_id"

    iput-object v0, p0, Lcom/appsflyer/w;->ᐝ:Ljava/lang/String;

    .line 31
    const-string v0, "sdk_version"

    iput-object v0, p0, Lcom/appsflyer/w;->ˏॱ:Ljava/lang/String;

    .line 32
    const-string v0, "devkey"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱˊ:Ljava/lang/String;

    .line 33
    const-string v0, "originalAppsFlyerId"

    iput-object v0, p0, Lcom/appsflyer/w;->ˊॱ:Ljava/lang/String;

    .line 34
    const-string v0, "uid"

    iput-object v0, p0, Lcom/appsflyer/w;->ͺ:Ljava/lang/String;

    .line 35
    const-string v0, "app_id"

    iput-object v0, p0, Lcom/appsflyer/w;->ˋॱ:Ljava/lang/String;

    .line 36
    const-string v0, "app_version"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱˎ:Ljava/lang/String;

    .line 37
    const-string v0, "channel"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱᐝ:Ljava/lang/String;

    .line 38
    const-string v0, "preInstall"

    iput-object v0, p0, Lcom/appsflyer/w;->ᐝॱ:Ljava/lang/String;

    .line 39
    const-string v0, "data"

    iput-object v0, p0, Lcom/appsflyer/w;->ʻॱ:Ljava/lang/String;

    .line 40
    const-string v0, "r_debugging_off"

    iput-object v0, p0, Lcom/appsflyer/w;->ॱˋ:Ljava/lang/String;

    .line 41
    const-string v0, "r_debugging_on"

    iput-object v0, p0, Lcom/appsflyer/w;->ʼॱ:Ljava/lang/String;

    .line 42
    const-string v0, "public_api_call"

    iput-object v0, p0, Lcom/appsflyer/w;->ʾ:Ljava/lang/String;

    .line 43
    const-string v0, "exception"

    iput-object v0, p0, Lcom/appsflyer/w;->ʿ:Ljava/lang/String;

    .line 44
    const-string v0, "server_request"

    iput-object v0, p0, Lcom/appsflyer/w;->ʽॱ:Ljava/lang/String;

    .line 45
    const-string v0, "server_response"

    iput-object v0, p0, Lcom/appsflyer/w;->ˈ:Ljava/lang/String;

    .line 46
    const-string v0, "yyyy-MM-dd HH:mm:ssZ"

    iput-object v0, p0, Lcom/appsflyer/w;->ˊˊ:Ljava/lang/String;

    .line 47
    const-string v0, "MM-dd HH:mm:ss.SSS"

    iput-object v0, p0, Lcom/appsflyer/w;->ˊᐝ:Ljava/lang/String;

    .line 50
    iput v1, p0, Lcom/appsflyer/w;->ˋˊ:I

    .line 55
    const-string v0, "-1"

    iput-object v0, p0, Lcom/appsflyer/w;->ˍ:Ljava/lang/String;

    .line 58
    new-instance v0, Lorg/json/JSONArray;

    invoke-direct {v0}, Lorg/json/JSONArray;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    .line 59
    iput v1, p0, Lcom/appsflyer/w;->ˋˊ:I

    .line 60
    iput-boolean v1, p0, Lcom/appsflyer/w;->ˌ:Z

    .line 61
    return-void
.end method

.method private declared-synchronized ʼ()V
    .locals 1

    .prologue
    .line 302
    monitor-enter p0

    const/4 v0, 0x0

    :try_start_0
    iput-object v0, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    .line 303
    new-instance v0, Lorg/json/JSONArray;

    invoke-direct {v0}, Lorg/json/JSONArray;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    .line 304
    const/4 v0, 0x0

    iput v0, p0, Lcom/appsflyer/w;->ˋˊ:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 306
    monitor-exit p0

    return-void

    .line 302
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method private declared-synchronized ʽ()Ljava/lang/String;
    .locals 4

    .prologue
    .line 225
    monitor-enter p0

    const/4 v0, 0x0

    .line 228
    :try_start_0
    iget-object v1, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v2, "data"

    iget-object v3, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 230
    iget-object v1, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    .line 232
    invoke-direct {p0}, Lcom/appsflyer/w;->ʼ()V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 237
    :goto_0
    monitor-exit p0

    return-object v0

    .line 225
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0

    :catch_0
    move-exception v1

    goto :goto_0
.end method

.method static ˊ(Ljava/lang/String;Landroid/content/pm/PackageManager;)V
    .locals 5

    .prologue
    .line 5064
    :try_start_0
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    if-nez v0, :cond_0

    .line 5065
    new-instance v0, Lcom/appsflyer/w;

    invoke-direct {v0}, Lcom/appsflyer/w;-><init>()V

    sput-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    .line 5067
    :cond_0
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    .line 95
    invoke-direct {v0, p0, p1}, Lcom/appsflyer/w;->ˋ(Ljava/lang/String;Landroid/content/pm/PackageManager;)V

    .line 7064
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    if-nez v0, :cond_1

    .line 7065
    new-instance v0, Lcom/appsflyer/w;

    invoke-direct {v0}, Lcom/appsflyer/w;-><init>()V

    sput-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    .line 7067
    :cond_1
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    .line 96
    invoke-direct {v0}, Lcom/appsflyer/w;->ʽ()Ljava/lang/String;

    move-result-object v0

    .line 97
    new-instance v1, Lcom/appsflyer/m;

    const/4 v2, 0x0

    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v3

    invoke-virtual {v3}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v3

    invoke-direct {v1, v2, v3}, Lcom/appsflyer/m;-><init>(Landroid/content/Context;Z)V

    .line 99
    iput-object v0, v1, Lcom/appsflyer/m;->ˋ:Ljava/lang/String;

    .line 100
    invoke-virtual {v1}, Lcom/appsflyer/m;->ˏ()V

    .line 101
    const/4 v0, 0x1

    new-array v0, v0, [Ljava/lang/String;

    const/4 v2, 0x0

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "https://monitorsdk.%s/remote-debug?app_id="

    invoke-static {v4}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v0, v2

    invoke-virtual {v1, v0}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 105
    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method private declared-synchronized ˋ(Ljava/lang/String;Landroid/content/pm/PackageManager;)V
    .locals 8

    .prologue
    .line 243
    monitor-enter p0

    :try_start_0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v7

    .line 244
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    .line 245
    const-string v1, "remote_debug_static_data"

    invoke-virtual {v7, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v1

    .line 246
    if-eqz v1, :cond_0

    .line 248
    :try_start_1
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_2
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 279
    :goto_0
    :try_start_2
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "launch_counter"

    iget-object v2, p0, Lcom/appsflyer/w;->ˍ:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_2
    .catch Lorg/json/JSONException; {:try_start_2 .. :try_end_2} :catch_0
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 283
    :goto_1
    monitor-exit p0

    return-void

    .line 252
    :cond_0
    :try_start_3
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    iput-object v1, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    .line 253
    sget-object v1, Landroid/os/Build;->BRAND:Ljava/lang/String;

    sget-object v2, Landroid/os/Build;->MODEL:Ljava/lang/String;

    sget-object v3, Landroid/os/Build$VERSION;->RELEASE:Ljava/lang/String;

    const-string v4, "advertiserId"

    .line 257
    invoke-virtual {v7, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    iget-object v5, v0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    iget-object v6, v0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    move-object v0, p0

    .line 253
    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/w;->ˋ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 260
    const-string v0, "4.8.14.393"

    const-string v1, "AppsFlyerKey"

    .line 262
    invoke-virtual {v7, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "KSAppsFlyerId"

    .line 263
    invoke-virtual {v7, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    const-string v3, "uid"

    .line 264
    invoke-virtual {v7, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 260
    invoke-direct {p0, v0, v1, v2, v3}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 268
    const/4 v0, 0x0

    :try_start_4
    invoke-virtual {p2, p1, v0}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v0

    iget v0, v0, Landroid/content/pm/PackageInfo;->versionCode:I

    .line 269
    const-string v1, "channel"

    invoke-virtual {v7, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 270
    const-string v2, "preInstallName"

    invoke-virtual {v7, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 272
    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, p1, v0, v1, v2}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 275
    :goto_2
    :try_start_5
    const-string v0, "remote_debug_static_data"

    iget-object v1, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v7, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    goto :goto_0

    .line 243
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0

    .line 281
    :catch_0
    move-exception v0

    :try_start_6
    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    goto :goto_1

    :catch_1
    move-exception v0

    goto :goto_2

    .line 250
    :catch_2
    move-exception v0

    goto :goto_0
.end method

.method private declared-synchronized ˋ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 114
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "brand"

    invoke-virtual {v0, v1, p1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 115
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "model"

    invoke-virtual {v0, v1, p2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 116
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "platform"

    const-string v2, "Android"

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 117
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "platform_version"

    invoke-virtual {v0, v1, p3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 118
    if-eqz p4, :cond_0

    invoke-virtual {p4}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_0

    .line 119
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "advertiserId"

    invoke-virtual {v0, v1, p4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 121
    :cond_0
    if-eqz p5, :cond_1

    invoke-virtual {p5}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_1

    .line 122
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "imei"

    invoke-virtual {v0, v1, p5}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 124
    :cond_1
    if-eqz p6, :cond_2

    invoke-virtual {p6}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_2

    .line 125
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "android_id"

    invoke-virtual {v0, v1, p6}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 131
    :cond_2
    :goto_0
    monitor-exit p0

    return-void

    .line 114
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0

    .line 131
    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method static ˎ()Lcom/appsflyer/w;
    .locals 1

    .prologue
    .line 64
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    if-nez v0, :cond_0

    .line 65
    new-instance v0, Lcom/appsflyer/w;

    invoke-direct {v0}, Lcom/appsflyer/w;-><init>()V

    sput-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    .line 67
    :cond_0
    sget-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;

    return-object v0
.end method

.method private declared-synchronized ˎ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 135
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "sdk_version"

    invoke-virtual {v0, v1, p1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 136
    if-eqz p2, :cond_0

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_0

    .line 137
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "devkey"

    invoke-virtual {v0, v1, p2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 139
    :cond_0
    if-eqz p3, :cond_1

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_1

    .line 140
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "originalAppsFlyerId"

    invoke-virtual {v0, v1, p3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 142
    :cond_1
    if-eqz p4, :cond_2

    invoke-virtual {p4}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_2

    .line 143
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "uid"

    invoke-virtual {v0, v1, p4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 148
    :cond_2
    :goto_0
    monitor-exit p0

    return-void

    .line 135
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0

    .line 148
    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method private varargs declared-synchronized ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V
    .locals 6

    .prologue
    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 191
    monitor-enter p0

    .line 9108
    :try_start_0
    iget-boolean v2, p0, Lcom/appsflyer/w;->ˏ:Z

    if-eqz v2, :cond_2

    iget-boolean v2, p0, Lcom/appsflyer/w;->ˋ:Z

    if-nez v2, :cond_0

    iget-boolean v2, p0, Lcom/appsflyer/w;->ˌ:Z

    if-eqz v2, :cond_2

    .line 191
    :cond_0
    :goto_0
    if-eqz v0, :cond_1

    iget v0, p0, Lcom/appsflyer/w;->ˋˊ:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const v1, 0x18000

    if-lt v0, v1, :cond_3

    .line 222
    :cond_1
    :goto_1
    monitor-exit p0

    return-void

    :cond_2
    move v0, v1

    .line 9108
    goto :goto_0

    .line 195
    :cond_3
    :try_start_1
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 196
    const-string v0, ""

    .line 197
    array-length v1, p3

    if-lez v1, :cond_5

    .line 198
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    .line 199
    array-length v0, p3

    add-int/lit8 v0, v0, -0x1

    :goto_2
    if-lez v0, :cond_4

    .line 200
    aget-object v4, p3, v0

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ", "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 199
    add-int/lit8 v0, v0, -0x1

    goto :goto_2

    .line 204
    :cond_4
    const/4 v0, 0x0

    aget-object v0, p3, v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 205
    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    .line 208
    :cond_5
    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v4, "MM-dd HH:mm:ss.SSS"

    sget-object v5, Ljava/util/Locale;->ENGLISH:Ljava/util/Locale;

    invoke-direct {v1, v4, v5}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/text/Format;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    .line 209
    if-eqz p1, :cond_6

    .line 210
    const-string v2, "%18s %5s _/%s [%s] %s %s"

    const/4 v3, 0x6

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object v1, v3, v4

    const/4 v1, 0x1

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Thread;->getId()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    aput-object v4, v3, v1

    const/4 v1, 0x2

    const-string v4, "AppsFlyer_4.8.14"

    aput-object v4, v3, v1

    const/4 v1, 0x3

    aput-object p1, v3, v1

    const/4 v1, 0x4

    aput-object p2, v3, v1

    const/4 v1, 0x5

    aput-object v0, v3, v1

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 216
    :goto_3
    iget-object v1, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    invoke-virtual {v1, v0}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    .line 218
    iget v1, p0, Lcom/appsflyer/w;->ˋˊ:I

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    array-length v0, v0

    add-int/2addr v0, v1

    iput v0, p0, Lcom/appsflyer/w;->ˋˊ:I

    goto :goto_1

    .line 222
    :catch_0
    move-exception v0

    goto :goto_1

    .line 212
    :cond_6
    const-string v2, "%18s %5s %s/%s %s"

    const/4 v3, 0x5

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object v1, v3, v4

    const/4 v1, 0x1

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Thread;->getId()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    aput-object v4, v3, v1

    const/4 v1, 0x2

    aput-object p2, v3, v1

    const/4 v1, 0x3

    const-string v4, "AppsFlyer_4.8.14"

    aput-object v4, v3, v1

    const/4 v1, 0x4

    aput-object v0, v3, v1

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result-object v0

    goto :goto_3

    .line 191
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method private declared-synchronized ॱ(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 152
    monitor-enter p0

    if-eqz p1, :cond_0

    :try_start_0
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_0

    .line 153
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "app_id"

    invoke-virtual {v0, v1, p1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 155
    :cond_0
    if-eqz p2, :cond_1

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_1

    .line 156
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "app_version"

    invoke-virtual {v0, v1, p2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 158
    :cond_1
    if-eqz p3, :cond_2

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_2

    .line 159
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "channel"

    invoke-virtual {v0, v1, p3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 161
    :cond_2
    if-eqz p4, :cond_3

    invoke-virtual {p4}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_3

    .line 162
    iget-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    const-string v1, "preInstall"

    invoke-virtual {v0, v1, p4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 167
    :cond_3
    :goto_0
    monitor-exit p0

    return-void

    .line 152
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0

    .line 167
    :catch_0
    move-exception v0

    goto :goto_0
.end method


# virtual methods
.method final ʻ()Z
    .locals 1

    .prologue
    .line 318
    iget-boolean v0, p0, Lcom/appsflyer/w;->ˌ:Z

    return v0
.end method

.method final declared-synchronized ˊ()V
    .locals 1

    .prologue
    .line 309
    monitor-enter p0

    const/4 v0, 0x0

    :try_start_0
    iput-boolean v0, p0, Lcom/appsflyer/w;->ˋ:Z

    .line 310
    invoke-direct {p0}, Lcom/appsflyer/w;->ʼ()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 311
    monitor-exit p0

    return-void

    .line 309
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method final ˊ(Ljava/lang/String;ILjava/lang/String;)V
    .locals 4

    .prologue
    .line 183
    const-string v0, "server_response"

    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    invoke-static {p2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v2

    const/4 v2, 0x1

    aput-object p3, v1, v2

    invoke-direct {p0, v0, p1, v1}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 184
    return-void
.end method

.method final varargs ˊ(Ljava/lang/String;[Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 170
    const-string v0, "public_api_call"

    invoke-direct {p0, v0, p1, p2}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 171
    return-void
.end method

.method final ˊ(Ljava/lang/Throwable;)V
    .locals 7

    .prologue
    const/4 v0, 0x1

    const/4 v6, 0x0

    .line 174
    invoke-virtual {p1}, Ljava/lang/Throwable;->getCause()Ljava/lang/Throwable;

    move-result-object v2

    .line 175
    const-string v4, "exception"

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v5

    if-nez v2, :cond_0

    invoke-virtual {p1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    move-object v3, v1

    :goto_0
    if-nez v2, :cond_1

    invoke-virtual {p1}, Ljava/lang/Throwable;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    move-object v2, v1

    .line 7286
    :goto_1
    if-nez v2, :cond_2

    .line 7287
    new-array v0, v0, [Ljava/lang/String;

    aput-object v3, v0, v6

    .line 175
    :goto_2
    invoke-direct {p0, v4, v5, v0}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 176
    return-void

    .line 175
    :cond_0
    invoke-virtual {v2}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    move-object v3, v1

    goto :goto_0

    :cond_1
    invoke-virtual {v2}, Ljava/lang/Throwable;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    move-object v2, v1

    goto :goto_1

    .line 7289
    :cond_2
    array-length v1, v2

    add-int/lit8 v1, v1, 0x1

    new-array v1, v1, [Ljava/lang/String;

    .line 7290
    aput-object v3, v1, v6

    .line 7291
    :goto_3
    array-length v3, v2

    if-ge v0, v3, :cond_3

    .line 7292
    aget-object v3, v2, v0

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v0

    .line 7291
    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_3
    move-object v0, v1

    .line 7294
    goto :goto_2
.end method

.method final declared-synchronized ˋ()V
    .locals 1

    .prologue
    .line 87
    monitor-enter p0

    const/4 v0, 0x0

    :try_start_0
    iput-object v0, p0, Lcom/appsflyer/w;->ˊˋ:Lorg/json/JSONObject;

    .line 88
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/appsflyer/w;->ˉ:Lorg/json/JSONArray;

    .line 89
    const/4 v0, 0x0

    sput-object v0, Lcom/appsflyer/w;->ˎ:Lcom/appsflyer/w;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 90
    monitor-exit p0

    return-void

    .line 87
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method final declared-synchronized ˏ()V
    .locals 4

    .prologue
    .line 81
    monitor-enter p0

    :try_start_0
    const-string v0, "r_debugging_off"

    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ssZ"

    sget-object v3, Ljava/util/Locale;->ENGLISH:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/text/Format;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-direct {p0, v0, v1, v2}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 82
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/appsflyer/w;->ˌ:Z

    .line 83
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/appsflyer/w;->ˋ:Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 84
    monitor-exit p0

    return-void

    .line 81
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method final declared-synchronized ˏ(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 71
    monitor-enter p0

    :try_start_0
    iput-object p1, p0, Lcom/appsflyer/w;->ˍ:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 72
    monitor-exit p0

    return-void

    .line 71
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method final ˏ(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 179
    const-string v0, "server_request"

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    aput-object p2, v1, v2

    invoke-direct {p0, v0, p1, v1}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 180
    return-void
.end method

.method final declared-synchronized ॱ()V
    .locals 4

    .prologue
    .line 76
    monitor-enter p0

    const/4 v0, 0x1

    :try_start_0
    iput-boolean v0, p0, Lcom/appsflyer/w;->ˌ:Z

    .line 77
    const-string v0, "r_debugging_on"

    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ssZ"

    sget-object v3, Ljava/util/Locale;->ENGLISH:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/text/Format;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-direct {p0, v0, v1, v2}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 78
    monitor-exit p0

    return-void

    .line 76
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method final ॱ(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 187
    const/4 v0, 0x0

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    aput-object p2, v1, v2

    invoke-direct {p0, v0, p1, v1}, Lcom/appsflyer/w;->ˎ(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V

    .line 188
    return-void
.end method

.method final ॱॱ()V
    .locals 1

    .prologue
    .line 314
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/appsflyer/w;->ˏ:Z

    .line 315
    return-void
.end method
