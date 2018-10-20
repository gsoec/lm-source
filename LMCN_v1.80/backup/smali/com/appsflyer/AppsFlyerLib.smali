.class public Lcom/appsflyer/AppsFlyerLib;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/a;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/AppsFlyerLib$c;,
        Lcom/appsflyer/AppsFlyerLib$e;,
        Lcom/appsflyer/AppsFlyerLib$b;,
        Lcom/appsflyer/AppsFlyerLib$d;,
        Lcom/appsflyer/AppsFlyerLib$a;
    }
.end annotation


# static fields
.field public static final AF_PRE_INSTALL_PATH:Ljava/lang/String; = "AF_PRE_INSTALL_PATH"

.field public static final ATTRIBUTION_ID_COLUMN_NAME:Ljava/lang/String; = "aid"

.field public static final ATTRIBUTION_ID_CONTENT_URI:Ljava/lang/String; = "content://com.facebook.katana.provider.AttributionIdProvider"

.field public static final IS_STOP_TRACKING_USED:Ljava/lang/String; = "is_stop_tracking_used"

.field public static final LOG_TAG:Ljava/lang/String; = "AppsFlyer_4.8.14"

.field public static final PRE_INSTALL_SYSTEM_DEFAULT:Ljava/lang/String; = "/data/local/tmp/pre_install.appsflyer"

.field public static final PRE_INSTALL_SYSTEM_DEFAULT_ETC:Ljava/lang/String; = "/etc/pre_install.appsflyer"

.field public static final PRE_INSTALL_SYSTEM_RO_PROP:Ljava/lang/String; = "ro.appsflyer.preinstall.path"

.field private static ʻ:Ljava/lang/String;

.field private static ʼ:Ljava/lang/String;

.field private static ʽॱ:Lcom/appsflyer/AppsFlyerLib;

.field static final ˊ:Ljava/lang/String;

.field private static final ˋॱ:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field static final ˎ:Ljava/lang/String;

.field static ˏ:Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;

.field private static final ˏॱ:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

.field private static ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

.field private static ॱॱ:Ljava/lang/String;

.field private static final ᐝ:Ljava/lang/String;


# instance fields
.field private ʻॱ:Z

.field private ʼॱ:J

.field private ʽ:J

.field private ʾ:Ljava/util/concurrent/ScheduledExecutorService;

.field private ʿ:Lcom/appsflyer/q$c;

.field private ˈ:J

.field private ˉ:Ljava/lang/String;

.field private ˊˊ:Landroid/net/Uri;

.field private ˊˋ:J

.field private ˊॱ:J

.field private ˊᐝ:Z

.field ˋ:Ljava/lang/String;

.field private ˋˊ:Z

.field private ˋˋ:Lcom/appsflyer/r;

.field private ˋᐝ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Long;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ˌ:Z

.field private ˍ:Z

.field private ˎˎ:Z

.field private ˏˎ:Z

.field ॱ:Ljava/lang/String;

.field private ॱˊ:J

.field private ॱˎ:Lcom/appsflyer/c;

.field private ॱᐝ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ᐝॱ:J


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .prologue
    const/4 v5, 0x1

    const/4 v4, 0x0

    const/4 v3, 0x0

    .line 76
    const-string v0, "4.8.14"

    const-string v1, "4.8.14"

    const-string v2, "."

    invoke-virtual {v1, v2}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v1

    invoke-virtual {v0, v3, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ˊ:Ljava/lang/String;

    .line 81
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ˊ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "/androidevent?buildnumber=4.8.14&app_id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ᐝ:Ljava/lang/String;

    .line 82
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "https://attr.%s/api/v"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ᐝ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ʻ:Ljava/lang/String;

    .line 83
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "https://t.%s/api/v"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ᐝ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ʼ:Ljava/lang/String;

    .line 84
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "https://events.%s/api/v"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ᐝ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ॱॱ:Ljava/lang/String;

    .line 85
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "https://register.%s/api/v"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ᐝ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ˎ:Ljava/lang/String;

    .line 117
    new-array v0, v5, [Ljava/lang/String;

    const-string v1, "is_cache"

    aput-object v1, v0, v3

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ˏॱ:Ljava/util/List;

    .line 118
    const/4 v0, 0x3

    new-array v0, v0, [Ljava/lang/String;

    const-string v1, "googleplay"

    aput-object v1, v0, v3

    const-string v1, "playstore"

    aput-object v1, v0, v5

    const/4 v1, 0x2

    const-string v2, "googleplaystore"

    aput-object v2, v0, v1

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ˋॱ:Ljava/util/List;

    .line 143
    sput-object v4, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    .line 144
    sput-object v4, Lcom/appsflyer/AppsFlyerLib;->ˏ:Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;

    .line 145
    sput-object v4, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    .line 162
    new-instance v0, Lcom/appsflyer/AppsFlyerLib;

    invoke-direct {v0}, Lcom/appsflyer/AppsFlyerLib;-><init>()V

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ʽॱ:Lcom/appsflyer/AppsFlyerLib;

    return-void
.end method

.method private constructor <init>()V
    .locals 6

    .prologue
    const-wide/16 v0, -0x1

    const/4 v5, 0x0

    const/4 v4, 0x0

    .line 375
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 94
    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʽ:J

    .line 95
    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˊ:J

    .line 140
    sget-object v0, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    const-wide/16 v2, 0x5

    invoke-virtual {v0, v2, v3}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˊॱ:J

    .line 147
    iput-object v5, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    .line 150
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ʻॱ:Z

    .line 152
    iput-object v5, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    .line 168
    iput-object v5, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    .line 170
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˊᐝ:Z

    .line 171
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˊ:Z

    .line 176
    new-instance v0, Lcom/appsflyer/r;

    invoke-direct {v0}, Lcom/appsflyer/r;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    .line 177
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˎˎ:Z

    .line 178
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˏˎ:Z

    .line 376
    invoke-static {}, Lcom/appsflyer/AFVersionDeclaration;->init()V

    .line 377
    return-void
.end method

.method public static getInstance()Lcom/appsflyer/AppsFlyerLib;
    .locals 1

    .prologue
    .line 382
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ʽॱ:Lcom/appsflyer/AppsFlyerLib;

    return-object v0
.end method

.method private static ʻ(Landroid/content/Context;)F
    .locals 6

    .prologue
    const/4 v5, -0x1

    .line 3362
    const/high16 v0, 0x3f800000    # 1.0f

    .line 3364
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    const/4 v2, 0x0

    new-instance v3, Landroid/content/IntentFilter;

    const-string v4, "android.intent.action.BATTERY_CHANGED"

    invoke-direct {v3, v4}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1, v2, v3}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    move-result-object v1

    .line 3365
    const-string v2, "level"

    const/4 v3, -0x1

    invoke-virtual {v1, v2, v3}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result v2

    .line 3366
    const-string v3, "scale"

    const/4 v4, -0x1

    invoke-virtual {v1, v3, v4}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result v0

    .line 3369
    if-eq v2, v5, :cond_0

    if-ne v0, v5, :cond_1

    .line 3370
    :cond_0
    const/high16 v0, 0x42480000    # 50.0f

    .line 3379
    :goto_0
    return v0

    .line 3373
    :cond_1
    int-to-float v1, v2

    int-to-float v0, v0

    div-float v0, v1, v0

    const/high16 v1, 0x42c80000    # 100.0f

    mul-float/2addr v0, v1

    .line 3377
    goto :goto_0

    .line 3375
    :catch_0
    move-exception v1

    .line 3376
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private static ʼ(Landroid/content/Context;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 2408
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "api_store_value"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 2410
    if-eqz v0, :cond_1

    .line 2418
    :cond_0
    :goto_0
    return-object v0

    .line 2414
    :cond_1
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    const-string v1, "AF_STORE"

    invoke-static {v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 2415
    if-nez v0, :cond_0

    .line 2418
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private static ˊ(Ljava/lang/String;Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/lang/String;
    .locals 4
    .annotation build Landroid/support/annotation/Nullable;
    .end annotation

    .prologue
    .line 2444
    const/4 v0, 0x0

    .line 2446
    const/16 v1, 0x80

    :try_start_0
    invoke-virtual {p1, p2, v1}, Landroid/content/pm/PackageManager;->getApplicationInfo(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;

    move-result-object v1

    .line 2447
    iget-object v1, v1, Landroid/content/pm/PackageItemInfo;->metaData:Landroid/os/Bundle;

    .line 2448
    if-eqz v1, :cond_0

    .line 2449
    invoke-virtual {v1, p0}, Landroid/os/Bundle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    .line 2450
    if-eqz v1, :cond_0

    .line 2451
    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 2458
    :cond_0
    :goto_0
    return-object v0

    .line 2454
    :catch_0
    move-exception v1

    .line 2455
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Could not find "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " value in the manifest"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private static ˊ(Ljava/lang/String;)Ljava/util/Map;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 1394
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 1397
    :try_start_0
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, p0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 1398
    invoke-virtual {v2}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v3

    .line 1399
    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 1400
    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 1401
    sget-object v4, Lcom/appsflyer/AppsFlyerLib;->ˏॱ:Ljava/util/List;

    invoke-interface {v4, v0}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 1402
    invoke-virtual {v2, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 1403
    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-nez v5, :cond_0

    const-string v5, "null"

    invoke-virtual {v5, v4}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_0

    .line 1404
    invoke-interface {v1, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 1408
    :catch_0
    move-exception v0

    .line 1409
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 1410
    const/4 v0, 0x0

    .line 1413
    :goto_1
    return-object v0

    :cond_1
    move-object v0, v1

    goto :goto_1
.end method

.method static synthetic ˊ(Lcom/appsflyer/AppsFlyerLib;)Ljava/util/concurrent/ScheduledExecutorService;
    .locals 1

    .prologue
    .line 71
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    return-object v0
.end method

.method static ˊ(Landroid/content/Context;Ljava/lang/String;)V
    .locals 8

    .prologue
    .line 313
    const-string v0, "received a new (extra) referrer: "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 317
    :try_start_0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    .line 319
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 320
    const-string v1, "extraReferrers"

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 321
    if-nez v0, :cond_2

    .line 322
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 323
    new-instance v0, Lorg/json/JSONArray;

    invoke-direct {v0}, Lorg/json/JSONArray;-><init>()V

    .line 332
    :goto_0
    invoke-virtual {v0}, Lorg/json/JSONArray;->length()I

    move-result v2

    int-to-long v2, v2

    const-wide/16 v6, 0x5

    cmp-long v2, v2, v6

    if-gez v2, :cond_0

    .line 333
    invoke-virtual {v0, v4, v5}, Lorg/json/JSONArray;->put(J)Lorg/json/JSONArray;

    .line 337
    :cond_0
    invoke-virtual {v1}, Lorg/json/JSONObject;->length()I

    move-result v2

    int-to-long v2, v2

    const-wide/16 v4, 0x4

    cmp-long v2, v2, v4

    if-ltz v2, :cond_1

    .line 338
    invoke-static {v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Lorg/json/JSONObject;)V

    .line 341
    :cond_1
    invoke-virtual {v0}, Lorg/json/JSONArray;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, p1, v0}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 344
    const-string v0, "extraReferrers"

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    .line 53874
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p0, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    .line 55876
    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v2

    .line 55877
    invoke-interface {v2, v0, v1}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 56880
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x9

    if-lt v0, v1, :cond_4

    .line 56881
    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->apply()V

    :goto_1
    return-void

    .line 325
    :cond_2
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 326
    invoke-virtual {v2, p1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 327
    new-instance v1, Lorg/json/JSONArray;

    invoke-virtual {v2, p1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-direct {v1, v0}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    move-object v0, v1

    move-object v1, v2

    goto :goto_0

    .line 329
    :cond_3
    new-instance v0, Lorg/json/JSONArray;

    invoke-direct {v0}, Lorg/json/JSONArray;-><init>()V

    move-object v1, v2

    goto :goto_0

    .line 56883
    :cond_4
    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->commit()Z
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_1

    .line 349
    :catch_0
    move-exception v0

    goto :goto_1

    .line 347
    :catch_1
    move-exception v0

    .line 348
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "Couldn\'t save referrer - "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ": "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_1
.end method

.method static synthetic ˊ(Landroid/content/Context;Ljava/lang/String;I)V
    .locals 0

    .prologue
    .line 71
    invoke-static {p0, p1, p2}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;I)V

    return-void
.end method

.method private static ˊ(Landroid/content/Context;Ljava/lang/String;J)V
    .locals 4

    .prologue
    .line 539
    .line 61949
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 64950
    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 64951
    invoke-interface {v0, p1, p2, p3}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 0
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x9

    if-lt v1, v2, :cond_0

    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    .line 540
    :goto_0
    return-void

    .line 0
    :cond_0
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method static synthetic ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 71
    invoke-static {p0, p1, p2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method static synthetic ˊ(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZZLandroid/content/Intent;)V
    .locals 11

    .prologue
    .line 71
    .line 0
    if-nez p1, :cond_0

    const-string v0, "sendTrackingWithEvent - got null context. skipping event/launch."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 71
    :goto_0
    return-void

    .line 0
    :cond_0
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p1, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v7

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, v7}, Lcom/appsflyer/AppsFlyerProperties;->saveProperties(Landroid/content/SharedPreferences;)V

    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v0

    if-nez v0, :cond_1

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "sendTrackingWithEvent from activity: "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    :cond_1
    if-nez p3, :cond_3

    const/4 v8, 0x1

    :goto_1
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object/from16 v5, p5

    move/from16 v6, p6

    move-object/from16 v9, p8

    invoke-virtual/range {v0 .. v9}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLandroid/content/SharedPreferences;ZLandroid/content/Intent;)Ljava/util/Map;

    move-result-object v6

    const-string v0, "appsflyerKey"

    invoke-interface {v6, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    if-eqz v0, :cond_2

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-nez v0, :cond_4

    :cond_2
    const-string v0, "Not sending data yet, waiting for dev key"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto :goto_0

    :cond_3
    const/4 v8, 0x0

    goto :goto_1

    :cond_4
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v0

    if-nez v0, :cond_5

    const-string v0, "AppsFlyerLib.sendTrackingWithEvent"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    :cond_5
    if-eqz v8, :cond_a

    if-eqz p7, :cond_9

    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ʻ:Ljava/lang/String;

    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    :goto_2
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    const-string v0, "appsFlyerCount"

    const/4 v1, 0x0

    invoke-static {v7, v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v9

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "collectAndroidIdForceByUser"

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-nez v0, :cond_6

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "collectIMEIForceByUser"

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_b

    :cond_6
    const/4 v0, 0x1

    :goto_3
    if-nez v0, :cond_8

    const-string v0, "advertiserId"

    invoke-interface {v6, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_8

    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_7

    const-string v0, "android_id"

    invoke-interface {v6, v0}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_7

    const-string v0, "validateGaidAndIMEI :: removing: android_id"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    :cond_7
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_8

    const-string v0, "imei"

    invoke-interface {v6, v0}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_8

    const-string v0, "validateGaidAndIMEI :: removing: imei"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_8
    :goto_4
    new-instance v3, Lcom/appsflyer/AppsFlyerLib$d;

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v7

    const/4 v10, 0x0

    move-object v4, p0

    invoke-direct/range {v3 .. v10}, Lcom/appsflyer/AppsFlyerLib$d;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/util/Map;Landroid/content/Context;ZIB)V

    if-eqz v8, :cond_d

    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_d

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    if-eqz v0, :cond_c

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->size()I

    move-result v0

    if-lez v0, :cond_c

    const/4 v0, 0x1

    :goto_5
    if-nez v0, :cond_d

    const-string v0, "Failed to get new referrer, wait ..."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v0

    const-wide/16 v4, 0x1f4

    sget-object v1, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v0, v3, v4, v5, v1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V

    goto/16 :goto_0

    :cond_9
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ʼ:Ljava/lang/String;

    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto/16 :goto_2

    :cond_a
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ॱॱ:Ljava/lang/String;

    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto/16 :goto_2

    :cond_b
    const/4 v0, 0x0

    goto :goto_3

    :catch_0
    move-exception v0

    const-string v1, "failed to remove IMEI or AndroidID key from params; "

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_4

    :cond_c
    const/4 v0, 0x0

    goto :goto_5

    :cond_d
    invoke-interface {v3}, Ljava/lang/Runnable;->run()V

    goto/16 :goto_0
.end method

.method private ˊ()Z
    .locals 11

    .prologue
    const/4 v10, 0x3

    const/4 v9, 0x2

    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 1457
    iget-wide v2, p0, Lcom/appsflyer/AppsFlyerLib;->ʽ:J

    const-wide/16 v4, 0x0

    cmp-long v2, v2, v4

    if-lez v2, :cond_2

    .line 1458
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 1459
    iget-wide v4, p0, Lcom/appsflyer/AppsFlyerLib;->ʽ:J

    sub-long/2addr v2, v4

    .line 1460
    const-string v4, "yyyy/MM/dd HH:mm:ss.SSS Z"

    .line 0
    new-instance v5, Ljava/text/SimpleDateFormat;

    sget-object v6, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v5, v4, v6}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 1461
    iget-wide v6, p0, Lcom/appsflyer/AppsFlyerLib;->ʽ:J

    .line 0
    const-string v4, "UTC"

    invoke-static {v4}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v4

    invoke-virtual {v5, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v4, Ljava/util/Date;

    invoke-direct {v4, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v5, v4}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    .line 1462
    iget-wide v6, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˊ:J

    .line 0
    const-string v8, "UTC"

    invoke-static {v8}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v8

    invoke-virtual {v5, v8}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v8, Ljava/util/Date;

    invoke-direct {v8, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v5, v8}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v5

    .line 1464
    iget-wide v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˊॱ:J

    cmp-long v6, v2, v6

    if-gez v6, :cond_0

    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v6

    if-nez v6, :cond_0

    .line 1465
    const-string v6, "Last Launch attempt: %s;\nLast successful Launch event: %s;\nThis launch is blocked: %s ms < %s ms"

    .line 1466
    sget-object v7, Ljava/util/Locale;->US:Ljava/util/Locale;

    const/4 v8, 0x4

    new-array v8, v8, [Ljava/lang/Object;

    aput-object v4, v8, v1

    aput-object v5, v8, v0

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v8, v9

    iget-wide v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˊॱ:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v8, v10

    invoke-static {v7, v6, v8}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1480
    :goto_0
    return v0

    .line 1470
    :cond_0
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v6

    if-nez v6, :cond_1

    .line 1471
    const-string v6, "Last Launch attempt: %s;\nLast successful Launch event: %s;\nSending launch (+%s ms)"

    .line 1472
    sget-object v7, Ljava/util/Locale;->US:Ljava/util/Locale;

    new-array v8, v10, [Ljava/lang/Object;

    aput-object v4, v8, v1

    aput-object v5, v8, v0

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    aput-object v0, v8, v9

    invoke-static {v7, v6, v8}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    :cond_1
    :goto_1
    move v0, v1

    .line 1480
    goto :goto_0

    .line 1476
    :cond_2
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v0

    if-nez v0, :cond_1

    .line 1477
    const-string v0, "Sending first launch for this session!"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    goto :goto_1
.end method

.method private static ˊ(Landroid/content/Context;)Z
    .locals 5

    .prologue
    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 2272
    :try_start_0
    invoke-static {}, Lcom/google/android/gms/common/GoogleApiAvailability;->getInstance()Lcom/google/android/gms/common/GoogleApiAvailability;

    move-result-object v2

    invoke-virtual {v2, p0}, Lcom/google/android/gms/common/GoogleApiAvailability;->isGooglePlayServicesAvailable(Landroid/content/Context;)I
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result v2

    .line 2273
    if-nez v2, :cond_0

    .line 2288
    :goto_0
    return v0

    .line 2277
    :catch_0
    move-exception v2

    .line 2278
    const-string v3, "WARNING:  Google play services is unavailable. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 2282
    :cond_0
    :try_start_1
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    const-string v3, "com.google.android.gms"

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;
    :try_end_1
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_0

    .line 2284
    :catch_1
    move-exception v0

    .line 2285
    const-string v2, "WARNING:  Google Play Services is unavailable. "

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move v0, v1

    .line 2288
    goto :goto_0
.end method

.method static ˋ(Landroid/content/SharedPreferences;)I
    .locals 2

    .prologue
    .line 2702
    const-string v0, "appsFlyerCount"

    const/4 v1, 0x0

    invoke-static {p0, v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v0

    return v0
.end method

.method static synthetic ˋ(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Landroid/content/pm/PackageManager$NameNotFoundException;
        }
    .end annotation

    .prologue
    .line 71
    invoke-static {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static ˋ(Ljava/lang/String;)Ljava/lang/String;
    .locals 6

    .prologue
    const/4 v1, 0x0

    .line 2422
    .line 2425
    :try_start_0
    const-string v0, "android.os.SystemProperties"

    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v0

    const-string v2, "get"

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/Class;

    const/4 v4, 0x0

    const-class v5, Ljava/lang/String;

    aput-object v5, v3, v4

    .line 2426
    invoke-virtual {v0, v2, v3}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v2, 0x0

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object p0, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 2430
    :goto_0
    return-object v0

    .line 2427
    :catch_0
    move-exception v0

    .line 2428
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v0, v1

    goto :goto_0
.end method

.method static synthetic ˋ()Ljava/util/List;
    .locals 1

    .prologue
    .line 71
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ˋॱ:Ljava/util/List;

    return-object v0
.end method

.method private static ˋ(Landroid/content/Context;Ljava/lang/String;I)V
    .locals 3

    .prologue
    .line 532
    .line 60942
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 533
    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 534
    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;

    .line 63943
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x9

    if-lt v1, v2, :cond_0

    .line 63944
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    :goto_0
    return-void

    .line 63946
    :cond_0
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method private static ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 1147
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "shouldMonitor"

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1149
    new-instance v0, Landroid/content/Intent;

    const-string v1, "com.appsflyer.MonitorBroadcast"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1150
    const-string v1, "com.appsflyer.nightvision"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setPackage(Ljava/lang/String;)Landroid/content/Intent;

    .line 1151
    const-string v1, "message"

    invoke-virtual {v0, v1, p2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1152
    const-string v1, "value"

    invoke-virtual {v0, v1, p3}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1153
    const-string v1, "packageName"

    const-string v2, "true"

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1154
    const-string v1, "pid"

    new-instance v2, Ljava/lang/Integer;

    invoke-static {}, Landroid/os/Process;->myPid()I

    move-result v3

    invoke-direct {v2, v3}, Ljava/lang/Integer;-><init>(I)V

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/io/Serializable;)Landroid/content/Intent;

    .line 1155
    const-string v1, "eventIdentifier"

    invoke-virtual {v0, v1, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1156
    const-string v1, "sdk"

    const-string v2, "4.8.14"

    invoke-virtual {v0, v1, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1158
    invoke-virtual {p0, v0}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 1161
    :cond_0
    return-void
.end method

.method static synthetic ˋ(Ljava/util/Map;)V
    .locals 2

    .prologue
    .line 0
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    if-eqz v0, :cond_0

    :try_start_0
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    invoke-interface {v0, p0}, Lcom/appsflyer/AppsFlyerConversionListener;->onAppOpenAttribution(Ljava/util/Map;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 71
    :cond_0
    :goto_0
    return-void

    .line 0
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private static ˋ(Landroid/content/Context;)Z
    .locals 3
    .param p0    # Landroid/content/Context;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    const/4 v0, 0x0

    .line 866
    .line 0
    const-string v1, "appsflyer-data"

    invoke-virtual {p0, v1, v0}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    const-string v2, "appsFlyerCount"

    invoke-static {v1, v2, v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v1

    .line 869
    const/4 v2, 0x2

    if-le v1, v2, :cond_0

    .line 870
    const-string v1, "Install referrer will not load, the counter > 2, "

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    .line 888
    :goto_0
    return v0

    .line 875
    :cond_0
    :try_start_0
    const-string v1, "com.android.installreferrer.api.InstallReferrerClient"

    invoke-static {v1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    .line 876
    const-string v1, "com.google.android.finsky.permission.BIND_GET_INSTALL_REFERRER_SERVICE"

    invoke-static {p0, v1}, Lcom/appsflyer/i$b;->ˎ(Landroid/content/Context;Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 877
    const-string v1, "Install referrer is allowed"

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    .line 878
    const/4 v0, 0x1

    goto :goto_0

    .line 881
    :catch_0
    move-exception v1

    const-string v1, "Class com.android.installreferrer.api.InstallReferrerClient not found"

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    goto :goto_0

    .line 883
    :catch_1
    move-exception v1

    .line 884
    const-string v2, "An error occurred while trying to verify manifest : com.android.installreferrer.api.InstallReferrerClient"

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 887
    :cond_1
    const-string v1, "Install referrer is not allowed"

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto :goto_0
.end method

.method static synthetic ˋ(Lcom/appsflyer/AppsFlyerLib;)Z
    .locals 1

    .prologue
    .line 71
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʻॱ:Z

    return v0
.end method

.method private static ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I
    .locals 4

    .prologue
    .line 2712
    const/4 v0, 0x0

    invoke-interface {p0, p1, v0}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v0

    .line 2714
    if-eqz p2, :cond_0

    .line 2715
    add-int/lit8 v0, v0, 0x1

    .line 2716
    invoke-interface {p0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v1

    .line 2717
    invoke-interface {v1, p1, v0}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;

    .line 0
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0x9

    if-lt v2, v3, :cond_2

    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V

    .line 2721
    :cond_0
    :goto_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    invoke-virtual {v1}, Lcom/appsflyer/w;->ʻ()Z

    move-result v1

    if-eqz v1, :cond_1

    .line 2722
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/appsflyer/w;->ˏ(Ljava/lang/String;)V

    .line 2725
    :cond_1
    return v0

    .line 0
    :cond_2
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method static synthetic ˎ(Lcom/appsflyer/AppsFlyerLib;J)J
    .locals 1

    .prologue
    .line 71
    iput-wide p1, p0, Lcom/appsflyer/AppsFlyerLib;->ᐝॱ:J

    return-wide p1
.end method

.method private static ˎ(Ljava/lang/String;)Ljava/io/File;
    .locals 2

    .prologue
    .line 2565
    if-eqz p0, :cond_0

    :try_start_0
    invoke-virtual {p0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-lez v0, :cond_0

    .line 2566
    new-instance v0, Ljava/io/File;

    invoke-virtual {p0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/io/File;-><init>(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 2571
    :goto_0
    return-object v0

    .line 2568
    :catch_0
    move-exception v0

    .line 2569
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 2571
    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private static ˎ(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;
    .locals 3
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Landroid/content/pm/PackageManager$NameNotFoundException;
        }
    .end annotation

    .prologue
    .line 2645
    .line 0
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 2646
    const-string v1, "CACHED_CHANNEL"

    invoke-interface {v0, v1}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 2647
    const-string v1, "CACHED_CHANNEL"

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    .line 2651
    :goto_0
    return-object p1

    .line 2650
    :cond_0
    const-string v0, "CACHED_CHANNEL"

    invoke-static {p0, v0, p1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method static synthetic ˎ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "channel"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_0

    const-string v0, "CHANNEL"

    invoke-static {p0, v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 71
    :cond_0
    return-object v0
.end method

.method private static ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;
    .locals 2
    .annotation build Landroid/support/annotation/Nullable;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;",
            "Ljava/lang/String;",
            ")",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 2436
    invoke-virtual {p0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    .line 2437
    const/4 v0, 0x0

    .line 2439
    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v1

    invoke-virtual {p0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    invoke-static {p1, v1, v0}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Ljava/lang/String;Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method static synthetic ˎ(Landroid/content/Context;)Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/appsflyer/l;
        }
    .end annotation

    .prologue
    .line 71
    invoke-static {p0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;)Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method static synthetic ˎ(Landroid/content/Context;Ljava/lang/String;J)V
    .locals 0

    .prologue
    .line 71
    invoke-static {p0, p1, p2, p3}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;J)V

    return-void
.end method

.method private static ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 517
    .line 59935
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 518
    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 519
    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 62936
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x9

    if-lt v1, v2, :cond_0

    .line 62937
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    :goto_0
    return-void

    .line 62939
    :cond_0
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method private ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/content/Intent;)V
    .locals 11

    .prologue
    .line 1418
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    .line 1419
    if-nez p3, :cond_1

    const/4 v0, 0x1

    .line 0
    :goto_0
    const-string v1, "waitForCustomerId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const/4 v4, 0x0

    invoke-virtual {v2, v1, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v1

    if-eqz v1, :cond_2

    const-string v1, "AppUserId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-nez v1, :cond_2

    const/4 v1, 0x1

    .line 1421
    :goto_1
    if-eqz v1, :cond_3

    .line 1422
    const-string v0, "CustomerUserId not set, Tracking is disabled"

    const/4 v1, 0x1

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 1454
    :cond_0
    :goto_2
    return-void

    .line 1419
    :cond_1
    const/4 v0, 0x0

    goto :goto_0

    .line 0
    :cond_2
    const/4 v1, 0x0

    goto :goto_1

    .line 1427
    :cond_3
    if-eqz v0, :cond_4

    .line 1429
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "launchProtectEnabled"

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    .line 1430
    if-eqz v0, :cond_5

    .line 1431
    invoke-direct {p0}, Lcom/appsflyer/AppsFlyerLib;->ˊ()Z

    move-result v0

    if-nez v0, :cond_0

    .line 1437
    :goto_3
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʽ:J

    .line 1439
    :cond_4
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v7

    .line 1443
    new-instance v0, Lcom/appsflyer/AppsFlyerLib$a;

    new-instance v2, Ljava/lang/ref/WeakReference;

    invoke-direct {v2, v3}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    const/4 v8, 0x0

    const/4 v10, 0x0

    move-object v1, p0

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object/from16 v6, p5

    move-object/from16 v9, p6

    invoke-direct/range {v0 .. v10}, Lcom/appsflyer/AppsFlyerLib$a;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/ref/WeakReference;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/concurrent/ExecutorService;ZLandroid/content/Intent;B)V

    .line 1453
    const-wide/16 v2, 0x96

    sget-object v1, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v7, v0, v2, v3, v1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V

    goto :goto_2

    .line 1435
    :cond_5
    const-string v0, "Allowing multiple launches within a 5 second time window."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    goto :goto_3
.end method

.method private ˎ(Ljava/net/URL;Ljava/lang/String;Ljava/lang/String;Ljava/lang/ref/WeakReference;Ljava/lang/String;Z)V
    .locals 10
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/net/URL;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;",
            "Ljava/lang/String;",
            "Z)V"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 2791
    invoke-virtual {p4}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    .line 2792
    if-eqz p6, :cond_9

    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    if-eqz v1, :cond_9

    const/4 v1, 0x1

    move v2, v1

    .line 2793
    :goto_0
    const/4 v3, 0x0

    .line 2795
    :try_start_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4, p2}, Lcom/appsflyer/w;->ˏ(Ljava/lang/String;Ljava/lang/String;)V

    .line 2796
    invoke-virtual {p1}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v1

    check-cast v1, Ljava/net/HttpURLConnection;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_2

    .line 2797
    :try_start_1
    const-string v3, "POST"

    invoke-virtual {v1, v3}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 2798
    invoke-virtual {p2}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    array-length v3, v3

    .line 2799
    const-string v4, "Content-Length"

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v4, v3}, Ljava/net/URLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 2800
    const-string v3, "Content-Type"

    const-string v4, "application/json"

    invoke-virtual {v1, v3, v4}, Ljava/net/URLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 2801
    const/16 v3, 0x2710

    invoke-virtual {v1, v3}, Ljava/net/URLConnection;->setConnectTimeout(I)V

    .line 2802
    const/4 v3, 0x1

    invoke-virtual {v1, v3}, Ljava/net/URLConnection;->setDoOutput(Z)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 2805
    const/4 v4, 0x0

    .line 2807
    :try_start_2
    new-instance v3, Ljava/io/OutputStreamWriter;

    invoke-virtual {v1}, Ljava/net/URLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v5

    const-string v6, "UTF-8"

    invoke-direct {v3, v5, v6}, Ljava/io/OutputStreamWriter;-><init>(Ljava/io/OutputStream;Ljava/lang/String;)V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 2808
    :try_start_3
    invoke-virtual {v3, p2}, Ljava/io/Writer;->write(Ljava/lang/String;)V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_3

    .line 2811
    :try_start_4
    invoke-virtual {v3}, Ljava/io/Writer;->close()V

    .line 2820
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v3

    .line 2822
    invoke-static {v1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/net/HttpURLConnection;)Ljava/lang/String;

    move-result-object v4

    .line 2823
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v5

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6, v3, v4}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;ILjava/lang/String;)V

    .line 2824
    const-string v5, "response code: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 2825
    const-string v5, "AppsFlyer_4.8.14"

    const-string v6, "SERVER_RESPONSE_CODE"

    invoke-static {v3}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v7

    invoke-static {v0, v5, v6, v7}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 0
    const-string v5, "appsflyer-data"

    const/4 v6, 0x0

    invoke-virtual {v0, v5, v6}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v5

    .line 2827
    const/16 v6, 0xc8

    if-ne v3, v6, :cond_f

    .line 2831
    invoke-virtual {p4}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v3

    if-eqz v3, :cond_0

    if-eqz p6, :cond_0

    .line 2832
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    iput-wide v6, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˊ:J

    .line 2833
    sget-object v3, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    if-eqz v3, :cond_0

    .line 2834
    sget-object v3, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    invoke-interface {v3}, Lcom/appsflyer/AppsFlyerTrackingRequestListener;->onTrackingRequestSuccess()V

    .line 2838
    :cond_0
    const-string v3, "afUninstallToken"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v6

    invoke-virtual {v6, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 2839
    if-eqz v3, :cond_d

    .line 2840
    const-string v6, "Uninstall Token exists: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 2842
    const-string v6, "sentRegisterRequestToAF"

    const/4 v7, 0x0

    invoke-interface {v5, v6, v7}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v6

    .line 2843
    if-nez v6, :cond_1

    .line 2844
    const-string v6, "Resending Uninstall token to AF servers: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 2845
    new-instance v6, Lcom/appsflyer/b;

    invoke-direct {v6, v3}, Lcom/appsflyer/b;-><init>(Ljava/lang/String;)V

    .line 2846
    invoke-static {v0, v6}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    .line 2854
    :cond_1
    :goto_1
    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    if-eqz v3, :cond_2

    .line 2855
    const/4 v3, 0x0

    iput-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    .line 2857
    :cond_2
    if-eqz p5, :cond_3

    .line 2858
    invoke-static {}, Lcom/appsflyer/cache/CacheManager;->getInstance()Lcom/appsflyer/cache/CacheManager;

    move-result-object v3

    invoke-virtual {v3, p5, v0}, Lcom/appsflyer/cache/CacheManager;->deleteRequest(Ljava/lang/String;Landroid/content/Context;)V

    .line 2860
    :cond_3
    invoke-virtual {p4}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v3

    if-eqz v3, :cond_4

    if-nez p5, :cond_4

    .line 2862
    const-string v3, "sentSuccessfully"

    const-string v6, "true"

    invoke-static {v0, v3, v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    .line 0
    iget-boolean v3, p0, Lcom/appsflyer/AppsFlyerLib;->ʻॱ:Z

    if-nez v3, :cond_4

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    iget-wide v8, p0, Lcom/appsflyer/AppsFlyerLib;->ᐝॱ:J

    sub-long/2addr v6, v8

    const-wide/16 v8, 0x3a98

    cmp-long v3, v6, v8

    if-gez v3, :cond_e

    .line 2866
    :cond_4
    :goto_2
    invoke-static {v4}, Lcom/appsflyer/ServerConfigHandler;->ˋ(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 2868
    const-string v4, "send_background"

    const/4 v6, 0x0

    invoke-virtual {v3, v4, v6}, Lorg/json/JSONObject;->optBoolean(Ljava/lang/String;Z)Z

    move-result v3

    iput-boolean v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˎˎ:Z

    .line 2876
    :cond_5
    :goto_3
    const-string v3, "appsflyerConversionDataRequestRetries"

    const/4 v4, 0x0

    invoke-interface {v5, v3, v4}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v3

    .line 2878
    const-string v4, "appsflyerConversionDataCacheExpiration"

    const-wide/16 v6, 0x0

    invoke-interface {v5, v4, v6, v7}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v6

    .line 2879
    const-wide/16 v8, 0x0

    cmp-long v4, v6, v8

    if-eqz v4, :cond_6

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    sub-long v6, v8, v6

    const-wide v8, 0x134fd9000L

    cmp-long v4, v6, v8

    if-lez v4, :cond_6

    .line 2880
    const-string v4, "attributionId"

    const/4 v6, 0x0

    invoke-static {v0, v4, v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    .line 2881
    const-string v4, "appsflyerConversionDataCacheExpiration"

    const-wide/16 v6, 0x0

    invoke-static {v0, v4, v6, v7}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;J)V

    .line 2884
    :cond_6
    const-string v4, "attributionId"

    const/4 v6, 0x0

    invoke-interface {v5, v4, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    if-nez v4, :cond_10

    if-eqz p3, :cond_10

    if-eqz v2, :cond_10

    sget-object v4, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    if-eqz v4, :cond_10

    const/4 v4, 0x5

    if-gt v3, v4, :cond_10

    .line 2886
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v2

    .line 2888
    new-instance v3, Lcom/appsflyer/AppsFlyerLib$b;

    invoke-virtual {v0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    invoke-direct {v3, p0, v0, p3, v2}, Lcom/appsflyer/AppsFlyerLib$b;-><init>(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/util/concurrent/ScheduledExecutorService;)V

    .line 2891
    const-wide/16 v4, 0xa

    sget-object v0, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v2, v3, v4, v5, v0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_1

    .line 2921
    :cond_7
    :goto_4
    if-eqz v1, :cond_8

    .line 2922
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    .line 2925
    :cond_8
    return-void

    .line 2792
    :cond_9
    const/4 v1, 0x0

    move v2, v1

    goto/16 :goto_0

    .line 2810
    :catchall_0
    move-exception v0

    move-object v2, v4

    :goto_5
    if-eqz v2, :cond_c

    .line 2811
    :try_start_5
    invoke-virtual {v2}, Ljava/io/Writer;->close()V

    .line 2814
    :cond_a
    :goto_6
    throw v0
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_1

    .line 2921
    :catchall_1
    move-exception v0

    :goto_7
    if-eqz v1, :cond_b

    .line 2922
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_b
    throw v0

    .line 2813
    :cond_c
    :try_start_6
    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    if-eqz v2, :cond_a

    .line 2814
    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    const-string v3, "No Connectivity"

    invoke-interface {v2, v3}, Lcom/appsflyer/AppsFlyerTrackingRequestListener;->onTrackingRequestFailure(Ljava/lang/String;)V

    goto :goto_6

    .line 2849
    :cond_d
    const-string v3, "gcmProjectNumber"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v6

    invoke-virtual {v6, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 2849
    if-eqz v3, :cond_1

    .line 2850
    const-string v3, "GCM Project number exists. Fetching token and sending to AF servers"

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 2851
    new-instance v3, Ljava/lang/ref/WeakReference;

    invoke-direct {v3, v0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    .line 0
    new-instance v6, Lcom/appsflyer/u$a;

    invoke-direct {v6, v3}, Lcom/appsflyer/u$a;-><init>(Ljava/lang/ref/WeakReference;)V

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Void;

    invoke-virtual {v6, v3}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    goto/16 :goto_1

    :cond_e
    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    if-nez v3, :cond_4

    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v3

    invoke-virtual {v3}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v3

    iput-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    new-instance v3, Lcom/appsflyer/AppsFlyerLib$c;

    invoke-direct {v3, p0, v0}, Lcom/appsflyer/AppsFlyerLib$c;-><init>(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;)V

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    const-wide/16 v8, 0x1

    sget-object v7, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v6, v3, v8, v9, v7}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V

    goto/16 :goto_2

    .line 2870
    :cond_f
    sget-object v4, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    if-eqz v4, :cond_5

    .line 2871
    const-string v4, "Failure: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v4, v3}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 2872
    sget-object v4, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    invoke-interface {v4, v3}, Lcom/appsflyer/AppsFlyerTrackingRequestListener;->onTrackingRequestFailure(Ljava/lang/String;)V

    goto/16 :goto_3

    .line 2894
    :cond_10
    if-nez p3, :cond_11

    .line 2895
    const-string v0, "AppsFlyer dev key is missing."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto/16 :goto_4

    .line 2896
    :cond_11
    if-eqz v2, :cond_7

    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    if-eqz v2, :cond_7

    const-string v2, "attributionId"

    const/4 v3, 0x0

    .line 2898
    invoke-interface {v5, v2, v3}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_7

    .line 0
    const-string v2, "appsFlyerCount"

    const/4 v3, 0x0

    invoke-static {v5, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_1

    move-result v2

    .line 2899
    const/4 v3, 0x1

    if-le v2, v3, :cond_7

    .line 2903
    :try_start_7
    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;)Ljava/util/Map;
    :try_end_7
    .catch Lcom/appsflyer/l; {:try_start_7 .. :try_end_7} :catch_1
    .catchall {:try_start_7 .. :try_end_7} :catchall_1

    move-result-object v0

    .line 2904
    if-eqz v0, :cond_7

    .line 2907
    :try_start_8
    const-string v2, "is_first_launch"

    invoke-interface {v0, v2}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_12

    .line 2908
    const-string v2, "is_first_launch"

    const/4 v3, 0x0

    invoke-static {v3}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2911
    :cond_12
    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    invoke-interface {v2, v0}, Lcom/appsflyer/AppsFlyerConversionListener;->onInstallConversionDataLoaded(Ljava/util/Map;)V
    :try_end_8
    .catch Ljava/lang/Throwable; {:try_start_8 .. :try_end_8} :catch_0
    .catch Lcom/appsflyer/l; {:try_start_8 .. :try_end_8} :catch_1
    .catchall {:try_start_8 .. :try_end_8} :catchall_1

    goto/16 :goto_4

    .line 2912
    :catch_0
    move-exception v0

    .line 2913
    :try_start_9
    invoke-virtual {v0}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_9
    .catch Lcom/appsflyer/l; {:try_start_9 .. :try_end_9} :catch_1
    .catchall {:try_start_9 .. :try_end_9} :catchall_1

    goto/16 :goto_4

    .line 2916
    :catch_1
    move-exception v0

    .line 2917
    :try_start_a
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_a
    .catchall {:try_start_a .. :try_end_a} :catchall_1

    goto/16 :goto_4

    .line 2921
    :catchall_2
    move-exception v0

    move-object v1, v3

    goto/16 :goto_7

    .line 2810
    :catchall_3
    move-exception v0

    move-object v2, v3

    goto/16 :goto_5
.end method

.method private static ˎ(Lorg/json/JSONObject;)V
    .locals 14

    .prologue
    const/4 v3, 0x0

    const/4 v5, 0x0

    .line 255
    new-instance v6, Ljava/util/ArrayList;

    invoke-direct {v6}, Ljava/util/ArrayList;-><init>()V

    .line 257
    invoke-virtual {p0}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v1

    .line 258
    :cond_0
    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 259
    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 264
    :try_start_0
    new-instance v2, Lorg/json/JSONArray;

    invoke-virtual {p0, v0}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-direct {v2, v0}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    move v0, v5

    .line 265
    :goto_1
    invoke-virtual {v2}, Lorg/json/JSONArray;->length()I

    move-result v4

    if-ge v0, v4, :cond_0

    .line 266
    invoke-virtual {v2, v0}, Lorg/json/JSONArray;->getLong(I)J

    move-result-wide v8

    invoke-static {v8, v9}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    invoke-interface {v6, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_1

    .line 265
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 274
    :cond_1
    invoke-static {v6}, Ljava/util/Collections;->sort(Ljava/util/List;)V

    .line 278
    invoke-virtual {p0}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v7

    move-object v2, v3

    .line 279
    :cond_2
    :goto_2
    invoke-interface {v7}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_5

    if-nez v2, :cond_5

    .line 280
    invoke-interface {v7}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, Ljava/lang/String;

    .line 283
    :try_start_1
    new-instance v8, Lorg/json/JSONArray;

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-direct {v8, v0}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    move v4, v5

    .line 286
    :goto_3
    invoke-virtual {v8}, Lorg/json/JSONArray;->length()I

    move-result v0

    if-ge v4, v0, :cond_2

    .line 288
    invoke-virtual {v8, v4}, Lorg/json/JSONArray;->getLong(I)J

    move-result-wide v10

    const/4 v0, 0x0

    invoke-interface {v6, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide v12

    cmp-long v0, v10, v12

    if-eqz v0, :cond_3

    .line 289
    invoke-virtual {v8, v4}, Lorg/json/JSONArray;->getLong(I)J

    move-result-wide v10

    const/4 v0, 0x1

    invoke-interface {v6, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide v12

    cmp-long v0, v10, v12

    if-eqz v0, :cond_3

    .line 290
    invoke-virtual {v8, v4}, Lorg/json/JSONArray;->getLong(I)J

    move-result-wide v10

    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    invoke-interface {v6, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    move-result-wide v12

    cmp-long v0, v10, v12

    if-nez v0, :cond_4

    :cond_3
    move-object v2, v3

    .line 294
    goto :goto_2

    .line 286
    :cond_4
    add-int/lit8 v0, v4, 0x1

    move v4, v0

    move-object v2, v1

    goto :goto_3

    .line 302
    :catch_0
    move-exception v0

    move-object v0, v2

    move-object v2, v0

    goto :goto_2

    .line 304
    :cond_5
    if-eqz v2, :cond_6

    .line 305
    invoke-virtual {p0, v2}, Lorg/json/JSONObject;->remove(Ljava/lang/String;)Ljava/lang/Object;

    .line 307
    :cond_6
    return-void

    .line 271
    :catch_1
    move-exception v0

    goto/16 :goto_0
.end method

.method private static ˎ(Landroid/net/Uri;)Z
    .locals 6

    .prologue
    const/4 v0, 0x0

    .line 2462
    invoke-virtual {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v2

    .line 2463
    sget-object v3, Lcom/appsflyer/share/Constants;->APPSFLYER_DOMAINS:[Ljava/lang/String;

    array-length v4, v3

    move v1, v0

    :goto_0
    if-ge v1, v4, :cond_0

    aget-object v5, v3, v1

    .line 2464
    invoke-virtual {v2, v5}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 2465
    const/4 v0, 0x1

    .line 2469
    :cond_0
    return v0

    .line 2463
    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0
.end method

.method static synthetic ˎ(Lcom/appsflyer/AppsFlyerLib;)Z
    .locals 1

    .prologue
    .line 71
    .line 0
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->size()I

    move-result v0

    if-lez v0, :cond_0

    const/4 v0, 0x1

    .line 71
    :goto_0
    return v0

    .line 0
    :cond_0
    const/4 v0, 0x0

    .line 71
    goto :goto_0
.end method

.method static ˏ(Landroid/content/Context;)Landroid/content/SharedPreferences;
    .locals 2

    .prologue
    .line 2698
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    return-object v0
.end method

.method private static ˏ(Ljava/io/File;Ljava/lang/String;)Ljava/lang/String;
    .locals 5

    .prologue
    const/4 v0, 0x0

    .line 2535
    .line 2538
    :try_start_0
    new-instance v2, Ljava/util/Properties;

    invoke-direct {v2}, Ljava/util/Properties;-><init>()V

    .line 2539
    new-instance v1, Ljava/io/FileReader;

    invoke-direct {v1, p0}, Ljava/io/FileReader;-><init>(Ljava/io/File;)V
    :try_end_0
    .catch Ljava/io/FileNotFoundException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_3
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 2540
    :try_start_1
    invoke-virtual {v2, v1}, Ljava/util/Properties;->load(Ljava/io/Reader;)V

    .line 2541
    const-string v3, "Found PreInstall property!"

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 2542
    invoke-virtual {v2, p1}, Ljava/util/Properties;->getProperty(Ljava/lang/String;)Ljava/lang/String;
    :try_end_1
    .catch Ljava/io/FileNotFoundException; {:try_start_1 .. :try_end_1} :catch_7
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_6
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    move-result-object v0

    .line 2550
    :try_start_2
    invoke-virtual {v1}, Ljava/io/Reader;->close()V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0

    .line 2556
    :cond_0
    :goto_0
    return-object v0

    .line 2552
    :catch_0
    move-exception v1

    .line 2553
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2544
    :catch_1
    move-exception v1

    move-object v1, v0

    :goto_1
    :try_start_3
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "PreInstall file wasn\'t found: "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_1

    .line 2549
    if-eqz v1, :cond_0

    .line 2550
    :try_start_4
    invoke-virtual {v1}, Ljava/io/Reader;->close()V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_2

    goto :goto_0

    .line 2552
    :catch_2
    move-exception v1

    .line 2553
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2545
    :catch_3
    move-exception v1

    move-object v2, v0

    .line 2546
    :goto_2
    :try_start_5
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_2

    .line 2549
    if-eqz v2, :cond_0

    .line 2550
    :try_start_6
    invoke-virtual {v2}, Ljava/io/Reader;->close()V
    :try_end_6
    .catch Ljava/lang/Throwable; {:try_start_6 .. :try_end_6} :catch_4

    goto :goto_0

    .line 2552
    :catch_4
    move-exception v1

    .line 2553
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2548
    :catchall_0
    move-exception v1

    move-object v4, v1

    move-object v1, v0

    move-object v0, v4

    .line 2549
    :goto_3
    if-eqz v1, :cond_1

    .line 2550
    :try_start_7
    invoke-virtual {v1}, Ljava/io/Reader;->close()V
    :try_end_7
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_5

    .line 2554
    :cond_1
    :goto_4
    throw v0

    .line 2552
    :catch_5
    move-exception v1

    .line 2553
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_4

    .line 2548
    :catchall_1
    move-exception v0

    goto :goto_3

    :catchall_2
    move-exception v0

    move-object v1, v2

    goto :goto_3

    .line 2545
    :catch_6
    move-exception v2

    move-object v4, v2

    move-object v2, v1

    move-object v1, v4

    goto :goto_2

    .line 2544
    :catch_7
    move-exception v2

    goto :goto_1
.end method

.method static synthetic ˏ(Ljava/lang/String;)Ljava/util/Map;
    .locals 1

    .prologue
    .line 71
    invoke-static {p0}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Ljava/lang/String;)Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method static synthetic ˏ(Lcom/appsflyer/AppsFlyerLib;)Ljava/util/concurrent/ScheduledExecutorService;
    .locals 1

    .prologue
    .line 71
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʾ:Ljava/util/concurrent/ScheduledExecutorService;

    return-object v0
.end method

.method private static ˏ(Landroid/content/Context;Ljava/util/Map;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "-",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 0
    sget-object v0, Lcom/appsflyer/i$d;->ˎ:Lcom/appsflyer/i;

    .line 2067
    invoke-static {p0}, Lcom/appsflyer/i;->ˏ(Landroid/content/Context;)Lcom/appsflyer/i$b;

    move-result-object v0

    .line 2068
    const-string v1, "network"

    invoke-virtual {v0}, Lcom/appsflyer/i$b;->ˊ()Ljava/lang/String;

    move-result-object v2

    invoke-interface {p1, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2069
    invoke-virtual {v0}, Lcom/appsflyer/i$b;->ˏ()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 2070
    const-string v1, "operator"

    invoke-virtual {v0}, Lcom/appsflyer/i$b;->ˏ()Ljava/lang/String;

    move-result-object v2

    invoke-interface {p1, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2072
    :cond_0
    invoke-virtual {v0}, Lcom/appsflyer/i$b;->ˋ()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_1

    .line 2073
    const-string v1, "carrier"

    invoke-virtual {v0}, Lcom/appsflyer/i$b;->ˋ()Ljava/lang/String;

    move-result-object v0

    invoke-interface {p1, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2075
    :cond_1
    return-void
.end method

.method static synthetic ˏ(Lcom/appsflyer/AppsFlyerLib;Z)Z
    .locals 0

    .prologue
    .line 71
    iput-boolean p1, p0, Lcom/appsflyer/AppsFlyerLib;->ʻॱ:Z

    return p1
.end method

.method static synthetic ॱ()Lcom/appsflyer/AppsFlyerConversionListener;
    .locals 1

    .prologue
    .line 71
    sget-object v0, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    return-object v0
.end method

.method static synthetic ॱ(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, p0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 71
    return-object v0
.end method

.method static ॱ(Ljava/net/HttpURLConnection;)Ljava/lang/String;
    .locals 7
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .prologue
    const/4 v1, 0x0

    .line 3263
    .line 3264
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    .line 3267
    :try_start_0
    invoke-virtual {p0}, Ljava/net/HttpURLConnection;->getErrorStream()Ljava/io/InputStream;

    move-result-object v0

    .line 3268
    if-nez v0, :cond_0

    .line 3269
    invoke-virtual {p0}, Ljava/net/URLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v0

    .line 3272
    :cond_0
    new-instance v2, Ljava/io/InputStreamReader;

    invoke-direct {v2, v0}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_6
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 3273
    :try_start_1
    new-instance v3, Ljava/io/BufferedReader;

    invoke-direct {v3, v2}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_7
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 3276
    :goto_0
    :try_start_2
    invoke-virtual {v3}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_3

    .line 3277
    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const/16 v1, 0xa

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0
    .catchall {:try_start_2 .. :try_end_2} :catchall_2

    goto :goto_0

    .line 3279
    :catch_0
    move-exception v0

    move-object v1, v2

    move-object v2, v3

    .line 3280
    :goto_1
    :try_start_3
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v5, "Could not read connection response from: "

    invoke-direct {v3, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0}, Ljava/net/URLConnection;->getURL()Ljava/net/URL;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_3

    .line 3283
    if-eqz v2, :cond_1

    .line 3284
    :try_start_4
    invoke-virtual {v2}, Ljava/io/Reader;->close()V

    .line 3286
    :cond_1
    if-eqz v1, :cond_2

    .line 3287
    invoke-virtual {v1}, Ljava/io/Reader;->close()V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_5

    .line 3292
    :cond_2
    :goto_2
    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    .line 3294
    :try_start_5
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V
    :try_end_5
    .catch Lorg/json/JSONException; {:try_start_5 .. :try_end_5} :catch_2

    .line 3302
    :goto_3
    return-object v0

    .line 3284
    :cond_3
    :try_start_6
    invoke-virtual {v3}, Ljava/io/Reader;->close()V

    .line 3287
    invoke-virtual {v2}, Ljava/io/Reader;->close()V
    :try_end_6
    .catch Ljava/lang/Throwable; {:try_start_6 .. :try_end_6} :catch_1

    goto :goto_2

    .line 3291
    :catch_1
    move-exception v0

    goto :goto_2

    .line 3282
    :catchall_0
    move-exception v0

    move-object v2, v1

    .line 3283
    :goto_4
    if-eqz v2, :cond_4

    .line 3284
    :try_start_7
    invoke-virtual {v2}, Ljava/io/Reader;->close()V

    .line 3286
    :cond_4
    if-eqz v1, :cond_5

    .line 3287
    invoke-virtual {v1}, Ljava/io/Reader;->close()V
    :try_end_7
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_4

    .line 3290
    :cond_5
    :goto_5
    throw v0

    .line 3297
    :catch_2
    move-exception v1

    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 3299
    :try_start_8
    const-string v2, "string_response"

    invoke-virtual {v1, v2, v0}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 3300
    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;
    :try_end_8
    .catch Lorg/json/JSONException; {:try_start_8 .. :try_end_8} :catch_3

    move-result-object v0

    goto :goto_3

    .line 3302
    :catch_3
    move-exception v0

    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0}, Lorg/json/JSONObject;-><init>()V

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_3

    :catch_4
    move-exception v1

    goto :goto_5

    .line 3282
    :catchall_1
    move-exception v0

    move-object v6, v2

    move-object v2, v1

    move-object v1, v6

    goto :goto_4

    :catchall_2
    move-exception v0

    move-object v1, v2

    move-object v2, v3

    goto :goto_4

    :catchall_3
    move-exception v0

    goto :goto_4

    .line 3291
    :catch_5
    move-exception v0

    goto :goto_2

    .line 3279
    :catch_6
    move-exception v0

    move-object v2, v1

    goto :goto_1

    :catch_7
    move-exception v0

    move-object v6, v2

    move-object v2, v1

    move-object v1, v6

    goto :goto_1
.end method

.method private static ॱ(Landroid/content/Context;)Ljava/util/Map;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/appsflyer/l;
        }
    .end annotation

    .prologue
    .line 1269
    const-string v0, "appsflyer-data"

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 1275
    const-string v1, "attributionId"

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1277
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v1

    if-lez v1, :cond_0

    .line 1278
    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Ljava/lang/String;)Ljava/util/Map;

    move-result-object v0

    return-object v0

    .line 1280
    :cond_0
    new-instance v0, Lcom/appsflyer/l;

    invoke-direct {v0}, Lcom/appsflyer/l;-><init>()V

    throw v0
.end method

.method private static ॱ(Landroid/content/Context;Ljava/lang/String;)Ljava/util/Map;
    .locals 11
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    const/4 v5, 0x0

    .line 1338
    new-instance v6, Ljava/util/LinkedHashMap;

    invoke-direct {v6}, Ljava/util/LinkedHashMap;-><init>()V

    .line 1339
    const-string v0, "&"

    invoke-virtual {p1, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v7

    .line 1342
    array-length v8, v7

    move v4, v5

    move v2, v5

    :goto_0
    if-ge v4, v8, :cond_6

    aget-object v1, v7, v4

    .line 1343
    const-string v0, "="

    invoke-virtual {v1, v0}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I

    move-result v9

    .line 1344
    if-lez v9, :cond_2

    invoke-virtual {v1, v5, v9}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    .line 1345
    :goto_1
    invoke-interface {v6, v0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_1

    .line 1347
    const-string v3, "c"

    invoke-virtual {v0, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    .line 1348
    const-string v0, "campaign"

    .line 1356
    :cond_0
    :goto_2
    const-string v3, ""

    invoke-interface {v6, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_1
    move v3, v2

    move-object v2, v0

    .line 1358
    if-lez v9, :cond_5

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v0

    add-int/lit8 v10, v9, 0x1

    if-le v0, v10, :cond_5

    add-int/lit8 v0, v9, 0x1

    invoke-virtual {v1, v0}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    .line 1359
    :goto_3
    invoke-interface {v6, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1342
    add-int/lit8 v0, v4, 0x1

    move v4, v0

    move v2, v3

    goto :goto_0

    :cond_2
    move-object v0, v1

    .line 1344
    goto :goto_1

    .line 1349
    :cond_3
    const-string v3, "pid"

    invoke-virtual {v0, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_4

    .line 1350
    const-string v0, "media_source"

    goto :goto_2

    .line 1351
    :cond_4
    const-string v3, "af_prt"

    invoke-virtual {v0, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 1352
    const/4 v2, 0x1

    .line 1353
    const-string v0, "agency"

    goto :goto_2

    .line 1358
    :cond_5
    const/4 v0, 0x0

    goto :goto_3

    .line 1362
    :cond_6
    :try_start_0
    const-string v0, "install_time"

    invoke-interface {v6, v0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_7

    .line 1363
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    const/4 v3, 0x0

    invoke-virtual {v0, v1, v3}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v0

    .line 1365
    const-string v1, "install_time"

    const-string v3, "yyyy-MM-dd HH:mm:ss"

    .line 0
    new-instance v4, Ljava/text/SimpleDateFormat;

    sget-object v5, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v4, v3, v5}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 1365
    iget-wide v8, v0, Landroid/content/pm/PackageInfo;->firstInstallTime:J

    .line 0
    const-string v0, "UTC"

    invoke-static {v0}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v0

    invoke-virtual {v4, v0}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v0, Ljava/util/Date;

    invoke-direct {v0, v8, v9}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v4, v0}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v0

    .line 1365
    invoke-interface {v6, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 1371
    :cond_7
    :goto_4
    const-string v0, "af_status"

    invoke-interface {v6, v0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_8

    .line 1372
    const-string v0, "af_status"

    const-string v1, "Non-organic"

    invoke-interface {v6, v0, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1375
    :cond_8
    if-eqz v2, :cond_9

    .line 1376
    const-string v0, "media_source"

    invoke-interface {v6, v0}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 1380
    :cond_9
    return-object v6

    .line 1368
    :catch_0
    move-exception v0

    .line 1369
    const-string v1, "Could not fetch install time. "

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_4
.end method

.method static synthetic ॱ(Lcom/appsflyer/AppsFlyerLib;)Ljava/util/Map;
    .locals 1

    .prologue
    .line 71
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    return-object v0
.end method

.method private ॱ(Landroid/app/Application;)V
    .locals 5

    .prologue
    const/4 v4, 0x0

    const/16 v2, 0xe

    .line 412
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->loadProperties(Landroid/content/Context;)V

    .line 414
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    if-lt v0, v2, :cond_1

    .line 416
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    if-lt v0, v2, :cond_0

    .line 418
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʿ:Lcom/appsflyer/q$c;

    if-nez v0, :cond_0

    .line 420
    invoke-static {}, Lcom/appsflyer/q;->ˎ()Lcom/appsflyer/q;

    .line 422
    new-instance v0, Lcom/appsflyer/AppsFlyerLib$2;

    invoke-direct {v0, p0}, Lcom/appsflyer/AppsFlyerLib$2;-><init>(Lcom/appsflyer/AppsFlyerLib;)V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʿ:Lcom/appsflyer/q$c;

    .line 436
    invoke-static {}, Lcom/appsflyer/q;->ˋ()Lcom/appsflyer/q;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ʿ:Lcom/appsflyer/q$c;

    invoke-virtual {v0, p1, v1}, Lcom/appsflyer/q;->ˏ(Landroid/app/Application;Lcom/appsflyer/q$c;)V

    .line 443
    :cond_0
    :goto_0
    return-void

    .line 440
    :cond_1
    const-string v0, "SDK<14 call trackEvent manually"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 59915
    const-string v0, "onBecameForeground"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 59916
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    .line 59921
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    iput-wide v2, v0, Lcom/appsflyer/AppsFlyerLib;->ʼॱ:J

    .line 59925
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-virtual {v0, p1, v4, v4}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 59927
    invoke-static {}, Lcom/appsflyer/AFLogger;->resetDeltaTime()V

    goto :goto_0
.end method

.method private ॱ(Landroid/content/Context;Ljava/util/Map;Landroid/net/Uri;)V
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;",
            "Landroid/net/Uri;",
            ")V"
        }
    .end annotation

    .prologue
    .line 2134
    const-string v0, "af_deeplink"

    invoke-virtual {p3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-interface {p2, v0, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2137
    const-string v0, "af_deeplink"

    invoke-virtual {p3, v0}, Landroid/net/Uri;->getQueryParameter(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_5

    .line 2139
    const-string v0, "media_source"

    invoke-virtual {p3, v0}, Landroid/net/Uri;->getQueryParameter(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 2140
    const-string v1, "is_retargeting"

    invoke-virtual {p3, v1}, Landroid/net/Uri;->getQueryParameter(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 2142
    const-string v2, "AppsFlyer_Test"

    invoke-virtual {v2, v0}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-static {v1}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    const/4 v0, 0x1

    :goto_0
    iput-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˊ:Z

    .line 2144
    invoke-virtual {p3}, Landroid/net/Uri;->getQuery()Ljava/lang/String;

    move-result-object v0

    invoke-static {p1, v0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;Ljava/lang/String;)Ljava/util/Map;

    move-result-object v0

    .line 2145
    const-string v1, "path"

    invoke-virtual {p3}, Landroid/net/Uri;->getPath()Ljava/lang/String;

    move-result-object v2

    .line 0
    if-eqz v2, :cond_0

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2146
    :cond_0
    const-string v1, "scheme"

    invoke-virtual {p3}, Landroid/net/Uri;->getScheme()Ljava/lang/String;

    move-result-object v2

    .line 0
    if-eqz v2, :cond_1

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2147
    :cond_1
    const-string v1, "host"

    invoke-virtual {p3}, Landroid/net/Uri;->getHost()Ljava/lang/String;

    move-result-object v2

    .line 0
    if-eqz v2, :cond_2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2154
    :cond_2
    :goto_1
    new-instance v1, Ljava/lang/ref/WeakReference;

    invoke-direct {v1, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    .line 2155
    new-instance v2, Lcom/appsflyer/p;

    invoke-direct {v2, p3, p0}, Lcom/appsflyer/p;-><init>(Landroid/net/Uri;Lcom/appsflyer/AppsFlyerLib;)V

    .line 2156
    new-instance v3, Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;

    invoke-direct {v3}, Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;-><init>()V

    invoke-virtual {v2, v3}, Lcom/appsflyer/OneLinkHttpTask;->setConnProvider(Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;)V

    .line 2157
    invoke-virtual {v2}, Lcom/appsflyer/p;->ˏ()Z

    move-result v3

    if-eqz v3, :cond_6

    .line 0
    new-instance v3, Lcom/appsflyer/AppsFlyerLib$1;

    invoke-direct {v3, p0, v0, v1}, Lcom/appsflyer/AppsFlyerLib$1;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/util/Map;Ljava/lang/ref/WeakReference;)V

    .line 2159
    invoke-virtual {v2, v3}, Lcom/appsflyer/p;->ˊ(Lcom/appsflyer/p$a;)V

    .line 2160
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->getThreadPoolExecutor()Ljava/util/concurrent/Executor;

    move-result-object v0

    invoke-interface {v0, v2}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 2165
    :cond_3
    :goto_2
    return-void

    .line 2142
    :cond_4
    const/4 v0, 0x0

    goto :goto_0

    .line 2150
    :cond_5
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 2151
    const-string v1, "link"

    invoke-virtual {p3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_1

    .line 0
    :cond_6
    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    if-eqz v1, :cond_3

    :try_start_0
    sget-object v1, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    invoke-interface {v1, v0}, Lcom/appsflyer/AppsFlyerConversionListener;->onAppOpenAttribution(Ljava/util/Map;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_2

    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_2
.end method

.method static synthetic ॱ(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/ref/WeakReference;Ljava/lang/String;Z)V
    .locals 7
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 71
    .line 0
    new-instance v1, Ljava/net/URL;

    invoke-direct {v1, p1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "url: "

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    const-string v0, "data: "

    invoke-static {p2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/j$1;->ˏ(Ljava/lang/String;)V

    invoke-virtual {p4}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v2, "AppsFlyer_4.8.14"

    const-string v3, "EVENT_DATA"

    invoke-static {v0, v2, v3, p2}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    move-object v0, p0

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move v6, p6

    :try_start_0
    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/net/URL;Ljava/lang/String;Ljava/lang/String;Ljava/lang/ref/WeakReference;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v1

    const-string v0, "Exception in sendRequestToServer. "

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v2, "useHttpFallback"

    const/4 v3, 0x0

    invoke-virtual {v0, v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    new-instance v1, Ljava/net/URL;

    const-string v0, "https:"

    const-string v2, "http:"

    invoke-virtual {p1, v0, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {v1, v0}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    move-object v0, p0

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move v6, p6

    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/net/URL;Ljava/lang/String;Ljava/lang/String;Ljava/lang/ref/WeakReference;Ljava/lang/String;Z)V

    goto :goto_0

    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "failed to send requeset to server. "

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    invoke-virtual {p4}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v2, "AppsFlyer_4.8.14"

    const-string v3, "ERROR"

    invoke-virtual {v1}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v4

    invoke-static {v0, v2, v3, v4}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    throw v1
.end method

.method private static ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V
    .locals 2

    .prologue
    .line 2962
    if-eqz p0, :cond_0

    .line 2963
    :try_start_0
    invoke-interface {p0}, Ljava/util/concurrent/ScheduledExecutorService;->isShutdown()Z

    move-result v0

    if-nez v0, :cond_0

    .line 2964
    invoke-interface {p0}, Ljava/util/concurrent/ScheduledExecutorService;->isTerminated()Z

    move-result v0

    if-nez v0, :cond_0

    .line 2966
    invoke-interface {p0, p1, p2, p3, p4}, Ljava/util/concurrent/ScheduledExecutorService;->schedule(Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)Ljava/util/concurrent/ScheduledFuture;

    .line 2976
    :goto_0
    return-void

    .line 2969
    :cond_0
    const-string v0, "scheduler is null, shut downed or terminated"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/util/concurrent/RejectedExecutionException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 2971
    :catch_0
    move-exception v0

    .line 2972
    const-string v1, "scheduleJob failed with RejectedExecutionException Exception"

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2973
    :catch_1
    move-exception v0

    .line 2974
    const-string v1, "scheduleJob failed with Exception"

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private static ᐝ(Landroid/content/Context;)Z
    .locals 4

    .prologue
    const/4 v1, 0x1

    const/4 v0, 0x0

    .line 2381
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "collectAndroidIdForceByUser"

    .line 2382
    invoke-virtual {v2, v3, v0}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-nez v2, :cond_0

    .line 2383
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "collectIMEIForceByUser"

    .line 2384
    invoke-virtual {v2, v3, v0}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-eqz v2, :cond_3

    :cond_0
    move v2, v1

    .line 2386
    :goto_0
    if-nez v2, :cond_1

    invoke-static {p0}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;)Z

    move-result v2

    if-nez v2, :cond_2

    :cond_1
    move v0, v1

    :cond_2
    return v0

    :cond_3
    move v2, v0

    .line 2384
    goto :goto_0
.end method


# virtual methods
.method public enableLocationCollection(Z)Lcom/appsflyer/AppsFlyerLib;
    .locals 0

    .prologue
    .line 508
    iput-boolean p1, p0, Lcom/appsflyer/AppsFlyerLib;->ˊᐝ:Z

    .line 509
    return-object p0
.end method

.method public enableUninstallTracking(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 479
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "enableUninstallTracking"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 480
    const-string v0, "gcmProjectNumber"

    .line 59929
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 481
    return-void
.end method

.method public getAppsFlyerUID(Landroid/content/Context;)Ljava/lang/String;
    .locals 3

    .prologue
    .line 2754
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "getAppsFlyerUID"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 2755
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v0}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getAttributionId(Landroid/content/ContentResolver;)Ljava/lang/String;
    .locals 6

    .prologue
    const/4 v3, 0x0

    .line 2674
    const/4 v0, 0x1

    new-array v2, v0, [Ljava/lang/String;

    const/4 v0, 0x0

    const-string v1, "aid"

    aput-object v1, v2, v0

    .line 2675
    const-string v0, "content://com.facebook.katana.provider.AttributionIdProvider"

    invoke-static {v0}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v1

    move-object v0, p1

    move-object v4, v3

    move-object v5, v3

    invoke-virtual/range {v0 .. v5}, Landroid/content/ContentResolver;->query(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v1

    .line 2678
    if-eqz v1, :cond_0

    :try_start_0
    invoke-interface {v1}, Landroid/database/Cursor;->moveToFirst()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result v0

    if-nez v0, :cond_2

    .line 2687
    :cond_0
    if-eqz v1, :cond_1

    .line 2688
    :try_start_1
    invoke-interface {v1}, Landroid/database/Cursor;->close()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    .line 2694
    :cond_1
    :goto_0
    return-object v3

    .line 2690
    :catch_0
    move-exception v0

    .line 2691
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2681
    :cond_2
    :try_start_2
    const-string v0, "aid"

    invoke-interface {v1, v0}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v0

    invoke-interface {v1, v0}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    move-result-object v3

    .line 2687
    if-eqz v1, :cond_1

    .line 2688
    :try_start_3
    invoke-interface {v1}, Landroid/database/Cursor;->close()V
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1

    goto :goto_0

    .line 2690
    :catch_1
    move-exception v0

    .line 2691
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2683
    :catch_2
    move-exception v0

    .line 2684
    :try_start_4
    const-string v2, "Could not collect cursor attribution. "

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 2687
    if-eqz v1, :cond_1

    .line 2688
    :try_start_5
    invoke-interface {v1}, Landroid/database/Cursor;->close()V
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_3

    goto :goto_0

    .line 2690
    :catch_3
    move-exception v0

    .line 2691
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2686
    :catchall_0
    move-exception v0

    .line 2687
    if-eqz v1, :cond_3

    .line 2688
    :try_start_6
    invoke-interface {v1}, Landroid/database/Cursor;->close()V
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_4

    .line 2692
    :cond_3
    :goto_1
    throw v0

    .line 2690
    :catch_4
    move-exception v1

    .line 2691
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_1
.end method

.method protected getConversionData(Landroid/content/Context;Lcom/appsflyer/ConversionDataListener;)V
    .locals 1

    .prologue
    .line 1317
    new-instance v0, Lcom/appsflyer/AppsFlyerLib$4;

    invoke-direct {v0, p0, p2}, Lcom/appsflyer/AppsFlyerLib$4;-><init>(Lcom/appsflyer/AppsFlyerLib;Lcom/appsflyer/ConversionDataListener;)V

    .line 0
    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    .line 1334
    return-void
.end method

.method public getHost()Ljava/lang/String;
    .locals 2

    .prologue
    .line 3393
    const-string v0, "custom_host"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 3395
    if-eqz v0, :cond_0

    .line 3398
    :goto_0
    return-object v0

    :cond_0
    const-string v0, "appsflyer.com"

    goto :goto_0
.end method

.method public getOutOfStore(Landroid/content/Context;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 628
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "api_store_value"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 629
    if-eqz v0, :cond_1

    .line 639
    :cond_0
    :goto_0
    return-object v0

    .line 633
    :cond_1
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    const-string v1, "AF_STORE"

    invoke-static {v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 634
    if-nez v0, :cond_0

    .line 638
    const-string v0, "No out-of-store value set"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 639
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public getSdkVersion()Ljava/lang/String;
    .locals 3

    .prologue
    .line 395
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "getSdkVersion"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 396
    const-string v0, "version: 4.8.14 (build 393)"

    return-object v0
.end method

.method public init(Ljava/lang/String;Lcom/appsflyer/AppsFlyerConversionListener;)Lcom/appsflyer/AppsFlyerLib;
    .locals 7

    .prologue
    const/4 v6, 0x2

    const/4 v5, 0x0

    const/4 v4, 0x1

    .line 825
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    const-string v2, "init"

    new-array v3, v6, [Ljava/lang/String;

    aput-object p1, v3, v5

    if-nez p2, :cond_0

    const-string v0, "null"

    :goto_0
    aput-object v0, v3, v4

    invoke-virtual {v1, v2, v3}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 826
    const-string v0, "Initializing AppsFlyer SDK: (v%s.%s)"

    new-array v1, v6, [Ljava/lang/Object;

    const-string v2, "4.8.14"

    aput-object v2, v1, v5

    const-string v2, "393"

    aput-object v2, v1, v4

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;)V

    .line 827
    iput-boolean v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˍ:Z

    .line 828
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 829
    invoke-static {p1}, Lcom/appsflyer/j$1;->ˋ(Ljava/lang/String;)V

    .line 830
    sput-object p2, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    .line 831
    return-object p0

    .line 825
    :cond_0
    const-string v0, "conversionDataListener"

    goto :goto_0
.end method

.method public init(Ljava/lang/String;Lcom/appsflyer/AppsFlyerConversionListener;Landroid/content/Context;)Lcom/appsflyer/AppsFlyerLib;
    .locals 1

    .prologue
    .line 847
    if-eqz p3, :cond_0

    .line 849
    invoke-static {p3}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 852
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    if-nez v0, :cond_1

    .line 853
    new-instance v0, Lcom/appsflyer/c;

    invoke-direct {v0}, Lcom/appsflyer/c;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    .line 854
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    invoke-virtual {v0, p3, p0}, Lcom/appsflyer/c;->ˎ(Landroid/content/Context;Lcom/appsflyer/a;)V

    .line 861
    :cond_0
    :goto_0
    invoke-virtual {p0, p1, p2}, Lcom/appsflyer/AppsFlyerLib;->init(Ljava/lang/String;Lcom/appsflyer/AppsFlyerConversionListener;)Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    return-object v0

    .line 857
    :cond_1
    const-string v0, "AFInstallReferrer instance already created"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public isPreInstalledApp(Landroid/content/Context;)Z
    .locals 4

    .prologue
    const/4 v0, 0x0

    .line 2630
    :try_start_0
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v1

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3}, Landroid/content/pm/PackageManager;->getApplicationInfo(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;

    move-result-object v1

    .line 2635
    iget v1, v1, Landroid/content/pm/ApplicationInfo;->flags:I
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    and-int/lit8 v1, v1, 0x1

    if-eqz v1, :cond_0

    .line 2636
    const/4 v0, 0x1

    .line 2641
    :cond_0
    :goto_0
    return v0

    .line 2638
    :catch_0
    move-exception v1

    .line 2639
    const-string v2, "Could not check if app is pre installed"

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public isTrackingStopped()Z
    .locals 1

    .prologue
    .line 2984
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˏˎ:Z

    return v0
.end method

.method public onHandleReferrer(Ljava/util/Map;)V
    .locals 0
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
    .line 2980
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib;->ॱᐝ:Ljava/util/Map;

    .line 2981
    return-void
.end method

.method public onPause(Landroid/content/Context;)V
    .locals 2

    .prologue
    .line 405
    invoke-static {p1}, Lcom/appsflyer/b;->ˏ(Landroid/content/Context;)V

    .line 406
    invoke-static {p1}, Lcom/appsflyer/j;->ˊ(Landroid/content/Context;)Lcom/appsflyer/j;

    move-result-object v0

    .line 58913
    iget-object v1, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v0, v0, Lcom/appsflyer/j;->ʽ:Ljava/lang/Runnable;

    invoke-virtual {v1, v0}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 407
    return-void
.end method

.method public registerConversionListener(Landroid/content/Context;Lcom/appsflyer/AppsFlyerConversionListener;)V
    .locals 3

    .prologue
    .line 1285
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "registerConversionListener"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 0
    if-eqz p2, :cond_0

    sput-object p2, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    .line 1287
    :cond_0
    return-void
.end method

.method public registerValidatorListener(Landroid/content/Context;Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;)V
    .locals 3

    .prologue
    .line 1303
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "registerValidatorListener"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1305
    const-string v0, "registerValidatorListener called"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 1307
    if-nez p2, :cond_0

    .line 1308
    const-string v0, "registerValidatorListener null listener"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 1313
    :goto_0
    return-void

    .line 1311
    :cond_0
    sput-object p2, Lcom/appsflyer/AppsFlyerLib;->ˏ:Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;

    goto :goto_0
.end method

.method public reportTrackSession(Landroid/content/Context;)V
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 1122
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "reportTrackSession"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1124
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/w;->ॱॱ()V

    .line 1125
    invoke-virtual {p0, p1, v3, v3}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 1126
    return-void
.end method

.method public sendDeepLinkData(Landroid/app/Activity;)V
    .locals 6

    .prologue
    const/4 v2, 0x2

    const/4 v5, 0x1

    const/4 v4, 0x0

    .line 672
    if-eqz p1, :cond_0

    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 673
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "sendDeepLinkData"

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {p1}, Landroid/app/Activity;->getLocalClassName()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v4

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "activity_intent_"

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v5

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 681
    :goto_0
    :try_start_0
    invoke-virtual {p1}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/app/Application;)V

    .line 682
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "getDeepLinkData with activity "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v1

    invoke-virtual {v1}, Landroid/content/Intent;->getDataString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 686
    :goto_1
    return-void

    .line 674
    :cond_0
    if-eqz p1, :cond_1

    .line 675
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "sendDeepLinkData"

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {p1}, Landroid/app/Activity;->getLocalClassName()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v4

    const-string v3, "activity_intent_null"

    aput-object v3, v2, v5

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    goto :goto_0

    .line 677
    :cond_1
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "sendDeepLinkData"

    new-array v2, v5, [Ljava/lang/String;

    const-string v3, "activity_null"

    aput-object v3, v2, v4

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    goto :goto_0

    .line 683
    :catch_0
    move-exception v0

    .line 684
    const-string v1, "getDeepLinkData Exception: "

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    goto :goto_1
.end method

.method public sendPushNotificationData(Landroid/app/Activity;)V
    .locals 13

    .prologue
    const/4 v1, 0x0

    const/4 v12, 0x2

    const/4 v6, 0x1

    const/4 v5, 0x0

    .line 689
    if-eqz p1, :cond_4

    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v0

    if-eqz v0, :cond_4

    .line 690
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "sendPushNotificationData"

    new-array v3, v12, [Ljava/lang/String;

    invoke-virtual {p1}, Landroid/app/Activity;->getLocalClassName()Ljava/lang/String;

    move-result-object v4

    aput-object v4, v3, v5

    new-instance v4, Ljava/lang/StringBuilder;

    const-string v5, "activity_intent_"

    invoke-direct {v4, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    aput-object v4, v3, v6

    invoke-virtual {v0, v2, v3}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 0
    :goto_0
    instance-of v0, p1, Landroid/app/Activity;

    if-eqz v0, :cond_a

    move-object v0, p1

    check-cast v0, Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v2

    if-eqz v2, :cond_a

    invoke-virtual {v2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v3

    if-eqz v3, :cond_a

    const-string v0, "af"

    invoke-virtual {v3, v0}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_0

    const-string v0, "Push Notification received af payload = "

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    const-string v0, "af"

    invoke-virtual {v3, v0}, Landroid/os/Bundle;->remove(Ljava/lang/String;)V

    move-object v0, p1

    check-cast v0, Landroid/app/Activity;

    invoke-virtual {v2, v3}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    move-result-object v2

    invoke-virtual {v0, v2}, Landroid/app/Activity;->setIntent(Landroid/content/Intent;)V

    :cond_0
    move-object v0, v1

    .line 696
    :goto_1
    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    .line 697
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    if-eqz v0, :cond_3

    .line 698
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    .line 700
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    if-nez v0, :cond_6

    .line 701
    const-string v0, "pushes: initializing pushes history.."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 702
    new-instance v0, Ljava/util/concurrent/ConcurrentHashMap;

    invoke-direct {v0}, Ljava/util/concurrent/ConcurrentHashMap;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    move-wide v2, v4

    .line 732
    :cond_1
    :goto_2
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "pushPayloadHistorySize"

    invoke-virtual {v0, v1, v12}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v0

    .line 733
    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-interface {v1}, Ljava/util/Map;->size()I

    move-result v1

    if-ne v1, v0, :cond_2

    .line 734
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "pushes: removing oldest overflowing push (oldest push:"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, v2, v3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ")"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 735
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 737
    :cond_2
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 740
    invoke-virtual {p1}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/app/Application;)V

    .line 743
    :cond_3
    :goto_3
    return-void

    .line 691
    :cond_4
    if-eqz p1, :cond_5

    .line 692
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "sendPushNotificationData"

    new-array v3, v12, [Ljava/lang/String;

    invoke-virtual {p1}, Landroid/app/Activity;->getLocalClassName()Ljava/lang/String;

    move-result-object v4

    aput-object v4, v3, v5

    const-string v4, "activity_intent_null"

    aput-object v4, v3, v6

    invoke-virtual {v0, v2, v3}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    goto/16 :goto_0

    .line 694
    :cond_5
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "sendPushNotificationData"

    new-array v3, v6, [Ljava/lang/String;

    const-string v4, "activity_null"

    aput-object v4, v3, v5

    invoke-virtual {v0, v2, v3}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    goto/16 :goto_0

    .line 705
    :cond_6
    :try_start_0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "pushPayloadMaxAging"

    const-wide/32 v2, 0x1b7740

    invoke-virtual {v0, v1, v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getLong(Ljava/lang/String;J)J

    move-result-wide v6

    .line 706
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    move-result-object v8

    move-wide v2, v4

    :goto_4
    :try_start_1
    invoke-interface {v8}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v8}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    .line 708
    new-instance v9, Lorg/json/JSONObject;

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    invoke-direct {v9, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 709
    new-instance v10, Lorg/json/JSONObject;

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-interface {v1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-direct {v10, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 710
    const-string v1, "pid"

    invoke-virtual {v9, v1}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    const-string v11, "pid"

    invoke-virtual {v10, v11}, Lorg/json/JSONObject;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v11

    invoke-virtual {v1, v11}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_7

    .line 711
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "PushNotificationMeasurement: A previous payload with same PID was already acknowledged! (old: "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ", new: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ")"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 712
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_3

    .line 726
    :catch_0
    move-exception v0

    .line 727
    :goto_5
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v6, "Error while handling push notification measurement: "

    invoke-direct {v1, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_2

    .line 717
    :cond_7
    :try_start_2
    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide v10

    sub-long v10, v4, v10

    cmp-long v1, v10, v6

    if-lez v1, :cond_8

    .line 718
    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ˋᐝ:Ljava/util/Map;

    invoke-interface {v1, v0}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 722
    :cond_8
    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide v10

    cmp-long v1, v10, v2

    if-gtz v1, :cond_9

    .line 723
    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0

    move-result-wide v0

    :goto_6
    move-wide v2, v0

    .line 725
    goto/16 :goto_4

    .line 726
    :catch_1
    move-exception v0

    move-wide v2, v4

    goto :goto_5

    :cond_9
    move-wide v0, v2

    goto :goto_6

    :cond_a
    move-object v0, v1

    goto/16 :goto_1
.end method

.method public setAdditionalData(Ljava/util/HashMap;)V
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 664
    if-eqz p1, :cond_0

    .line 665
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setAdditionalData"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 666
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p1}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 667
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->setCustomData(Ljava/lang/String;)V

    .line 669
    :cond_0
    return-void
.end method

.method public setAndroidIdData(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 503
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setAndroidIdData"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 504
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    .line 505
    return-void
.end method

.method public setAppId(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 983
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setAppId"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 984
    const-string v0, "appid"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 985
    return-void
.end method

.method public setAppInviteOneLink(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 653
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setAppInviteOneLink"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 654
    const-string v0, "setAppInviteOneLink = "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 655
    if-eqz p1, :cond_0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "oneLinkSlug"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 656
    :cond_0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "onelinkDomain"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->remove(Ljava/lang/String;)V

    .line 657
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "onelinkVersion"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->remove(Ljava/lang/String;)V

    .line 658
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "onelinkScheme"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->remove(Ljava/lang/String;)V

    .line 660
    :cond_1
    const-string v0, "oneLinkSlug"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 661
    return-void
.end method

.method public setAppUserId(Ljava/lang/String;)V
    .locals 4
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 593
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setAppUserId"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 594
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->setCustomerUserId(Ljava/lang/String;)V

    .line 595
    return-void
.end method

.method public setCollectAndroidID(Z)V
    .locals 5

    .prologue
    .line 799
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setCollectAndroidID"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 800
    const-string v0, "collectAndroidId"

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 801
    const-string v0, "collectAndroidIdForceByUser"

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 802
    return-void
.end method

.method public setCollectFingerPrint(Z)V
    .locals 5
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 812
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setCollectFingerPrint"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 813
    const-string v0, "collectFingerPrint"

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 814
    return-void
.end method

.method public setCollectIMEI(Z)V
    .locals 5

    .prologue
    .line 805
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setCollectIMEI"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 806
    const-string v0, "collectIMEI"

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 807
    const-string v0, "collectIMEIForceByUser"

    invoke-static {p1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 808
    return-void
.end method

.method public setConsumeAFDeepLinks(Z)V
    .locals 3

    .prologue
    .line 2473
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "consumeAfDeepLink"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 2474
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setConsumeAFDeepLinks: "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 2475
    return-void
.end method

.method public setCurrencyCode(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 1006
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setCurrencyCode"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1007
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "currencyCode"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 1008
    return-void
.end method

.method public setCustomerIdAndTrack(Ljava/lang/String;Landroid/content/Context;)V
    .locals 7
    .param p2    # Landroid/content/Context;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    const/4 v0, 0x0

    const/4 v3, 0x0

    const/4 v1, 0x1

    .line 611
    if-eqz p2, :cond_2

    .line 0
    const-string v2, "waitForCustomerId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v2, v0}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-eqz v2, :cond_0

    const-string v2, "AppUserId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-nez v2, :cond_0

    move v0, v1

    .line 612
    :cond_0
    if-eqz v0, :cond_4

    .line 613
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->setCustomerUserId(Ljava/lang/String;)V

    .line 614
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "CustomerUserId set: "

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, " - Initializing AppsFlyer Tacking"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 615
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, p2}, Lcom/appsflyer/AppsFlyerProperties;->getReferrer(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 616
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 616
    if-nez v5, :cond_1

    const-string v5, ""

    :cond_1
    instance-of v0, p2, Landroid/app/Activity;

    if-eqz v0, :cond_3

    move-object v0, p2

    check-cast v0, Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v6

    :goto_0
    move-object v0, p0

    move-object v1, p2

    move-object v4, v3

    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/content/Intent;)V

    .line 617
    const-string v0, "afUninstallToken"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 617
    if-eqz v0, :cond_2

    .line 618
    const-string v0, "afUninstallToken"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 618
    invoke-virtual {p0, p2, v0}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;Ljava/lang/String;)V

    .line 625
    :cond_2
    :goto_1
    return-void

    :cond_3
    move-object v6, v3

    .line 616
    goto :goto_0

    .line 621
    :cond_4
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->setCustomerUserId(Ljava/lang/String;)V

    .line 622
    const-string v0, "waitForCustomerUserId is false; setting CustomerUserID: "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    goto :goto_1
.end method

.method public setCustomerUserId(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 598
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setCustomerUserId"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 599
    const-string v0, "setCustomerUserId = "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 600
    const-string v0, "AppUserId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 601
    return-void
.end method

.method public setDebugLog(Z)V
    .locals 5

    .prologue
    .line 492
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setDebugLog"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 493
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    .line 60931
    const-string v1, "shouldLog"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 494
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    if-eqz p1, :cond_0

    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->DEBUG:Lcom/appsflyer/AFLogger$LogLevel;

    .line 61933
    :goto_0
    const-string v2, "logLevel"

    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-virtual {v1, v2, v0}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;I)V

    .line 495
    return-void

    .line 494
    :cond_0
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    goto :goto_0
.end method

.method protected setDeepLinkData(Landroid/content/Intent;)V
    .locals 2

    .prologue
    .line 1112
    if-eqz p1, :cond_0

    :try_start_0
    const-string v0, "android.intent.action.VIEW"

    invoke-virtual {p1}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1113
    invoke-virtual {p1}, Landroid/content/Intent;->getData()Landroid/net/Uri;

    move-result-object v0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    .line 1114
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "Unity setDeepLinkData = "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 1119
    :cond_0
    :goto_0
    return-void

    .line 1116
    :catch_0
    move-exception v0

    .line 1117
    const-string v1, "Exception while setting deeplink data (unity). "

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public setDeviceTrackingDisabled(Z)V
    .locals 5

    .prologue
    .line 1261
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setDeviceTrackingDisabled"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1262
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "deviceTrackingDisabled"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 1263
    return-void
.end method

.method public setExtension(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 996
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setExtension"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 997
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "sdkExtension"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 998
    return-void
.end method

.method public setGCMProjectID(Ljava/lang/String;)V
    .locals 4
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 451
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setGCMProjectID"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 452
    const-string v0, "Method \'setGCMProjectNumber\' is deprecated. Please follow the documentation."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 453
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->enableUninstallTracking(Ljava/lang/String;)V

    .line 454
    return-void
.end method

.method public setGCMProjectNumber(Landroid/content/Context;Ljava/lang/String;)V
    .locals 4
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 473
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setGCMProjectNumber"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p2, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 474
    const-string v0, "Method \'setGCMProjectNumber\' is deprecated. Please use \'enableUninstallTracking\'."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 475
    invoke-virtual {p0, p2}, Lcom/appsflyer/AppsFlyerLib;->enableUninstallTracking(Ljava/lang/String;)V

    .line 476
    return-void
.end method

.method public setGCMProjectNumber(Ljava/lang/String;)V
    .locals 4
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 462
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setGCMProjectNumber"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 463
    const-string v0, "Method \'setGCMProjectNumber\' is deprecated. Please follow the documentation."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 464
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->enableUninstallTracking(Ljava/lang/String;)V

    .line 465
    return-void
.end method

.method public setHostName(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 3388
    const-string v0, "custom_host"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 3389
    return-void
.end method

.method public setImeiData(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 498
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setImeiData"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 499
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    .line 500
    return-void
.end method

.method public setIsUpdate(Z)V
    .locals 5

    .prologue
    .line 1001
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setIsUpdate"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1002
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "IS_UPDATE"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 1003
    return-void
.end method

.method public setLogLevel(Lcom/appsflyer/AFLogger$LogLevel;)V
    .locals 3

    .prologue
    .line 3384
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    .line 0
    const-string v1, "logLevel"

    invoke-virtual {p1}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v2

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;I)V

    .line 3385
    return-void
.end method

.method public setMinTimeBetweenSessions(I)V
    .locals 4

    .prologue
    .line 3402
    sget-object v0, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    int-to-long v2, p1

    invoke-virtual {v0, v2, v3}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˊॱ:J

    .line 3403
    return-void
.end method

.method public setOutOfStore(Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 643
    if-eqz p1, :cond_0

    .line 644
    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    .line 645
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v2, "api_store_value"

    invoke-virtual {v1, v2, v0}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 646
    const-string v1, "Store API set with value: "

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x1

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 650
    :goto_0
    return-void

    .line 648
    :cond_0
    const-string v0, "Cannot set setOutOfStore with null"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->ˋ(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public setPreinstallAttribution(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 2478
    const-string v0, "setPreinstallAttribution API called"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 2479
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 2481
    if-eqz p1, :cond_0

    .line 2482
    :try_start_0
    const-string v0, "pid"

    invoke-virtual {v1, v0, p1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 2484
    :cond_0
    if-eqz p2, :cond_1

    .line 2485
    const-string v0, "c"

    invoke-virtual {v1, v0, p2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 2487
    :cond_1
    if-eqz p3, :cond_2

    .line 2488
    const-string v0, "af_siteid"

    invoke-virtual {v1, v0, p3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 2495
    :cond_2
    :goto_0
    const-string v0, "pid"

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 2496
    const-string v0, "preInstallName"

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 2501
    :goto_1
    return-void

    .line 2491
    :catch_0
    move-exception v0

    .line 2492
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 2499
    :cond_3
    const-string v0, "Cannot set preinstall attribution data without a media source"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_1
.end method

.method public setUserEmail(Ljava/lang/String;)V
    .locals 4
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .prologue
    .line 751
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setUserEmail"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 752
    const-string v0, "userEmail"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 753
    return-void
.end method

.method public varargs setUserEmails(Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;[Ljava/lang/String;)V
    .locals 8

    .prologue
    .line 761
    new-instance v0, Ljava/util/ArrayList;

    array-length v1, p2

    add-int/lit8 v1, v1, 0x1

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    .line 762
    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 763
    invoke-static {p2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/List;->addAll(Ljava/util/Collection;)Z

    .line 764
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    const-string v2, "setUserEmails"

    array-length v3, p2

    add-int/lit8 v3, v3, 0x1

    new-array v3, v3, [Ljava/lang/String;

    invoke-interface {v0, v3}, Ljava/util/List;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Ljava/lang/String;

    invoke-virtual {v1, v2, v0}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 766
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "userEmailsCryptType"

    invoke-virtual {p1}, Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;->getValue()I

    move-result v2

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;I)V

    .line 767
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 768
    const/4 v1, 0x0

    .line 769
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    .line 771
    array-length v4, p2

    const/4 v0, 0x0

    move v7, v0

    move-object v0, v1

    move v1, v7

    :goto_0
    if-ge v1, v4, :cond_0

    aget-object v5, p2, v1

    .line 772
    sget-object v0, Lcom/appsflyer/AppsFlyerLib$5;->ˋ:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v6

    aget v0, v0, v6

    packed-switch v0, :pswitch_data_0

    .line 775
    const-string v0, "sha1_el_arr"

    .line 776
    invoke-static {v5}, Lcom/appsflyer/s;->ˎ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v5}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    .line 771
    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 779
    :pswitch_0
    const-string v0, "md5_el_arr"

    .line 780
    invoke-static {v5}, Lcom/appsflyer/s;->ˊ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v5}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    goto :goto_1

    .line 783
    :pswitch_1
    const-string v0, "sha256_el_arr"

    .line 784
    invoke-static {v5}, Lcom/appsflyer/s;->ˏ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v5}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    goto :goto_1

    .line 787
    :pswitch_2
    const-string v0, "plain_el_arr"

    .line 788
    invoke-virtual {v3, v5}, Ljava/util/AbstractCollection;->add(Ljava/lang/Object;)Z

    goto :goto_1

    .line 793
    :cond_0
    invoke-interface {v2, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 794
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v2}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 795
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->setUserEmails(Ljava/lang/String;)V

    .line 796
    return-void

    .line 772
    :pswitch_data_0
    .packed-switch 0x2
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method

.method public varargs setUserEmails([Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 756
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "setUserEmails"

    invoke-virtual {v0, v1, p1}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 757
    sget-object v0, Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;->NONE:Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;

    invoke-virtual {p0, v0, p1}, Lcom/appsflyer/AppsFlyerLib;->setUserEmails(Lcom/appsflyer/AppsFlyerProperties$EmailsCryptType;[Ljava/lang/String;)V

    .line 758
    return-void
.end method

.method public startTracking(Landroid/app/Application;)V
    .locals 1

    .prologue
    .line 900
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˍ:Z

    if-nez v0, :cond_0

    .line 901
    const-string v0, "ERROR: AppsFlyer SDK is not initialized! The API call \'startTracking(Application)\' must be called after the \'init(String, AppsFlyerConversionListener)\' API method, which should be called on the Application\'s onCreate."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 906
    :goto_0
    return-void

    .line 905
    :cond_0
    const/4 v0, 0x0

    invoke-virtual {p0, p1, v0}, Lcom/appsflyer/AppsFlyerLib;->startTracking(Landroid/app/Application;Ljava/lang/String;)V

    goto :goto_0
.end method

.method public startTracking(Landroid/app/Application;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 917
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0}, Lcom/appsflyer/AppsFlyerLib;->startTracking(Landroid/app/Application;Ljava/lang/String;Lcom/appsflyer/AppsFlyerTrackingRequestListener;)V

    .line 918
    return-void
.end method

.method public startTracking(Landroid/app/Application;Ljava/lang/String;Lcom/appsflyer/AppsFlyerTrackingRequestListener;)V
    .locals 5

    .prologue
    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 932
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "startTracking"

    new-array v2, v4, [Ljava/lang/String;

    aput-object p2, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 933
    const-string v0, "Starting AppsFlyer Tracking: (v%s.%s)"

    const/4 v1, 0x2

    new-array v1, v1, [Ljava/lang/Object;

    const-string v2, "4.8.14"

    aput-object v2, v1, v3

    const-string v2, "393"

    aput-object v2, v1, v4

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 934
    const-string v0, "Build Number: 393"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 935
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->loadProperties(Landroid/content/Context;)V

    .line 936
    invoke-static {p2}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_2

    .line 937
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 938
    invoke-static {p2}, Lcom/appsflyer/j$1;->ˋ(Ljava/lang/String;)V

    .line 948
    :cond_0
    if-eqz p3, :cond_1

    .line 949
    sput-object p3, Lcom/appsflyer/AppsFlyerLib;->ॱˋ:Lcom/appsflyer/AppsFlyerTrackingRequestListener;

    .line 951
    :cond_1
    invoke-direct {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/app/Application;)V

    .line 952
    :goto_0
    return-void

    .line 940
    :cond_2
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 940
    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 941
    const-string v0, "ERROR: AppsFlyer SDK is not initialized! You must provide AppsFlyer Dev-Key either in the \'init\' API method (should be called on Application\'s onCreate),or in the startTracking API method (should be called on Activity\'s onCreate)."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public stopTracking(ZLandroid/content/Context;)V
    .locals 3

    .prologue
    .line 386
    iput-boolean p1, p0, Lcom/appsflyer/AppsFlyerLib;->ˏˎ:Z

    .line 387
    invoke-static {}, Lcom/appsflyer/cache/CacheManager;->getInstance()Lcom/appsflyer/cache/CacheManager;

    move-result-object v0

    invoke-virtual {v0, p2}, Lcom/appsflyer/cache/CacheManager;->clearCache(Landroid/content/Context;)V

    .line 388
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˏˎ:Z

    if-eqz v0, :cond_0

    .line 389
    const-string v0, "is_stop_tracking_used"

    .line 54896
    const-string v1, "appsflyer-data"

    const/4 v2, 0x0

    invoke-virtual {p2, v1, v2}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    .line 56898
    invoke-interface {v1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v1

    .line 56899
    const/4 v2, 0x1

    invoke-interface {v1, v0, v2}, Landroid/content/SharedPreferences$Editor;->putBoolean(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;

    .line 57902
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x9

    if-lt v0, v2, :cond_1

    .line 57903
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V

    :cond_0
    :goto_0
    return-void

    .line 57905
    :cond_1
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_0
.end method

.method public trackAppLaunch(Landroid/content/Context;Ljava/lang/String;)V
    .locals 7

    .prologue
    const/4 v3, 0x0

    .line 1087
    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1090
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    if-nez v0, :cond_1

    .line 1091
    new-instance v0, Lcom/appsflyer/c;

    invoke-direct {v0}, Lcom/appsflyer/c;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    .line 1092
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib;->ॱˎ:Lcom/appsflyer/c;

    invoke-virtual {v0, p1, p0}, Lcom/appsflyer/c;->ˎ(Landroid/content/Context;Lcom/appsflyer/a;)V

    .line 1098
    :cond_0
    :goto_0
    const-string v5, ""

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v4, v3

    move-object v6, v3

    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/content/Intent;)V

    .line 1106
    return-void

    .line 1094
    :cond_1
    const-string v0, "AFInstallReferrer instance already created"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 1129
    new-instance v1, Lorg/json/JSONObject;

    if-nez p3, :cond_0

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    :goto_0
    invoke-direct {v1, v0}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 1130
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "trackEvent"

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/String;

    const/4 v4, 0x0

    aput-object p2, v3, v4

    const/4 v4, 0x1

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1131
    invoke-virtual {p0, p1, p2, p3}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 1132
    return-void

    :cond_0
    move-object v0, p3

    .line 1129
    goto :goto_0
.end method

.method public trackLocation(Landroid/content/Context;DD)V
    .locals 6

    .prologue
    .line 1011
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "trackLocation"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    invoke-static {p2, p3}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    const/4 v3, 0x1

    invoke-static {p4, p5}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1012
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 1013
    const-string v1, "af_long"

    invoke-static {p4, p5}, Ljava/lang/Double;->toString(D)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1014
    const-string v1, "af_lat"

    invoke-static {p2, p3}, Ljava/lang/Double;->toString(D)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1016
    const-string v1, "af_location_coordinates"

    invoke-virtual {p0, p1, v1, v0}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 1017
    return-void
.end method

.method public unregisterConversionListener()V
    .locals 3

    .prologue
    .line 1298
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "unregisterConversionListener"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 1299
    const/4 v0, 0x0

    sput-object v0, Lcom/appsflyer/AppsFlyerLib;->ͺ:Lcom/appsflyer/AppsFlyerConversionListener;

    .line 1300
    return-void
.end method

.method public updateServerUninstallToken(Landroid/content/Context;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 485
    if-eqz p2, :cond_0

    .line 486
    new-instance v0, Lcom/appsflyer/b;

    invoke-direct {v0, p2}, Lcom/appsflyer/b;-><init>(Ljava/lang/String;)V

    .line 487
    invoke-static {p1, v0}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    .line 489
    :cond_0
    return-void
.end method

.method public validateAndTrackInAppPurchase(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;)V
    .locals 13
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 2928
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v3

    const-string v4, "validateAndTrackInAppPurchase"

    const/4 v2, 0x6

    new-array v5, v2, [Ljava/lang/String;

    const/4 v2, 0x0

    aput-object p2, v5, v2

    const/4 v2, 0x1

    aput-object p3, v5, v2

    const/4 v2, 0x2

    aput-object p4, v5, v2

    const/4 v2, 0x3

    aput-object p5, v5, v2

    const/4 v2, 0x4

    aput-object p6, v5, v2

    const/4 v6, 0x5

    if-nez p7, :cond_3

    const-string v2, ""

    :goto_0
    aput-object v2, v5, v6

    invoke-virtual {v3, v4, v5}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;[Ljava/lang/String;)V

    .line 2930
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    if-nez v2, :cond_0

    .line 2931
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Validate in app called with parameters: "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    move-object/from16 v0, p4

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    move-object/from16 v0, p5

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    move-object/from16 v0, p6

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 2933
    :cond_0
    if-eqz p2, :cond_1

    if-eqz p5, :cond_1

    if-eqz p3, :cond_1

    if-eqz p6, :cond_1

    if-nez p4, :cond_4

    .line 2934
    :cond_1
    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ˏ:Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;

    if-eqz v2, :cond_2

    .line 2935
    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ˏ:Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;

    const-string v3, "Please provide purchase parameters"

    invoke-interface {v2, v3}, Lcom/appsflyer/AppsFlyerInAppPurchaseValidatorListener;->onValidateInAppFailure(Ljava/lang/String;)V

    .line 2957
    :cond_2
    :goto_1
    return-void

    .line 2928
    :cond_3
    invoke-virtual/range {p7 .. p7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    goto :goto_0

    .line 2939
    :cond_4
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v11

    .line 2941
    new-instance v2, Lcom/appsflyer/h;

    .line 2942
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const-string v4, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v5

    invoke-virtual {v5, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 2943
    instance-of v5, p1, Landroid/app/Activity;

    if-eqz v5, :cond_5

    check-cast p1, Landroid/app/Activity;

    .line 2950
    invoke-virtual {p1}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v12

    :goto_2
    move-object v5, p2

    move-object/from16 v6, p3

    move-object/from16 v7, p4

    move-object/from16 v8, p5

    move-object/from16 v9, p6

    move-object/from16 v10, p7

    invoke-direct/range {v2 .. v12}, Lcom/appsflyer/h;-><init>(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;Ljava/util/concurrent/ScheduledExecutorService;Landroid/content/Intent;)V

    .line 2953
    const-wide/16 v4, 0xa

    sget-object v3, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v11, v2, v4, v5, v3}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V

    goto :goto_1

    .line 2950
    :cond_5
    const/4 v12, 0x0

    goto :goto_2
.end method

.method public waitForCustomerUserId(Z)V
    .locals 2

    .prologue
    .line 606
    const-string v0, "initAfterCustomerUserID: "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x1

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 607
    const-string v0, "waitForCustomerId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0, p1}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 608
    return-void
.end method

.method final ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation

    .prologue
    const/4 v2, 0x0

    .line 1135
    instance-of v0, p1, Landroid/app/Activity;

    if-eqz v0, :cond_0

    move-object v0, p1

    check-cast v0, Landroid/app/Activity;

    invoke-virtual {v0}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v6

    .line 1136
    :goto_0
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1137
    if-nez v0, :cond_1

    .line 1138
    const-string v0, "[TrackEvent/Launch] AppsFlyer\'s SDK cannot send any event without providing DevKey."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 1144
    :goto_1
    return-void

    :cond_0
    move-object v6, v2

    .line 1135
    goto :goto_0

    .line 1141
    :cond_1
    new-instance v0, Lorg/json/JSONObject;

    if-nez p3, :cond_2

    new-instance p3, Ljava/util/HashMap;

    invoke-direct {p3}, Ljava/util/HashMap;-><init>()V

    :cond_2
    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 1142
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, p1}, Lcom/appsflyer/AppsFlyerProperties;->getReferrer(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 1143
    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v4

    if-nez v5, :cond_3

    const-string v5, ""

    :cond_3
    move-object v0, p0

    move-object v1, p1

    move-object v3, p2

    invoke-direct/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/content/Intent;)V

    goto :goto_1
.end method

.method final ˋ(Ljava/lang/ref/WeakReference;)V
    .locals 10
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;)V"
        }
    .end annotation

    .prologue
    const/4 v9, 0x0

    .line 1020
    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    .line 1082
    :goto_0
    return-void

    .line 1024
    :cond_0
    const-string v0, "app went to background"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1025
    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v1, "appsflyer-data"

    invoke-virtual {v0, v1, v9}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    .line 1026
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, v2}, Lcom/appsflyer/AppsFlyerProperties;->saveProperties(Landroid/content/SharedPreferences;)V

    .line 1029
    iget-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˈ:J

    iget-wide v4, p0, Lcom/appsflyer/AppsFlyerLib;->ʼॱ:J

    sub-long v4, v0, v4

    .line 1031
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 1032
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 1033
    if-nez v6, :cond_1

    .line 1034
    const-string v0, "[callStats] AppsFlyer\'s SDK cannot send any event without providing DevKey."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_0

    .line 1037
    :cond_1
    const-string v0, "KSAppsFlyerId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    invoke-virtual {v1, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 1039
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v7, "deviceTrackingDisabled"

    invoke-virtual {v0, v7, v9}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    .line 1040
    if-eqz v0, :cond_2

    .line 1041
    const-string v0, "deviceTrackingDisabled"

    const-string v7, "true"

    invoke-interface {v3, v0, v7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1043
    :cond_2
    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/o;->ˎ(Landroid/content/ContentResolver;)Lcom/appsflyer/n;

    move-result-object v0

    .line 1044
    if-eqz v0, :cond_3

    .line 1045
    const-string v7, "amazon_aid"

    invoke-virtual {v0}, Lcom/appsflyer/n;->ˊ()Ljava/lang/String;

    move-result-object v8

    invoke-interface {v3, v7, v8}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1046
    const-string v7, "amazon_aid_limit"

    invoke-virtual {v0}, Lcom/appsflyer/n;->ˏ()Z

    move-result v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v0

    invoke-interface {v3, v7, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1048
    :cond_3
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v7, "advertiserId"

    invoke-virtual {v0, v7}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1049
    if-eqz v0, :cond_4

    .line 1050
    const-string v7, "advertiserId"

    invoke-interface {v3, v7, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1052
    :cond_4
    const-string v7, "app_id"

    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    invoke-interface {v3, v7, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1053
    const-string v0, "devkey"

    invoke-interface {v3, v0, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1054
    const-string v0, "uid"

    invoke-static {p1}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v3, v0, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1055
    const-string v0, "time_in_app"

    const-wide/16 v6, 0x3e8

    div-long/2addr v4, v6

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v4

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1056
    const-string v0, "statType"

    const-string v4, "user_closed_app"

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1057
    const-string v0, "platform"

    const-string v4, "Android"

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1058
    const-string v0, "launch_counter"

    .line 0
    const-string v4, "appsFlyerCount"

    invoke-static {v2, v4, v9}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v4

    .line 1058
    invoke-static {v4}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v4

    invoke-interface {v3, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1059
    const-string v0, "gcd_conversion_data_timing"

    const-string v4, "appsflyerGetConversionDataTiming"

    const-wide/16 v6, 0x0

    invoke-interface {v2, v4, v6, v7}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->toString(J)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v3, v0, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1060
    const-string v2, "channel"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v4, "channel"

    invoke-virtual {v0, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_5

    const-string v0, "CHANNEL"

    invoke-static {p1, v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1060
    :cond_5
    invoke-interface {v3, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1061
    const-string v2, "originalAppsflyerId"

    if-eqz v1, :cond_6

    move-object v0, v1

    :goto_1
    invoke-interface {v3, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1063
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˎˎ:Z

    if-eqz v0, :cond_8

    .line 1065
    :try_start_0
    new-instance v0, Lcom/appsflyer/m;

    const/4 v1, 0x0

    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    invoke-direct {v0, v1, v2}, Lcom/appsflyer/m;-><init>(Landroid/content/Context;Z)V

    .line 1066
    iput-object v3, v0, Lcom/appsflyer/m;->ˎ:Ljava/util/Map;

    .line 1067
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    invoke-virtual {v2}, Landroid/os/Looper;->getThread()Ljava/lang/Thread;

    move-result-object v2

    if-ne v1, v2, :cond_7

    .line 1068
    const-string v1, "Main thread detected. Running callStats task in a new thread."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 1069
    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "https://stats.%s/stats"

    invoke-static {v3}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v2

    invoke-virtual {v0, v1}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 1075
    :catch_0
    move-exception v0

    .line 1076
    const-string v1, "Could not send callStats request"

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_0

    .line 1061
    :cond_6
    const-string v0, ""

    goto :goto_1

    .line 1071
    :cond_7
    :try_start_1
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "Running callStats task (on current thread: "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, " )"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 1072
    invoke-virtual {v0}, Lcom/appsflyer/m;->onPreExecute()V

    .line 1073
    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/String;

    const/4 v2, 0x0

    const-string v3, "https://stats.%s/stats"

    invoke-static {v3}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    aput-object v3, v1, v2

    invoke-virtual {v0, v1}, Lcom/appsflyer/m;->ॱ([Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/appsflyer/m;->ˎ(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0

    .line 1080
    :cond_8
    const-string v0, "Stats call is disabled, ignore ..."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto/16 :goto_0
.end method

.method final ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLandroid/content/SharedPreferences;ZLandroid/content/Intent;)Ljava/util/Map;
    .locals 12
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Z",
            "Landroid/content/SharedPreferences;",
            "Z",
            "Landroid/content/Intent;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation

    .prologue
    .line 1624
    new-instance v5, Ljava/util/HashMap;

    invoke-direct {v5}, Ljava/util/HashMap;-><init>()V

    .line 1625
    invoke-static {p1, v5}, Lcom/appsflyer/o;->ˏ(Landroid/content/Context;Ljava/util/Map;)V

    .line 1627
    new-instance v2, Ljava/util/Date;

    invoke-direct {v2}, Ljava/util/Date;-><init>()V

    invoke-virtual {v2}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    .line 1628
    const-string v4, "af_timestamp"

    invoke-static {v2, v3}, Ljava/lang/Long;->toString(J)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v5, v4, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1630
    invoke-static {p1, v2, v3}, Lcom/appsflyer/d;->ˏ(Landroid/content/Context;J)Ljava/lang/String;

    move-result-object v2

    .line 1631
    if-eqz v2, :cond_0

    .line 1632
    const-string v3, "cksm_v1"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1636
    :cond_0
    :try_start_0
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    if-nez v2, :cond_38

    .line 1637
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v2, "******* sendTrackingWithEvent: "

    invoke-direct {v3, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    if-eqz p8, :cond_37

    const-string v2, "Launch"

    :goto_0
    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1641
    :goto_1
    const-string v3, "AppsFlyer_4.8.14"

    const-string v4, "EVENT_CREATED_WITH_NAME"

    if-eqz p8, :cond_39

    const-string v2, "Launch"

    :goto_2
    invoke-static {p1, v3, v4, v2}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1642
    invoke-static {}, Lcom/appsflyer/cache/CacheManager;->getInstance()Lcom/appsflyer/cache/CacheManager;

    move-result-object v2

    invoke-virtual {v2, p1}, Lcom/appsflyer/cache/CacheManager;->init(Landroid/content/Context;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 1646
    :try_start_1
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    const/16 v4, 0x1000

    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v2

    .line 1647
    iget-object v2, v2, Landroid/content/pm/PackageInfo;->requestedPermissions:[Ljava/lang/String;

    invoke-static {v2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    .line 1648
    const-string v3, "android.permission.INTERNET"

    invoke-interface {v2, v3}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_1

    .line 1649
    const-string v3, "Permission android.permission.INTERNET is missing in the AndroidManifest.xml"

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 1650
    const/4 v3, 0x0

    const-string v4, "PERMISSION_INTERNET_MISSING"

    const/4 v6, 0x0

    invoke-static {p1, v3, v4, v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1652
    :cond_1
    const-string v3, "android.permission.ACCESS_NETWORK_STATE"

    invoke-interface {v2, v3}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_2

    .line 1653
    const-string v3, "Permission android.permission.ACCESS_NETWORK_STATE is missing in the AndroidManifest.xml"

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 1655
    :cond_2
    const-string v3, "android.permission.ACCESS_WIFI_STATE"

    invoke-interface {v2, v3}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_3

    .line 1656
    const-string v2, "Permission android.permission.ACCESS_WIFI_STATE is missing in the AndroidManifest.xml"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    .line 1662
    :cond_3
    :goto_3
    if-eqz p6, :cond_4

    .line 1663
    :try_start_2
    const-string v2, "af_events_api"

    const-string v3, "1"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1665
    :cond_4
    const-string v2, "brand"

    sget-object v3, Landroid/os/Build;->BRAND:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1666
    const-string v2, "device"

    sget-object v3, Landroid/os/Build;->DEVICE:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1667
    const-string v2, "product"

    sget-object v3, Landroid/os/Build;->PRODUCT:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1668
    const-string v2, "sdk"

    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    invoke-static {v3}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1669
    const-string v2, "model"

    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1670
    const-string v2, "deviceType"

    sget-object v3, Landroid/os/Build;->TYPE:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1671
    const-string v2, "deviceRm"

    sget-object v3, Landroid/os/Build;->DISPLAY:Ljava/lang/String;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1673
    if-eqz p8, :cond_49

    .line 0
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v3, "appsFlyerCount"

    invoke-interface {v2, v3}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_3a

    const/4 v2, 0x1

    .line 1674
    :goto_4
    if-eqz v2, :cond_7

    .line 1675
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AppsFlyerProperties;->isOtherSdkStringDisabled()Z

    move-result v2

    if-nez v2, :cond_5

    .line 1676
    const-string v3, "af_sdks"

    .line 0
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "com.tune.Tune"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3b

    const/4 v2, 0x1

    :goto_5
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "com.adjust.sdk.Adjust"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3c

    const/4 v2, 0x1

    :goto_6
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "com.kochava.android.tracker.Feature"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3d

    const/4 v2, 0x1

    :goto_7
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "io.branch.referral.Branch"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3e

    const/4 v2, 0x1

    :goto_8
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "com.apsalar.sdk.Apsalar"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3f

    const/4 v2, 0x1

    :goto_9
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "com.localytics.android.Localytics"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_40

    const/4 v2, 0x1

    :goto_a
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "com.tenjin.android.TenjinSDK"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_41

    const/4 v2, 0x1

    :goto_b
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "place holder for TD"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_42

    const/4 v2, 0x1

    :goto_c
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "it.partytrack.sdk.Track"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_43

    const/4 v2, 0x1

    :goto_d
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v2, "jp.appAdForce.android.LtvManager"

    iget-object v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v6, v2}, Lcom/appsflyer/r;->ˊ(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_44

    const/4 v2, 0x1

    :goto_e
    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    .line 1676
    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1677
    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ʻ(Landroid/content/Context;)F

    move-result v2

    .line 1678
    const-string v3, "batteryLevel"

    invoke-static {v2}, Ljava/lang/String;->valueOf(F)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :cond_5
    const/16 v2, 0x12

    const-string v3, "OPPO"

    sget-object v4, Landroid/os/Build;->BRAND:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_45

    const/4 v3, 0x1

    :goto_f
    if-eqz v3, :cond_6

    const/16 v2, 0x17

    const-string v3, "OPPO device found"

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    :cond_6
    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    if-lt v3, v2, :cond_47

    const-string v2, "keyPropDisableAFKeystore"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    const/4 v4, 0x0

    invoke-virtual {v3, v2, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-nez v2, :cond_47

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "OS SDK is="

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "; use KeyStore"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    new-instance v2, Lcom/appsflyer/AFKeystoreWrapper;

    invoke-direct {v2, p1}, Lcom/appsflyer/AFKeystoreWrapper;-><init>(Landroid/content/Context;)V

    invoke-virtual {v2}, Lcom/appsflyer/AFKeystoreWrapper;->ˊ()Z

    move-result v3

    if-nez v3, :cond_46

    new-instance v3, Ljava/lang/ref/WeakReference;

    invoke-direct {v3, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v3}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/appsflyer/AFKeystoreWrapper;->ˏ(Ljava/lang/String;)V

    :goto_10
    const-string v3, "KSAppsFlyerId"

    invoke-virtual {v2}, Lcom/appsflyer/AFKeystoreWrapper;->ˏ()Ljava/lang/String;

    move-result-object v4

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v6

    invoke-virtual {v6, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    const-string v3, "KSAppsFlyerRICounter"

    invoke-virtual {v2}, Lcom/appsflyer/AFKeystoreWrapper;->ॱ()I

    move-result v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 1682
    :cond_7
    :goto_11
    const-string v4, "timepassedsincelastlaunch"

    .line 0
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v3, "AppsFlyerTimePassedSincePrevLaunch"

    const-wide/16 v6, 0x0

    invoke-interface {v2, v3, v6, v7}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v2

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    const-string v8, "AppsFlyerTimePassedSincePrevLaunch"

    invoke-static {p1, v8, v6, v7}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;J)V

    const-wide/16 v8, 0x0

    cmp-long v8, v2, v8

    if-lez v8, :cond_48

    sub-long v2, v6, v2

    const-wide/16 v6, 0x3e8

    div-long/2addr v2, v6

    .line 1682
    :goto_12
    invoke-static {v2, v3}, Ljava/lang/Long;->toString(J)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v4, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "oneLinkSlug"

    invoke-virtual {v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_8

    const-string v3, "onelink_id"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v2, "ol_ver"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    const-string v4, "onelinkVersion"

    invoke-virtual {v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1689
    :cond_8
    :goto_13
    const-string v2, "KSAppsFlyerId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1690
    const-string v3, "KSAppsFlyerRICounter"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 1691
    if-eqz v2, :cond_9

    if-eqz v3, :cond_9

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Number;->intValue()I

    move-result v4

    if-lez v4, :cond_9

    .line 1692
    const-string v4, "reinstallCounter"

    invoke-interface {v5, v4, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1693
    const-string v3, "originalAppsflyerId"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1696
    :cond_9
    const-string v2, "additionalCustomData"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1697
    if-eqz v2, :cond_a

    .line 1698
    const-string v3, "customData"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0

    .line 1702
    :cond_a
    :try_start_3
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Landroid/content/pm/PackageManager;->getInstallerPackageName(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1703
    if-eqz v2, :cond_b

    .line 1704
    const-string v3, "installer_package"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_3
    .catch Ljava/lang/Throwable; {:try_start_3 .. :try_end_3} :catch_0

    .line 1710
    :cond_b
    :goto_14
    :try_start_4
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "sdkExtension"

    invoke-virtual {v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1711
    if-eqz v2, :cond_c

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    if-lez v3, :cond_c

    .line 1712
    const-string v3, "sdkExtension"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1715
    :cond_c
    new-instance v3, Ljava/lang/ref/WeakReference;

    invoke-direct {v3, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v4, "channel"

    invoke-virtual {v2, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-nez v2, :cond_d

    const-string v2, "CHANNEL"

    invoke-static {v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1717
    :cond_d
    invoke-static {p1, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 1718
    if-eqz v3, :cond_e

    .line 1719
    const-string v4, "channel"

    invoke-interface {v5, v4, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1722
    :cond_e
    if-eqz v3, :cond_f

    invoke-virtual {v3, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_10

    :cond_f
    if-nez v3, :cond_11

    if-eqz v2, :cond_11

    .line 1724
    :cond_10
    const-string v3, "af_latestchannel"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :cond_11
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v3, "INSTALL_STORE"

    invoke-interface {v2, v3}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_4c

    const-string v3, "INSTALL_STORE"

    const/4 v4, 0x0

    invoke-interface {v2, v3, v4}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1728
    :goto_15
    if-eqz v2, :cond_12

    .line 1729
    const-string v3, "af_installstore"

    invoke-virtual {v2}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :cond_12
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v3

    const-string v2, "preInstallName"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-nez v2, :cond_14

    const-string v4, "preInstallName"

    invoke-interface {v3, v4}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_4f

    const-string v2, "preInstallName"

    const/4 v4, 0x0

    invoke-interface {v3, v2, v4}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    :cond_13
    :goto_16
    if-eqz v2, :cond_14

    const-string v3, "preInstallName"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 1733
    :cond_14
    if-eqz v2, :cond_15

    .line 1734
    const-string v3, "af_preinstall_name"

    invoke-virtual {v2}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1737
    :cond_15
    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ʼ(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v2

    .line 1738
    if-eqz v2, :cond_16

    .line 1739
    const-string v3, "af_currentstore"

    invoke-virtual {v2}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1742
    :cond_16
    if-eqz p2, :cond_5e

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v2

    if-ltz v2, :cond_5e

    .line 1743
    const-string v2, "appsflyerKey"

    invoke-interface {v5, v2, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :goto_17
    const-string v2, "AppUserId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1757
    if-eqz v2, :cond_17

    .line 1758
    const-string v3, "appUserId"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1761
    :cond_17
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "userEmails"

    invoke-virtual {v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1763
    if-eqz v2, :cond_60

    .line 1764
    const-string v3, "user_emails"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1772
    :cond_18
    :goto_18
    if-eqz p3, :cond_19

    .line 1773
    const-string v2, "eventName"

    invoke-interface {v5, v2, p3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1774
    if-eqz p4, :cond_19

    .line 1775
    const-string v2, "eventValue"

    move-object/from16 v0, p4

    invoke-interface {v5, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :cond_19
    const-string v2, "appid"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1779
    if-eqz v2, :cond_1a

    .line 1780
    const-string v2, "appid"

    const-string v3, "appid"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 1780
    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1782
    :cond_1a
    const-string v2, "currencyCode"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1783
    if-eqz v2, :cond_1c

    .line 1784
    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    const/4 v4, 0x3

    if-eq v3, v4, :cond_1b

    .line 1785
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "WARNING: currency code should be 3 characters!!! \'"

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "\' is not a legal value."

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 1787
    :cond_1b
    const-string v3, "currency"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1790
    :cond_1c
    const-string v2, "IS_UPDATE"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1791
    if-eqz v2, :cond_1d

    .line 1792
    const-string v3, "isUpdate"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1794
    :cond_1d
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyerLib;->isPreInstalledApp(Landroid/content/Context;)Z

    move-result v2

    .line 1795
    const-string v3, "af_preinstalled"

    invoke-static {v2}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1797
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "collectFacebookAttrId"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_0

    move-result v2

    .line 1799
    if-eqz v2, :cond_1e

    .line 1802
    :try_start_5
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    const-string v3, "com.facebook.katana"

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->getApplicationInfo(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;

    .line 1803
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v2

    invoke-virtual {p0, v2}, Lcom/appsflyer/AppsFlyerLib;->getAttributionId(Landroid/content/ContentResolver;)Ljava/lang/String;
    :try_end_5
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_5 .. :try_end_5} :catch_4
    .catch Ljava/lang/Throwable; {:try_start_5 .. :try_end_5} :catch_5

    move-result-object v2

    .line 1811
    :goto_19
    if-eqz v2, :cond_1e

    .line 1812
    :try_start_6
    const-string v3, "fb"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    :cond_1e
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "deviceTrackingDisabled"

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    if-eqz v2, :cond_61

    const-string v2, "deviceTrackingDisabled"

    const-string v3, "true"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_6
    .catch Ljava/lang/Throwable; {:try_start_6 .. :try_end_6} :catch_0

    .line 1819
    :goto_1a
    :try_start_7
    new-instance v2, Ljava/lang/ref/WeakReference;

    invoke-direct {v2, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v2}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v2

    .line 1820
    if-eqz v2, :cond_1f

    .line 1821
    const-string v3, "uid"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_7
    .catch Ljava/lang/Exception; {:try_start_7 .. :try_end_7} :catch_9
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_0

    .line 1828
    :cond_1f
    :goto_1b
    :try_start_8
    const-string v2, "lang"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/Locale;->getDisplayLanguage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_8
    .catch Ljava/lang/Exception; {:try_start_8 .. :try_end_8} :catch_a
    .catch Ljava/lang/Throwable; {:try_start_8 .. :try_end_8} :catch_0

    .line 1834
    :goto_1c
    :try_start_9
    const-string v2, "lang_code"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/Locale;->getLanguage()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_9
    .catch Ljava/lang/Exception; {:try_start_9 .. :try_end_9} :catch_b
    .catch Ljava/lang/Throwable; {:try_start_9 .. :try_end_9} :catch_0

    .line 1840
    :goto_1d
    :try_start_a
    const-string v2, "country"

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/Locale;->getCountry()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_a
    .catch Ljava/lang/Exception; {:try_start_a .. :try_end_a} :catch_c
    .catch Ljava/lang/Throwable; {:try_start_a .. :try_end_a} :catch_0

    .line 1845
    :goto_1e
    :try_start_b
    const-string v2, "platformextension"

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˋ:Lcom/appsflyer/r;

    invoke-virtual {v3}, Lcom/appsflyer/r;->ˋ()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1847
    invoke-static {p1, v5}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;Ljava/util/Map;)V

    .line 1850
    const-string v2, "yyyy-MM-dd_HHmmssZ"

    .line 0
    new-instance v3, Ljava/text/SimpleDateFormat;

    sget-object v4, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v3, v2, v4}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 1852
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_b
    .catch Ljava/lang/Throwable; {:try_start_b .. :try_end_b} :catch_0

    const/16 v4, 0x9

    if-lt v2, v4, :cond_20

    .line 1854
    :try_start_c
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v4

    const/4 v6, 0x0

    invoke-virtual {v2, v4, v6}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v2

    iget-wide v6, v2, Landroid/content/pm/PackageInfo;->firstInstallTime:J

    .line 1855
    const-string v2, "installDate"

    .line 0
    const-string v4, "UTC"

    invoke-static {v4}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v4, Ljava/util/Date;

    invoke-direct {v4, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    .line 1855
    invoke-interface {v5, v2, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_c
    .catch Ljava/lang/Exception; {:try_start_c .. :try_end_c} :catch_d
    .catch Ljava/lang/Throwable; {:try_start_c .. :try_end_c} :catch_0

    .line 1862
    :cond_20
    :goto_1f
    :try_start_d
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v4

    const/4 v6, 0x0

    invoke-virtual {v2, v4, v6}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v2

    .line 1864
    const-string v4, "versionCode"

    const/4 v6, 0x0

    move-object/from16 v0, p7

    invoke-interface {v0, v4, v6}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v4

    .line 1866
    iget v6, v2, Landroid/content/pm/PackageInfo;->versionCode:I

    if-le v6, v4, :cond_21

    .line 1869
    const-string v4, "appsflyerConversionDataRequestRetries"

    const/4 v6, 0x0

    invoke-static {p1, v4, v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;I)V

    .line 1870
    const-string v4, "versionCode"

    iget v6, v2, Landroid/content/pm/PackageInfo;->versionCode:I

    invoke-static {p1, v4, v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;I)V

    .line 1874
    :cond_21
    const-string v4, "app_version_code"

    iget v6, v2, Landroid/content/pm/PackageInfo;->versionCode:I

    invoke-static {v6}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v5, v4, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1875
    const-string v4, "app_version_name"

    iget-object v6, v2, Landroid/content/pm/PackageInfo;->versionName:Ljava/lang/String;

    invoke-interface {v5, v4, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1877
    sget v4, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v6, 0x9

    if-lt v4, v6, :cond_23

    .line 1880
    iget-wide v6, v2, Landroid/content/pm/PackageInfo;->firstInstallTime:J

    .line 1881
    iget-wide v8, v2, Landroid/content/pm/PackageInfo;->lastUpdateTime:J

    .line 1882
    const-string v2, "date1"

    .line 0
    const-string v4, "UTC"

    invoke-static {v4}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v4, Ljava/util/Date;

    invoke-direct {v4, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    .line 1882
    invoke-interface {v5, v2, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1883
    const-string v2, "date2"

    .line 0
    const-string v4, "UTC"

    invoke-static {v4}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v4, Ljava/util/Date;

    invoke-direct {v4, v8, v9}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v3, v4}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v4

    .line 1883
    invoke-interface {v5, v2, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    const-string v2, "appsflyer-data"

    const/4 v4, 0x0

    invoke-virtual {p1, v2, v4}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v4, "appsFlyerFirstInstall"

    const/4 v6, 0x0

    invoke-interface {v2, v4, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-nez v2, :cond_22

    const-string v2, "appsflyer-data"

    const/4 v4, 0x0

    invoke-virtual {p1, v2, v4}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v4, "appsFlyerCount"

    invoke-interface {v2, v4}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_6b

    const/4 v2, 0x1

    :goto_20
    if-eqz v2, :cond_6c

    const-string v2, "AppsFlyer: first launch detected"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    new-instance v2, Ljava/util/Date;

    invoke-direct {v2}, Ljava/util/Date;-><init>()V

    invoke-virtual {v3, v2}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v2

    :goto_21
    const-string v3, "appsFlyerFirstInstall"

    invoke-static {p1, v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    :cond_22
    const-string v3, "AppsFlyer: first launch date: "

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1885
    const-string v3, "firstLaunchDate"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_d
    .catch Ljava/lang/Throwable; {:try_start_d .. :try_end_d} :catch_e

    .line 1893
    :cond_23
    :goto_22
    :try_start_e
    invoke-virtual/range {p5 .. p5}, Ljava/lang/String;->length()I

    move-result v2

    if-lez v2, :cond_24

    .line 1894
    const-string v2, "referrer"

    move-object/from16 v0, p5

    invoke-interface {v5, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1902
    :cond_24
    const-string v2, "extraReferrers"

    const/4 v3, 0x0

    move-object/from16 v0, p7

    invoke-interface {v0, v2, v3}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1903
    if-eqz v2, :cond_25

    .line 1904
    const-string v3, "extraReferrers"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1908
    :cond_25
    const-string v2, "afUninstallToken"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1909
    if-eqz v2, :cond_26

    .line 1910
    invoke-static {v2}, Lcom/appsflyer/b;->ˏ(Ljava/lang/String;)Lcom/appsflyer/b;

    move-result-object v2

    .line 1912
    const-string v3, "af_gcm_token"

    invoke-virtual {v2}, Lcom/appsflyer/b;->ˎ()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1917
    :cond_26
    invoke-static {p1}, Lcom/appsflyer/u;->ˊ(Landroid/content/Context;)Z

    move-result v2

    iput-boolean v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˌ:Z

    .line 1918
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "didConfigureTokenRefreshService="

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˌ:Z

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 1919
    iget-boolean v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˌ:Z

    if-nez v2, :cond_27

    .line 1920
    const-string v2, "tokenRefreshConfigured"

    sget-object v3, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1924
    :cond_27
    if-eqz p8, :cond_29

    .line 1925
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    if-eqz v2, :cond_28

    .line 1926
    new-instance v2, Lorg/json/JSONObject;

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    invoke-direct {v2, v3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 1927
    const-string v3, "isPush"

    const-string v4, "true"

    invoke-virtual {v2, v3, v4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 1928
    const-string v3, "af_deeplink"

    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1930
    :cond_28
    const/4 v2, 0x0

    iput-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˉ:Ljava/lang/String;

    .line 1934
    :cond_29
    if-eqz p8, :cond_2b

    .line 0
    const/4 v2, 0x0

    if-eqz p9, :cond_2a

    const-string v3, "android.intent.action.VIEW"

    invoke-virtual/range {p9 .. p9}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_2a

    invoke-virtual/range {p9 .. p9}, Landroid/content/Intent;->getData()Landroid/net/Uri;

    move-result-object v2

    .line 1936
    :cond_2a
    if-eqz v2, :cond_6f

    .line 1937
    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/net/Uri;)Z

    move-result v3

    if-eqz v3, :cond_6e

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    const-string v4, "consumeAfDeepLink"

    const/4 v6, 0x0

    invoke-virtual {v3, v4, v6}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v3

    if-eqz v3, :cond_6e

    .line 1938
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    const-string v4, "prevDPURI"

    invoke-virtual {v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 1939
    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v4, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_6d

    .line 1940
    const-string v2, "Skipping execution of previously consumed AppsFlyer deep link"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1955
    :cond_2b
    :goto_23
    iget-boolean v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˋˊ:Z

    if-eqz v2, :cond_2c

    .line 1956
    const-string v2, "testAppMode_retargeting"

    const-string v3, "true"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1957
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, v5}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 1958
    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    .line 0
    new-instance v3, Landroid/content/Intent;

    const-string v4, "com.appsflyer.testIntgrationBroadcast"

    invoke-direct {v3, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const-string v4, "params"

    invoke-virtual {v3, v4, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    invoke-virtual {p1, v3}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 1959
    const-string v2, "Sent retargeting params to test app"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 0
    :cond_2c
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    iget-wide v6, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˋ:J

    sub-long/2addr v2, v6

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v4

    invoke-virtual {v4, p1}, Lcom/appsflyer/AppsFlyerProperties;->getReferrer(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    const-wide/16 v6, 0x7530

    cmp-long v2, v2, v6

    if-gtz v2, :cond_70

    if-eqz v4, :cond_70

    const-string v2, "AppsFlyer_Test"

    invoke-virtual {v4, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_70

    const/4 v2, 0x1

    .line 1963
    :goto_24
    if-eqz v2, :cond_2d

    .line 1964
    const-string v2, "testAppMode"

    const-string v3, "true"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1965
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, v5}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 1966
    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    .line 0
    new-instance v3, Landroid/content/Intent;

    const-string v4, "com.appsflyer.testIntgrationBroadcast"

    invoke-direct {v3, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const-string v4, "params"

    invoke-virtual {v3, v4, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    invoke-virtual {p1, v3}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 1967
    const-string v2, "Sent params to test app"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 0
    const-string v2, "Test mode ended!"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    const-wide/16 v2, 0x0

    iput-wide v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˋ:J

    .line 1971
    :cond_2d
    const-string v2, "advertiserId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1971
    if-nez v2, :cond_2e

    .line 1972
    invoke-static {p1, v5}, Lcom/appsflyer/o;->ˏ(Landroid/content/Context;Ljava/util/Map;)V

    .line 1973
    const-string v2, "advertiserId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1973
    if-eqz v2, :cond_71

    .line 1974
    const-string v2, "GAID_retry"

    const-string v3, "true"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1980
    :cond_2e
    :goto_25
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/o;->ˎ(Landroid/content/ContentResolver;)Lcom/appsflyer/n;

    move-result-object v2

    .line 1981
    if-eqz v2, :cond_2f

    .line 1982
    const-string v3, "amazon_aid"

    invoke-virtual {v2}, Lcom/appsflyer/n;->ˊ()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v5, v3, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1983
    const-string v3, "amazon_aid_limit"

    invoke-virtual {v2}, Lcom/appsflyer/n;->ˏ()Z

    move-result v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1988
    :cond_2f
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2, p1}, Lcom/appsflyer/AppsFlyerProperties;->getReferrer(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v2

    .line 1989
    if-eqz v2, :cond_30

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    if-lez v3, :cond_30

    const-string v3, "referrer"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    if-nez v3, :cond_30

    .line 1991
    const-string v3, "referrer"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1993
    :cond_30
    const-string v2, "true"

    const-string v3, "sentSuccessfully"

    const-string v4, ""

    move-object/from16 v0, p7

    invoke-interface {v0, v3, v4}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    .line 1995
    const-string v2, "sentRegisterRequestToAF"

    const/4 v4, 0x0

    move-object/from16 v0, p7

    invoke-interface {v0, v2, v4}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    .line 1996
    const-string v4, "registeredUninstall"

    invoke-static {v2}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v2

    invoke-interface {v5, v4, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    const-string v2, "appsFlyerCount"

    move-object/from16 v0, p7

    move/from16 v1, p8

    invoke-static {v0, v2, v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v4

    .line 1998
    const-string v2, "counter"

    invoke-static {v4}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v5, v2, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1999
    const-string v6, "iaecounter"

    if-eqz p3, :cond_72

    const/4 v2, 0x1

    .line 0
    :goto_26
    const-string v7, "appsFlyerInAppEventCount"

    move-object/from16 v0, p7

    invoke-static {v0, v7, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v2

    .line 1999
    invoke-static {v2}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v6, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2001
    if-eqz p8, :cond_31

    const/4 v2, 0x1

    if-ne v4, v2, :cond_31

    .line 2002
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AppsFlyerProperties;->setFirstLaunchCalled()V

    .line 2003
    const-string v2, "waitForCustomerId"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v6

    const/4 v7, 0x0

    invoke-virtual {v6, v2, v7}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    .line 2003
    if-eqz v2, :cond_31

    .line 2004
    const-string v2, "wait_cid"

    const/4 v6, 0x1

    invoke-static {v6}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v5, v2, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2007
    :cond_31
    const-string v6, "isFirstCall"

    if-nez v3, :cond_73

    const/4 v2, 0x1

    :goto_27
    invoke-static {v2}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v6, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    const-string v3, "cpu_abi"

    const-string v6, "ro.product.cpu.abi"

    invoke-static {v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v2, v3, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v3, "cpu_abi2"

    const-string v6, "ro.product.cpu.abi2"

    invoke-static {v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v2, v3, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v3, "arch"

    const-string v6, "os.arch"

    invoke-static {v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v2, v3, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v3, "build_display_id"

    const-string v6, "ro.build.display.id"

    invoke-static {v6}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v2, v3, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    if-eqz p8, :cond_35

    iget-boolean v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˊᐝ:Z

    if-eqz v3, :cond_33

    sget-object v3, Lcom/appsflyer/f$b;->ˎ:Lcom/appsflyer/f;

    invoke-static {p1}, Lcom/appsflyer/f;->ˏ(Landroid/content/Context;)Landroid/location/Location;

    move-result-object v3

    new-instance v6, Ljava/util/HashMap;

    const/4 v7, 0x3

    invoke-direct {v6, v7}, Ljava/util/HashMap;-><init>(I)V

    if-eqz v3, :cond_32

    const-string v7, "lat"

    invoke-virtual {v3}, Landroid/location/Location;->getLatitude()D

    move-result-wide v8

    invoke-static {v8, v9}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v8

    invoke-interface {v6, v7, v8}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v7, "lon"

    invoke-virtual {v3}, Landroid/location/Location;->getLongitude()D

    move-result-wide v8

    invoke-static {v8, v9}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v8

    invoke-interface {v6, v7, v8}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v7, "ts"

    invoke-virtual {v3}, Landroid/location/Location;->getTime()J

    move-result-wide v8

    invoke-static {v8, v9}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v6, v7, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_32
    invoke-interface {v6}, Ljava/util/Map;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_33

    const-string v3, "loc"

    invoke-interface {v2, v3, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_33
    sget-object v3, Lcom/appsflyer/e$d;->ˋ:Lcom/appsflyer/e;

    invoke-virtual {v3, p1}, Lcom/appsflyer/e;->ˏ(Landroid/content/Context;)Lcom/appsflyer/e$a;

    move-result-object v3

    const-string v6, "btl"

    invoke-virtual {v3}, Lcom/appsflyer/e$a;->ˊ()F

    move-result v7

    invoke-static {v7}, Ljava/lang/Float;->toString(F)Ljava/lang/String;

    move-result-object v7

    invoke-interface {v2, v6, v7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    invoke-virtual {v3}, Lcom/appsflyer/e$a;->ˏ()Ljava/lang/String;

    move-result-object v6

    if-eqz v6, :cond_34

    const-string v6, "btch"

    invoke-virtual {v3}, Lcom/appsflyer/e$a;->ˏ()Ljava/lang/String;

    move-result-object v3

    invoke-interface {v2, v6, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_34
    const/4 v3, 0x2

    if-lt v3, v4, :cond_35

    invoke-static {p1}, Lcom/appsflyer/j;->ˊ(Landroid/content/Context;)Lcom/appsflyer/j;

    move-result-object v3

    invoke-virtual {v3}, Lcom/appsflyer/j;->ˎ()Ljava/util/List;

    move-result-object v3

    invoke-interface {v3}, Ljava/util/List;->isEmpty()Z

    move-result v4

    if-nez v4, :cond_35

    const-string v4, "sensors"

    invoke-interface {v2, v4, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_35
    invoke-static {p1}, Lcom/appsflyer/AFScreenManager;->getScreenMetrics(Landroid/content/Context;)Ljava/util/Map;

    move-result-object v3

    const-string v4, "dim"

    invoke-interface {v2, v4, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    const-string v3, "deviceData"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2013
    new-instance v2, Lcom/appsflyer/s;

    invoke-direct {v2}, Lcom/appsflyer/s;-><init>()V

    .line 0
    const-string v2, "appsflyerKey"

    invoke-interface {v5, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const-string v3, "af_timestamp"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    const-string v4, "uid"

    invoke-interface {v5, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const/4 v7, 0x0

    const/4 v8, 0x7

    invoke-virtual {v2, v7, v8}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const/4 v6, 0x0

    const/4 v7, 0x7

    invoke-virtual {v4, v6, v7}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v4

    add-int/lit8 v4, v4, -0x7

    invoke-virtual {v3, v4}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/s;->ˎ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 2014
    const-string v3, "af_v"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2016
    new-instance v2, Lcom/appsflyer/s;

    invoke-direct {v2}, Lcom/appsflyer/s;-><init>()V

    .line 0
    const-string v2, "appsflyerKey"

    invoke-interface {v5, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "af_timestamp"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "uid"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "installDate"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "counter"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "iaecounter"

    invoke-interface {v5, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/s;->ˊ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/s;->ˎ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 2017
    const-string v3, "af_v2"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 2021
    const-string v2, "is_stop_tracking_used"

    move-object/from16 v0, p7

    invoke-interface {v0, v2}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_36

    .line 2022
    const-string v2, "istu"

    const-string v3, "is_stop_tracking_used"

    const/4 v4, 0x0

    move-object/from16 v0, p7

    invoke-interface {v0, v3, v4}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v3

    invoke-static {v3}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_36
    :goto_28
    move-object v2, v5

    .line 2027
    :goto_29
    return-object v2

    :cond_37
    move-object v2, p3

    .line 1637
    goto/16 :goto_0

    .line 1639
    :cond_38
    const-string v2, "SDK tracking has been stopped"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_e
    .catch Ljava/lang/Throwable; {:try_start_e .. :try_end_e} :catch_0

    goto/16 :goto_1

    .line 2024
    :catch_0
    move-exception v2

    .line 2025
    invoke-virtual {v2}, Ljava/lang/Throwable;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_28

    :cond_39
    move-object v2, p3

    .line 1641
    goto/16 :goto_2

    .line 1658
    :catch_1
    move-exception v2

    .line 1659
    :try_start_f
    const-string v3, "Exception while validation permissions. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_3

    .line 0
    :cond_3a
    const/4 v2, 0x0

    goto/16 :goto_4

    :cond_3b
    const/4 v2, 0x0

    goto/16 :goto_5

    :cond_3c
    const/4 v2, 0x0

    goto/16 :goto_6

    :cond_3d
    const/4 v2, 0x0

    goto/16 :goto_7

    :cond_3e
    const/4 v2, 0x0

    goto/16 :goto_8

    :cond_3f
    const/4 v2, 0x0

    goto/16 :goto_9

    :cond_40
    const/4 v2, 0x0

    goto/16 :goto_a

    :cond_41
    const/4 v2, 0x0

    goto/16 :goto_b

    :cond_42
    const/4 v2, 0x0

    goto/16 :goto_c

    :cond_43
    const/4 v2, 0x0

    goto/16 :goto_d

    :cond_44
    const/4 v2, 0x0

    goto/16 :goto_e

    :cond_45
    const/4 v3, 0x0

    goto/16 :goto_f

    :cond_46
    invoke-virtual {v2}, Lcom/appsflyer/AFKeystoreWrapper;->ˋ()V

    goto/16 :goto_10

    :cond_47
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "OS SDK is="

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    sget v3, Landroid/os/Build$VERSION;->SDK_INT:I

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "; no KeyStore usage"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    goto/16 :goto_11

    :cond_48
    const-wide/16 v2, -0x1

    goto/16 :goto_12

    :cond_49
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;
    :try_end_f
    .catch Ljava/lang/Throwable; {:try_start_f .. :try_end_f} :catch_0

    move-result-object v3

    :try_start_10
    const-string v4, "prev_event_name"

    const/4 v6, 0x0

    invoke-interface {v2, v4, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    if-eqz v4, :cond_4a

    new-instance v6, Lorg/json/JSONObject;

    invoke-direct {v6}, Lorg/json/JSONObject;-><init>()V

    const-string v7, "prev_event_timestamp"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "prev_event_timestamp"

    const-wide/16 v10, -0x1

    invoke-interface {v2, v9, v10, v11}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v10

    invoke-virtual {v8, v10, v11}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v6, v7, v8}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v7, "prev_event_value"

    const-string v8, "prev_event_value"

    const/4 v9, 0x0

    invoke-interface {v2, v8, v9}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v6, v7, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "prev_event_name"

    invoke-virtual {v6, v2, v4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "prev_event"

    invoke-virtual {v6}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v5, v2, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_4a
    const-string v2, "prev_event_name"

    invoke-interface {v3, v2, p3}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    const-string v2, "prev_event_value"

    move-object/from16 v0, p4

    invoke-interface {v3, v2, v0}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    const-string v2, "prev_event_timestamp"

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    invoke-interface {v3, v2, v6, v7}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v4, 0x9

    if-lt v2, v4, :cond_4b

    invoke-interface {v3}, Landroid/content/SharedPreferences$Editor;->apply()V
    :try_end_10
    .catch Ljava/lang/Exception; {:try_start_10 .. :try_end_10} :catch_2
    .catch Ljava/lang/Throwable; {:try_start_10 .. :try_end_10} :catch_0

    goto/16 :goto_13

    :catch_2
    move-exception v2

    :try_start_11
    const-string v3, "Error while processing previous event."

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_11
    .catch Ljava/lang/Throwable; {:try_start_11 .. :try_end_11} :catch_0

    goto/16 :goto_13

    :cond_4b
    :try_start_12
    invoke-interface {v3}, Landroid/content/SharedPreferences$Editor;->commit()Z
    :try_end_12
    .catch Ljava/lang/Exception; {:try_start_12 .. :try_end_12} :catch_2
    .catch Ljava/lang/Throwable; {:try_start_12 .. :try_end_12} :catch_0

    goto/16 :goto_13

    .line 1706
    :catch_3
    move-exception v2

    .line 1707
    :try_start_13
    const-string v3, "Exception while getting the app\'s installer package. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_14

    .line 0
    :cond_4c
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    const-string v3, "appsFlyerCount"

    invoke-interface {v2, v3}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_4d

    const/4 v2, 0x1

    :goto_2a
    if-eqz v2, :cond_4e

    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ʼ(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v2

    :goto_2b
    const-string v3, "INSTALL_STORE"

    invoke-static {p1, v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_15

    :cond_4d
    const/4 v2, 0x0

    goto :goto_2a

    :cond_4e
    const/4 v2, 0x0

    goto :goto_2b

    :cond_4f
    const-string v3, "appsflyer-data"

    const/4 v4, 0x0

    invoke-virtual {p1, v3, v4}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v3

    const-string v4, "appsFlyerCount"

    invoke-interface {v3, v4}, Landroid/content/SharedPreferences;->contains(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_57

    const/4 v3, 0x1

    :goto_2c
    if-eqz v3, :cond_56

    const-string v2, "ro.appsflyer.preinstall.path"

    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    if-eqz v2, :cond_50

    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v3

    if-nez v3, :cond_58

    :cond_50
    const/4 v3, 0x1

    :goto_2d
    if-eqz v3, :cond_51

    const-string v2, "AF_PRE_INSTALL_PATH"

    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v4

    invoke-static {v2, v3, v4}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Ljava/lang/String;Landroid/content/pm/PackageManager;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    :cond_51
    if-eqz v2, :cond_52

    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v3

    if-nez v3, :cond_59

    :cond_52
    const/4 v3, 0x1

    :goto_2e
    if-eqz v3, :cond_53

    const-string v2, "/data/local/tmp/pre_install.appsflyer"

    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    :cond_53
    if-eqz v2, :cond_54

    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v3

    if-nez v3, :cond_5a

    :cond_54
    const/4 v3, 0x1

    :goto_2f
    if-eqz v3, :cond_77

    const-string v2, "/etc/pre_install.appsflyer"

    invoke-static {v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    move-object v3, v2

    :goto_30
    if-eqz v3, :cond_55

    invoke-virtual {v3}, Ljava/io/File;->exists()Z

    move-result v2

    if-nez v2, :cond_5b

    :cond_55
    const/4 v2, 0x1

    :goto_31
    if-nez v2, :cond_5c

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-static {v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Ljava/io/File;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_5c

    :goto_32
    if-eqz v2, :cond_5d

    :cond_56
    :goto_33
    if-eqz v2, :cond_13

    const-string v3, "preInstallName"

    invoke-static {p1, v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_16

    :cond_57
    const/4 v3, 0x0

    goto :goto_2c

    :cond_58
    const/4 v3, 0x0

    goto :goto_2d

    :cond_59
    const/4 v3, 0x0

    goto :goto_2e

    :cond_5a
    const/4 v3, 0x0

    goto :goto_2f

    :cond_5b
    const/4 v2, 0x0

    goto :goto_31

    :cond_5c
    const/4 v2, 0x0

    goto :goto_32

    :cond_5d
    new-instance v2, Ljava/lang/ref/WeakReference;

    invoke-direct {v2, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    const-string v3, "AF_PRE_INSTALL_NAME"

    invoke-static {v2, v3}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    goto :goto_33

    .line 1745
    :cond_5e
    const-string v2, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1746
    if-eqz v2, :cond_5f

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    if-ltz v3, :cond_5f

    .line 1747
    const-string v3, "appsflyerKey"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto/16 :goto_17

    .line 1749
    :cond_5f
    const-string v2, "AppsFlyer dev key is missing!!! Please use  AppsFlyerLib.getInstance().setAppsFlyerKey(...) to set it. "

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1750
    const-string v2, "AppsFlyer_4.8.14"

    const-string v3, "DEV_KEY_MISSING"

    const/4 v4, 0x0

    invoke-static {p1, v2, v3, v4}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1751
    const-string v2, "AppsFlyer will not track this event."

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 1752
    const/4 v2, 0x0

    goto/16 :goto_29

    .line 1766
    :cond_60
    const-string v2, "userEmail"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 1767
    if-eqz v2, :cond_18

    .line 1768
    const-string v3, "sha1_el"

    invoke-static {v2}, Lcom/appsflyer/s;->ˎ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto/16 :goto_18

    .line 1805
    :catch_4
    move-exception v2

    const/4 v2, 0x0

    .line 1806
    const-string v3, "Exception while collecting facebook\'s attribution ID. "

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto/16 :goto_19

    .line 1807
    :catch_5
    move-exception v2

    .line 1808
    const/4 v3, 0x0

    .line 1809
    const-string v4, "Exception while collecting facebook\'s attribution ID. "

    invoke-static {v4, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v2, v3

    goto/16 :goto_19

    .line 0
    :cond_61
    const-string v2, "appsflyer-data"

    const/4 v3, 0x0

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v6

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "collectIMEI"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v2

    const-string v3, "imeiCached"

    const/4 v4, 0x0

    invoke-interface {v6, v3, v4}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const/4 v4, 0x0

    if-eqz v2, :cond_65

    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    invoke-static {v2}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_65

    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ᐝ(Landroid/content/Context;)Z
    :try_end_13
    .catch Ljava/lang/Throwable; {:try_start_13 .. :try_end_13} :catch_0

    move-result v2

    if-eqz v2, :cond_75

    :try_start_14
    const-string v2, "phone"

    invoke-virtual {p1, v2}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/telephony/TelephonyManager;

    invoke-virtual {v2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v7

    const-string v8, "getDeviceId"

    const/4 v9, 0x0

    new-array v9, v9, [Ljava/lang/Class;

    invoke-virtual {v7, v8, v9}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v7

    const/4 v8, 0x0

    new-array v8, v8, [Ljava/lang/Object;

    invoke-virtual {v7, v2, v8}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;
    :try_end_14
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_14 .. :try_end_14} :catch_6
    .catch Ljava/lang/Exception; {:try_start_14 .. :try_end_14} :catch_7
    .catch Ljava/lang/Throwable; {:try_start_14 .. :try_end_14} :catch_0

    if-eqz v2, :cond_63

    :goto_34
    if-eqz v2, :cond_66

    :try_start_15
    const-string v3, "imeiCached"

    invoke-static {p1, v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    const-string v3, "imei"

    invoke-interface {v5, v3, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :goto_35
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    const-string v3, "collectAndroidId"

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v4

    const-string v2, "androidIdCached"

    const/4 v3, 0x0

    invoke-interface {v6, v2, v3}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x0

    if-eqz v4, :cond_69

    iget-object v4, p0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_69

    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ᐝ(Landroid/content/Context;)Z
    :try_end_15
    .catch Ljava/lang/Throwable; {:try_start_15 .. :try_end_15} :catch_0

    move-result v4

    if-eqz v4, :cond_62

    :try_start_16
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v4

    const-string v6, "android_id"

    invoke-static {v4, v6}, Landroid/provider/Settings$Secure;->getString(Landroid/content/ContentResolver;Ljava/lang/String;)Ljava/lang/String;
    :try_end_16
    .catch Ljava/lang/Exception; {:try_start_16 .. :try_end_16} :catch_8
    .catch Ljava/lang/Throwable; {:try_start_16 .. :try_end_16} :catch_0

    move-result-object v4

    if-eqz v4, :cond_67

    move-object v3, v4

    :cond_62
    :goto_36
    if-eqz v3, :cond_6a

    :try_start_17
    const-string v2, "androidIdCached"

    invoke-static {p1, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    const-string v2, "android_id"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_17
    .catch Ljava/lang/Throwable; {:try_start_17 .. :try_end_17} :catch_0

    goto/16 :goto_1a

    :cond_63
    if-eqz v3, :cond_75

    :try_start_18
    const-string v2, "use cached IMEI: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v2, v7}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V
    :try_end_18
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_18 .. :try_end_18} :catch_6
    .catch Ljava/lang/Exception; {:try_start_18 .. :try_end_18} :catch_7
    .catch Ljava/lang/Throwable; {:try_start_18 .. :try_end_18} :catch_0

    move-object v2, v3

    goto :goto_34

    :catch_6
    move-exception v2

    if-eqz v3, :cond_76

    :try_start_19
    const-string v2, "use cached IMEI: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v2, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    move-object v2, v3

    :goto_37
    const-string v3, "WARNING: READ_PHONE_STATE is missing."

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_34

    :catch_7
    move-exception v2

    if-eqz v3, :cond_64

    const-string v4, "use cached IMEI: "

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v4, v7}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    move-object v4, v3

    :cond_64
    const-string v3, "WARNING: other reason: "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v2, v4

    goto/16 :goto_34

    :cond_65
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    if-eqz v2, :cond_75

    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ॱ:Ljava/lang/String;

    goto/16 :goto_34

    :cond_66
    const-string v2, "IMEI was not collected."

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_19
    .catch Ljava/lang/Throwable; {:try_start_19 .. :try_end_19} :catch_0

    goto/16 :goto_35

    :cond_67
    if-eqz v2, :cond_74

    :try_start_1a
    const-string v4, "use cached AndroidId: "

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v6}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V
    :try_end_1a
    .catch Ljava/lang/Exception; {:try_start_1a .. :try_end_1a} :catch_8
    .catch Ljava/lang/Throwable; {:try_start_1a .. :try_end_1a} :catch_0

    :goto_38
    move-object v3, v2

    goto :goto_36

    :catch_8
    move-exception v4

    if-eqz v2, :cond_68

    :try_start_1b
    const-string v3, "use cached AndroidId: "

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    move-object v3, v2

    :cond_68
    invoke-virtual {v4}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v4}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_36

    :cond_69
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    if-eqz v2, :cond_62

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib;->ˋ:Ljava/lang/String;

    goto/16 :goto_36

    :cond_6a
    const-string v2, "Android ID was not collected."

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    goto/16 :goto_1a

    .line 1823
    :catch_9
    move-exception v2

    .line 1824
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "ERROR: could not get uid "

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_1b

    .line 1829
    :catch_a
    move-exception v2

    .line 1830
    const-string v3, "Exception while collecting display language name. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_1c

    .line 1835
    :catch_b
    move-exception v2

    .line 1836
    const-string v3, "Exception while collecting display language code. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_1d

    .line 1841
    :catch_c
    move-exception v2

    .line 1842
    const-string v3, "Exception while collecting country name. "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_1e

    .line 1856
    :catch_d
    move-exception v2

    .line 1857
    const-string v4, "Exception while collecting install date. "

    invoke-static {v4, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_1b
    .catch Ljava/lang/Throwable; {:try_start_1b .. :try_end_1b} :catch_0

    goto/16 :goto_1f

    .line 0
    :cond_6b
    const/4 v2, 0x0

    goto/16 :goto_20

    :cond_6c
    :try_start_1c
    const-string v2, ""
    :try_end_1c
    .catch Ljava/lang/Throwable; {:try_start_1c .. :try_end_1c} :catch_e

    goto/16 :goto_21

    .line 1889
    :catch_e
    move-exception v2

    .line 1890
    :try_start_1d
    const-string v3, "Exception while collecting app version data "

    invoke-static {v3, v2}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_22

    .line 1942
    :cond_6d
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    const-string v4, "prevDPURI"

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v4, v6}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 1943
    invoke-direct {p0, p1, v5, v2}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;Ljava/util/Map;Landroid/net/Uri;)V

    goto/16 :goto_23

    .line 1946
    :cond_6e
    invoke-direct {p0, p1, v5, v2}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;Ljava/util/Map;Landroid/net/Uri;)V

    goto/16 :goto_23

    .line 1948
    :cond_6f
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    if-eqz v2, :cond_2b

    .line 1950
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˊ:Landroid/net/Uri;

    invoke-direct {p0, p1, v5, v2}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/content/Context;Ljava/util/Map;Landroid/net/Uri;)V

    goto/16 :goto_23

    .line 0
    :cond_70
    const/4 v2, 0x0

    goto/16 :goto_24

    .line 1976
    :cond_71
    const-string v2, "GAID_retry"

    const-string v3, "false"

    invoke-interface {v5, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1d
    .catch Ljava/lang/Throwable; {:try_start_1d .. :try_end_1d} :catch_0

    goto/16 :goto_25

    .line 1999
    :cond_72
    const/4 v2, 0x0

    goto/16 :goto_26

    .line 2007
    :cond_73
    const/4 v2, 0x0

    goto/16 :goto_27

    :cond_74
    move-object v2, v3

    goto/16 :goto_38

    :cond_75
    move-object v2, v4

    goto/16 :goto_34

    :cond_76
    move-object v2, v4

    goto/16 :goto_37

    :cond_77
    move-object v3, v2

    goto/16 :goto_30
.end method

.method final ˎ()V
    .locals 2

    .prologue
    .line 186
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˈ:J

    .line 187
    return-void
.end method

.method final ˏ()V
    .locals 2

    .prologue
    .line 182
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ʼॱ:J

    .line 183
    return-void
.end method

.method final ˏ(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 11

    .prologue
    const/16 v2, 0x9

    const/4 v3, 0x0

    const/4 v10, 0x0

    .line 190
    const-string v0, "shouldMonitor"

    invoke-virtual {p2, v0}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 191
    if-eqz v0, :cond_1

    .line 192
    const-string v1, "Turning on monitoring."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 193
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v2, "shouldMonitor"

    const-string v4, "true"

    invoke-virtual {v0, v4}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    invoke-virtual {v1, v2, v0}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Z)V

    .line 194
    const-string v0, "START_TRACKING"

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    invoke-static {p1, v3, v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 230
    :cond_0
    :goto_0
    return-void

    .line 198
    :cond_1
    const-string v0, "****** onReceive called *******"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 200
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerProperties;->setOnReceiveCalled()V

    .line 202
    const-string v0, "referrer"

    invoke-virtual {p2, v0}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 203
    const-string v0, "Play store referrer: "

    invoke-static {v6}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 205
    if-eqz v6, :cond_0

    .line 207
    const-string v0, "TestIntegrationMode"

    invoke-virtual {p2, v0}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 209
    const-string v1, "AppsFlyer_Test"

    invoke-virtual {v1, v0}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 51817
    const-string v0, "appsflyer-data"

    invoke-virtual {p1, v0, v10}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 212
    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 213
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->clear()Landroid/content/SharedPreferences$Editor;

    .line 54818
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    if-lt v1, v2, :cond_3

    .line 54819
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->apply()V

    .line 216
    :goto_1
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, v10}, Lcom/appsflyer/AppsFlyerProperties;->setFirstLaunchCalled(Z)V

    .line 54824
    const-string v0, "Test mode started.."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 54825
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/AppsFlyerLib;->ˊˋ:J

    .line 220
    :cond_2
    const-string v0, "referrer"

    .line 52832
    const-string v1, "appsflyer-data"

    invoke-virtual {p1, v1, v10}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    .line 54834
    invoke-interface {v1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v1

    .line 54835
    invoke-interface {v1, v0, v6}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 55838
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    if-lt v0, v2, :cond_4

    .line 55839
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V

    .line 223
    :goto_2
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0, v6}, Lcom/appsflyer/AppsFlyerProperties;->setReferrer(Ljava/lang/String;)V

    .line 225
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerProperties;->isFirstLaunchCalled()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 226
    const-string v0, "onReceive: isLaunchCalled"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 54849
    if-eqz v6, :cond_0

    invoke-virtual {v6}, Ljava/lang/String;->length()I

    move-result v0

    const/4 v1, 0x5

    if-le v0, v1, :cond_0

    .line 54850
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v7

    .line 54855
    new-instance v0, Lcom/appsflyer/AppsFlyerLib$a;

    new-instance v2, Ljava/lang/ref/WeakReference;

    .line 54856
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    const/4 v8, 0x1

    move-object v1, p0

    move-object v4, v3

    move-object v5, v3

    move-object v9, p2

    invoke-direct/range {v0 .. v10}, Lcom/appsflyer/AppsFlyerLib$a;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/ref/WeakReference;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/concurrent/ExecutorService;ZLandroid/content/Intent;B)V

    .line 54866
    const-wide/16 v2, 0x5

    sget-object v1, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-static {v7, v0, v2, v3, v1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/util/concurrent/ScheduledExecutorService;Ljava/lang/Runnable;JLjava/util/concurrent/TimeUnit;)V

    goto/16 :goto_0

    .line 54821
    :cond_3
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_1

    .line 55841
    :cond_4
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->commit()Z

    goto :goto_2
.end method

.method final ˏ(Landroid/content/Context;Ljava/lang/String;)V
    .locals 9

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 0
    const-string v0, "waitForCustomerId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v0, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    const-string v0, "AppUserId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_0

    move v0, v1

    .line 1165
    :goto_0
    if-eqz v0, :cond_1

    .line 1166
    const-string v0, "CustomerUserId not set, Tracking is disabled"

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 1249
    :goto_1
    return-void

    :cond_0
    move v0, v2

    .line 0
    goto :goto_0

    .line 1170
    :cond_1
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 1171
    const-string v0, "AppsFlyerKey"

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    invoke-virtual {v3, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 1172
    if-nez v3, :cond_2

    .line 1173
    const-string v0, "[registerUninstall] AppsFlyer\'s SDK cannot send any event without providing DevKey."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_1

    .line 1178
    :cond_2
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    .line 1179
    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v4

    .line 1182
    const/4 v5, 0x0

    :try_start_0
    invoke-virtual {v0, v4, v5}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v5

    .line 1183
    const-string v6, "app_version_code"

    iget v7, v5, Landroid/content/pm/PackageInfo;->versionCode:I

    invoke-static {v7}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v7

    invoke-interface {v1, v6, v7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1184
    const-string v6, "app_version_name"

    iget-object v7, v5, Landroid/content/pm/PackageInfo;->versionName:Ljava/lang/String;

    invoke-interface {v1, v6, v7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1187
    iget-object v6, v5, Landroid/content/pm/PackageInfo;->applicationInfo:Landroid/content/pm/ApplicationInfo;

    invoke-virtual {v0, v6}, Landroid/content/pm/PackageManager;->getApplicationLabel(Landroid/content/pm/ApplicationInfo;)Ljava/lang/CharSequence;

    move-result-object v0

    invoke-interface {v0}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v0

    .line 1188
    const-string v6, "app_name"

    invoke-interface {v1, v6, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1191
    iget-wide v6, v5, Landroid/content/pm/PackageInfo;->firstInstallTime:J

    .line 1192
    const-string v0, "yyyy-MM-dd_HHmmssZ"

    .line 0
    new-instance v5, Ljava/text/SimpleDateFormat;

    sget-object v8, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v5, v0, v8}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 1193
    const-string v0, "installDate"

    .line 0
    const-string v8, "UTC"

    invoke-static {v8}, Ljava/util/TimeZone;->getTimeZone(Ljava/lang/String;)Ljava/util/TimeZone;

    move-result-object v8

    invoke-virtual {v5, v8}, Ljava/text/DateFormat;->setTimeZone(Ljava/util/TimeZone;)V

    new-instance v8, Ljava/util/Date;

    invoke-direct {v8, v6, v7}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v5, v8}, Ljava/text/DateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v5

    .line 1193
    invoke-interface {v1, v0, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    .line 1197
    :goto_2
    invoke-static {p1, v1}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;Ljava/util/Map;)V

    .line 0
    const-string v0, "AppUserId"

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v5

    invoke-virtual {v5, v0}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1201
    if-eqz v0, :cond_3

    .line 1202
    const-string v5, "appUserId"

    invoke-interface {v1, v5, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1207
    :cond_3
    :try_start_1
    const-string v0, "model"

    sget-object v5, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-interface {v1, v0, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1208
    const-string v0, "brand"

    sget-object v5, Landroid/os/Build;->BRAND:Ljava/lang/String;

    invoke-interface {v1, v0, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_2

    .line 1214
    :goto_3
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v5, "deviceTrackingDisabled"

    invoke-virtual {v0, v5, v2}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    .line 1215
    if-eqz v0, :cond_4

    .line 1216
    const-string v0, "deviceTrackingDisabled"

    const-string v5, "true"

    invoke-interface {v1, v0, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1219
    :cond_4
    invoke-virtual {p1}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/o;->ˎ(Landroid/content/ContentResolver;)Lcom/appsflyer/n;

    move-result-object v0

    .line 1220
    if-eqz v0, :cond_5

    .line 1221
    const-string v5, "amazon_aid"

    invoke-virtual {v0}, Lcom/appsflyer/n;->ˊ()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v1, v5, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1222
    const-string v5, "amazon_aid_limit"

    invoke-virtual {v0}, Lcom/appsflyer/n;->ˏ()Z

    move-result v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v0

    invoke-interface {v1, v5, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1225
    :cond_5
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v5, "advertiserId"

    invoke-virtual {v0, v5}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1226
    if-eqz v0, :cond_6

    .line 1227
    const-string v5, "advertiserId"

    invoke-interface {v1, v5, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1230
    :cond_6
    const-string v0, "devkey"

    invoke-interface {v1, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1231
    const-string v0, "uid"

    new-instance v3, Ljava/lang/ref/WeakReference;

    invoke-direct {v3, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v3}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1232
    const-string v0, "af_gcm_token"

    invoke-interface {v1, v0, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    const-string v0, "appsflyer-data"

    invoke-virtual {p1, v0, v2}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    const-string v3, "appsFlyerCount"

    invoke-static {v0, v3, v2}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/SharedPreferences;Ljava/lang/String;Z)I

    move-result v0

    .line 1234
    const-string v2, "launch_counter"

    invoke-static {v0}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v0

    invoke-interface {v1, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1235
    const-string v0, "sdk"

    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    invoke-static {v2}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v1, v0, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1236
    new-instance v2, Ljava/lang/ref/WeakReference;

    invoke-direct {v2, p1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    .line 0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v3, "channel"

    invoke-virtual {v0, v3}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_7

    const-string v0, "CHANNEL"

    invoke-static {v2, v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1237
    :cond_7
    if-eqz v0, :cond_8

    .line 1238
    const-string v2, "channel"

    invoke-interface {v1, v2, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1242
    :cond_8
    :try_start_2
    new-instance v0, Lcom/appsflyer/m;

    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    invoke-direct {v0, p1, v2}, Lcom/appsflyer/m;-><init>(Landroid/content/Context;Z)V

    .line 1243
    iput-object v1, v0, Lcom/appsflyer/m;->ˎ:Ljava/util/Map;

    .line 1244
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/appsflyer/AppsFlyerLib;->ˎ:Ljava/lang/String;

    invoke-static {v2}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    .line 1245
    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    aput-object v1, v2, v3

    invoke-virtual {v0, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0

    goto/16 :goto_1

    .line 1246
    :catch_0
    move-exception v0

    .line 1247
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_1

    .line 1194
    :catch_1
    move-exception v0

    .line 1195
    const-string v5, "Exception while collecting application version info."

    invoke-static {v5, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_2

    .line 1209
    :catch_2
    move-exception v0

    .line 1210
    const-string v5, "Exception while collecting device brand and model."

    invoke-static {v5, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_3
.end method
