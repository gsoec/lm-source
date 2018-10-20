.class Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;
.super Ljava/lang/Object;
.source "IGGAccountTransferAgent.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transfer(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

.field final synthetic val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    .prologue
    .line 198
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    iput-object p2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 9
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 202
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v6

    if-eqz v6, :cond_0

    .line 203
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    new-instance v7, Ljava/lang/Exception;

    const-string v8, "404"

    invoke-direct {v7, v8}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V

    .line 229
    :goto_0
    return-void

    .line 207
    :cond_0
    const/4 v6, 0x0

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v7

    add-int/lit8 v7, v7, -0x20

    invoke-virtual {p3, v6, v7}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v4

    .line 209
    .local v4, "result":Ljava/lang/String;
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v4}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 210
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v6, "errCode"

    invoke-virtual {v0, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 211
    .local v2, "errCode":Ljava/lang/String;
    const-string v6, "0"

    invoke-virtual {v2, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_2

    .line 212
    const-string v6, "result"

    invoke-virtual {v0, v6}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 213
    .local v3, "jsonObject":Lorg/json/JSONObject;
    const-string v6, "return"

    invoke-virtual {v3, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 214
    .local v5, "resultCode":Ljava/lang/String;
    const-string v6, "1"

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 215
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 225
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errCode":Ljava/lang/String;
    .end local v3    # "jsonObject":Lorg/json/JSONObject;
    .end local v5    # "resultCode":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 226
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 227
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    new-instance v7, Ljava/lang/Exception;

    const-string v8, "400"

    invoke-direct {v7, v8}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 217
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v2    # "errCode":Ljava/lang/String;
    .restart local v3    # "jsonObject":Lorg/json/JSONObject;
    .restart local v5    # "resultCode":Ljava/lang/String;
    :cond_1
    :try_start_1
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    new-instance v7, Ljava/lang/Exception;

    const-string v8, "400"

    invoke-direct {v7, v8}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 219
    .end local v3    # "jsonObject":Lorg/json/JSONObject;
    .end local v5    # "resultCode":Ljava/lang/String;
    :cond_2
    const-string v6, "100022"

    invoke-virtual {v2, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_3

    .line 221
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    new-instance v7, Ljava/lang/Exception;

    const-string v8, "300"

    invoke-direct {v7, v8}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 223
    :cond_3
    iget-object v6, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$3;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;

    new-instance v7, Ljava/lang/Exception;

    const-string v8, "400"

    invoke-direct {v7, v8}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    invoke-interface {v6, v7}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferListener;->onCompleted(Lcom/igg/sdk/error/IGGError;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
