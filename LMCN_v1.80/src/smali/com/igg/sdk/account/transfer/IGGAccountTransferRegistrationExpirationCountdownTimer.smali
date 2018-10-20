.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;
.super Ljava/lang/Object;
.source "IGGAccountTransferRegistrationExpirationCountdownTimer.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGAccountTransferRegistrationExpirationCountdownTimer"


# instance fields
.field private expiredAt:Ljava/util/Date;

.field listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;

.field private timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;


# direct methods
.method public constructor <init>(Ljava/util/Date;)V
    .locals 0
    .param p1, "expiredAt"    # Ljava/util/Date;

    .prologue
    .line 19
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 20
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->expiredAt:Ljava/util/Date;

    .line 21
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;)Ljava/util/Date;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    .prologue
    .line 12
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->expiredAt:Ljava/util/Date;

    return-object v0
.end method


# virtual methods
.method public start(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;)V
    .locals 10
    .param p1, "listener"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;

    .prologue
    .line 24
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;

    .line 25
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->expiredAt:Ljava/util/Date;

    if-nez v0, :cond_0

    .line 40
    :goto_0
    return-void

    .line 29
    :cond_0
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    .line 30
    .local v8, "currentMills":J
    new-instance v6, Ljava/util/Date;

    invoke-direct {v6, v8, v9}, Ljava/util/Date;-><init>(J)V

    .line 31
    .local v6, "currentDate":Ljava/util/Date;
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->expiredAt:Ljava/util/Date;

    invoke-virtual {v0, v6}, Ljava/util/Date;->before(Ljava/util/Date;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 32
    invoke-interface {p1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;->expired()V

    goto :goto_0

    .line 36
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->expiredAt:Ljava/util/Date;

    invoke-virtual {v0}, Ljava/util/Date;->getTime()J

    move-result-wide v0

    invoke-virtual {v6}, Ljava/util/Date;->getTime()J

    move-result-wide v4

    sub-long v2, v0, v4

    .line 38
    .local v2, "millisInFuture":J
    new-instance v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    const-wide/16 v4, 0x3e8

    move-object v1, p0

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;-><init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;JJ)V

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    .line 39
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    invoke-virtual {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->start()Landroid/os/CountDownTimer;

    goto :goto_0
.end method

.method public stop()V
    .locals 2

    .prologue
    .line 72
    monitor-enter p0

    .line 73
    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    if-eqz v0, :cond_0

    .line 74
    const-string v0, "IGGAccountTransferRegistrationExpirationCountdownTimer"

    const-string v1, "timer.cancel()"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 75
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    invoke-virtual {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->cancel()V

    .line 76
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->timer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;

    .line 78
    :cond_0
    monitor-exit p0

    .line 79
    return-void

    .line 78
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method
