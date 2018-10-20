.class final Lcom/appsflyer/e;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/e$d;,
        Lcom/appsflyer/e$a;
    }
.end annotation


# instance fields
.field private ॱ:Landroid/content/IntentFilter;


# direct methods
.method constructor <init>()V
    .locals 2

    .prologue
    .line 17
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 18
    new-instance v0, Landroid/content/IntentFilter;

    const-string v1, "android.intent.action.BATTERY_CHANGED"

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/appsflyer/e;->ॱ:Landroid/content/IntentFilter;

    .line 19
    return-void
.end method


# virtual methods
.method final ˏ(Landroid/content/Context;)Lcom/appsflyer/e$a;
    .locals 7
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .prologue
    const/4 v1, 0x0

    const/4 v6, -0x1

    .line 36
    .line 37
    const/4 v0, 0x0

    .line 39
    const/4 v2, 0x0

    :try_start_0
    iget-object v3, p0, Lcom/appsflyer/e;->ॱ:Landroid/content/IntentFilter;

    invoke-virtual {p1, v2, v3}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    move-result-object v3

    .line 41
    if-eqz v3, :cond_0

    .line 43
    const/4 v2, 0x2

    const-string v4, "status"

    const/4 v5, -0x1

    .line 44
    invoke-virtual {v3, v4, v5}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result v4

    if-ne v2, v4, :cond_1

    const/4 v2, 0x1

    .line 45
    :goto_0
    if-eqz v2, :cond_2

    .line 47
    const-string v2, "plugged"

    const/4 v4, -0x1

    invoke-virtual {v3, v2, v4}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result v2

    .line 48
    packed-switch v2, :pswitch_data_0

    .line 59
    :pswitch_0
    const-string v1, "other"

    .line 66
    :goto_1
    const-string v2, "level"

    const/4 v4, -0x1

    invoke-virtual {v3, v2, v4}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result v2

    .line 67
    const-string v4, "scale"

    const/4 v5, -0x1

    invoke-virtual {v3, v4, v5}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result v3

    .line 69
    if-eq v6, v2, :cond_0

    if-eq v6, v3, :cond_0

    .line 70
    const/high16 v0, 0x42c80000    # 100.0f

    int-to-float v2, v2

    mul-float/2addr v0, v2

    int-to-float v2, v3

    div-float/2addr v0, v2

    .line 76
    :cond_0
    :goto_2
    new-instance v2, Lcom/appsflyer/e$a;

    invoke-direct {v2, v0, v1}, Lcom/appsflyer/e$a;-><init>(FLjava/lang/String;)V

    return-object v2

    .line 44
    :cond_1
    const/4 v2, 0x0

    goto :goto_0

    .line 50
    :pswitch_1
    :try_start_1
    const-string v1, "usb"

    goto :goto_1

    .line 53
    :pswitch_2
    const-string v1, "ac"

    goto :goto_1

    .line 56
    :pswitch_3
    const-string v1, "wireless"

    goto :goto_1

    .line 62
    :cond_2
    const-string v1, "no"
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1

    :catch_0
    move-exception v2

    goto :goto_2

    .line 48
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_2
        :pswitch_1
        :pswitch_0
        :pswitch_3
    .end packed-switch
.end method
