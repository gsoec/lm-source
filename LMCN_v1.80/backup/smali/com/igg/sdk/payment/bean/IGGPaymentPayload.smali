.class public Lcom/igg/sdk/payment/bean/IGGPaymentPayload;
.super Ljava/lang/Object;
.source "IGGPaymentPayload.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGPaymentPayload"


# instance fields
.field private characterId:Ljava/lang/String;

.field private iggId:Ljava/lang/String;

.field private itemId:Ljava/lang/String;

.field private orderType:Ljava/lang/String;

.field private rmId:Ljava/lang/String;

.field private serverId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 15
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getCharacterId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 107
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->characterId:Ljava/lang/String;

    return-object v0
.end method

.method public getIggId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 115
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->iggId:Ljava/lang/String;

    return-object v0
.end method

.method public getItemId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 123
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->itemId:Ljava/lang/String;

    return-object v0
.end method

.method public getOrderType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 131
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->orderType:Ljava/lang/String;

    return-object v0
.end method

.method public getRmId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 139
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->rmId:Ljava/lang/String;

    return-object v0
.end method

.method public getServerId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 99
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->serverId:Ljava/lang/String;

    return-object v0
.end method

.method public serialize()Ljava/lang/String;
    .locals 5

    .prologue
    .line 69
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 71
    .local v1, "json":Lorg/json/JSONObject;
    :try_start_0
    const-string v2, "u_id"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->iggId:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 72
    const-string v2, "server_id"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->serverId:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 73
    const-string v2, "cha_id"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->characterId:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 74
    const-string v2, "game_item_id"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->itemId:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 75
    const-string v2, "pm_type"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->orderType:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 76
    const-string v2, "rmid"

    iget-object v3, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->rmId:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 91
    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    :goto_0
    return-object v2

    .line 77
    :catch_0
    move-exception v0

    .line 78
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 80
    const-string v2, "IGGPaymentPayload"

    const-string v3, "failed to serialize:"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 81
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "IGGId: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->iggId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 82
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "serverId: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->serverId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 83
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "characterId: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->characterId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 84
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "itemId: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->itemId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 85
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "orderType: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->orderType:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    const-string v2, "IGGPaymentPayload"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "rmid: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->rmId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 88
    const/4 v2, 0x0

    goto/16 :goto_0
.end method

.method public setCharacterId(Ljava/lang/String;)V
    .locals 0
    .param p1, "characterId"    # Ljava/lang/String;

    .prologue
    .line 111
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->characterId:Ljava/lang/String;

    .line 112
    return-void
.end method

.method public setIggId(Ljava/lang/String;)V
    .locals 0
    .param p1, "iggId"    # Ljava/lang/String;

    .prologue
    .line 119
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->iggId:Ljava/lang/String;

    .line 120
    return-void
.end method

.method public setItemId(Ljava/lang/String;)V
    .locals 0
    .param p1, "itemId"    # Ljava/lang/String;

    .prologue
    .line 127
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->itemId:Ljava/lang/String;

    .line 128
    return-void
.end method

.method public setOrderType(Ljava/lang/String;)V
    .locals 0
    .param p1, "orderType"    # Ljava/lang/String;

    .prologue
    .line 135
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->orderType:Ljava/lang/String;

    .line 136
    return-void
.end method

.method public setRmId(Ljava/lang/String;)V
    .locals 0
    .param p1, "rmId"    # Ljava/lang/String;

    .prologue
    .line 143
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->rmId:Ljava/lang/String;

    .line 144
    return-void
.end method

.method public setServerId(Ljava/lang/String;)V
    .locals 0
    .param p1, "serverId"    # Ljava/lang/String;

    .prologue
    .line 103
    iput-object p1, p0, Lcom/igg/sdk/payment/bean/IGGPaymentPayload;->serverId:Ljava/lang/String;

    .line 104
    return-void
.end method
