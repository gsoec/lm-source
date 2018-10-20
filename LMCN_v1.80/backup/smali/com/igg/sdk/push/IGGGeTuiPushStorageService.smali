.class public Lcom/igg/sdk/push/IGGGeTuiPushStorageService;
.super Ljava/lang/Object;
.source "IGGGeTuiPushStorageService.java"


# static fields
.field public static final storagePushName:Ljava/lang/String; = "getui_push_message"


# instance fields
.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 26
    new-instance v0, Lcom/igg/util/LocalStorage;

    const-string v1, "getui_push_message"

    invoke-direct {v0, p1, v1}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    .line 27
    return-void
.end method


# virtual methods
.method public currentGameId()Ljava/lang/String;
    .locals 2

    .prologue
    .line 73
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "gameId"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public currentIGGId()Ljava/lang/String;
    .locals 2

    .prologue
    .line 33
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "iggId"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public currentRegId()Ljava/lang/String;
    .locals 2

    .prologue
    .line 53
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "regId"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public declared-synchronized setGameId(Ljava/lang/String;)V
    .locals 2
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 82
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "gameId"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 83
    monitor-exit p0

    return-void

    .line 82
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setIGGId(Ljava/lang/String;)V
    .locals 2
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 42
    monitor-enter p0

    if-nez p1, :cond_0

    .line 43
    :try_start_0
    const-string p1, ""

    .line 46
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "iggId"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 47
    monitor-exit p0

    return-void

    .line 42
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setRegId(Ljava/lang/String;)V
    .locals 2
    .param p1, "regId"    # Ljava/lang/String;

    .prologue
    .line 62
    monitor-enter p0

    if-nez p1, :cond_0

    .line 63
    :try_start_0
    const-string p1, ""

    .line 66
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGeTuiPushStorageService;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "regId"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 67
    monitor-exit p0

    return-void

    .line 62
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
