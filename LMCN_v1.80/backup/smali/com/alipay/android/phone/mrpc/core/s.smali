.class public final Lcom/alipay/android/phone/mrpc/core/s;
.super Lcom/alipay/android/phone/mrpc/core/y;


# instance fields
.field a:J

.field b:J

.field c:Ljava/lang/String;

.field d:Lcom/alipay/android/phone/mrpc/core/q;

.field private g:I

.field private h:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lcom/alipay/android/phone/mrpc/core/q;ILjava/lang/String;[B)V
    .locals 0

    invoke-direct {p0}, Lcom/alipay/android/phone/mrpc/core/y;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/s;->d:Lcom/alipay/android/phone/mrpc/core/q;

    iput p2, p0, Lcom/alipay/android/phone/mrpc/core/s;->g:I

    iput-object p3, p0, Lcom/alipay/android/phone/mrpc/core/s;->h:Ljava/lang/String;

    iput-object p4, p0, Lcom/alipay/android/phone/mrpc/core/s;->e:[B

    return-void
.end method

.method private a(J)V
    .locals 1

    iput-wide p1, p0, Lcom/alipay/android/phone/mrpc/core/s;->a:J

    return-void
.end method

.method private a(Lcom/alipay/android/phone/mrpc/core/q;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/s;->d:Lcom/alipay/android/phone/mrpc/core/q;

    return-void
.end method

.method private b()I
    .locals 1

    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->g:I

    return v0
.end method

.method private b(J)V
    .locals 1

    iput-wide p1, p0, Lcom/alipay/android/phone/mrpc/core/s;->b:J

    return-void
.end method

.method private b(Ljava/lang/String;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/s;->c:Ljava/lang/String;

    return-void
.end method

.method private c()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->h:Ljava/lang/String;

    return-object v0
.end method

.method private d()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->c:Ljava/lang/String;

    return-object v0
.end method

.method private e()J
    .locals 2

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->a:J

    return-wide v0
.end method

.method private f()J
    .locals 2

    iget-wide v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->b:J

    return-wide v0
.end method

.method private g()Lcom/alipay/android/phone/mrpc/core/q;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/s;->d:Lcom/alipay/android/phone/mrpc/core/q;

    return-object v0
.end method
