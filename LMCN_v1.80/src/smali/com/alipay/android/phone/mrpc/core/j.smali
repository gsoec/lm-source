.class final Lcom/alipay/android/phone/mrpc/core/j;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/alipay/android/phone/mrpc/core/h;


# instance fields
.field final synthetic a:Lcom/alipay/android/phone/mrpc/core/ae;

.field final synthetic b:Lcom/alipay/android/phone/mrpc/core/i;


# direct methods
.method constructor <init>(Lcom/alipay/android/phone/mrpc/core/i;Lcom/alipay/android/phone/mrpc/core/ae;)V
    .locals 0

    iput-object p1, p0, Lcom/alipay/android/phone/mrpc/core/j;->b:Lcom/alipay/android/phone/mrpc/core/i;

    iput-object p2, p0, Lcom/alipay/android/phone/mrpc/core/j;->a:Lcom/alipay/android/phone/mrpc/core/ae;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final a()Ljava/lang/String;
    .locals 1

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/j;->a:Lcom/alipay/android/phone/mrpc/core/ae;

    .line 1000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/ae;->a:Ljava/lang/String;

    .line 0
    return-object v0
.end method

.method public final b()Lcom/alipay/android/phone/mrpc/core/ag;
    .locals 1

    .prologue
    .line 0
    .line 2000
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/j;->b:Lcom/alipay/android/phone/mrpc/core/i;

    .line 3000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/i;->a:Landroid/content/Context;

    .line 2000
    invoke-virtual {v0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    .line 0
    invoke-static {v0}, Lcom/alipay/android/phone/mrpc/core/n;->a(Landroid/content/Context;)Lcom/alipay/android/phone/mrpc/core/n;

    move-result-object v0

    return-object v0
.end method

.method public final c()Lcom/alipay/android/phone/mrpc/core/ae;
    .locals 1

    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/j;->a:Lcom/alipay/android/phone/mrpc/core/ae;

    return-object v0
.end method

.method public final d()Landroid/content/Context;
    .locals 1

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/j;->b:Lcom/alipay/android/phone/mrpc/core/i;

    .line 4000
    iget-object v0, v0, Lcom/alipay/android/phone/mrpc/core/i;->a:Landroid/content/Context;

    .line 0
    invoke-virtual {v0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    return-object v0
.end method

.method public final e()Z
    .locals 1

    .prologue
    .line 0
    iget-object v0, p0, Lcom/alipay/android/phone/mrpc/core/j;->a:Lcom/alipay/android/phone/mrpc/core/ae;

    .line 5000
    iget-boolean v0, v0, Lcom/alipay/android/phone/mrpc/core/ae;->c:Z

    .line 0
    return v0
.end method
