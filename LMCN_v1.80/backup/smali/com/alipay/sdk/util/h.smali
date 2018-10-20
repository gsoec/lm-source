.class final Lcom/alipay/sdk/util/h;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field final synthetic a:Landroid/content/Intent;

.field final synthetic b:Lcom/alipay/sdk/util/g;


# direct methods
.method constructor <init>(Lcom/alipay/sdk/util/g;Landroid/content/Intent;)V
    .locals 0

    .prologue
    .line 210
    iput-object p1, p0, Lcom/alipay/sdk/util/h;->b:Lcom/alipay/sdk/util/g;

    iput-object p2, p0, Lcom/alipay/sdk/util/h;->a:Landroid/content/Intent;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .prologue
    .line 213
    iget-object v0, p0, Lcom/alipay/sdk/util/h;->b:Lcom/alipay/sdk/util/g;

    iget-object v0, v0, Lcom/alipay/sdk/util/g;->a:Lcom/alipay/sdk/util/e;

    invoke-static {v0}, Lcom/alipay/sdk/util/e;->b(Lcom/alipay/sdk/util/e;)Landroid/app/Activity;

    move-result-object v0

    iget-object v1, p0, Lcom/alipay/sdk/util/h;->a:Landroid/content/Intent;

    invoke-virtual {v0, v1}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V

    .line 214
    return-void
.end method
