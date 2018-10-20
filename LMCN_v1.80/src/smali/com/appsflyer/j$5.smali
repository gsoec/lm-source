.class final Lcom/appsflyer/j$5;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/j;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private synthetic ˊ:Lcom/appsflyer/j;


# direct methods
.method constructor <init>(Lcom/appsflyer/j;)V
    .locals 0

    .prologue
    .line 62
    iput-object p1, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 3

    .prologue
    .line 65
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-object v1, v0, Lcom/appsflyer/j;->ˊ:Ljava/lang/Object;

    monitor-enter v1

    .line 66
    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-boolean v0, v0, Lcom/appsflyer/j;->ॱ:Z

    if-eqz v0, :cond_0

    .line 68
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-object v0, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v2, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-object v2, v2, Lcom/appsflyer/j;->ˏ:Ljava/lang/Runnable;

    invoke-virtual {v0, v2}, Landroid/os/Handler;->removeCallbacks(Ljava/lang/Runnable;)V

    .line 69
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-object v0, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v2, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    iget-object v2, v2, Lcom/appsflyer/j;->ˎ:Ljava/lang/Runnable;

    invoke-virtual {v0, v2}, Landroid/os/Handler;->removeCallbacks(Ljava/lang/Runnable;)V

    .line 71
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    invoke-virtual {v0}, Lcom/appsflyer/j;->ॱ()V

    .line 72
    iget-object v0, p0, Lcom/appsflyer/j$5;->ˊ:Lcom/appsflyer/j;

    const/4 v2, 0x0

    iput-boolean v2, v0, Lcom/appsflyer/j;->ॱ:Z

    .line 74
    :cond_0
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method
