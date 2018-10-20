.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
.super Ljava/lang/Object;
.source "IGGAccountTransferRegistration.java"


# instance fields
.field private accountProfile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

.field private countdownTimer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

.field private expiredAt:Ljava/util/Date;

.field private transferToken:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V
    .locals 0
    .param p1, "transferToken"    # Ljava/lang/String;
    .param p2, "expiredAt"    # Ljava/util/Date;
    .param p3, "accountProfile"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    .prologue
    .line 15
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 16
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    .line 17
    iput-object p2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->expiredAt:Ljava/util/Date;

    .line 18
    iput-object p3, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->accountProfile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    .line 19
    return-void
.end method


# virtual methods
.method public accountProfile()Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;
    .locals 1

    .prologue
    .line 40
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->accountProfile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    return-object v0
.end method

.method public getCountdownTimer()Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;
    .locals 2

    .prologue
    .line 49
    new-instance v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    iget-object v1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->expiredAt:Ljava/util/Date;

    invoke-direct {v0, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;-><init>(Ljava/util/Date;)V

    iput-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->countdownTimer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    .line 50
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->countdownTimer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    return-object v0
.end method

.method public getTransferToken()Ljava/lang/String;
    .locals 1

    .prologue
    .line 54
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    return-object v0
.end method

.method public readableTransferToken()Ljava/lang/String;
    .locals 5

    .prologue
    const/16 v4, 0x8

    const/4 v3, 0x4

    .line 27
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    if-eqz v0, :cond_0

    .line 28
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    const/4 v2, 0x0

    invoke-virtual {v1, v2, v3}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, " "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    invoke-virtual {v1, v3, v4}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, " "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->transferToken:Ljava/lang/String;

    const/16 v2, 0xc

    invoke-virtual {v1, v4, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 31
    :goto_0
    return-object v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public stop()V
    .locals 1

    .prologue
    .line 61
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->countdownTimer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    if-eqz v0, :cond_0

    .line 62
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->countdownTimer:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;

    invoke-virtual {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationExpirationCountdownTimer;->stop()V

    .line 64
    :cond_0
    return-void
.end method
