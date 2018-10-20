.class public final Lcom/alipay/android/phone/mrpc/core/ab;
.super Ljava/lang/Object;


# instance fields
.field a:Lcom/alipay/android/phone/mrpc/core/h;

.field b:Lcom/alipay/android/phone/mrpc/core/ad;


# direct methods
.method public constructor <init>(Lcom/alipay/android/phone/mrpc/core/h;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    new-instance v0, Lcom/alipay/android/phone/mrpc/core/ad;

    invoke-direct {v0, p0}, Lcom/alipay/android/phone/mrpc/core/ad;-><init>(Lcom/alipay/android/phone/mrpc/core/ab;)V

    iput-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ab;->b:Lcom/alipay/android/phone/mrpc/core/ad;

    return-void
.end method

.method private a()Lcom/alipay/android/phone/mrpc/core/h;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    return-object v0
.end method

.method private a(Ljava/lang/Class;)Ljava/lang/Object;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Ljava/lang/Class",
            "<TT;>;)TT;"
        }
    .end annotation

    invoke-virtual {p1}, Ljava/lang/Class;->getClassLoader()Ljava/lang/ClassLoader;

    move-result-object v0

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/Class;

    const/4 v2, 0x0

    aput-object p1, v1, v2

    new-instance v2, Lcom/alipay/android/phone/mrpc/core/ac;

    iget-object v3, p0, Lcom/alipay/android/phone/mrpc/core/ab;->a:Lcom/alipay/android/phone/mrpc/core/h;

    iget-object v4, p0, Lcom/alipay/android/phone/mrpc/core/ab;->b:Lcom/alipay/android/phone/mrpc/core/ad;

    invoke-direct {v2, v3, p1, v4}, Lcom/alipay/android/phone/mrpc/core/ac;-><init>(Lcom/alipay/android/phone/mrpc/core/h;Ljava/lang/Class;Lcom/alipay/android/phone/mrpc/core/ad;)V

    invoke-static {v0, v1, v2}, Ljava/lang/reflect/Proxy;->newProxyInstance(Ljava/lang/ClassLoader;[Ljava/lang/Class;Ljava/lang/reflect/InvocationHandler;)Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method
