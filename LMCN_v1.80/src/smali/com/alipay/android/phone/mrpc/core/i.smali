.class public final Lcom/alipay/android/phone/mrpc/core/i;
.super Lcom/alipay/android/phone/mrpc/core/aa;


# instance fields
.field a:Landroid/content/Context;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 0

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/aa;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/i;->a:Landroid/content/Context;

    return-void
.end method

.method private static synthetic a(Lcom/alipay/android/phone/mrpc/core/i;)Landroid/content/Context;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/i;->a:Landroid/content/Context;

    return-object v0
.end method

.method private a(Lcom/alipay/android/phone/mrpc/core/ae;)Lcom/alipay/android/phone/mrpc/core/h;
    .locals 1

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/j;

    invoke-direct {v0, p0, p1}, Lcom/alipay/android/phone/mrpc/core/j;-><init>(Lcom/alipay/android/phone/mrpc/core/i;Lcom/alipay/android/phone/mrpc/core/ae;)V

    return-object v0
.end method


# virtual methods
.method public final a(Ljava/lang/Class;Lcom/alipay/android/phone/mrpc/core/ae;)Ljava/lang/Object;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/lang/Class",
            "<TT;>;",
            "Lcom/alipay/android/phone/mrpc/core/ae;",
            ")TT;"
        }
    .end annotation

    .prologue
    .line 0
    new-instance v0, Lcom/alipay/android/phone/mrpc/core/ab;

    .line 1000
    new-instance v1, Lcom/alipay/android/phone/mrpc/core/j;

    invoke-direct {v1, p0, p2}, Lcom/alipay/android/phone/mrpc/core/j;-><init>(Lcom/alipay/android/phone/mrpc/core/i;Lcom/alipay/android/phone/mrpc/core/ae;)V

    .line 0
    invoke-direct {v0, v1}, Lcom/alipay/android/phone/mrpc/core/ab;-><init>(Lcom/alipay/android/phone/mrpc/core/h;)V

    .line 2000
    invoke-virtual {p1}, Ljava/lang/Class;->getClassLoader()Ljava/lang/ClassLoader;

    move-result-object v1

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/Class;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    new-instance v3, Lcom/alipay/android/phone/mrpc/core/ac;

    iget-object v4, v0, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/ab;->b:Lcom/alipay/android/phone/mrpc/core/ad;

    invoke-direct {v3, v4, p1, v0}, Lcom/alipay/android/phone/mrpc/core/ac;-><init>(Lcom/alipay/android/phone/mrpc/core/h;Ljava/lang/Class;Lcom/alipay/android/phone/mrpc/core/ad;)V

    invoke-static {v1, v2, v3}, Ljava/lang/reflect/Proxy;->newProxyInstance(Ljava/lang/ClassLoader;[Ljava/lang/Class;Ljava/lang/reflect/InvocationHandler;)Ljava/lang/Object;

    move-result-object v0

    .line 0
    return-object v0
.end method
