.class public Lcom/igg/sdk/IGGDeviceStorage;
.super Ljava/lang/Object;
.source "IGGDeviceStorage.java"


# static fields
.field public static final storageName:Ljava/lang/String; = "IGGSDK_deviceUID_file"


# instance fields
.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    if-nez p1, :cond_0

    .line 23
    const-string v0, "IGGDeviceStorage"

    const-string v1, "context\uff1a null"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 26
    :cond_0
    new-instance v0, Lcom/igg/util/LocalStorage;

    const-string v1, "IGGSDK_deviceUID_file"

    invoke-direct {v0, p1, v1}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    .line 27
    return-void
.end method


# virtual methods
.method public currentDeviceUID()Ljava/lang/String;
    .locals 4

    .prologue
    .line 35
    const-string v0, "IGGDeviceStorage"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Read current storage DeviceUID\uff1a "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v3, "deviceUID"

    invoke-virtual {v2, v3}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 36
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "deviceUID"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getEmulatorFlag()Z
    .locals 2

    .prologue
    .line 116
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "EmulatorFlag"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public getIncreasedDeviceUID()Ljava/lang/String;
    .locals 2

    .prologue
    .line 60
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "IncreasedDeviceUID"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getUUID()Ljava/lang/String;
    .locals 2

    .prologue
    .line 97
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "UUID"

    invoke-virtual {v0, v1}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public declared-synchronized setDeviceUID(Ljava/lang/String;)V
    .locals 3
    .param p1, "deviceUID"    # Ljava/lang/String;

    .prologue
    .line 45
    monitor-enter p0

    if-nez p1, :cond_0

    .line 46
    :try_start_0
    const-string p1, ""

    .line 49
    :cond_0
    const-string v0, "IGGDeviceStorage"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Storage setDeviceUID\uff1a "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 50
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "deviceUID"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 51
    monitor-exit p0

    return-void

    .line 45
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setEmulatorFlag(Z)V
    .locals 3
    .param p1, "Flag"    # Z

    .prologue
    .line 106
    monitor-enter p0

    :try_start_0
    const-string v0, "IGGDeviceStorage"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Storage setEmulatorFlag\uff1a "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 107
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "EmulatorFlag"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 108
    monitor-exit p0

    return-void

    .line 106
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setIncreasedDeviceUID(Ljava/lang/String;)V
    .locals 2
    .param p1, "deviceUID"    # Ljava/lang/String;

    .prologue
    .line 69
    monitor-enter p0

    if-nez p1, :cond_0

    .line 74
    :goto_0
    monitor-exit p0

    return-void

    .line 73
    :cond_0
    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "IncreasedDeviceUID"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_0

    .line 69
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized setUUID(Ljava/lang/String;)V
    .locals 3
    .param p1, "uuid"    # Ljava/lang/String;

    .prologue
    .line 82
    monitor-enter p0

    if-nez p1, :cond_0

    .line 83
    :try_start_0
    const-string p1, ""

    .line 86
    :cond_0
    const-string v0, "IGGDeviceStorage"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Storage uuid\uff1a "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 87
    iget-object v0, p0, Lcom/igg/sdk/IGGDeviceStorage;->storage:Lcom/igg/util/LocalStorage;

    const-string v1, "UUID"

    invoke-virtual {v0, v1, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 88
    monitor-exit p0

    return-void

    .line 82
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
