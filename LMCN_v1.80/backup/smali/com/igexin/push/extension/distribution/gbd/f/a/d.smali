.class public Lcom/igexin/push/extension/distribution/gbd/f/a/d;
.super Lcom/igexin/push/extension/distribution/gbd/f/d;


# direct methods
.method public constructor <init>()V
    .locals 2

    const/4 v1, 0x1

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/f/b;->b()Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;-><init>(Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/i/e;->b()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;->c(Z)V

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;->n()V

    return-void

    :cond_0
    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;->a(Z)V

    const/4 v0, 0x0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;->b(Z)V

    goto :goto_0
.end method


# virtual methods
.method public a(Ljava/util/Map;[B)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;[B)V"
        }
    .end annotation

    if-eqz p2, :cond_0

    :try_start_0
    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/e/a/f;->a()Lcom/igexin/push/extension/distribution/gbd/e/a/f;

    move-result-object v0

    invoke-virtual {v0, p2}, Lcom/igexin/push/extension/distribution/gbd/e/a/f;->a([B)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :cond_0
    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public n()V
    .locals 4

    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0}, Lorg/json/JSONObject;-><init>()V

    :try_start_0
    const-string v1, "action"

    const-string v2, "fetchus"

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v1, "cid"

    sget-object v2, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v1, "appid"

    sget-object v2, Lcom/igexin/push/core/g;->a:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    const-string v1, "pkgs"

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->a:Landroid/content/Context;

    const/4 v3, 0x0

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/gbd/i/e;->a(Landroid/content/Context;I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;->a([B)V

    const-string v1, "GBD_GSSHP"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "init jsonObject = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method
