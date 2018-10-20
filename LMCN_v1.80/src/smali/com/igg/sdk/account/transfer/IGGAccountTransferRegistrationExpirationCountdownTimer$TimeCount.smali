.class Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;
.super Landroid/os/CountDownTimer;
.source "IGGAccountTransferRegistrationExpirationCountdownTimer.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "TimeCount"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;JJ)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;
    .param p2, "millisInFuture"    # J
    .param p4, "countDownInterval"    # J

    .prologue
    .line 44
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    .line 46
    invoke-direct {p0, p2, p3, p4, p5}, Landroid/os/CountDownTimer;-><init>(JJ)V

    .line 47
    return-void
.end method


# virtual methods
.method public onFinish()V
    .locals 1

    .prologue
    .line 52
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    invoke-virtual {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->stop()V

    .line 54
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;

    invoke-interface {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;->expired()V

    .line 55
    return-void
.end method

.method public onTick(J)V
    .locals 8
    .param p1, "millisUntilFinished"    # J

    .prologue
    .line 59
    const-string v4, "IGGAccountTransferRegistrationExpirationCountdownTimer"

    const-string v5, "timer run......"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 61
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 62
    .local v2, "currentMills":J
    new-instance v0, Ljava/util/Date;

    invoke-direct {v0, v2, v3}, Ljava/util/Date;-><init>(J)V

    .line 63
    .local v0, "currentDate":Ljava/util/Date;
    iget-object v4, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    invoke-static {v4}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->access$000(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;)Ljava/util/Date;

    move-result-object v4

    invoke-virtual {v4}, Ljava/util/Date;->getTime()J

    move-result-wide v4

    invoke-virtual {v0}, Ljava/util/Date;->getTime()J

    move-result-wide v6

    sub-long/2addr v4, v6

    long-to-int v4, v4

    div-int/lit16 v1, v4, 0x3e8

    .line 64
    .local v1, "s":I
    iget-object v4, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer$TimeCount;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    iget-object v4, v4, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;

    invoke-interface {v4, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimerListener;->tick(I)V

    .line 65
    return-void
.end method
