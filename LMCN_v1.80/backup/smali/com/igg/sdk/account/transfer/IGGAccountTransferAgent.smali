.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;
.super Ljava/lang/Object;
.source "IGGAccountTransferAgent.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;,
        Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGAccountTransferAgent"


# instance fields
.field gameId:Ljava/lang/String;

.field transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->gameId:Ljava/lang/String;

    .line 46
    return-void
.end method


# virtual methods
.method public registerForTransfer(Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;)V
    .locals 4
    .param p1, "transferor"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;
    .param p2, "profile"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;
    .param p3, "listener"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    .prologue
    .line 58
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 59
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "m_game_id"

    iget-object v2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 60
    const-string v1, "IGGAccountTransferAgent"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "registerForTransfer m_game_id:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->gameId:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 61
    const-string v1, "access_key"

    invoke-virtual {p1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->getAccessKey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 62
    const-string v1, "IGGAccountTransferAgent"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "registerForTransfer access_key:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->getAccessKey()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 63
    const-string v1, "m_transfer_data"

    invoke-virtual {p2}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->toJSONString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 64
    const-string v1, "IGGAccountTransferAgent"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "registerForTransfer m_transfer_data:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p2}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->toJSONString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 66
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "/public/getTransferKey"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;

    invoke-direct {v3, p0, p3, p2}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;-><init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 104
    return-void
.end method

.method public registrationOf(Ljava/lang/String;Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;)V
    .locals 4
    .param p1, "transferToken"    # Ljava/lang/String;
    .param p2, "transferor"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;
    .param p3, "listener"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    .prologue
    .line 125
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 126
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "m_game_id"

    iget-object v2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 127
    const-string v1, "access_key"

    invoke-virtual {p2}, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->getAccessKey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 128
    const-string v1, "m_key"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 129
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "public/getTransferData"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;

    invoke-direct {v3, p0, p3, p1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;-><init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;Ljava/lang/String;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 180
    return-void
.end method

.method public stop()V
    .locals 1

    .prologue
    .line 110
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    if-eqz v0, :cond_0

    .line 111
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    invoke-virtual {v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->stop()V

    .line 113
    :cond_0
    return-void
.end method

.method public transfer(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;)V
    .locals 4
    .param p1, "registration"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    .param p2, "transferor"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;
    .param p3, "listener"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    .prologue
    .line 192
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 193
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "m_game_id"

    iget-object v2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->gameId:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 194
    const-string v1, "access_key"

    invoke-virtual {p2}, Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;->getAccessKey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 195
    const-string v1, "m_key"

    invoke-virtual {p1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;->getTransferToken()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 196
    const-string v1, "only"

    const-string v2, "1"

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 198
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "public/Transfer"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getCGIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;

    invoke-direct {v3, p0, p3}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;-><init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 231
    return-void
.end method
