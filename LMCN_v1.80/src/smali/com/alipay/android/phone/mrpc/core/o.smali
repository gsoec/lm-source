.class final Lcom/alipay/android/phone/mrpc/core/o;
.super Ljava/util/concurrent/FutureTask;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/util/concurrent/FutureTask",
        "<",
        "Lcom/alipay/android/phone/mrpc/core/y;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic a:Lcom/alipay/android/phone/mrpc/core/t;

.field final synthetic b:Lcom/alipay/android/phone/mrpc/core/n;


# direct methods
.method constructor <init>(Lcom/alipay/android/phone/mrpc/core/n;Ljava/util/concurrent/Callable;Lcom/alipay/android/phone/mrpc/core/t;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/o;->b:Lcom/alipay/android/phone/mrpc/core/n;

    iput-object p3, p0, Lcom/alipay/android/phone/mrpc/core/o;->a:Lcom/alipay/android/phone/mrpc/core/t;

    invoke-direct {p0, p2}, Ljava/util/concurrent/FutureTask;-><init>(Ljava/util/concurrent/Callable;)V

    return-void
.end method


# virtual methods
.method protected final done()V
    .locals 3

    .prologue
    const/4 v2, 0x1

    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/o;->a:Lcom/alipay/android/phone/mrpc/core/t;

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/t;->a()Lcom/alipay/android/phone/mrpc/core/r;

    move-result-object v0

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/x;->a()Lcom/alipay/android/phone/mrpc/core/ah;

    move-result-object v1

    if-nez v1, :cond_1

    invoke-super {p0}, Ljava/util/concurrent/FutureTask;->done()V

    :cond_0
    :goto_0
    return-void

    :cond_1
    :try_start_0
    invoke-virtual {p0}, Lcom/alipay/android/phone/mrpc/core/o;->get()Ljava/lang/Object;

    invoke-virtual {p0}, Lcom/alipay/android/phone/mrpc/core/o;->isCancelled()Z

    move-result v1

    if-nez v1, :cond_2

    .line 1000
    iget-boolean v1, v0, Lcom/alipay/android/phone/mrpc/core/x;->f:Z

    .line 0
    if-eqz v1, :cond_0

    .line 2000
    :cond_2
    const/4 v1, 0x1

    iput-boolean v1, v0, Lcom/alipay/android/phone/mrpc/core/x;->f:Z

    .line 0
    invoke-virtual {p0}, Lcom/alipay/android/phone/mrpc/core/o;->isCancelled()Z

    move-result v1

    if-eqz v1, :cond_3

    invoke-virtual {p0}, Lcom/alipay/android/phone/mrpc/core/o;->isDone()Z

    move-result v1

    if-nez v1, :cond_0

    :cond_3
    const/4 v1, 0x0

    invoke-virtual {p0, v1}, Lcom/alipay/android/phone/mrpc/core/o;->cancel(Z)Z
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/util/concurrent/CancellationException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_3

    goto :goto_0

    :catch_0
    move-exception v0

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    goto :goto_0

    :catch_1
    move-exception v0

    invoke-virtual {v0}, Ljava/util/concurrent/ExecutionException;->getCause()Ljava/lang/Throwable;

    move-result-object v1

    if-eqz v1, :cond_4

    invoke-virtual {v0}, Ljava/util/concurrent/ExecutionException;->getCause()Ljava/lang/Throwable;

    move-result-object v1

    instance-of v1, v1, Lcom/alipay/android/phone/mrpc/core/HttpException;

    if-eqz v1, :cond_4

    invoke-virtual {v0}, Ljava/util/concurrent/ExecutionException;->getCause()Ljava/lang/Throwable;

    move-result-object v0

    check-cast v0, Lcom/alipay/android/phone/mrpc/core/HttpException;

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/HttpException;->getCode()I

    invoke-virtual {v0}, Lcom/alipay/android/phone/mrpc/core/HttpException;->getMsg()Ljava/lang/String;

    goto :goto_0

    :cond_4
    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    goto :goto_0

    :catch_2
    move-exception v1

    .line 3000
    iput-boolean v2, v0, Lcom/alipay/android/phone/mrpc/core/x;->f:Z

    goto :goto_0

    .line 0
    :catch_3
    move-exception v0

    new-instance v1, Ljava/lang/RuntimeException;

    const-string v2, "An error occured while executing http request"

    invoke-direct {v1, v2, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v1
.end method
