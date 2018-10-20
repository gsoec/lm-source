.class public final Lcom/alipay/android/phone/mrpc/core/ad;
.super Ljava/lang/Object;


# static fields
.field private static final a:Ljava/lang/ThreadLocal;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ThreadLocal",
            "<",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation
.end field

.field private static final b:Ljava/lang/ThreadLocal;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ThreadLocal",
            "<",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;>;"
        }
    .end annotation
.end field

.field private static final c:B = 0x0t

.field private static final d:B = 0x1t


# instance fields
.field private e:B

.field private f:Ljava/util/concurrent/atomic/AtomicInteger;

.field private g:Lcom/alipay/android/phone/mrpc/core/ab;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    new-instance v0, Ljava/lang/ThreadLocal;

    invoke-direct {v0}, Ljava/lang/ThreadLocal;-><init>()V

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->a:Ljava/lang/ThreadLocal;

    new-instance v0, Ljava/lang/ThreadLocal;

    invoke-direct {v0}, Ljava/lang/ThreadLocal;-><init>()V

    sput-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    return-void
.end method

.method public constructor <init>(Lcom/alipay/android/phone/mrpc/core/ab;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    iput-byte v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->e:B

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/ad;->g:Lcom/alipay/android/phone/mrpc/core/ab;

    new-instance v0, Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-direct {v0}, Ljava/util/concurrent/atomic/AtomicInteger;-><init>()V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->f:Ljava/util/concurrent/atomic/AtomicInteger;

    return-void
.end method

.method private static a(Ljava/lang/reflect/Type;[B)Lcom/alipay/android/phone/mrpc/core/gwprotocol/c;
    .locals 1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/gwprotocol/d;

    invoke-direct {v0, p0, p1}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/d;-><init>(Ljava/lang/reflect/Type;[B)V

    return-object v0
.end method

.method private static a(ILjava/lang/String;[Ljava/lang/Object;)Lcom/alipay/android/phone/mrpc/core/gwprotocol/f;
    .locals 1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;

    invoke-direct {v0, p0, p1, p2}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;-><init>(ILjava/lang/String;Ljava/lang/Object;)V

    return-object v0
.end method

.method private a(Ljava/lang/reflect/Method;ILjava/lang/String;[BZ)Lcom/alipay/android/phone/mrpc/core/z;
    .locals 7

    .prologue
    .line 0
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/l;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/ad;->g:Lcom/alipay/android/phone/mrpc/core/ab;

    .line 11000
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    move-object v2, p1

    move v3, p2

    move-object v4, p3

    move-object v5, p4

    move v6, p5

    .line 0
    invoke-direct/range {v0 .. v6}, Lcom/alipay/android/phone/mrpc/core/l;-><init>(Lcom/alipay/android/phone/mrpc/core/h;Ljava/lang/reflect/Method;ILjava/lang/String;[BZ)V

    return-object v0
.end method

.method private static a()V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    return-void
.end method

.method private static a(Lcom/alipay/android/phone/mrpc/core/RpcException;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/alipay/android/phone/mrpc/core/RpcException;",
            ")V"
        }
    .end annotation

    throw p0
.end method

.method private static a(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 2

    sget-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    if-nez v0, :cond_0

    sget-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    invoke-virtual {v0, v1}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    :cond_0
    sget-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map;

    invoke-interface {v0, p0, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method private a(Ljava/lang/reflect/Method;[Ljava/lang/Object;Ljava/lang/String;IZ)[B
    .locals 7

    .prologue
    .line 0
    .line 8000
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;

    invoke-direct {v0, p4, p3, p2}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;-><init>(ILjava/lang/String;Ljava/lang/Object;)V

    .line 0
    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v1}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_0

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v1}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/f;->a(Ljava/lang/Object;)V

    :cond_0
    invoke-interface {v0}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/f;->a()[B

    move-result-object v5

    .line 9000
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/l;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/ad;->g:Lcom/alipay/android/phone/mrpc/core/ab;

    .line 10000
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    move-object v2, p1

    move v3, p4

    move-object v4, p3

    move v6, p5

    .line 9000
    invoke-direct/range {v0 .. v6}, Lcom/alipay/android/phone/mrpc/core/l;-><init>(Lcom/alipay/android/phone/mrpc/core/h;Ljava/lang/reflect/Method;ILjava/lang/String;[BZ)V

    .line 0
    invoke-interface {v0}, Lcom/alipay/android/phone/mrpc/core/z;->a()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    const/4 v2, 0x0

    invoke-virtual {v1, v2}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    return-object v0
.end method

.method private static b()V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    return-void
.end method

.method private c()V
    .locals 1

    const/4 v0, 0x1

    iput-byte v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->e:B

    return-void
.end method

.method private d()Ljava/util/concurrent/FutureTask;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/concurrent/FutureTask",
            "<*>;"
        }
    .end annotation

    const/4 v0, 0x0

    iput-byte v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->e:B

    const/4 v0, 0x0

    return-object v0
.end method


# virtual methods
.method public final a(Ljava/lang/reflect/Method;[Ljava/lang/Object;)Ljava/lang/Object;
    .locals 8
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/reflect/Method;",
            "[",
            "Ljava/lang/Object;",
            ")",
            "Ljava/lang/Object;"
        }
    .end annotation

    .prologue
    const/4 v6, 0x1

    const/4 v1, 0x0

    const/4 v3, 0x0

    .line 1000
    invoke-static {}, Landroid/os/Looper;->myLooper()Landroid/os/Looper;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-static {}, Landroid/os/Looper;->myLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    if-ne v0, v2, :cond_0

    move v0, v6

    .line 0
    :goto_0
    if-eqz v0, :cond_1

    new-instance v0, Ljava/lang/IllegalThreadStateException;

    const-string v1, "can\'t in main thread call rpc ."

    invoke-direct {v0, v1}, Ljava/lang/IllegalThreadStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    move v0, v1

    .line 1000
    goto :goto_0

    .line 0
    :cond_1
    const-class v0, Lcom/alipay/mobile/framework/service/annotation/a;

    invoke-virtual {p1, v0}, Ljava/lang/reflect/Method;->getAnnotation(Ljava/lang/Class;)Ljava/lang/annotation/Annotation;

    move-result-object v0

    check-cast v0, Lcom/alipay/mobile/framework/service/annotation/a;

    const-class v2, Lcom/alipay/mobile/framework/service/annotation/b;

    invoke-virtual {p1, v2}, Ljava/lang/reflect/Method;->getAnnotation(Ljava/lang/Class;)Ljava/lang/annotation/Annotation;

    move-result-object v2

    if-eqz v2, :cond_2

    :goto_1
    invoke-virtual {p1}, Ljava/lang/reflect/Method;->getGenericReturnType()Ljava/lang/reflect/Type;

    move-result-object v7

    invoke-virtual {p1}, Ljava/lang/reflect/Method;->getAnnotations()[Ljava/lang/annotation/Annotation;

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->a:Ljava/lang/ThreadLocal;

    invoke-virtual {v1, v3}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v1, v3}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    if-nez v0, :cond_3

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "OperationType must be set."

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_2
    move v6, v1

    goto :goto_1

    :cond_3
    invoke-interface {v0}, Lcom/alipay/mobile/framework/service/annotation/a;->a()Ljava/lang/String;

    move-result-object v4

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->f:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    move-result v3

    :try_start_0
    iget-byte v0, p0, Lcom/alipay/android/phone/mrpc/core/ad;->e:B

    if-nez v0, :cond_5

    .line 3000
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;

    invoke-direct {v0, v3, v4, p2}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/e;-><init>(ILjava/lang/String;Ljava/lang/Object;)V

    .line 2000
    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v1}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_4

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    invoke-virtual {v1}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v1

    invoke-interface {v0, v1}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/f;->a(Ljava/lang/Object;)V

    :cond_4
    invoke-interface {v0}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/f;->a()[B

    move-result-object v5

    .line 4000
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/l;

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/ad;->g:Lcom/alipay/android/phone/mrpc/core/ab;

    .line 5000
    iget-object v1, v1, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    move-object v2, p1

    .line 4000
    invoke-direct/range {v0 .. v6}, Lcom/alipay/android/phone/mrpc/core/l;-><init>(Lcom/alipay/android/phone/mrpc/core/h;Ljava/lang/reflect/Method;ILjava/lang/String;[BZ)V

    .line 2000
    invoke-interface {v0}, Lcom/alipay/android/phone/mrpc/core/z;->a()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->b:Ljava/lang/ThreadLocal;

    const/4 v2, 0x0

    invoke-virtual {v1, v2}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V

    .line 6000
    new-instance v1, Lcom/alipay/android/phone/mrpc/core/gwprotocol/d;

    invoke-direct {v1, v7, v0}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/d;-><init>(Ljava/lang/reflect/Type;[B)V

    .line 0
    invoke-interface {v1}, Lcom/alipay/android/phone/mrpc/core/gwprotocol/c;->a()Ljava/lang/Object;

    move-result-object v0

    sget-object v1, Ljava/lang/Void;->TYPE:Ljava/lang/Class;

    if-eq v7, v1, :cond_5

    sget-object v1, Lcom/alipay/android/phone/mrpc/core/ad;->a:Ljava/lang/ThreadLocal;

    invoke-virtual {v1, v0}, Ljava/lang/ThreadLocal;->set(Ljava/lang/Object;)V
    :try_end_0
    .catch Lcom/alipay/android/phone/mrpc/core/RpcException; {:try_start_0 .. :try_end_0} :catch_0

    :cond_5
    sget-object v0, Lcom/alipay/android/phone/mrpc/core/ad;->a:Ljava/lang/ThreadLocal;

    invoke-virtual {v0}, Ljava/lang/ThreadLocal;->get()Ljava/lang/Object;

    move-result-object v0

    return-object v0

    :catch_0
    move-exception v0

    invoke-virtual {v0, v4}, Lcom/alipay/android/phone/mrpc/core/RpcException;->setOperationType(Ljava/lang/String;)V

    .line 7000
    throw v0
.end method
