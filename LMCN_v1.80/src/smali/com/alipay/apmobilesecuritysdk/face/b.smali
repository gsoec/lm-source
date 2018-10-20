.class final Lcom/alipay/apmobilesecuritysdk/face/b;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field final synthetic a:Ljava/util/Map;

.field final synthetic b:Lcom/alipay/apmobilesecuritysdk/face/a$a;

.field final synthetic c:Lcom/alipay/apmobilesecuritysdk/face/a;


# direct methods
.method constructor <init>(Lcom/alipay/apmobilesecuritysdk/face/a;Ljava/util/Map;)V
    .locals 1

    iput-object p1, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->c:Lcom/alipay/apmobilesecuritysdk/face/a;

    iput-object p2, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->a:Ljava/util/Map;

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->b:Lcom/alipay/apmobilesecuritysdk/face/a$a;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    new-instance v0, Lcom/alipay/apmobilesecuritysdk/a/a;

    iget-object v1, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->c:Lcom/alipay/apmobilesecuritysdk/face/a;

    invoke-static {v1}, Lcom/alipay/apmobilesecuritysdk/face/a;->a(Lcom/alipay/apmobilesecuritysdk/face/a;)Landroid/content/Context;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/alipay/apmobilesecuritysdk/a/a;-><init>(Landroid/content/Context;)V

    iget-object v1, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->a:Ljava/util/Map;

    invoke-virtual {v0, v1}, Lcom/alipay/apmobilesecuritysdk/a/a;->a(Ljava/util/Map;)I

    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->b:Lcom/alipay/apmobilesecuritysdk/face/a$a;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/alipay/apmobilesecuritysdk/face/b;->c:Lcom/alipay/apmobilesecuritysdk/face/a;

    invoke-virtual {v0}, Lcom/alipay/apmobilesecuritysdk/face/a;->a()Lcom/alipay/apmobilesecuritysdk/face/a$b;

    :cond_0
    return-void
.end method
