.class public final Lcom/alipay/android/phone/mrpc/core/n;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/alipay/android/phone/mrpc/core/ag;


# static fields
.field public static final a:Ljava/lang/String; = "HttpManager"

.field private static h:Lcom/alipay/android/phone/mrpc/core/n; = null

.field private static final i:I = 0xa

.field private static final j:I = 0xb

.field private static final k:I = 0x3

.field private static final l:I = 0x14

.field private static final n:Ljava/util/concurrent/ThreadFactory;


# instance fields
.field b:Landroid/content/Context;

.field c:Lcom/alipay/android/phone/mrpc/core/b;

.field d:J

.field e:J

.field f:J

.field g:I

.field private m:Ljava/util/concurrent/ThreadPoolExecutor;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const/4 v0, 0x0

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/p;

    invoke-direct {v0}, Lcom/alipay/android/phone/mrpc/core/p;-><init>()V

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/n;->n:Ljava/util/concurrent/ThreadFactory;

    return-void
.end method

.method private constructor <init>(Landroid/content/Context;)V
    .locals 11

    .prologue
    const/4 v10, 0x1

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/n;->b:Landroid/content/Context;

    .line 1000
    const-string v0, "android"

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a(Ljava/lang/String;)Lcom/alipay/android/phone/mrpc/core/b;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    new-instance v1, Ljava/util/concurrent/ThreadPoolExecutor;

    const/16 v2, 0xa

    const/16 v3, 0xb

    const-wide/16 v4, 0x3

    sget-object v6, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    new-instance v7, Ljava/util/concurrent/ArrayBlockingQueue;

    const/16 v0, 0x14

    invoke-direct {v7, v0}, Ljava/util/concurrent/ArrayBlockingQueue;-><init>(I)V

    sget-object v8, Lcom/alipay/android/phone/mrpc/core/n;->n:Ljava/util/concurrent/ThreadFactory;

    new-instance v9, Ljava/util/concurrent/ThreadPoolExecutor$CallerRunsPolicy;

    invoke-direct {v9}, Ljava/util/concurrent/ThreadPoolExecutor$CallerRunsPolicy;-><init>()V

    invoke-direct/range {v1 .. v9}, Ljava/util/concurrent/ThreadPoolExecutor;-><init>(IIJLjava/util/concurrent/TimeUnit;Ljava/util/concurrent/BlockingQueue;Ljava/util/concurrent/ThreadFactory;Ljava/util/concurrent/RejectedExecutionHandler;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    :try_start_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ThreadPoolExecutor;->allowCoreThreadTimeOut(Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->b:Landroid/content/Context;

    invoke-static {v0}, Landroid/webkit/CookieSyncManager;->createInstance(Landroid/content/Context;)Landroid/webkit/CookieSyncManager;

    invoke-static {}, Landroid/webkit/CookieManager;->getInstance()Landroid/webkit/CookieManager;

    move-result-object v0

    invoke-virtual {v0, v10}, Landroid/webkit/CookieManager;->setAcceptCookie(Z)V

    .line 0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method public static final a(Landroid/content/Context;)Lcom/alipay/android/phone/mrpc/core/n;
    .locals 1

    sget-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;

    if-eqz v0, :cond_0

    sget-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;

    :goto_0
    return-object v0

    :cond_0
    invoke-static {p0}, Lcom/alipay/android/phone/mrpc/core/n;->b(Landroid/content/Context;)Lcom/alipay/android/phone/mrpc/core/n;

    move-result-object v0

    goto :goto_0
.end method

.method private a(Lcom/alipay/android/phone/mrpc/core/r;)Lcom/alipay/android/phone/mrpc/core/t;
    .locals 1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/t;

    invoke-direct {v0, p0, p1}, Lcom/alipay/android/phone/mrpc/core/t;-><init>(Lcom/alipay/android/phone/mrpc/core/n;Lcom/alipay/android/phone/mrpc/core/r;)V

    return-object v0
.end method

.method private a(Lcom/alipay/android/phone/mrpc/core/t;)Ljava/util/concurrent/FutureTask;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/alipay/android/phone/mrpc/core/t;",
            ")",
            "Ljava/util/concurrent/FutureTask",
            "<",
            "Lcom/alipay/android/phone/mrpc/core/y;",
            ">;"
        }
    .end annotation

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/o;

    invoke-direct {v0, p0, p1, p1}, Lcom/alipay/android/phone/mrpc/core/o;-><init>(Lcom/alipay/android/phone/mrpc/core/n;Ljava/util/concurrent/Callable;Lcom/alipay/android/phone/mrpc/core/t;)V

    return-object v0
.end method

.method private a()V
    .locals 11

    const/4 v10, 0x1

    const-string v0, "android"

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a(Ljava/lang/String;)Lcom/alipay/android/phone/mrpc/core/b;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    new-instance v1, Ljava/util/concurrent/ThreadPoolExecutor;

    const/16 v2, 0xa

    const/16 v3, 0xb

    const-wide/16 v4, 0x3

    sget-object v6, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    new-instance v7, Ljava/util/concurrent/ArrayBlockingQueue;

    const/16 v0, 0x14

    invoke-direct {v7, v0}, Ljava/util/concurrent/ArrayBlockingQueue;-><init>(I)V

    sget-object v8, Lcom/alipay/android/phone/mrpc/core/n;->n:Ljava/util/concurrent/ThreadFactory;

    new-instance v9, Ljava/util/concurrent/ThreadPoolExecutor$CallerRunsPolicy;

    invoke-direct {v9}, Ljava/util/concurrent/ThreadPoolExecutor$CallerRunsPolicy;-><init>()V

    invoke-direct/range {v1 .. v9}, Ljava/util/concurrent/ThreadPoolExecutor;-><init>(IIJLjava/util/concurrent/TimeUnit;Ljava/util/concurrent/BlockingQueue;Ljava/util/concurrent/ThreadFactory;Ljava/util/concurrent/RejectedExecutionHandler;)V

    iput-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    :try_start_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ThreadPoolExecutor;->allowCoreThreadTimeOut(Z)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->b:Landroid/content/Context;

    invoke-static {v0}, Landroid/webkit/CookieSyncManager;->createInstance(Landroid/content/Context;)Landroid/webkit/CookieSyncManager;

    invoke-static {}, Landroid/webkit/CookieManager;->getInstance()Landroid/webkit/CookieManager;

    move-result-object v0

    invoke-virtual {v0, v10}, Landroid/webkit/CookieManager;->setAcceptCookie(Z)V

    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method private a(J)V
    .locals 3

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    add-long/2addr v0, p1

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    return-void
.end method

.method private b()Lcom/alipay/android/phone/mrpc/core/b;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    return-object v0
.end method

.method private static final declared-synchronized b(Landroid/content/Context;)Lcom/alipay/android/phone/mrpc/core/n;
    .locals 2

    const-class v1, Lcom/alipay/android/phone/mrpc/core/n;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;

    if-eqz v0, :cond_0

    sget-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :goto_0
    monitor-exit v1

    return-object v0

    :cond_0
    :try_start_1
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/n;

    invoke-direct {v0, p0}, Lcom/alipay/android/phone/mrpc/core/n;-><init>(Landroid/content/Context;)V

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/n;->h:Lcom/alipay/android/phone/mrpc/core/n;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method private b(J)V
    .locals 3

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    add-long/2addr v0, p1

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    return-void
.end method

.method private c()J
    .locals 4

    const-wide/16 v0, 0x0

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    cmp-long v2, v2, v0

    if-nez v2, :cond_0

    :goto_0
    return-wide v0

    :cond_0
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    const-wide/16 v2, 0x3e8

    mul-long/2addr v0, v2

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    div-long/2addr v0, v2

    const/16 v2, 0xa

    shr-long/2addr v0, v2

    goto :goto_0
.end method

.method private c(J)V
    .locals 3

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    add-long/2addr v0, p1

    iput-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    return-void
.end method

.method private d()J
    .locals 4

    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    if-nez v0, :cond_0

    const-wide/16 v0, 0x0

    :goto_0
    return-wide v0

    :cond_0
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    iget v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    int-to-long v2, v2

    div-long/2addr v0, v2

    goto :goto_0
.end method

.method private e()Ljava/lang/String;
    .locals 10

    .prologue
    const-wide/16 v2, 0x0

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "HttpManager"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ": Active Task = %d, Completed Task = %d, All Task = %d,Avarage Speed = %d KB/S, Connetct Time = %d ms, All data size = %d bytes, All enqueueConnect time = %d ms, All socket time = %d ms, All request times = %d times"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    const/16 v0, 0x9

    new-array v5, v0, [Ljava/lang/Object;

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getActiveCount()I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x1

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getCompletedTaskCount()J

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x2

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getTaskCount()J

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v6, 0x3

    .line 7000
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    cmp-long v0, v0, v2

    if-nez v0, :cond_0

    move-wide v0, v2

    .line 0
    :goto_0
    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    aput-object v0, v5, v6

    const/4 v0, 0x4

    .line 8000
    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    if-nez v1, :cond_1

    .line 0
    :goto_1
    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x5

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x6

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x7

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/16 v0, 0x8

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    aput-object v1, v5, v0

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0

    .line 7000
    :cond_0
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    const-wide/16 v8, 0x3e8

    mul-long/2addr v0, v8

    iget-wide v8, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    div-long/2addr v0, v8

    const/16 v7, 0xa

    shr-long/2addr v0, v7

    goto :goto_0

    .line 8000
    :cond_1
    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    int-to-long v6, v1

    div-long/2addr v2, v6

    goto :goto_1
.end method

.method private f()V
    .locals 3

    .prologue
    const/4 v2, 0x0

    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v0}, Ljava/util/concurrent/ThreadPoolExecutor;->shutdown()V

    iput-object v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    :cond_0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    .line 9000
    iget-object v1, v0, Lcom/alipay/android/phone/mrpc/core/b;->c:Ljava/lang/RuntimeException;

    if-eqz v1, :cond_1

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/b;->getConnectionManager()Lorg/apache/http/conn/ClientConnectionManager;

    move-result-object v1

    invoke-interface {v1}, Lorg/apache/http/conn/ClientConnectionManager;->shutdown()V

    iput-object v2, v0, Lcom/alipay/android/phone/mrpc/core/b;->c:Ljava/lang/RuntimeException;

    .line 0
    :cond_1
    iput-object v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->c:Lcom/alipay/android/phone/mrpc/core/b;

    return-void
.end method


# virtual methods
.method public final a(Lcom/alipay/android/phone/mrpc/core/x;)Ljava/util/concurrent/Future;
    .locals 10
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/alipay/android/phone/mrpc/core/x;",
            ")",
            "Ljava/util/concurrent/Future",
            "<",
            "Lcom/alipay/android/phone/mrpc/core/y;",
            ">;"
        }
    .end annotation

    .prologue
    const-wide/16 v2, 0x0

    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->b:Landroid/content/Context;

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/v;->a(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 2000
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "HttpManager"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ": Active Task = %d, Completed Task = %d, All Task = %d,Avarage Speed = %d KB/S, Connetct Time = %d ms, All data size = %d bytes, All enqueueConnect time = %d ms, All socket time = %d ms, All request times = %d times"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    const/16 v0, 0x9

    new-array v5, v0, [Ljava/lang/Object;

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getActiveCount()I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x1

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getCompletedTaskCount()J

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x2

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v1}, Ljava/util/concurrent/ThreadPoolExecutor;->getTaskCount()J

    move-result-wide v6

    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v6, 0x3

    .line 3000
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    cmp-long v0, v0, v2

    if-nez v0, :cond_1

    move-wide v0, v2

    .line 2000
    :goto_0
    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    aput-object v0, v5, v6

    const/4 v0, 0x4

    .line 4000
    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    if-nez v1, :cond_2

    .line 2000
    :goto_1
    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x5

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x6

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/4 v0, 0x7

    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v5, v0

    const/16 v0, 0x8

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    aput-object v1, v5, v0

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    .line 0
    :cond_0
    check-cast p1, Lcom/alipay/android/phone/mrpc/core/r;

    .line 5000
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/t;

    invoke-direct {v0, p0, p1}, Lcom/alipay/android/phone/mrpc/core/t;-><init>(Lcom/alipay/android/phone/mrpc/core/n;Lcom/alipay/android/phone/mrpc/core/r;)V

    .line 6000
    new-instance v1, Lcom/alipay/android/phone/mrpc/core/o;

    invoke-direct {v1, p0, v0, v0}, Lcom/alipay/android/phone/mrpc/core/o;-><init>(Lcom/alipay/android/phone/mrpc/core/n;Ljava/util/concurrent/Callable;Lcom/alipay/android/phone/mrpc/core/t;)V

    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->m:Ljava/util/concurrent/ThreadPoolExecutor;

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ThreadPoolExecutor;->execute(Ljava/lang/Runnable;)V

    return-object v1

    .line 3000
    :cond_1
    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/n;->d:J

    const-wide/16 v8, 0x3e8

    mul-long/2addr v0, v8

    iget-wide v8, p0, Lcom/alipay/android/phone/mrpc/core/n;->f:J

    div-long/2addr v0, v8

    const/16 v7, 0xa

    shr-long/2addr v0, v7

    goto :goto_0

    .line 4000
    :cond_2
    iget-wide v2, p0, Lcom/alipay/android/phone/mrpc/core/n;->e:J

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/n;->g:I

    int-to-long v6, v1

    div-long/2addr v2, v6

    goto :goto_1
.end method
