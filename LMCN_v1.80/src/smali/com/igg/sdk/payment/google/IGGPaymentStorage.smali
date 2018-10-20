.class Lcom/igg/sdk/payment/google/IGGPaymentStorage;
.super Ljava/lang/Object;
.source "IGGPaymentStorage.java"


# static fields
.field public static final storagePushName:Ljava/lang/String; = "payment_message"


# instance fields
.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 21
    new-instance v0, Lcom/igg/util/LocalStorage;

    const-string v1, "payment_message"

    invoke-direct {v0, p1, v1}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentStorage;->storage:Lcom/igg/util/LocalStorage;

    .line 22
    return-void
.end method


# virtual methods
.method public currentRetryInterval()I
    .locals 2

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "retry_interval"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readInt(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    return v0
.end method

.method public declared-synchronized setRetryInterval(I)V
    .locals 3
    .param p1, "retryInterval"    # I

    .prologue
    .line 29
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "retry_interval"

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/util/LocalStorage;->writeInt(Ljava/lang/String;Ljava/lang/Integer;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 30
    monitor-exit p0

    return-void

    .line 29
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
