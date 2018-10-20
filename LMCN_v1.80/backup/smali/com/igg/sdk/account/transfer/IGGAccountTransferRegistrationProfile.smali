.class public Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;
.super Ljava/lang/Object;
.source "IGGAccountTransferRegistrationProfile.java"


# instance fields
.field private extra:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private iggId:Ljava/lang/String;

.field private name:Ljava/lang/String;

.field private version:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getExtra()Ljava/util/HashMap;
    .locals 1

    .prologue
    .line 55
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->extra:Ljava/util/HashMap;

    return-object v0
.end method

.method public getIGGId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 43
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->iggId:Ljava/lang/String;

    return-object v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 47
    iget-object v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->name:Ljava/lang/String;

    return-object v0
.end method

.method public getVersion()I
    .locals 1

    .prologue
    .line 51
    iget v0, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->version:I

    return v0
.end method

.method public setExtra(Ljava/util/HashMap;)V
    .locals 0
    .param p1, "extra"    # Ljava/util/HashMap;

    .prologue
    .line 71
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->extra:Ljava/util/HashMap;

    .line 72
    return-void
.end method

.method public setIGGId(Ljava/lang/String;)V
    .locals 0
    .param p1, "IGGId"    # Ljava/lang/String;

    .prologue
    .line 59
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->iggId:Ljava/lang/String;

    .line 60
    return-void
.end method

.method public setName(Ljava/lang/String;)V
    .locals 0
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 63
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->name:Ljava/lang/String;

    .line 64
    return-void
.end method

.method public setVersion(I)V
    .locals 0
    .param p1, "version"    # I

    .prologue
    .line 67
    iput p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->version:I

    .line 68
    return-void
.end method

.method public toJSONString()Ljava/lang/String;
    .locals 6

    .prologue
    .line 22
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 23
    .local v1, "jObject":Lorg/json/JSONObject;
    iget-object v4, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->extra:Ljava/util/HashMap;

    if-eqz v4, :cond_0

    .line 24
    iget-object v4, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->extra:Ljava/util/HashMap;

    invoke-virtual {v4}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :goto_0
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_0

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 25
    .local v3, "key":Ljava/lang/String;
    iget-object v5, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->extra:Ljava/util/HashMap;

    invoke-virtual {v5, v3}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    invoke-virtual {v1, v3, v5}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 36
    .end local v1    # "jObject":Lorg/json/JSONObject;
    .end local v3    # "key":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 37
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 38
    const/4 v4, 0x0

    .end local v0    # "e":Lorg/json/JSONException;
    :goto_1
    return-object v4

    .line 29
    .restart local v1    # "jObject":Lorg/json/JSONObject;
    :cond_0
    :try_start_1
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2}, Lorg/json/JSONObject;-><init>()V

    .line 30
    .local v2, "jsonObject":Lorg/json/JSONObject;
    const-string v4, "name"

    iget-object v5, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->name:Ljava/lang/String;

    invoke-virtual {v2, v4, v5}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 31
    const-string v4, "iggid"

    iget-object v5, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->iggId:Ljava/lang/String;

    invoke-virtual {v2, v4, v5}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 32
    const-string v4, "version"

    iget v5, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->version:I

    invoke-virtual {v2, v4, v5}, Lorg/json/JSONObject;->put(Ljava/lang/String;I)Lorg/json/JSONObject;

    .line 33
    const-string v4, "extra"

    invoke-virtual {v2, v4, v1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 34
    const-string v4, "IGGAccountTransferRegistrationProfile"

    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 35
    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    move-result-object v4

    goto :goto_1
.end method
