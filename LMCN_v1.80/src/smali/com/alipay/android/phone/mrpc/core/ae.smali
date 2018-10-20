.class public final Lcom/alipay/android/phone/mrpc/core/ae;
.super Ljava/lang/Object;


# instance fields
.field public a:Ljava/lang/String;

.field b:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lorg/apache/http/Header;",
            ">;"
        }
    .end annotation
.end field

.field c:Z


# direct methods
.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private a()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ae;->a:Ljava/lang/String;

    return-object v0
.end method

.method private a(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/ae;->a:Ljava/lang/String;

    return-void
.end method

.method private a(Ljava/util/List;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lorg/apache/http/Header;",
            ">;)V"
        }
    .end annotation

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/ae;->b:Ljava/util/List;

    return-void
.end method

.method private a(Z)V
    .locals 0

    iput-boolean p1, p0, Lcom/alipay/android/phone/mrpc/core/ae;->c:Z

    return-void
.end method

.method private b()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List",
            "<",
            "Lorg/apache/http/Header;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/ae;->b:Ljava/util/List;

    return-object v0
.end method

.method private c()Z
    .locals 1

    iget-boolean v0, p0, Lcom/alipay/android/phone/mrpc/core/ae;->c:Z

    return v0
.end method
