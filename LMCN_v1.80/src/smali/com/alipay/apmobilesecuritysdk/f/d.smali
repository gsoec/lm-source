.class public final Lcom/alipay/apmobilesecuritysdk/f/d;
.super Ljava/lang/Object;


# direct methods
.method private static a(Ljava/lang/String;)Lcom/alipay/apmobilesecuritysdk/f/c;
    .locals 8

    const/4 v6, 0x0

    :try_start_0
    invoke-static {p0}, Lcom/alipay/b/a/a/a/a;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    new-instance v5, Lorg/json/JSONObject;

    invoke-direct {v5, p0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    new-instance v0, Lcom/alipay/apmobilesecuritysdk/f/c;

    const-string v1, "apdid"

    invoke-virtual {v5, v1}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "deviceInfoHash"

    invoke-virtual {v5, v2}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    const-string v3, "timestamp"

    invoke-virtual {v5, v3}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    const-string v4, "tid"

    invoke-virtual {v5, v4}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    const-string v7, "utdid"

    invoke-virtual {v5, v7}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-direct/range {v0 .. v5}, Lcom/alipay/apmobilesecuritysdk/f/c;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-object v0

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/c/a;->a(Ljava/lang/Throwable;)V

    :cond_0
    move-object v0, v6

    goto :goto_0
.end method

.method public static declared-synchronized a()V
    .locals 1

    const-class v0, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v0

    monitor-exit v0

    return-void
.end method

.method public static declared-synchronized a(Landroid/content/Context;)V
    .locals 4

    const-class v1, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v1

    :try_start_0
    const-string v0, "vkeyid_profiles_v4"

    const-string v2, "key_deviceid_v4"

    const-string v3, ""

    invoke-static {p0, v0, v2, v3}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    const-string v0, "wxcasxx_v4"

    const-string v2, "key_wxcasxx_v4"

    const-string v3, ""

    invoke-static {v0, v2, v3}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-void

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method public static declared-synchronized a(Landroid/content/Context;Lcom/alipay/apmobilesecuritysdk/f/c;)V
    .locals 4

    .prologue
    .line 0
    const-class v1, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v1

    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0}, Lorg/json/JSONObject;-><init>()V

    const-string v2, "apdid"

    .line 1000
    iget-object v3, p1, Lcom/alipay/apmobilesecuritysdk/f/c;->a:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "deviceInfoHash"

    .line 2000
    iget-object v3, p1, Lcom/alipay/apmobilesecuritysdk/f/c;->b:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "timestamp"

    .line 3000
    iget-object v3, p1, Lcom/alipay/apmobilesecuritysdk/f/c;->c:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "tid"

    .line 4000
    iget-object v3, p1, Lcom/alipay/apmobilesecuritysdk/f/c;->d:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v2, "utdid"

    .line 5000
    iget-object v3, p1, Lcom/alipay/apmobilesecuritysdk/f/c;->e:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v2, "vkeyid_profiles_v4"

    const-string v3, "key_deviceid_v4"

    invoke-static {p0, v2, v3, v0}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    const-string v2, "wxcasxx_v4"

    const-string v3, "key_wxcasxx_v4"

    invoke-static {v2, v3, v0}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :goto_0
    monitor-exit v1

    return-void

    :catch_0
    move-exception v0

    :try_start_1
    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/c/a;->a(Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method public static declared-synchronized b()Lcom/alipay/apmobilesecuritysdk/f/c;
    .locals 3

    const-class v1, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v1

    :try_start_0
    const-string v0, "wxcasxx_v4"

    const-string v2, "key_wxcasxx_v4"

    invoke-static {v0, v2}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->a(Ljava/lang/String;)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result v2

    if-eqz v2, :cond_0

    const/4 v0, 0x0

    :goto_0
    monitor-exit v1

    return-object v0

    :cond_0
    :try_start_1
    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/f/d;->a(Ljava/lang/String;)Lcom/alipay/apmobilesecuritysdk/f/c;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result-object v0

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method public static declared-synchronized b(Landroid/content/Context;)Lcom/alipay/apmobilesecuritysdk/f/c;
    .locals 3

    const-class v1, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v1

    :try_start_0
    const-string v0, "vkeyid_profiles_v4"

    const-string v2, "key_deviceid_v4"

    invoke-static {p0, v0, v2}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->a(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_0

    const-string v0, "wxcasxx_v4"

    const-string v2, "key_wxcasxx_v4"

    invoke-static {v0, v2}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    :cond_0
    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/f/d;->a(Ljava/lang/String;)Lcom/alipay/apmobilesecuritysdk/f/c;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v0

    monitor-exit v1

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method public static declared-synchronized c(Landroid/content/Context;)Lcom/alipay/apmobilesecuritysdk/f/c;
    .locals 3

    const-class v1, Lcom/alipay/apmobilesecuritysdk/f/d;

    monitor-enter v1

    :try_start_0
    const-string v0, "vkeyid_profiles_v4"

    const-string v2, "key_deviceid_v4"

    invoke-static {p0, v0, v2}, Lcom/alipay/apmobilesecuritysdk/g/a;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->a(Ljava/lang/String;)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result v2

    if-eqz v2, :cond_0

    const/4 v0, 0x0

    :goto_0
    monitor-exit v1

    return-object v0

    :cond_0
    :try_start_1
    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/f/d;->a(Ljava/lang/String;)Lcom/alipay/apmobilesecuritysdk/f/c;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result-object v0

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method
