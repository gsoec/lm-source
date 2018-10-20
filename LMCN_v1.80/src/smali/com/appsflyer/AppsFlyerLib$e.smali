.class abstract Lcom/appsflyer/AppsFlyerLib$e;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/AppsFlyerLib;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x400
    name = "e"
.end annotation


# instance fields
.field private synthetic ˊ:Lcom/appsflyer/AppsFlyerLib;

.field private ˋ:Ljava/util/concurrent/ScheduledExecutorService;

.field ˎ:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;"
        }
    .end annotation
.end field

.field private ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

.field private ॱ:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/util/concurrent/ScheduledExecutorService;)V
    .locals 2

    .prologue
    .line 3120
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˊ:Lcom/appsflyer/AppsFlyerLib;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 3110
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    .line 3118
    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>(I)V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    .line 3121
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p2}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    .line 3122
    iput-object p3, p0, Lcom/appsflyer/AppsFlyerLib$e;->ॱ:Ljava/lang/String;

    .line 3123
    if-nez p4, :cond_0

    .line 3124
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->ˋ()Ljava/util/concurrent/ScheduledThreadPoolExecutor;

    move-result-object v0

    iput-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˋ:Ljava/util/concurrent/ScheduledExecutorService;

    .line 3128
    :goto_0
    return-void

    .line 3126
    :cond_0
    iput-object p4, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˋ:Ljava/util/concurrent/ScheduledExecutorService;

    goto :goto_0
.end method


# virtual methods
.method public run()V
    .locals 11

    .prologue
    const/4 v10, 0x1

    .line 3131
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ॱ:Ljava/lang/String;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ॱ:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    if-nez v0, :cond_1

    .line 3257
    :cond_0
    :goto_0
    return-void

    .line 3136
    :cond_1
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˊ:Lcom/appsflyer/AppsFlyerLib;

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v0

    if-nez v0, :cond_0

    .line 3140
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    .line 3141
    const/4 v2, 0x0

    .line 3143
    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    .line 3144
    if-nez v0, :cond_2

    .line 3251
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->decrementAndGet()I

    goto :goto_0

    .line 3148
    :cond_2
    :try_start_1
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    .line 3149
    new-instance v1, Ljava/lang/ref/WeakReference;

    invoke-direct {v1, v0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 3150
    const-string v1, ""

    .line 3151
    if-eqz v3, :cond_3

    .line 3152
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ˋ()Ljava/util/List;

    move-result-object v6

    invoke-virtual {v3}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v7

    invoke-interface {v6, v7}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_9

    .line 3153
    const-string v1, "-"

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 3158
    :cond_3
    :goto_1
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    .line 3159
    invoke-virtual {p0}, Lcom/appsflyer/AppsFlyerLib$e;->ˋ()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    .line 3160
    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    .line 3161
    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "?devkey="

    .line 3162
    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v3, p0, Lcom/appsflyer/AppsFlyerLib$e;->ॱ:Ljava/lang/String;

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "&device_id="

    .line 3163
    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    new-instance v3, Ljava/lang/ref/WeakReference;

    invoke-direct {v3, v0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    invoke-static {v3}, Lcom/appsflyer/t;->ˋ(Ljava/lang/ref/WeakReference;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    .line 3165
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    const-string v7, ""

    invoke-virtual {v1, v6, v7}, Lcom/appsflyer/w;->ˏ(Ljava/lang/String;Ljava/lang/String;)V

    .line 3166
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v6, "Calling server for attribution url: "

    invoke-direct {v1, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v1, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/j$1;->ˏ(Ljava/lang/String;)V

    .line 3168
    new-instance v1, Ljava/net/URL;

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v1, v6}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v1

    check-cast v1, Ljava/net/HttpURLConnection;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 3170
    :try_start_2
    const-string v2, "GET"

    invoke-virtual {v1, v2}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 3171
    const/16 v2, 0x2710

    invoke-virtual {v1, v2}, Ljava/net/URLConnection;->setConnectTimeout(I)V

    .line 3172
    const-string v2, "Connection"

    const-string v6, "close"

    invoke-virtual {v1, v2, v6}, Ljava/net/URLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 3173
    invoke-virtual {v1}, Ljava/net/URLConnection;->connect()V

    .line 3175
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v2

    .line 3176
    invoke-static {v1}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/net/HttpURLConnection;)Ljava/lang/String;

    move-result-object v6

    .line 3177
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v7

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8, v2, v6}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;ILjava/lang/String;)V

    .line 3178
    const/16 v7, 0xc8

    if-ne v2, v7, :cond_e

    .line 3180
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 3182
    const-string v7, "appsflyerGetConversionDataTiming"

    sub-long/2addr v2, v4

    const-wide/16 v4, 0x3e8

    div-long/2addr v2, v4

    invoke-static {v0, v7, v2, v3}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;J)V

    .line 3185
    const-string v2, "Attribution data: "

    invoke-static {v6}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/j$1;->ˏ(Ljava/lang/String;)V

    .line 3187
    invoke-virtual {v6}, Ljava/lang/String;->length()I

    move-result v2

    if-lez v2, :cond_7

    if-eqz v0, :cond_7

    .line 3188
    invoke-static {v6}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Ljava/lang/String;)Ljava/util/Map;

    move-result-object v4

    .line 3189
    const-string v2, "iscache"

    invoke-interface {v4, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 3192
    if-eqz v2, :cond_4

    const/4 v3, 0x0

    invoke-static {v3}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_4

    .line 3194
    const-string v3, "appsflyerConversionDataCacheExpiration"

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    invoke-static {v0, v3, v8, v9}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;Ljava/lang/String;J)V

    .line 3196
    :cond_4
    const-string v3, "af_siteid"

    invoke-interface {v4, v3}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_5

    .line 3197
    const-string v3, "af_channel"

    invoke-interface {v4, v3}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_b

    .line 3199
    new-instance v5, Ljava/lang/StringBuilder;

    const-string v3, "[Invite] Detected App-Invite via channel: "

    invoke-direct {v5, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "af_channel"

    invoke-interface {v4, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 3207
    :cond_5
    :goto_2
    const-string v3, "af_siteid"

    invoke-interface {v4, v3}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_6

    .line 3208
    new-instance v5, Ljava/lang/StringBuilder;

    const-string v3, "[Invite] Detected App-Invite via channel: "

    invoke-direct {v5, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "af_channel"

    invoke-interface {v4, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 3212
    :cond_6
    const-string v3, "is_first_launch"

    const/4 v5, 0x0

    invoke-static {v5}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v5

    invoke-interface {v4, v3, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 3214
    new-instance v3, Lorg/json/JSONObject;

    invoke-direct {v3, v4}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    invoke-virtual {v3}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v3

    .line 3215
    if-eqz v3, :cond_c

    .line 3216
    const-string v5, "attributionId"

    invoke-static {v0, v5, v3}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    .line 3222
    :goto_3
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v5, "iscache="

    invoke-direct {v3, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " caching conversion data"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    .line 3224
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v2

    if-eqz v2, :cond_7

    .line 3225
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v2}, Ljava/lang/Number;->intValue()I
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_1
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    move-result v2

    if-gt v2, v10, :cond_7

    .line 3228
    :try_start_3
    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ˎ(Landroid/content/Context;)Ljava/util/Map;
    :try_end_3
    .catch Lcom/appsflyer/l; {:try_start_3 .. :try_end_3} :catch_2
    .catch Ljava/lang/Throwable; {:try_start_3 .. :try_end_3} :catch_1
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    move-result-object v0

    .line 3233
    :goto_4
    :try_start_4
    invoke-virtual {p0, v0}, Lcom/appsflyer/AppsFlyerLib$e;->ˎ(Ljava/util/Map;)V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 3251
    :cond_7
    :goto_5
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->decrementAndGet()I

    .line 3252
    if-eqz v1, :cond_8

    .line 3253
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    .line 3256
    :cond_8
    :goto_6
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˋ:Ljava/util/concurrent/ScheduledExecutorService;

    invoke-interface {v0}, Ljava/util/concurrent/ScheduledExecutorService;->shutdown()V

    goto/16 :goto_0

    .line 3155
    :cond_9
    :try_start_5
    const-string v6, "AF detected using redundant Google-Play channel for attribution - %s. Using without channel postfix."

    const/4 v7, 0x1

    new-array v7, v7, [Ljava/lang/Object;

    const/4 v8, 0x0

    aput-object v3, v7, v8

    invoke-static {v6, v7}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_5
    .catch Ljava/lang/Throwable; {:try_start_5 .. :try_end_5} :catch_0
    .catchall {:try_start_5 .. :try_end_5} :catchall_1

    goto/16 :goto_1

    .line 3245
    :catch_0
    move-exception v0

    move-object v1, v2

    .line 3246
    :goto_7
    :try_start_6
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v2

    if-eqz v2, :cond_a

    .line 3247
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    const/4 v3, 0x0

    invoke-virtual {p0, v2, v3}, Lcom/appsflyer/AppsFlyerLib$e;->ˋ(Ljava/lang/String;I)V

    .line 3249
    :cond_a
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    .line 3251
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->decrementAndGet()I

    .line 3252
    if-eqz v1, :cond_8

    .line 3253
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_6

    .line 3202
    :cond_b
    :try_start_7
    const-string v3, "[CrossPromotion] App was installed via %s\'s Cross Promotion"

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v7, 0x0

    const-string v8, "af_siteid"

    .line 3204
    invoke-interface {v4, v8}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v8

    aput-object v8, v5, v7

    .line 3202
    invoke-static {v3, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto/16 :goto_2

    .line 3245
    :catch_1
    move-exception v0

    goto :goto_7

    .line 3219
    :cond_c
    const-string v3, "attributionId"

    invoke-static {v0, v3, v6}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_7
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_1
    .catchall {:try_start_7 .. :try_end_7} :catchall_0

    goto/16 :goto_3

    .line 3251
    :catchall_0
    move-exception v0

    :goto_8
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˏ:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v2}, Ljava/util/concurrent/atomic/AtomicInteger;->decrementAndGet()I

    .line 3252
    if-eqz v1, :cond_d

    .line 3253
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_d
    throw v0

    .line 3229
    :catch_2
    move-exception v0

    .line 3230
    :try_start_8
    const-string v2, "Exception while trying to fetch attribution data. "

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v0, v4

    .line 3231
    goto :goto_4

    .line 3239
    :cond_e
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v0

    if-eqz v0, :cond_f

    .line 3240
    const-string v0, "Error connection to server: "

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v0, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0, v2}, Lcom/appsflyer/AppsFlyerLib$e;->ˋ(Ljava/lang/String;I)V

    .line 3242
    :cond_f
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v4, "AttributionIdFetcher response code: "

    invoke-direct {v0, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, "  url: "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/j$1;->ˏ(Ljava/lang/String;)V
    :try_end_8
    .catch Ljava/lang/Throwable; {:try_start_8 .. :try_end_8} :catch_1
    .catchall {:try_start_8 .. :try_end_8} :catchall_0

    goto/16 :goto_5

    .line 3251
    :catchall_1
    move-exception v0

    move-object v1, v2

    goto :goto_8
.end method

.method public abstract ˋ()Ljava/lang/String;
.end method

.method protected abstract ˋ(Ljava/lang/String;I)V
.end method

.method protected abstract ˎ(Ljava/util/Map;)V
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
.end method
