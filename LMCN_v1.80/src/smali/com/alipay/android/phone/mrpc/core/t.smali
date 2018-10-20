.class public final Lcom/alipay/android/phone/mrpc/core/t;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/util/concurrent/Callable;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Ljava/util/concurrent/Callable",
        "<",
        "Lcom/alipay/android/phone/mrpc/core/y;",
        ">;"
    }
.end annotation


# static fields
.field private static final e:Ljava/lang/String; = "HttpWorker"

.field private static final f:Lorg/apache/http/client/HttpRequestRetryHandler;


# instance fields
.field protected a:Lcom/alipay/android/phone/mrpc/core/n;

.field protected b:Landroid/content/Context;

.field protected c:Lcom/alipay/android/phone/mrpc/core/r;

.field d:Ljava/lang/String;

.field private g:Lorg/apache/http/client/methods/HttpUriRequest;

.field private h:Lorg/apache/http/protocol/HttpContext;

.field private i:Lorg/apache/http/client/CookieStore;

.field private j:Landroid/webkit/CookieManager;

.field private k:Lorg/apache/http/entity/AbstractHttpEntity;

.field private l:Lorg/apache/http/HttpHost;

.field private m:Ljava/net/URL;

.field private n:I

.field private o:Z

.field private p:Z

.field private q:Ljava/lang/String;

.field private r:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/ai;

    invoke-direct {v0}, Lcom/alipay/android/phone/mrpc/core/ai;-><init>()V

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/t;->f:Lorg/apache/http/client/HttpRequestRetryHandler;

    return-void
.end method

.method public constructor <init>(Lcom/alipay/android/phone/mrpc/core/n;Lcom/alipay/android/phone/mrpc/core/r;)V
    .locals 2

    const/4 v1, 0x0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Lorg/apache/http/protocol/BasicHttpContext;

    invoke-direct {v0}, Lorg/apache/http/protocol/BasicHttpContext;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->h:Lorg/apache/http/protocol/HttpContext;

    new-instance v0, Lorg/apache/http/impl/client/BasicCookieStore;

    invoke-direct {v0}, Lorg/apache/http/impl/client/BasicCookieStore;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->i:Lorg/apache/http/client/CookieStore;

    iput v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->n:I

    iput-boolean v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->o:Z

    iput-boolean v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->p:Z

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->q:Ljava/lang/String;

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/n;->b:Landroid/content/Context;

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    iput-object p2, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    return-void
.end method

.method private static a([Ljava/lang/String;)J
    .locals 3

    const/4 v0, 0x0

    :goto_0
    array-length v1, p0

    if-ge v0, v1, :cond_1

    aget-object v1, p0, v0

    const-string v2, "max-age"

    invoke-virtual {v2, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    add-int/lit8 v1, v0, 0x1

    aget-object v1, p0, v1

    if-eqz v1, :cond_0

    add-int/lit8 v1, v0, 0x1

    :try_start_0
    aget-object v1, p0, v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-wide v0

    :goto_1
    return-wide v0

    :catch_0
    move-exception v1

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    const-wide/16 v0, 0x0

    goto :goto_1
.end method

.method private static a(Lorg/apache/http/HttpResponse;)Lcom/alipay/android/phone/mrpc/core/q;
    .locals 7

    .prologue
    .line 0
    new-instance v1, Lcom/alipay/android/phone/mrpc/core/q;

    invoke-direct {v1}, Lcom/alipay/android/phone/mrpc/core/q;-><init>()V

    invoke-interface {p0}, Lorg/apache/http/HttpResponse;->getAllHeaders()[Lorg/apache/http/Header;

    move-result-object v2

    array-length v3, v2

    const/4 v0, 0x0

    :goto_0
    if-ge v0, v3, :cond_0

    aget-object v4, v2, v0

    invoke-interface {v4}, Lorg/apache/http/Header;->getName()Ljava/lang/String;

    move-result-object v5

    invoke-interface {v4}, Lorg/apache/http/Header;->getValue()Ljava/lang/String;

    move-result-object v4

    .line 51025
    iget-object v6, v1, Lcom/alipay/android/phone/mrpc/core/q;->a:Ljava/util/Map;

    invoke-interface {v6, v5, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-object v1
.end method

.method private a(Lorg/apache/http/HttpResponse;ILjava/lang/String;)Lcom/alipay/android/phone/mrpc/core/y;
    .locals 9

    .prologue
    const/4 v0, 0x0

    .line 0
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "\u5f00\u59cbhandle\uff0chandleResponse-1,"

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Thread;->getId()J

    move-result-wide v2

    invoke-virtual {v1, v2, v3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v1

    if-eqz v1, :cond_2

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v2

    invoke-interface {v2}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v2

    const/16 v3, 0xc8

    if-ne v2, v3, :cond_2

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "200\uff0c\u5f00\u59cb\u5904\u7406\uff0chandleResponse-2,threadid = "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Thread;->getId()J

    move-result-wide v4

    invoke-virtual {v2, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    :try_start_0
    new-instance v3, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v3}, Ljava/io/ByteArrayOutputStream;-><init>()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :try_start_1
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-direct {p0, v1, v3}, Lcom/alipay/android/phone/mrpc/core/t;->a(Lorg/apache/http/HttpEntity;Ljava/io/OutputStream;)V

    invoke-virtual {v3}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v1

    const/4 v2, 0x0

    iput-boolean v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->p:Z

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    sub-long v4, v6, v4

    .line 51019
    iget-wide v6, v2, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    add-long/2addr v4, v6

    iput-wide v4, v2, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    .line 0
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    array-length v4, v1

    int-to-long v4, v4

    .line 51020
    iget-wide v6, v2, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    add-long/2addr v4, v6

    iput-wide v4, v2, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    .line 0
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v4, "res:"

    invoke-direct {v2, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    array-length v4, v1

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    new-instance v2, Lcom/alipay/android/phone/mrpc/core/s;

    invoke-static {p1}, Lcom/alipay/android/phone/mrpc/core/t;->a(Lorg/apache/http/HttpResponse;)Lcom/alipay/android/phone/mrpc/core/q;

    move-result-object v4

    invoke-direct {v2, v4, p2, p3, v1}, Lcom/alipay/android/phone/mrpc/core/s;-><init>(Lcom/alipay/android/phone/mrpc/core/q;ILjava/lang/String;[B)V

    .line 51021
    invoke-static {p1}, Lcom/alipay/android/phone/mrpc/core/t;->b(Lorg/apache/http/HttpResponse;)J

    move-result-wide v4

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v1

    invoke-interface {v1}, Lorg/apache/http/HttpEntity;->getContentType()Lorg/apache/http/Header;

    move-result-object v1

    if-eqz v1, :cond_3

    invoke-interface {v1}, Lorg/apache/http/Header;->getValue()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/t;->a(Ljava/lang/String;)Ljava/util/HashMap;

    move-result-object v1

    const-string v0, "charset"

    invoke-virtual {v1, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v6, "Content-Type"

    invoke-virtual {v1, v6}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    :goto_0
    invoke-virtual {v2, v1}, Lcom/alipay/android/phone/mrpc/core/s;->a(Ljava/lang/String;)V

    .line 51022
    iput-object v0, v2, Lcom/alipay/android/phone/mrpc/core/s;->c:Ljava/lang/String;

    .line 51021
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    .line 51023
    iput-wide v0, v2, Lcom/alipay/android/phone/mrpc/core/s;->a:J

    .line 51024
    iput-wide v4, v2, Lcom/alipay/android/phone/mrpc/core/s;->b:J
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    .line 0
    :try_start_2
    invoke-virtual {v3}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_2
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_0

    move-object v0, v2

    :cond_0
    :goto_1
    return-object v0

    :catch_0
    move-exception v0

    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "ArrayOutputStream close error!"

    invoke-virtual {v0}, Ljava/io/IOException;->getCause()Ljava/lang/Throwable;

    move-result-object v0

    invoke-direct {v1, v2, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v1

    :catchall_0
    move-exception v1

    move-object v8, v1

    move-object v1, v0

    move-object v0, v8

    :goto_2
    if-eqz v1, :cond_1

    :try_start_3
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_3
    .catch Ljava/io/IOException; {:try_start_3 .. :try_end_3} :catch_1

    :cond_1
    throw v0

    :catch_1
    move-exception v0

    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "ArrayOutputStream close error!"

    invoke-virtual {v0}, Ljava/io/IOException;->getCause()Ljava/lang/Throwable;

    move-result-object v0

    invoke-direct {v1, v2, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v1

    :cond_2
    if-nez v1, :cond_0

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v1

    invoke-interface {v1}, Lorg/apache/http/StatusLine;->getStatusCode()I

    goto :goto_1

    :catchall_1
    move-exception v0

    move-object v1, v3

    goto :goto_2

    :cond_3
    move-object v1, v0

    goto :goto_0
.end method

.method private static a(Ljava/lang/String;)Ljava/util/HashMap;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    const/4 v8, 0x1

    const/4 v2, 0x0

    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    const-string v0, ";"

    invoke-virtual {p0, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v4

    array-length v5, v4

    move v1, v2

    :goto_0
    if-ge v1, v5, :cond_1

    aget-object v6, v4, v1

    const/16 v0, 0x3d

    invoke-virtual {v6, v0}, Ljava/lang/String;->indexOf(I)I

    move-result v0

    const/4 v7, -0x1

    if-ne v0, v7, :cond_0

    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const-string v7, "Content-Type"

    aput-object v7, v0, v2

    aput-object v6, v0, v8

    :goto_1
    aget-object v6, v0, v2

    aget-object v0, v0, v8

    invoke-virtual {v3, v6, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_0
    const-string v0, "="

    invoke-virtual {v6, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    goto :goto_1

    :cond_1
    return-object v3
.end method

.method private static a(Lcom/alipay/android/phone/mrpc/core/s;Lorg/apache/http/HttpResponse;)V
    .locals 11

    .prologue
    const/4 v1, 0x0

    const/4 v10, 0x1

    const/4 v2, 0x0

    .line 0
    invoke-static {p1}, Lcom/alipay/android/phone/mrpc/core/t;->b(Lorg/apache/http/HttpResponse;)J

    move-result-wide v4

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v0

    invoke-interface {v0}, Lorg/apache/http/HttpEntity;->getContentType()Lorg/apache/http/Header;

    move-result-object v0

    if-eqz v0, :cond_2

    invoke-interface {v0}, Lorg/apache/http/Header;->getValue()Ljava/lang/String;

    move-result-object v0

    .line 51026
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    const-string v1, ";"

    invoke-virtual {v0, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v6

    array-length v7, v6

    move v1, v2

    :goto_0
    if-ge v1, v7, :cond_1

    aget-object v8, v6, v1

    const/16 v0, 0x3d

    invoke-virtual {v8, v0}, Ljava/lang/String;->indexOf(I)I

    move-result v0

    const/4 v9, -0x1

    if-ne v0, v9, :cond_0

    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const-string v9, "Content-Type"

    aput-object v9, v0, v2

    aput-object v8, v0, v10

    :goto_1
    aget-object v8, v0, v2

    aget-object v0, v0, v10

    invoke-virtual {v3, v8, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_0
    const-string v0, "="

    invoke-virtual {v8, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    goto :goto_1

    .line 0
    :cond_1
    const-string v0, "charset"

    invoke-virtual {v3, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v1, "Content-Type"

    invoke-virtual {v3, v1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    :goto_2
    invoke-virtual {p0, v1}, Lcom/alipay/android/phone/mrpc/core/s;->a(Ljava/lang/String;)V

    .line 51027
    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->c:Ljava/lang/String;

    .line 0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    .line 51028
    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->a:J

    .line 51029
    iput-wide v4, p0, Lcom/alipay/android/phone/mrpc/core/s;->b:J

    .line 0
    return-void

    :cond_2
    move-object v0, v1

    goto :goto_2
.end method

.method private a(Lorg/apache/http/HttpEntity;Ljava/io/OutputStream;)V
    .locals 6

    .prologue
    .line 0
    invoke-static {p1}, Lcom/alipay/android/phone/mrpc/core/b;->a(Lorg/apache/http/HttpEntity;)Ljava/io/InputStream;

    move-result-object v1

    invoke-interface {p1}, Lorg/apache/http/HttpEntity;->getContentLength()J

    move-result-wide v2

    const/16 v0, 0x800

    :try_start_0
    new-array v0, v0, [B

    :cond_0
    :goto_0
    invoke-virtual {v1, v0}, Ljava/io/InputStream;->read([B)I

    move-result v4

    const/4 v5, -0x1

    if-eq v4, v5, :cond_1

    iget-object v5, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 51030
    iget-boolean v5, v5, Lcom/alipay/android/phone/mrpc/core/x;->f:Z

    .line 0
    if-nez v5, :cond_1

    const/4 v5, 0x0

    invoke-virtual {p2, v0, v5, v4}, Ljava/io/OutputStream;->write([BII)V

    .line 51031
    iget-object v4, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v4}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v4

    .line 0
    if-eqz v4, :cond_0

    const-wide/16 v4, 0x0

    cmp-long v4, v2, v4

    if-lez v4, :cond_0

    goto :goto_0

    :cond_1
    invoke-virtual {p2}, Ljava/io/OutputStream;->flush()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    invoke-static {v1}, Lcom/alipay/android/phone/mrpc/core/u;->a(Ljava/io/Closeable;)V

    return-void

    :catch_0
    move-exception v0

    :try_start_1
    invoke-virtual {v0}, Ljava/lang/Exception;->getCause()Ljava/lang/Throwable;

    new-instance v2, Ljava/io/IOException;

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, "HttpWorker Request Error!"

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/lang/Exception;->getLocalizedMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v2, v0}, Ljava/io/IOException;-><init>(Ljava/lang/String;)V

    throw v2
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    :catchall_0
    move-exception v0

    invoke-static {v1}, Lcom/alipay/android/phone/mrpc/core/u;->a(Ljava/io/Closeable;)V

    throw v0
.end method

.method private static a(I)Z
    .locals 1

    const/16 v0, 0x130

    if-ne p0, v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private static b(Lorg/apache/http/HttpResponse;)J
    .locals 5

    const-wide/16 v0, 0x0

    const-string v2, "Cache-Control"

    invoke-interface {p0, v2}, Lorg/apache/http/HttpResponse;->getFirstHeader(Ljava/lang/String;)Lorg/apache/http/Header;

    move-result-object v2

    if-eqz v2, :cond_1

    invoke-interface {v2}, Lorg/apache/http/Header;->getValue()Ljava/lang/String;

    move-result-object v2

    const-string v3, "="

    invoke-virtual {v2, v3}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v2

    array-length v3, v2

    const/4 v4, 0x2

    if-lt v3, v4, :cond_1

    :try_start_0
    invoke-static {v2}, Lcom/alipay/android/phone/mrpc/core/t;->a([Ljava/lang/String;)J
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-wide v0

    :cond_0
    :goto_0
    return-wide v0

    :catch_0
    move-exception v2

    :cond_1
    const-string v2, "Expires"

    invoke-interface {p0, v2}, Lorg/apache/http/HttpResponse;->getFirstHeader(Ljava/lang/String;)Lorg/apache/http/Header;

    move-result-object v2

    if-eqz v2, :cond_0

    invoke-interface {v2}, Lorg/apache/http/Header;->getValue()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->b(Ljava/lang/String;)J

    move-result-wide v0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    sub-long/2addr v0, v2

    goto :goto_0
.end method

.method private b()Ljava/net/URI;
    .locals 2

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 1000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->d:Ljava/lang/String;

    if-eqz v1, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->d:Ljava/lang/String;

    :cond_0
    if-nez v0, :cond_1

    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "url should not be null"

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    new-instance v1, Ljava/net/URI;

    invoke-direct {v1, v0}, Ljava/net/URI;-><init>(Ljava/lang/String;)V

    return-object v1
.end method

.method private c(Lorg/apache/http/HttpResponse;)Lcom/alipay/android/phone/mrpc/core/y;
    .locals 3

    .prologue
    .line 0
    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v0

    invoke-interface {v0}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v1

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v0

    invoke-interface {v0}, Lorg/apache/http/StatusLine;->getReasonPhrase()Ljava/lang/String;

    move-result-object v2

    const/16 v0, 0xc8

    if-eq v1, v0, :cond_1

    .line 51032
    const/16 v0, 0x130

    if-ne v1, v0, :cond_0

    const/4 v0, 0x1

    .line 0
    :goto_0
    if-nez v0, :cond_1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v1

    invoke-interface {v1}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-interface {p1}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v2

    invoke-interface {v2}, Lorg/apache/http/StatusLine;->getReasonPhrase()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v0

    .line 51032
    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 0
    :cond_1
    invoke-direct {p0, p1, v1, v2}, Lcom/alipay/android/phone/mrpc/core/t;->a(Lorg/apache/http/HttpResponse;ILjava/lang/String;)Lcom/alipay/android/phone/mrpc/core/y;

    move-result-object v0

    return-object v0
.end method

.method private c()Lorg/apache/http/entity/AbstractHttpEntity;
    .locals 3

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 2000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    .line 0
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    const-string v2, "gzip"

    invoke-virtual {v1, v2}, Lcom/alipay/android/phone/mrpc/core/r;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-eqz v0, :cond_1

    const-string v2, "true"

    invoke-static {v1, v2}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a([B)Lorg/apache/http/entity/AbstractHttpEntity;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    :goto_1
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 3000
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    .line 0
    invoke-virtual {v0, v1}, Lorg/apache/http/entity/AbstractHttpEntity;->setContentType(Ljava/lang/String;)V

    :cond_1
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    goto :goto_0

    :cond_2
    new-instance v1, Lorg/apache/http/entity/ByteArrayEntity;

    invoke-direct {v1, v0}, Lorg/apache/http/entity/ByteArrayEntity;-><init>([B)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    goto :goto_1
.end method

.method private d()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList",
            "<",
            "Lorg/apache/http/Header;",
            ">;"
        }
    .end annotation

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 4000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    .line 0
    return-object v0
.end method

.method private e()Lorg/apache/http/client/methods/HttpUriRequest;
    .locals 3

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    :goto_0
    return-object v0

    .line 5000
    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 6000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/r;->b:[B

    .line 5000
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    const-string v2, "gzip"

    invoke-virtual {v1, v2}, Lcom/alipay/android/phone/mrpc/core/r;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    if-eqz v0, :cond_1

    const-string v2, "true"

    invoke-static {v1, v2}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a([B)Lorg/apache/http/entity/AbstractHttpEntity;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    :goto_1
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 7000
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/r;->c:Ljava/lang/String;

    .line 5000
    invoke-virtual {v0, v1}, Lorg/apache/http/entity/AbstractHttpEntity;->setContentType(Ljava/lang/String;)V

    :cond_1
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    .line 0
    if-eqz v0, :cond_3

    new-instance v1, Lorg/apache/http/client/methods/HttpPost;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->b()Ljava/net/URI;

    move-result-object v2

    invoke-direct {v1, v2}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/net/URI;)V

    invoke-virtual {v1, v0}, Lorg/apache/http/client/methods/HttpPost;->setEntity(Lorg/apache/http/HttpEntity;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    :goto_2
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    goto :goto_0

    .line 5000
    :cond_2
    new-instance v1, Lorg/apache/http/entity/ByteArrayEntity;

    invoke-direct {v1, v0}, Lorg/apache/http/entity/ByteArrayEntity;-><init>([B)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->k:Lorg/apache/http/entity/AbstractHttpEntity;

    goto :goto_1

    .line 0
    :cond_3
    new-instance v0, Lorg/apache/http/client/methods/HttpGet;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->b()Ljava/net/URI;

    move-result-object v1

    invoke-direct {v0, v1}, Lorg/apache/http/client/methods/HttpGet;-><init>(Ljava/net/URI;)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    goto :goto_2
.end method

.method private f()Lcom/alipay/android/phone/mrpc/core/y;
    .locals 15

    .prologue
    const/4 v14, 0x6

    const/4 v13, 0x3

    const/4 v12, 0x2

    const/4 v4, 0x1

    const/4 v5, 0x0

    .line 0
    :goto_0
    :try_start_0
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    .line 8000
    const-string v3, "connectivity"

    invoke-virtual {v2, v3}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/net/ConnectivityManager;

    invoke-virtual {v2}, Landroid/net/ConnectivityManager;->getAllNetworkInfo()[Landroid/net/NetworkInfo;

    move-result-object v3

    if-nez v3, :cond_1

    move v2, v5

    .line 0
    :goto_1
    if-nez v2, :cond_3

    new-instance v2, Lcom/alipay/android/phone/mrpc/core/HttpException;

    const/4 v3, 0x1

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    const-string v6, "The network is not available"

    invoke-direct {v2, v3, v6}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v2
    :try_end_0
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_0 .. :try_end_0} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_0 .. :try_end_0} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_0 .. :try_end_0} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_0 .. :try_end_0} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_0 .. :try_end_0} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_0 .. :try_end_0} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_0 .. :try_end_0} :catch_a
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_0 .. :try_end_0} :catch_c
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_d

    :catch_0
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 34000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_0

    invoke-virtual {v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;->getCode()I

    invoke-virtual {v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;->getMsg()Ljava/lang/String;

    :cond_0
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    throw v2

    .line 8000
    :cond_1
    :try_start_1
    array-length v6, v3

    move v2, v5

    :goto_2
    if-ge v2, v6, :cond_1e

    aget-object v7, v3, v2

    if-eqz v7, :cond_2

    invoke-virtual {v7}, Landroid/net/NetworkInfo;->isAvailable()Z

    move-result v8

    if-eqz v8, :cond_2

    invoke-virtual {v7}, Landroid/net/NetworkInfo;->isConnectedOrConnecting()Z

    move-result v7

    if-eqz v7, :cond_2

    move v2, v4

    goto :goto_1

    :cond_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    .line 10000
    :cond_3
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 11000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    .line 9000
    if-eqz v2, :cond_4

    invoke-virtual {v2}, Ljava/util/ArrayList;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_4

    invoke-virtual {v2}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_3
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_4

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lorg/apache/http/Header;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v6

    invoke-interface {v6, v2}, Lorg/apache/http/client/methods/HttpUriRequest;->addHeader(Lorg/apache/http/Header;)V
    :try_end_1
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_1 .. :try_end_1} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_1 .. :try_end_1} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_1 .. :try_end_1} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_1 .. :try_end_1} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_1 .. :try_end_1} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_1 .. :try_end_1} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_1 .. :try_end_1} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_1 .. :try_end_1} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_1 .. :try_end_1} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_1 .. :try_end_1} :catch_a
    .catch Ljava/io/IOException; {:try_start_1 .. :try_end_1} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_1 .. :try_end_1} :catch_c
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_d

    goto :goto_3

    .line 0
    :catch_1
    move-exception v2

    new-instance v3, Ljava/lang/RuntimeException;

    const-string v4, "Url parser error!"

    invoke-virtual {v2}, Ljava/net/URISyntaxException;->getCause()Ljava/lang/Throwable;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v3

    .line 9000
    :cond_4
    :try_start_2
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v2

    invoke-static {v2}, Lcom/alipay/android/phone/mrpc/core/b;->a(Lorg/apache/http/HttpRequest;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v2

    invoke-static {v2}, Lcom/alipay/android/phone/mrpc/core/b;->b(Lorg/apache/http/HttpRequest;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v2

    const-string v3, "cookie"

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->r()Landroid/webkit/CookieManager;

    move-result-object v6

    iget-object v7, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 12000
    iget-object v7, v7, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 9000
    invoke-virtual {v6, v7}, Landroid/webkit/CookieManager;->getCookie(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v2, v3, v6}, Lorg/apache/http/client/methods/HttpUriRequest;->addHeader(Ljava/lang/String;Ljava/lang/String;)V

    .line 0
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->h:Lorg/apache/http/protocol/HttpContext;

    const-string v3, "http.cookie-store"

    iget-object v6, p0, Lcom/alipay/android/phone/mrpc/core/t;->i:Lorg/apache/http/client/CookieStore;

    invoke-interface {v2, v3, v6}, Lorg/apache/http/protocol/HttpContext;->setAttribute(Ljava/lang/String;Ljava/lang/Object;)V

    .line 13000
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 14000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 0
    sget-object v3, Lcom/alipay/android/phone/mrpc/core/t;->f:Lorg/apache/http/client/HttpRequestRetryHandler;

    .line 15000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/b;->b:Lorg/apache/http/client/HttpClient;

    check-cast v2, Lorg/apache/http/impl/client/DefaultHttpClient;

    invoke-virtual {v2, v3}, Lorg/apache/http/impl/client/DefaultHttpClient;->setHttpRequestRetryHandler(Lorg/apache/http/client/HttpRequestRetryHandler;)V

    .line 0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v6

    .line 17000
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "By Http/Https to request. operationType="

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->k()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " url="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    invoke-interface {v3}, Lorg/apache/http/client/methods/HttpUriRequest;->getURI()Ljava/net/URI;

    move-result-object v3

    invoke-virtual {v3}, Ljava/net/URI;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 18000
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 19000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 17000
    invoke-virtual {v2}, Lcom/alipay/android/phone/mrpc/core/b;->getParams()Lorg/apache/http/params/HttpParams;

    move-result-object v8

    const-string v9, "http.route.default-proxy"

    .line 20000
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    .line 21000
    const/4 v3, 0x0

    .line 22000
    const-string v10, "connectivity"

    invoke-virtual {v2, v10}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/net/ConnectivityManager;

    invoke-virtual {v2}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v2

    .line 21000
    if-eqz v2, :cond_1d

    invoke-virtual {v2}, Landroid/net/NetworkInfo;->isAvailable()Z

    move-result v2

    if-eqz v2, :cond_1d

    invoke-static {}, Landroid/net/Proxy;->getDefaultHost()Ljava/lang/String;

    move-result-object v10

    invoke-static {}, Landroid/net/Proxy;->getDefaultPort()I

    move-result v11

    if-eqz v10, :cond_1d

    new-instance v2, Lorg/apache/http/HttpHost;

    invoke-direct {v2, v10, v11}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;I)V

    .line 20000
    :goto_4
    if-eqz v2, :cond_5

    invoke-virtual {v2}, Lorg/apache/http/HttpHost;->getHostName()Ljava/lang/String;

    move-result-object v3

    const-string v10, "127.0.0.1"

    invoke-static {v3, v10}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v3

    if-eqz v3, :cond_5

    invoke-virtual {v2}, Lorg/apache/http/HttpHost;->getPort()I

    move-result v3

    const/16 v10, 0x1f97

    if-ne v3, v10, :cond_5

    const/4 v2, 0x0

    .line 17000
    :cond_5
    invoke-interface {v8, v9, v2}, Lorg/apache/http/params/HttpParams;->setParameter(Ljava/lang/String;Ljava/lang/Object;)Lorg/apache/http/params/HttpParams;

    .line 23000
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    if-eqz v2, :cond_a

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    .line 17000
    :goto_5
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v3

    const/16 v8, 0x50

    if-ne v3, v8, :cond_6

    new-instance v2, Lorg/apache/http/HttpHost;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v3

    invoke-virtual {v3}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v3

    invoke-direct {v2, v3}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;)V

    .line 24000
    :cond_6
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 25000
    iget-object v3, v3, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 17000
    iget-object v8, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    iget-object v9, p0, Lcom/alipay/android/phone/mrpc/core/t;->h:Lorg/apache/http/protocol/HttpContext;

    invoke-virtual {v3, v2, v8, v9}, Lcom/alipay/android/phone/mrpc/core/b;->execute(Lorg/apache/http/HttpHost;Lorg/apache/http/HttpRequest;Lorg/apache/http/protocol/HttpContext;)Lorg/apache/http/HttpResponse;

    move-result-object v3

    .line 0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    sub-long v6, v8, v6

    .line 26000
    iget-wide v8, v2, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    add-long/2addr v6, v8

    iput-wide v6, v2, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    iget v6, v2, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    add-int/lit8 v6, v6, 0x1

    iput v6, v2, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    .line 0
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->i:Lorg/apache/http/client/CookieStore;

    invoke-interface {v2}, Lorg/apache/http/client/CookieStore;->getCookies()Ljava/util/List;

    move-result-object v2

    iget-object v6, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 27000
    iget-boolean v6, v6, Lcom/alipay/android/phone/mrpc/core/r;->e:Z

    .line 0
    if-eqz v6, :cond_7

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->r()Landroid/webkit/CookieManager;

    move-result-object v6

    invoke-virtual {v6}, Landroid/webkit/CookieManager;->removeAllCookie()V

    :cond_7
    invoke-interface {v2}, Ljava/util/List;->isEmpty()Z

    move-result v6

    if-nez v6, :cond_c

    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v6

    :cond_8
    :goto_6
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_c

    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lorg/apache/http/cookie/Cookie;

    invoke-interface {v2}, Lorg/apache/http/cookie/Cookie;->getDomain()Ljava/lang/String;

    move-result-object v7

    if-eqz v7, :cond_8

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    invoke-interface {v2}, Lorg/apache/http/cookie/Cookie;->getName()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-interface {v2}, Lorg/apache/http/cookie/Cookie;->getValue()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "; domain="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-interface {v2}, Lorg/apache/http/cookie/Cookie;->getDomain()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-interface {v2}, Lorg/apache/http/cookie/Cookie;->isSecure()Z

    move-result v2

    if-eqz v2, :cond_b

    const-string v2, "; Secure"

    :goto_7
    invoke-virtual {v7, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->r()Landroid/webkit/CookieManager;

    move-result-object v7

    iget-object v8, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 28000
    iget-object v8, v8, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    invoke-virtual {v7, v8, v2}, Landroid/webkit/CookieManager;->setCookie(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {}, Landroid/webkit/CookieSyncManager;->getInstance()Landroid/webkit/CookieSyncManager;

    move-result-object v2

    invoke-virtual {v2}, Landroid/webkit/CookieSyncManager;->sync()V
    :try_end_2
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_2 .. :try_end_2} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_2 .. :try_end_2} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_2 .. :try_end_2} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_2 .. :try_end_2} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_2 .. :try_end_2} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_2 .. :try_end_2} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_2 .. :try_end_2} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_2 .. :try_end_2} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_2 .. :try_end_2} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_2 .. :try_end_2} :catch_a
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_2 .. :try_end_2} :catch_c
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_d

    goto :goto_6

    :catch_2
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 35000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_9

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_9
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v12}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    .line 23000
    :cond_a
    :try_start_3
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v2

    new-instance v3, Lorg/apache/http/HttpHost;

    invoke-virtual {v2}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v8

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v9

    invoke-virtual {v2}, Ljava/net/URL;->getProtocol()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v8, v9, v2}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    iput-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    goto/16 :goto_5

    .line 0
    :cond_b
    const-string v2, ""

    goto :goto_7

    .line 29000
    :cond_c
    invoke-interface {v3}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v2

    invoke-interface {v2}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v6

    invoke-interface {v3}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v2

    invoke-interface {v2}, Lorg/apache/http/StatusLine;->getReasonPhrase()Ljava/lang/String;

    move-result-object v7

    const/16 v2, 0xc8

    if-eq v6, v2, :cond_f

    .line 30000
    const/16 v2, 0x130

    if-ne v6, v2, :cond_e

    move v2, v4

    .line 29000
    :goto_8
    if-nez v2, :cond_f

    new-instance v2, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-interface {v3}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v6

    invoke-interface {v6}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v6

    invoke-static {v6}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v6

    invoke-interface {v3}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v3

    invoke-interface {v3}, Lorg/apache/http/StatusLine;->getReasonPhrase()Ljava/lang/String;

    move-result-object v3

    invoke-direct {v2, v6, v3}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v2
    :try_end_3
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_3 .. :try_end_3} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_3 .. :try_end_3} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_3 .. :try_end_3} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_3 .. :try_end_3} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_3 .. :try_end_3} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_3 .. :try_end_3} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_3 .. :try_end_3} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_3 .. :try_end_3} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_3 .. :try_end_3} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_3 .. :try_end_3} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_3 .. :try_end_3} :catch_a
    .catch Ljava/io/IOException; {:try_start_3 .. :try_end_3} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_3 .. :try_end_3} :catch_c
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_d

    .line 0
    :catch_3
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 36000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_d

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_d
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v12}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :cond_e
    move v2, v5

    .line 30000
    goto :goto_8

    .line 29000
    :cond_f
    :try_start_4
    invoke-direct {p0, v3, v6, v7}, Lcom/alipay/android/phone/mrpc/core/t;->a(Lorg/apache/http/HttpResponse;ILjava/lang/String;)Lcom/alipay/android/phone/mrpc/core/y;

    move-result-object v3

    .line 0
    const-wide/16 v6, -0x1

    if-eqz v3, :cond_10

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/y;->a()[B

    move-result-object v2

    if-eqz v2, :cond_10

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/y;->a()[B

    move-result-object v2

    array-length v2, v2

    int-to-long v6, v2

    :cond_10
    const-wide/16 v8, -0x1

    cmp-long v2, v6, v8

    if-nez v2, :cond_11

    instance-of v2, v3, Lcom/alipay/android/phone/mrpc/core/s;

    if-eqz v2, :cond_11

    move-object v0, v3

    check-cast v0, Lcom/alipay/android/phone/mrpc/core/s;

    move-object v2, v0
    :try_end_4
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_4 .. :try_end_4} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_4 .. :try_end_4} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_4 .. :try_end_4} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_4 .. :try_end_4} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_4 .. :try_end_4} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_4 .. :try_end_4} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_4 .. :try_end_4} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_4 .. :try_end_4} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_4 .. :try_end_4} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_4 .. :try_end_4} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_4 .. :try_end_4} :catch_a
    .catch Ljava/io/IOException; {:try_start_4 .. :try_end_4} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_4 .. :try_end_4} :catch_c
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_d

    .line 31000
    :try_start_5
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/s;->d:Lcom/alipay/android/phone/mrpc/core/q;

    .line 0
    const-string v6, "Content-Length"

    .line 32000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/q;->a:Ljava/util/Map;

    invoke-interface {v2, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 0
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_e
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_5 .. :try_end_5} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_5 .. :try_end_5} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_5 .. :try_end_5} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_5 .. :try_end_5} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_5 .. :try_end_5} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_5 .. :try_end_5} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_5 .. :try_end_5} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_5 .. :try_end_5} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_5 .. :try_end_5} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_5 .. :try_end_5} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_5 .. :try_end_5} :catch_a
    .catch Ljava/io/IOException; {:try_start_5 .. :try_end_5} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_5 .. :try_end_5} :catch_c

    :cond_11
    :goto_9
    :try_start_6
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 33000
    iget-object v2, v2, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    if-eqz v2, :cond_12

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->k()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v6

    if-nez v6, :cond_12

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v6, "#"

    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->k()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_6
    .catch Lcom/alipay/android/phone/mrpc/core/HttpException; {:try_start_6 .. :try_end_6} :catch_0
    .catch Ljava/net/URISyntaxException; {:try_start_6 .. :try_end_6} :catch_1
    .catch Ljavax/net/ssl/SSLHandshakeException; {:try_start_6 .. :try_end_6} :catch_2
    .catch Ljavax/net/ssl/SSLPeerUnverifiedException; {:try_start_6 .. :try_end_6} :catch_3
    .catch Ljavax/net/ssl/SSLException; {:try_start_6 .. :try_end_6} :catch_4
    .catch Lorg/apache/http/conn/ConnectionPoolTimeoutException; {:try_start_6 .. :try_end_6} :catch_5
    .catch Lorg/apache/http/conn/ConnectTimeoutException; {:try_start_6 .. :try_end_6} :catch_6
    .catch Ljava/net/SocketTimeoutException; {:try_start_6 .. :try_end_6} :catch_7
    .catch Lorg/apache/http/NoHttpResponseException; {:try_start_6 .. :try_end_6} :catch_8
    .catch Lorg/apache/http/conn/HttpHostConnectException; {:try_start_6 .. :try_end_6} :catch_9
    .catch Ljava/net/UnknownHostException; {:try_start_6 .. :try_end_6} :catch_a
    .catch Ljava/io/IOException; {:try_start_6 .. :try_end_6} :catch_b
    .catch Ljava/lang/NullPointerException; {:try_start_6 .. :try_end_6} :catch_c
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_d

    :cond_12
    return-object v3

    :catch_4
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 37000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_13

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_13
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v14}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_5
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 38000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_14

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_14
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v13}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_6
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 39000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_15

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_15
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v13}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_7
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 40000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_16

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_16
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    const/4 v4, 0x4

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_8
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 41000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_17

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_17
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    const/4 v4, 0x5

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_9
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 42000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_18

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_18
    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    const/16 v4, 0x8

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_a
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 43000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_19

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_19
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    const/16 v4, 0x9

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_b
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 44000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_1a

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_1a
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v14}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_c
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    iget v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->n:I

    if-gtz v3, :cond_1b

    iget v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->n:I

    add-int/lit8 v2, v2, 0x1

    iput v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->n:I

    goto/16 :goto_0

    :cond_1b
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_d
    move-exception v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->g()V

    .line 45000
    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v3}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v3

    .line 0
    if-eqz v3, :cond_1c

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    :cond_1c
    new-instance v3, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v3, v4, v2}, Lcom/alipay/android/phone/mrpc/core/HttpException;-><init>(Ljava/lang/Integer;Ljava/lang/String;)V

    throw v3

    :catch_e
    move-exception v2

    goto/16 :goto_9

    :cond_1d
    move-object v2, v3

    goto/16 :goto_4

    :cond_1e
    move v2, v5

    goto/16 :goto_1
.end method

.method private g()V
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    invoke-interface {v0}, Lorg/apache/http/client/methods/HttpUriRequest;->abort()V

    :cond_0
    return-void
.end method

.method private h()Lcom/alipay/android/phone/mrpc/core/ah;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/r;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v0

    return-object v0
.end method

.method private i()Lorg/apache/http/HttpResponse;
    .locals 6

    .prologue
    const/4 v1, 0x0

    .line 0
    .line 46000
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "By Http/Https to request. operationType="

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->k()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, " url="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    invoke-interface {v2}, Lorg/apache/http/client/methods/HttpUriRequest;->getURI()Ljava/net/URI;

    move-result-object v2

    invoke-virtual {v2}, Ljava/net/URI;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 47000
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 48000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 46000
    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/b;->getParams()Lorg/apache/http/params/HttpParams;

    move-result-object v2

    const-string v3, "http.route.default-proxy"

    .line 49000
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    .line 51000
    const-string v4, "connectivity"

    invoke-virtual {v0, v4}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/net/ConnectivityManager;

    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v0

    .line 50000
    if-eqz v0, :cond_3

    invoke-virtual {v0}, Landroid/net/NetworkInfo;->isAvailable()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-static {}, Landroid/net/Proxy;->getDefaultHost()Ljava/lang/String;

    move-result-object v4

    invoke-static {}, Landroid/net/Proxy;->getDefaultPort()I

    move-result v5

    if-eqz v4, :cond_3

    new-instance v0, Lorg/apache/http/HttpHost;

    invoke-direct {v0, v4, v5}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;I)V

    .line 49000
    :goto_0
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getHostName()Ljava/lang/String;

    move-result-object v4

    const-string v5, "127.0.0.1"

    invoke-static {v4, v5}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getPort()I

    move-result v4

    const/16 v5, 0x1f97

    if-ne v4, v5, :cond_0

    move-object v0, v1

    .line 46000
    :cond_0
    invoke-interface {v2, v3, v0}, Lorg/apache/http/params/HttpParams;->setParameter(Ljava/lang/String;Ljava/lang/Object;)Lorg/apache/http/params/HttpParams;

    .line 51001
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    .line 46000
    :goto_1
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v1

    const/16 v2, 0x50

    if-ne v1, v2, :cond_1

    new-instance v0, Lorg/apache/http/HttpHost;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v1

    invoke-virtual {v1}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;)V

    .line 51002
    :cond_1
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 51003
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 46000
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->h:Lorg/apache/http/protocol/HttpContext;

    invoke-virtual {v1, v0, v2, v3}, Lcom/alipay/android/phone/mrpc/core/b;->execute(Lorg/apache/http/HttpHost;Lorg/apache/http/HttpRequest;Lorg/apache/http/protocol/HttpContext;)Lorg/apache/http/HttpResponse;

    move-result-object v0

    .line 0
    return-object v0

    .line 51001
    :cond_2
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v0

    new-instance v1, Lorg/apache/http/HttpHost;

    invoke-virtual {v0}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v3

    invoke-virtual {v0}, Ljava/net/URL;->getProtocol()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v1, v2, v3, v0}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    goto :goto_1

    :cond_3
    move-object v0, v1

    goto :goto_0
.end method

.method private j()Lorg/apache/http/HttpResponse;
    .locals 6

    .prologue
    const/4 v1, 0x0

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v2, "By Http/Https to request. operationType="

    invoke-direct {v0, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->k()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, " url="

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    invoke-interface {v2}, Lorg/apache/http/client/methods/HttpUriRequest;->getURI()Ljava/net/URI;

    move-result-object v2

    invoke-virtual {v2}, Ljava/net/URI;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 51004
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 51005
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 0
    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/b;->getParams()Lorg/apache/http/params/HttpParams;

    move-result-object v2

    const-string v3, "http.route.default-proxy"

    .line 51006
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    .line 51008
    const-string v4, "connectivity"

    invoke-virtual {v0, v4}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/net/ConnectivityManager;

    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v0

    .line 51007
    if-eqz v0, :cond_3

    invoke-virtual {v0}, Landroid/net/NetworkInfo;->isAvailable()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-static {}, Landroid/net/Proxy;->getDefaultHost()Ljava/lang/String;

    move-result-object v4

    invoke-static {}, Landroid/net/Proxy;->getDefaultPort()I

    move-result v5

    if-eqz v4, :cond_3

    new-instance v0, Lorg/apache/http/HttpHost;

    invoke-direct {v0, v4, v5}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;I)V

    .line 51006
    :goto_0
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getHostName()Ljava/lang/String;

    move-result-object v4

    const-string v5, "127.0.0.1"

    invoke-static {v4, v5}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getPort()I

    move-result v4

    const/16 v5, 0x1f97

    if-ne v4, v5, :cond_0

    move-object v0, v1

    .line 0
    :cond_0
    invoke-interface {v2, v3, v0}, Lorg/apache/http/params/HttpParams;->setParameter(Ljava/lang/String;Ljava/lang/Object;)Lorg/apache/http/params/HttpParams;

    .line 51009
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    .line 0
    :goto_1
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v1

    const/16 v2, 0x50

    if-ne v1, v2, :cond_1

    new-instance v0, Lorg/apache/http/HttpHost;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v1

    invoke-virtual {v1}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;)V

    .line 51010
    :cond_1
    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 51011
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 0
    iget-object v2, p0, Lcom/alipay/android/phone/mrpc/core/t;->g:Lorg/apache/http/client/methods/HttpUriRequest;

    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->h:Lorg/apache/http/protocol/HttpContext;

    invoke-virtual {v1, v0, v2, v3}, Lcom/alipay/android/phone/mrpc/core/b;->execute(Lorg/apache/http/HttpHost;Lorg/apache/http/HttpRequest;Lorg/apache/http/protocol/HttpContext;)Lorg/apache/http/HttpResponse;

    move-result-object v0

    return-object v0

    .line 51009
    :cond_2
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v0

    new-instance v1, Lorg/apache/http/HttpHost;

    invoke-virtual {v0}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v3

    invoke-virtual {v0}, Ljava/net/URL;->getProtocol()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v1, v2, v3, v0}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    goto :goto_1

    :cond_3
    move-object v0, v1

    goto :goto_0
.end method

.method private k()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->r:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->r:Ljava/lang/String;

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    const-string v1, "operationType"

    invoke-virtual {v0, v1}, Lcom/alipay/android/phone/mrpc/core/r;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->r:Ljava/lang/String;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->r:Ljava/lang/String;

    goto :goto_0
.end method

.method private l()Lcom/alipay/android/phone/mrpc/core/b;
    .locals 1

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->a:Lcom/alipay/android/phone/mrpc/core/n;

    .line 51012
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 0
    return-object v0
.end method

.method private m()V
    .locals 4

    .prologue
    .line 0
    .line 51013
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 51014
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/r;->d:Ljava/util/ArrayList;

    .line 0
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/util/ArrayList;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-virtual {v0}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lorg/apache/http/Header;

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v2

    invoke-interface {v2, v0}, Lorg/apache/http/client/methods/HttpUriRequest;->addHeader(Lorg/apache/http/Header;)V

    goto :goto_0

    :cond_0
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a(Lorg/apache/http/HttpRequest;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->b(Lorg/apache/http/HttpRequest;)V

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->e()Lorg/apache/http/client/methods/HttpUriRequest;

    move-result-object v0

    const-string v1, "cookie"

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->r()Landroid/webkit/CookieManager;

    move-result-object v2

    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 51015
    iget-object v3, v3, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    invoke-virtual {v2, v3}, Landroid/webkit/CookieManager;->getCookie(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Lorg/apache/http/client/methods/HttpUriRequest;->addHeader(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method private n()Lorg/apache/http/HttpHost;
    .locals 4

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    :goto_0
    return-object v0

    :cond_0
    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v0

    new-instance v1, Lorg/apache/http/HttpHost;

    invoke-virtual {v0}, Ljava/net/URL;->getHost()Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->o()I

    move-result v3

    invoke-virtual {v0}, Ljava/net/URL;->getProtocol()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v1, v2, v3, v0}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;ILjava/lang/String;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->l:Lorg/apache/http/HttpHost;

    goto :goto_0
.end method

.method private o()I
    .locals 3

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->p()Ljava/net/URL;

    move-result-object v0

    invoke-virtual {v0}, Ljava/net/URL;->getPort()I

    move-result v1

    const/4 v2, -0x1

    if-ne v1, v2, :cond_0

    invoke-virtual {v0}, Ljava/net/URL;->getDefaultPort()I

    move-result v0

    :goto_0
    return v0

    :cond_0
    invoke-virtual {v0}, Ljava/net/URL;->getPort()I

    move-result v0

    goto :goto_0
.end method

.method private p()Ljava/net/URL;
    .locals 2

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->m:Ljava/net/URL;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->m:Ljava/net/URL;

    :goto_0
    return-object v0

    :cond_0
    new-instance v0, Ljava/net/URL;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    .line 51016
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/r;->a:Ljava/lang/String;

    .line 0
    invoke-direct {v0, v1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->m:Ljava/net/URL;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->m:Ljava/net/URL;

    goto :goto_0
.end method

.method private q()Lorg/apache/http/HttpHost;
    .locals 4

    .prologue
    const/4 v1, 0x0

    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->b:Landroid/content/Context;

    .line 51018
    const-string v2, "connectivity"

    invoke-virtual {v0, v2}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/net/ConnectivityManager;

    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v0

    .line 51017
    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroid/net/NetworkInfo;->isAvailable()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-static {}, Landroid/net/Proxy;->getDefaultHost()Ljava/lang/String;

    move-result-object v2

    invoke-static {}, Landroid/net/Proxy;->getDefaultPort()I

    move-result v3

    if-eqz v2, :cond_1

    new-instance v0, Lorg/apache/http/HttpHost;

    invoke-direct {v0, v2, v3}, Lorg/apache/http/HttpHost;-><init>(Ljava/lang/String;I)V

    .line 0
    :goto_0
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getHostName()Ljava/lang/String;

    move-result-object v2

    const-string v3, "127.0.0.1"

    invoke-static {v2, v3}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-virtual {v0}, Lorg/apache/http/HttpHost;->getPort()I

    move-result v2

    const/16 v3, 0x1f97

    if-ne v2, v3, :cond_0

    move-object v0, v1

    :cond_0
    return-object v0

    :cond_1
    move-object v0, v1

    goto :goto_0
.end method

.method private r()Landroid/webkit/CookieManager;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->j:Landroid/webkit/CookieManager;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->j:Landroid/webkit/CookieManager;

    :goto_0
    return-object v0

    :cond_0
    invoke-static {}, Landroid/webkit/CookieManager;->getInstance()Landroid/webkit/CookieManager;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->j:Landroid/webkit/CookieManager;

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->j:Landroid/webkit/CookieManager;

    goto :goto_0
.end method


# virtual methods
.method public final a()Lcom/alipay/android/phone/mrpc/core/r;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/t;->c:Lcom/alipay/android/phone/mrpc/core/r;

    return-object v0
.end method

.method public final synthetic call()Ljava/lang/Object;
    .locals 1

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/t;->f()Lcom/alipay/android/phone/mrpc/core/y;

    move-result-object v0

    return-object v0
.end method
