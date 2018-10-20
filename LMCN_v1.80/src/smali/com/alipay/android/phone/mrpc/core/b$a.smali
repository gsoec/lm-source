.class final Lcom/alipay/android/phone/mrpc/core/b$a;
.super Ljava/lang/Object;

# interfaces
.implements Lorg/apache/http/HttpRequestInterceptor;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/alipay/android/phone/mrpc/core/b;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "a"
.end annotation


# instance fields
.field final synthetic a:Lcom/alipay/android/phone/mrpc/core/b;


# direct methods
.method private constructor <init>(Lcom/alipay/android/phone/mrpc/core/b;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/b$a;->a:Lcom/alipay/android/phone/mrpc/core/b;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method synthetic constructor <init>(Lcom/alipay/android/phone/mrpc/core/b;B)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/alipay/android/phone/mrpc/core/b$a;-><init>(Lcom/alipay/android/phone/mrpc/core/b;)V

    return-void
.end method


# virtual methods
.method public final process(Lorg/apache/http/HttpRequest;Lorg/apache/http/protocol/HttpContext;)V
    .locals 3

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/b$a;->a:Lcom/alipay/android/phone/mrpc/core/b;

    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/b;->a(Lcom/alipay/android/phone/mrpc/core/b;)Lcom/alipay/android/phone/mrpc/core/b$b;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 2000
    iget-object v1, v0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    iget v2, v0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    invoke-static {v1, v2}, Landroid/util/Log;->isLoggable(Ljava/lang/String;I)Z

    move-result v1

    .line 0
    if-eqz v1, :cond_0

    instance-of v1, p1, Lorg/apache/http/client/methods/HttpUriRequest;

    if-eqz v1, :cond_0

    check-cast p1, Lorg/apache/http/client/methods/HttpUriRequest;

    invoke-static {p1}, Lcom/alipay/android/phone/mrpc/core/b;->a(Lorg/apache/http/client/methods/HttpUriRequest;)Ljava/lang/String;

    move-result-object v1

    .line 4000
    iget v2, v0, Lcom/alipay/android/phone/mrpc/core/b$b;->b:I

    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/b$b;->a:Ljava/lang/String;

    invoke-static {v2, v0, v1}, Landroid/util/Log;->println(ILjava/lang/String;Ljava/lang/String;)I

    .line 0
    :cond_0
    return-void
.end method
