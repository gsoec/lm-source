.class public Lcom/igg/sdk/push/IGGPushStorageService;
.super Ljava/lang/Object;
.source "IGGPushStorageService.java"


# static fields
.field public static final storagePushName:Ljava/lang/String; = "igg_push_storage_message"


# instance fields
.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 24
    new-instance v0, Lcom/igg/util/LocalStorage;

    const-string v1, "getui_push_message"

    invoke-direct {v0, p1, v1}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    .line 25
    return-void
.end method


# virtual methods
.method public isCustomHandleMessage()Z
    .locals 2

    .prologue
    .line 31
    iget-object v0, p0, Lcom/igg/sdk/push/IGGPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "pushMessageHandleFlag"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public declared-synchronized setCustomHandleMessageFlag(Z)V
    .locals 2
    .param p1, "pushMessageHandleFlag"    # Z

    .prologue
    .line 40
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "pushMessageHandleFlag"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 41
    monitor-exit p0

    return-void

    .line 40
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
