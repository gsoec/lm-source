.class final Lcom/alipay/apmobilesecuritysdk/g/c;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field final synthetic a:Lcom/alipay/apmobilesecuritysdk/g/b;


# direct methods
.method constructor <init>(Lcom/alipay/apmobilesecuritysdk/g/b;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 3

    const/4 v0, 0x0

    :try_start_0
    invoke-static {v0}, Landroid/os/Process;->setThreadPriority(I)V

    :cond_0
    :goto_0
    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/g/b;->a(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/util/LinkedList;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/LinkedList;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/g/b;->a(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/util/LinkedList;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Ljava/util/LinkedList;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Runnable;

    iget-object v1, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v1}, Lcom/alipay/apmobilesecuritysdk/g/b;->a(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/util/LinkedList;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {v1, v2}, Ljava/util/LinkedList;->remove(I)Ljava/lang/Object;

    if-eqz v0, :cond_0

    invoke-interface {v0}, Ljava/lang/Runnable;->run()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    :catch_0
    move-exception v0

    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/g/b;->b(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/lang/Thread;

    :goto_1
    return-void

    :cond_1
    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v0}, Lcom/alipay/apmobilesecuritysdk/g/b;->b(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/lang/Thread;

    goto :goto_1

    :catchall_0
    move-exception v0

    iget-object v1, p0, Lcom/alipay/apmobilesecuritysdk/g/c;->a:Lcom/alipay/apmobilesecuritysdk/g/b;

    invoke-static {v1}, Lcom/alipay/apmobilesecuritysdk/g/b;->b(Lcom/alipay/apmobilesecuritysdk/g/b;)Ljava/lang/Thread;

    throw v0
.end method
