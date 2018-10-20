.class final Lcom/alipay/android/phone/mrpc/core/b$b;
.super Ljava/lang/Object;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/alipay/android/phone/mrpc/core/b;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "b"
.end annotation


# instance fields
.field final a:Ljava/lang/String;

.field final b:I


# direct methods
.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    iput p2, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    return-void
.end method

.method synthetic constructor <init>(Ljava/lang/String;IB)V
    .locals 0

    invoke-direct {p0, p1, p2}, Lcom/alipay/android/phone/mrpc/core/b$b;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method private static synthetic a(Lcom/alipay/android/phone/mrpc/core/b$b;Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 0
    .line 2000
    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Landroid/util/Log;->println(ILjava/lang/String;Ljava/lang/String;)I

    .line 0
    return-void
.end method

.method private a(Ljava/lang/String;)V
    .locals 2

    iget v0, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    iget-object v1, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    invoke-static {v0, v1, p1}, Landroid/util/Log;->println(ILjava/lang/String;Ljava/lang/String;)I

    return-void
.end method

.method private a()Z
    .locals 2

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    invoke-static {v0, v1}, Landroid/util/Log;->isLoggable(Ljava/lang/String;I)Z

    move-result v0

    return v0
.end method

.method private static synthetic a(Lcom/alipay/android/phone/mrpc/core/b$b;)Z
    .locals 2

    .prologue
    .line 0
    .line 1000
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    iget v1, p0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    invoke-static {v0, v1}, Landroid/util/Log;->isLoggable(Ljava/lang/String;I)Z

    move-result v0

    .line 0
    return v0
.end method
