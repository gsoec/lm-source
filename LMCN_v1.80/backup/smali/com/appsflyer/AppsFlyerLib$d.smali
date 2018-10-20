.class final Lcom/appsflyer/AppsFlyerLib$d;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/AppsFlyerLib;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "d"
.end annotation


# instance fields
.field private ˊ:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;"
        }
    .end annotation
.end field

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

.field private ˏ:Ljava/lang/String;

.field private ॱ:I

.field private synthetic ᐝ:Lcom/appsflyer/AppsFlyerLib;


# direct methods
.method private constructor <init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/util/Map;Landroid/content/Context;ZI)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;",
            "Landroid/content/Context;",
            "ZI)V"
        }
    .end annotation

    .prologue
    .line 3037
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$d;->ᐝ:Lcom/appsflyer/AppsFlyerLib;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3028
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˊ:Ljava/lang/ref/WeakReference;

    .line 3038
    iput-object p2, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˏ:Ljava/lang/String;

    .line 3039
    iput-object p3, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˎ:Ljava/util/Map;

    .line 3040
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p4}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˊ:Ljava/lang/ref/WeakReference;

    .line 3041
    iput-boolean p5, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˋ:Z

    .line 3042
    iput p6, p0, Lcom/appsflyer/AppsFlyerLib$d;->ॱ:I

    .line 3043
    return-void
.end method

.method synthetic constructor <init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/util/Map;Landroid/content/Context;ZIB)V
    .locals 0

    .prologue
    .line 3025
    invoke-direct/range {p0 .. p6}, Lcom/appsflyer/AppsFlyerLib$d;-><init>(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/util/Map;Landroid/content/Context;ZI)V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 3047
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ᐝ:Lcom/appsflyer/AppsFlyerLib;

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 3076
    :cond_0
    :goto_0
    return-void

    .line 3053
    :cond_1
    iget-boolean v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˋ:Z

    if-eqz v0, :cond_2

    iget v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ॱ:I

    const/4 v1, 0x2

    if-gt v0, v1, :cond_2

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ᐝ:Lcom/appsflyer/AppsFlyerLib;

    .line 3055
    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Lcom/appsflyer/AppsFlyerLib;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 3057
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˎ:Ljava/util/Map;

    const-string v1, "rfr"

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib$d;->ᐝ:Lcom/appsflyer/AppsFlyerLib;

    invoke-static {v3}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Lcom/appsflyer/AppsFlyerLib;)Ljava/util/Map;

    move-result-object v3

    invoke-interface {v0, v1, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 3061
    :cond_2
    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˎ:Ljava/util/Map;

    const-string v1, "appsflyerKey"

    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 3063
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˎ:Ljava/util/Map;

    invoke-static {v0}, Lcom/appsflyer/AFHelper;->convertToJsonObject(Ljava/util/Map;)Lorg/json/JSONObject;

    move-result-object v0

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    .line 3065
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ᐝ:Lcom/appsflyer/AppsFlyerLib;

    iget-object v1, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˏ:Ljava/lang/String;

    iget-object v4, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˊ:Ljava/lang/ref/WeakReference;

    const/4 v5, 0x0

    iget-boolean v6, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˋ:Z

    invoke-static/range {v0 .. v6}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Lcom/appsflyer/AppsFlyerLib;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/ref/WeakReference;Ljava/lang/String;Z)V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 3067
    :catch_0
    move-exception v0

    move-object v1, v0

    .line 3068
    const-string v0, "Exception while sending request to server. "

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 3069
    if-eqz v2, :cond_0

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˊ:Ljava/lang/ref/WeakReference;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˏ:Ljava/lang/String;

    const-string v3, "&isCachedRequest=true&timeincache="

    invoke-virtual {v0, v3}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 3070
    invoke-static {}, Lcom/appsflyer/cache/CacheManager;->getInstance()Lcom/appsflyer/cache/CacheManager;

    move-result-object v3

    new-instance v4, Lcom/appsflyer/cache/RequestCacheData;

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˏ:Ljava/lang/String;

    const-string v5, "4.8.14"

    invoke-direct {v4, v0, v2, v5}, Lcom/appsflyer/cache/RequestCacheData;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$d;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-virtual {v3, v4, v0}, Lcom/appsflyer/cache/CacheManager;->cacheRequest(Lcom/appsflyer/cache/RequestCacheData;Landroid/content/Context;)V

    .line 3071
    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0

    .line 3073
    :catch_1
    move-exception v0

    .line 3074
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method
