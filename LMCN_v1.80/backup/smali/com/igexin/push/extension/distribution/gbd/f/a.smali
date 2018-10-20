.class public Lcom/igexin/push/extension/distribution/gbd/f/a;
.super Lcom/igexin/b/a/d/d;


# instance fields
.field public a:Lcom/igexin/push/extension/distribution/gbd/f/d;

.field private b:Ljava/net/HttpURLConnection;

.field private c:Z


# direct methods
.method public constructor <init>(Lcom/igexin/push/extension/distribution/gbd/f/d;)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/b/a/d/d;-><init>(I)V

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->c:Z

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    return-void
.end method

.method private varargs a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "[",
            "Ljava/lang/Class",
            "<*>;)",
            "Ljava/lang/reflect/Method;"
        }
    .end annotation

    :try_start_0
    const-string v0, "com.igexin.push.util.EncryptUtils"

    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Ljava/lang/Class;->getMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    :goto_0
    return-object v0

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const/4 v0, 0x0

    goto :goto_0
.end method

.method private a(Ljava/net/HttpURLConnection;[B)V
    .locals 5

    if-nez p1, :cond_0

    :goto_0
    return-void

    :cond_0
    const/4 v0, 0x0

    :try_start_0
    new-array v0, v0, [B

    if-eqz p2, :cond_1

    :goto_1
    const-string v0, "GT_C_T"

    const/4 v1, 0x1

    invoke-static {v1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1, v0, v1}, Ljava/net/HttpURLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "GT_C_K"

    new-instance v2, Ljava/lang/String;

    const-string v0, "getRSAKeyId"

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Class;

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v3, 0x0

    const/4 v4, 0x0

    new-array v4, v4, [Ljava/lang/Object;

    invoke-virtual {v0, v3, v4}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    check-cast v0, [B

    invoke-direct {v2, v0}, Ljava/lang/String;-><init>([B)V

    invoke-virtual {p1, v1, v2}, Ljava/net/HttpURLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "GT_C_V"

    const-string v0, "getHttpGTCV"

    const/4 v2, 0x0

    new-array v2, v2, [Ljava/lang/Class;

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v2, 0x0

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Object;

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {p1, v1, v0}, Ljava/net/HttpURLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    const-string v0, "getHttpSignature"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/Class;

    const/4 v3, 0x0

    const-class v4, Ljava/lang/String;

    aput-object v4, v2, v3

    const/4 v3, 0x1

    const-class v4, [B

    aput-object v4, v2, v3

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v2, 0x0

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object v1, v3, v4

    const/4 v4, 0x1

    aput-object p2, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v2, "GT_T"

    invoke-virtual {p1, v2, v1}, Ljava/net/HttpURLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "GT_C_S"

    invoke-virtual {p1, v1, v0}, Ljava/net/HttpURLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto/16 :goto_0

    :cond_1
    move-object p2, v0

    goto :goto_1
.end method

.method private a(Ljava/util/Map;)[B
    .locals 8
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;)[B"
        }
    .end annotation

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    :try_start_0
    new-instance v0, Ljava/net/URL;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->k()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v0

    check-cast v0, Ljava/net/HttpURLConnection;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->e()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->f()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->h()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setDoInput(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->g()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setDoOutput(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    const-string v1, "POST"

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->d()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->c()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setInstanceFollowRedirects(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->i()Ljava/util/HashMap;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v6

    :goto_0
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iget-object v7, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->i()Ljava/util/HashMap;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v7, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_5

    goto :goto_0

    :catch_0
    move-exception v0

    move-object v1, v2

    move-object v3, v2

    move-object v4, v2

    :goto_1
    :try_start_1
    iget-object v5, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    if-eqz v5, :cond_0

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v5, v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a(Ljava/lang/Throwable;)V

    :cond_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const-string v5, "GBDAsyncHttpTask"

    invoke-virtual {v0}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v5, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_9

    if-eqz v4, :cond_1

    :try_start_2
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->close()V

    :cond_1
    if-eqz v3, :cond_2

    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_2
    if-eqz v1, :cond_3

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_6
    .catchall {:try_start_2 .. :try_end_2} :catchall_4

    :cond_3
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_2
    move-object v0, v2

    :goto_3
    return-object v0

    :cond_4
    :try_start_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->l()[B

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->j()Z

    move-result v1

    if-eqz v1, :cond_d

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/i/e;->c()Z
    :try_end_3
    .catch Ljava/lang/Throwable; {:try_start_3 .. :try_end_3} :catch_0
    .catchall {:try_start_3 .. :try_end_3} :catchall_5

    move-result v1

    if-nez v1, :cond_8

    if-eqz v2, :cond_5

    :try_start_4
    invoke-virtual {v3}, Ljava/io/DataOutputStream;->close()V

    :cond_5
    if-eqz v2, :cond_6

    invoke-virtual {v4}, Ljava/io/InputStream;->close()V

    :cond_6
    if-eqz v2, :cond_7

    invoke-virtual {v5}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    :cond_7
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_4
    move-object v0, v2

    goto :goto_3

    :catch_1
    move-exception v0

    :try_start_5
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto :goto_4

    :catchall_0
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :cond_8
    :try_start_6
    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a([B)[B
    :try_end_6
    .catch Ljava/lang/Throwable; {:try_start_6 .. :try_end_6} :catch_0
    .catchall {:try_start_6 .. :try_end_6} :catchall_5

    move-result-object v0

    :cond_9
    :goto_5
    if-nez v0, :cond_e

    if-eqz v2, :cond_a

    :try_start_7
    invoke-virtual {v3}, Ljava/io/DataOutputStream;->close()V

    :cond_a
    if-eqz v2, :cond_b

    invoke-virtual {v4}, Ljava/io/InputStream;->close()V

    :cond_b
    if-eqz v2, :cond_c

    invoke-virtual {v5}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_7
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_2
    .catchall {:try_start_7 .. :try_end_7} :catchall_1

    :cond_c
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_6
    move-object v0, v2

    goto :goto_3

    :cond_d
    :try_start_8
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a()Z

    move-result v1

    if-eqz v1, :cond_9

    invoke-static {v0}, Lcom/igexin/b/b/a;->b([B)[B
    :try_end_8
    .catch Ljava/lang/Throwable; {:try_start_8 .. :try_end_8} :catch_0
    .catchall {:try_start_8 .. :try_end_8} :catchall_5

    move-result-object v0

    goto :goto_5

    :catch_2
    move-exception v0

    :try_start_9
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_9
    .catchall {:try_start_9 .. :try_end_9} :catchall_1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto :goto_6

    :catchall_1
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :cond_e
    :try_start_a
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->connect()V

    new-instance v4, Ljava/io/DataOutputStream;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v1

    invoke-direct {v4, v1}, Ljava/io/DataOutputStream;-><init>(Ljava/io/OutputStream;)V
    :try_end_a
    .catch Ljava/lang/Throwable; {:try_start_a .. :try_end_a} :catch_0
    .catchall {:try_start_a .. :try_end_a} :catchall_5

    const/4 v1, 0x0

    :try_start_b
    array-length v3, v0

    invoke-virtual {v4, v0, v1, v3}, Ljava/io/DataOutputStream;->write([BII)V

    invoke-virtual {v4}, Ljava/io/DataOutputStream;->flush()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v0

    const/16 v1, 0xc8

    if-ne v0, v1, :cond_14

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getHeaderFields()Ljava/util/Map;

    move-result-object v0

    if-eqz v0, :cond_f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getHeaderFields()Ljava/util/Map;

    move-result-object v0

    invoke-interface {p1, v0}, Ljava/util/Map;->putAll(Ljava/util/Map;)V

    :cond_f
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;
    :try_end_b
    .catch Ljava/lang/Throwable; {:try_start_b .. :try_end_b} :catch_8
    .catchall {:try_start_b .. :try_end_b} :catchall_7

    move-result-object v3

    :try_start_c
    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V
    :try_end_c
    .catch Ljava/lang/Throwable; {:try_start_c .. :try_end_c} :catch_9
    .catchall {:try_start_c .. :try_end_c} :catchall_8

    const/16 v0, 0x400

    :try_start_d
    new-array v0, v0, [B

    :goto_7
    invoke-virtual {v3, v0}, Ljava/io/InputStream;->read([B)I

    move-result v5

    const/4 v6, -0x1

    if-eq v5, v6, :cond_10

    const/4 v6, 0x0

    invoke-virtual {v1, v0, v6, v5}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :goto_7

    :catch_3
    move-exception v0

    goto/16 :goto_1

    :cond_10
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v0

    if-eqz v0, :cond_16

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v5

    invoke-direct {p0, v0, v5}, Lcom/igexin/push/extension/distribution/gbd/f/a;->b(Ljava/net/HttpURLConnection;[B)[B
    :try_end_d
    .catch Ljava/lang/Throwable; {:try_start_d .. :try_end_d} :catch_3
    .catchall {:try_start_d .. :try_end_d} :catchall_9

    move-result-object v0

    if-eqz v4, :cond_11

    :try_start_e
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->close()V

    :cond_11
    if-eqz v3, :cond_12

    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_12
    if-eqz v1, :cond_13

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_e
    .catch Ljava/lang/Throwable; {:try_start_e .. :try_end_e} :catch_4
    .catchall {:try_start_e .. :try_end_e} :catchall_2

    :cond_13
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_3

    :catch_4
    move-exception v1

    :try_start_f
    invoke-static {v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_f
    .catchall {:try_start_f .. :try_end_f} :catchall_2

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_3

    :catchall_2
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :cond_14
    :try_start_10
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    if-eqz v0, :cond_15

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a(I)V
    :try_end_10
    .catch Ljava/lang/Throwable; {:try_start_10 .. :try_end_10} :catch_8
    .catchall {:try_start_10 .. :try_end_10} :catchall_7

    :cond_15
    move-object v1, v2

    move-object v3, v2

    :cond_16
    if-eqz v4, :cond_17

    :try_start_11
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->close()V

    :cond_17
    if-eqz v3, :cond_18

    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_18
    if-eqz v1, :cond_19

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_11
    .catch Ljava/lang/Throwable; {:try_start_11 .. :try_end_11} :catch_5
    .catchall {:try_start_11 .. :try_end_11} :catchall_3

    :cond_19
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catch_5
    move-exception v0

    :try_start_12
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_12
    .catchall {:try_start_12 .. :try_end_12} :catchall_3

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catchall_3
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catch_6
    move-exception v0

    :try_start_13
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_13
    .catchall {:try_start_13 .. :try_end_13} :catchall_4

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catchall_4
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catchall_5
    move-exception v0

    move-object v3, v2

    move-object v4, v2

    :goto_8
    if-eqz v4, :cond_1a

    :try_start_14
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->close()V

    :cond_1a
    if-eqz v3, :cond_1b

    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_1b
    if-eqz v2, :cond_1c

    invoke-virtual {v2}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_14
    .catch Ljava/lang/Throwable; {:try_start_14 .. :try_end_14} :catch_7
    .catchall {:try_start_14 .. :try_end_14} :catchall_6

    :cond_1c
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_9
    throw v0

    :catch_7
    move-exception v1

    :try_start_15
    invoke-static {v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_15
    .catchall {:try_start_15 .. :try_end_15} :catchall_6

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto :goto_9

    :catchall_6
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catchall_7
    move-exception v0

    move-object v3, v2

    goto :goto_8

    :catchall_8
    move-exception v0

    goto :goto_8

    :catchall_9
    move-exception v0

    move-object v2, v1

    goto :goto_8

    :catch_8
    move-exception v0

    move-object v1, v2

    move-object v3, v2

    goto/16 :goto_1

    :catch_9
    move-exception v0

    move-object v1, v2

    goto/16 :goto_1
.end method

.method private a([B)[B
    .locals 9

    const/4 v8, 0x0

    const/4 v5, 0x2

    const/4 v7, 0x1

    const/4 v6, 0x0

    invoke-static {p1}, Lcom/igexin/b/a/b/f;->a([B)[B

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-direct {p0, v1, v0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/net/HttpURLConnection;[B)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    const-string v2, "GT_C_S"

    invoke-virtual {v1, v2}, Ljava/net/HttpURLConnection;->getRequestProperty(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_0

    const-string v2, "aesEncHttp"

    new-array v3, v5, [Ljava/lang/Class;

    const-class v4, [B

    aput-object v4, v3, v6

    const-class v4, [B

    aput-object v4, v3, v7

    invoke-direct {p0, v2, v3}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v2

    new-array v3, v5, [Ljava/lang/Object;

    aput-object v0, v3, v6

    const-string v0, "md5"

    new-array v4, v7, [Ljava/lang/Class;

    const-class v5, [B

    aput-object v5, v4, v6

    invoke-direct {p0, v0, v4}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    new-array v4, v7, [Ljava/lang/Object;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    aput-object v1, v4, v6

    invoke-virtual {v0, v8, v4}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    aput-object v0, v3, v7

    invoke-virtual {v2, v8, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    check-cast v0, [B

    :cond_0
    return-object v0
.end method

.method private b(Ljava/net/HttpURLConnection;[B)[B
    .locals 12

    const/4 v2, 0x0

    :try_start_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->j()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->b()Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x0

    invoke-static {p2, v0}, Landroid/util/Base64;->decode([BI)[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/b/a;->c([B)[B

    move-result-object p2

    :cond_0
    :goto_0
    return-object p2

    :cond_1
    const-string v0, "GT_ERR"

    invoke-virtual {p1, v0}, Ljava/net/HttpURLConnection;->getHeaderField(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_2

    const-string v1, "0"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3

    :cond_2
    move-object p2, v2

    goto :goto_0

    :cond_3
    const-string v0, "GT_T"

    invoke-virtual {p1, v0}, Ljava/net/HttpURLConnection;->getHeaderField(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-nez v1, :cond_4

    move-object p2, v2

    goto :goto_0

    :cond_4
    const-string v0, "GT_C_S"

    invoke-virtual {p1, v0}, Ljava/net/HttpURLConnection;->getHeaderField(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    if-nez v3, :cond_5

    move-object p2, v2

    goto :goto_0

    :cond_5
    const-string v0, "aesDecHttp"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Class;

    const/4 v5, 0x0

    const-class v6, [B

    aput-object v6, v4, v5

    const/4 v5, 0x1

    const-class v6, [B

    aput-object v6, v4, v5

    invoke-direct {p0, v0, v4}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v4, 0x0

    const/4 v5, 0x2

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v6, 0x0

    aput-object p2, v5, v6

    const/4 v6, 0x1

    const-string v7, "md5"

    const/4 v8, 0x1

    new-array v8, v8, [Ljava/lang/Class;

    const/4 v9, 0x0

    const-class v10, [B

    aput-object v10, v8, v9

    invoke-direct {p0, v7, v8}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v7

    const/4 v8, 0x0

    const/4 v9, 0x1

    new-array v9, v9, [Ljava/lang/Object;

    const/4 v10, 0x0

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v11

    aput-object v11, v9, v10

    invoke-virtual {v7, v8, v9}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    aput-object v7, v5, v6

    invoke-virtual {v0, v4, v5}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    check-cast v0, [B

    const-string v4, "getHttpSignature"

    const/4 v5, 0x2

    new-array v5, v5, [Ljava/lang/Class;

    const/4 v6, 0x0

    const-class v7, Ljava/lang/String;

    aput-object v7, v5, v6

    const/4 v6, 0x1

    const-class v7, [B

    aput-object v7, v5, v6

    invoke-direct {p0, v4, v5}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v4

    const/4 v5, 0x0

    const/4 v6, 0x2

    new-array v6, v6, [Ljava/lang/Object;

    const/4 v7, 0x0

    aput-object v1, v6, v7

    const/4 v1, 0x1

    aput-object v0, v6, v1

    invoke-virtual {v4, v5, v6}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    if-eqz v1, :cond_6

    invoke-virtual {v1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result v1

    if-nez v1, :cond_7

    :cond_6
    move-object p2, v2

    goto/16 :goto_0

    :cond_7
    move-object p2, v0

    goto/16 :goto_0

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    move-object p2, v2

    goto/16 :goto_0
.end method

.method private b(Ljava/util/Map;)[B
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;)[B"
        }
    .end annotation

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    :try_start_0
    new-instance v0, Ljava/net/URL;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->k()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v0

    check-cast v0, Ljava/net/HttpURLConnection;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->e()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->f()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->h()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setDoInput(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    const-string v1, "GET"

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->d()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->c()Z

    move-result v1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setInstanceFollowRedirects(Z)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->i()Ljava/util/HashMap;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :goto_0
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/gbd/f/d;->i()Ljava/util/HashMap;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v6, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_4

    goto :goto_0

    :catch_0
    move-exception v0

    move-object v1, v2

    move-object v3, v2

    :goto_1
    :try_start_1
    iget-object v4, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    if-eqz v4, :cond_0

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v4, v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a(Ljava/lang/Throwable;)V

    :cond_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_7

    if-eqz v3, :cond_1

    :try_start_2
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_1
    if-eqz v1, :cond_2

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_5
    .catchall {:try_start_2 .. :try_end_2} :catchall_3

    :cond_2
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_2
    move-object v0, v2

    :goto_3
    return-object v0

    :cond_3
    :try_start_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->j()Z

    move-result v0

    if-eqz v0, :cond_7

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/i/e;->c()Z
    :try_end_3
    .catch Ljava/lang/Throwable; {:try_start_3 .. :try_end_3} :catch_0
    .catchall {:try_start_3 .. :try_end_3} :catchall_4

    move-result v0

    if-nez v0, :cond_6

    if-eqz v2, :cond_4

    :try_start_4
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_4
    if-eqz v2, :cond_5

    invoke-virtual {v4}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    :cond_5
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_4
    move-object v0, v2

    goto :goto_3

    :catch_1
    move-exception v0

    :try_start_5
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto :goto_4

    :catchall_0
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :cond_6
    :try_start_6
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    const/4 v1, 0x0

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/net/HttpURLConnection;[B)V

    :cond_7
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;
    :try_end_6
    .catch Ljava/lang/Throwable; {:try_start_6 .. :try_end_6} :catch_0
    .catchall {:try_start_6 .. :try_end_6} :catchall_4

    move-result-object v3

    :try_start_7
    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V
    :try_end_7
    .catch Ljava/lang/Throwable; {:try_start_7 .. :try_end_7} :catch_7
    .catchall {:try_start_7 .. :try_end_7} :catchall_6

    :try_start_8
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v0

    const/16 v4, 0xc8

    if-ne v0, v4, :cond_c

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getHeaderFields()Ljava/util/Map;

    move-result-object v0

    if-eqz v0, :cond_8

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getHeaderFields()Ljava/util/Map;

    move-result-object v0

    invoke-interface {p1, v0}, Ljava/util/Map;->putAll(Ljava/util/Map;)V

    :cond_8
    const/16 v0, 0x400

    new-array v0, v0, [B

    :goto_5
    invoke-virtual {v3, v0}, Ljava/io/InputStream;->read([B)I

    move-result v4

    const/4 v5, -0x1

    if-eq v4, v5, :cond_9

    const/4 v5, 0x0

    invoke-virtual {v1, v0, v5, v4}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :goto_5

    :catch_2
    move-exception v0

    goto/16 :goto_1

    :cond_9
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v0

    if-eqz v0, :cond_d

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v4

    invoke-direct {p0, v0, v4}, Lcom/igexin/push/extension/distribution/gbd/f/a;->b(Ljava/net/HttpURLConnection;[B)[B
    :try_end_8
    .catch Ljava/lang/Throwable; {:try_start_8 .. :try_end_8} :catch_2
    .catchall {:try_start_8 .. :try_end_8} :catchall_7

    move-result-object v0

    if-eqz v3, :cond_a

    :try_start_9
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_a
    if-eqz v1, :cond_b

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_9
    .catch Ljava/lang/Throwable; {:try_start_9 .. :try_end_9} :catch_3
    .catchall {:try_start_9 .. :try_end_9} :catchall_1

    :cond_b
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_3

    :catch_3
    move-exception v1

    :try_start_a
    invoke-static {v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_a
    .catchall {:try_start_a .. :try_end_a} :catchall_1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_3

    :catchall_1
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :cond_c
    :try_start_b
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    if-eqz v0, :cond_d

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v4}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v4

    invoke-virtual {v0, v4}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a(I)V
    :try_end_b
    .catch Ljava/lang/Throwable; {:try_start_b .. :try_end_b} :catch_2
    .catchall {:try_start_b .. :try_end_b} :catchall_7

    :cond_d
    if-eqz v3, :cond_e

    :try_start_c
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_e
    if-eqz v1, :cond_f

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_c
    .catch Ljava/lang/Throwable; {:try_start_c .. :try_end_c} :catch_4
    .catchall {:try_start_c .. :try_end_c} :catchall_2

    :cond_f
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catch_4
    move-exception v0

    :try_start_d
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_d
    .catchall {:try_start_d .. :try_end_d} :catchall_2

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catchall_2
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catch_5
    move-exception v0

    :try_start_e
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_e
    .catchall {:try_start_e .. :try_end_e} :catchall_3

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto/16 :goto_2

    :catchall_3
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catchall_4
    move-exception v0

    move-object v3, v2

    :goto_6
    if-eqz v3, :cond_10

    :try_start_f
    invoke-virtual {v3}, Ljava/io/InputStream;->close()V

    :cond_10
    if-eqz v2, :cond_11

    invoke-virtual {v2}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_f
    .catch Ljava/lang/Throwable; {:try_start_f .. :try_end_f} :catch_6
    .catchall {:try_start_f .. :try_end_f} :catchall_5

    :cond_11
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    :goto_7
    throw v0

    :catch_6
    move-exception v1

    :try_start_10
    invoke-static {v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_10
    .catchall {:try_start_10 .. :try_end_10} :catchall_5

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    goto :goto_7

    :catchall_5
    move-exception v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    throw v0

    :catchall_6
    move-exception v0

    goto :goto_6

    :catchall_7
    move-exception v0

    move-object v2, v1

    goto :goto_6

    :catch_7
    move-exception v0

    move-object v1, v2

    goto/16 :goto_1
.end method

.method private g()V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    if-eqz v0, :cond_0

    :try_start_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;

    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->disconnect()V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->b:Ljava/net/HttpURLConnection;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :cond_0
    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const-string v1, "GBDAsyncHttpTask"

    invoke-virtual {v0}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method


# virtual methods
.method public final a_()V
    .locals 3

    const/16 v0, 0xa

    :try_start_0
    invoke-static {v0}, Landroid/os/Process;->setThreadPriority(I)V

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->c:Z

    if-eqz v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->p()V

    :cond_0
    :goto_0
    return-void

    :cond_1
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->c:Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/gbd/f/d;->b:[B

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/gbd/f/d;->b:[B

    array-length v0, v0

    sget v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    mul-int/lit16 v1, v1, 0x400

    if-le v0, v1, :cond_2

    const-string v0, "GBDAsyncHttpTask"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "http data size ("

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v2, v2, Lcom/igexin/push/extension/distribution/gbd/f/d;->b:[B

    array-length v2, v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ") > max size ("

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    sget v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    mul-int/lit16 v2, v2, 0x400

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ")"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0

    :cond_2
    :try_start_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->m()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/gbd/f/d;->a:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    const-string v0, "GBDAsyncHttpTask"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "-----------"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v2, v2, Lcom/igexin/push/extension/distribution/gbd/f/d;->a:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "-----------"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/gbd/f/d;->b:[B

    if-nez v0, :cond_3

    invoke-direct {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a;->b(Ljava/util/Map;)[B

    move-result-object v0

    :goto_1
    if-eqz v0, :cond_0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->a:Lcom/igexin/push/extension/distribution/gbd/f/d;

    invoke-virtual {v2, v1, v0}, Lcom/igexin/push/extension/distribution/gbd/f/d;->a(Ljava/util/Map;[B)V

    goto/16 :goto_0

    :cond_3
    invoke-direct {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/f/a;->a(Ljava/util/Map;)[B
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    move-result-object v0

    goto :goto_1
.end method

.method public final b()I
    .locals 1

    const v0, -0x7ffffff7

    return v0
.end method

.method public d()V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/f/a;->n:Z

    return-void
.end method

.method protected e()V
    .locals 0

    return-void
.end method

.method public f()V
    .locals 0

    invoke-super {p0}, Lcom/igexin/b/a/d/d;->f()V

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/f/a;->g()V

    return-void
.end method
