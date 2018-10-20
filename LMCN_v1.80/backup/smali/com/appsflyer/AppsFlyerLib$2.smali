.class final Lcom/appsflyer/AppsFlyerLib$2;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/q$c;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/appsflyer/AppsFlyerLib;->ॱ(Landroid/app/Application;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private synthetic ˊ:Lcom/appsflyer/AppsFlyerLib;


# direct methods
.method constructor <init>(Lcom/appsflyer/AppsFlyerLib;)V
    .locals 0

    .prologue
    .line 422
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$2;->ˊ:Lcom/appsflyer/AppsFlyerLib;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final ˋ(Ljava/lang/ref/WeakReference;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 432
    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-static {v0}, Lcom/appsflyer/b;->ˏ(Landroid/content/Context;)V

    .line 433
    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-static {v0}, Lcom/appsflyer/j;->ˊ(Landroid/content/Context;)Lcom/appsflyer/j;

    move-result-object v0

    .line 6137
    iget-object v1, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v0, v0, Lcom/appsflyer/j;->ʽ:Ljava/lang/Runnable;

    invoke-virtual {v1, v0}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 434
    return-void
.end method

.method public final ॱ(Landroid/app/Activity;)V
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 425
    const/4 v0, 0x2

    invoke-static {p1}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Landroid/content/SharedPreferences;)I

    move-result v1

    if-le v0, v1, :cond_0

    .line 426
    invoke-static {p1}, Lcom/appsflyer/j;->ˊ(Landroid/content/Context;)Lcom/appsflyer/j;

    move-result-object v0

    .line 4128
    iget-object v1, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v2, v0, Lcom/appsflyer/j;->ʽ:Ljava/lang/Runnable;

    invoke-virtual {v1, v2}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 4130
    iget-object v1, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v0, v0, Lcom/appsflyer/j;->ˏ:Ljava/lang/Runnable;

    invoke-virtual {v1, v0}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 6015
    :cond_0
    const-string v0, "onBecameForeground"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 6016
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerLib;->ˏ()V

    .line 6017
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-virtual {v0, p1, v3, v3}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 6019
    invoke-static {}, Lcom/appsflyer/AFLogger;->resetDeltaTime()V

    .line 429
    return-void
.end method
