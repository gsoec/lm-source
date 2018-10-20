.class Lcom/igg/sdk/service/IGGService$8;
.super Ljava/lang/Object;
.source "IGGService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGService;->CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGService;

.field final synthetic val$isFlatStruct:Z

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;Z)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGService;

    .prologue
    .line 792
    iput-object p1, p0, Lcom/igg/sdk/service/IGGService$8;->this$0:Lcom/igg/sdk/service/IGGService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    iput-boolean p3, p0, Lcom/igg/sdk/service/IGGService$8;->val$isFlatStruct:Z

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 11
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    const/16 v8, 0x1f5

    const/16 v10, 0x1f4

    const/4 v9, 0x0

    .line 795
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v5

    if-eqz v5, :cond_0

    .line 796
    const-string v5, "CGIRequest"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "CGIRequest failed responseString:"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 797
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    invoke-interface {v5, p1, v9, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    .line 850
    :goto_0
    return-void

    .line 801
    :cond_0
    invoke-virtual {p2}, Ljava/lang/Integer;->intValue()I

    move-result v5

    const/16 v6, 0xc8

    if-eq v5, v6, :cond_1

    .line 802
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "The response status code is "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "but not HttpStatus.SC_OK"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 803
    .local v1, "description":Ljava/lang/String;
    const-string v5, "IGGService"

    invoke-static {v5, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 804
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "statusCode:"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-direct {v6, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v7, 0x190

    invoke-static {v6, v7}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    invoke-interface {v5, v6, v9, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto :goto_0

    .line 808
    .end local v1    # "description":Ljava/lang/String;
    :cond_1
    if-nez p3, :cond_2

    .line 809
    const-string v1, "Can not read response content"

    .line 810
    .restart local v1    # "description":Ljava/lang/String;
    const-string v5, "IGGService"

    invoke-static {v5, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 811
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    const-string v7, "Error: server returns data empty"

    invoke-direct {v6, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v6, v10}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    invoke-interface {v5, v6, v9, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto :goto_0

    .line 815
    .end local v1    # "description":Ljava/lang/String;
    :cond_2
    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v5

    const/16 v6, 0x20

    if-ge v5, v6, :cond_3

    .line 816
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "The length of response content is invalid. Actual length is: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 817
    .restart local v1    # "description":Ljava/lang/String;
    const-string v5, "IGGService"

    invoke-static {v5, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 818
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    const-string v7, "Error: server returns data error"

    invoke-direct {v6, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v6, v8, p3}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    invoke-interface {v5, v6, v9, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 823
    .end local v1    # "description":Ljava/lang/String;
    :cond_3
    const/4 v5, 0x0

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v6

    add-int/lit8 v6, v6, -0x20

    invoke-virtual {p3, v5, v6}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v4

    .line 824
    .local v4, "result":Ljava/lang/String;
    const-string v5, "IGGService"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "result:"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 826
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v4}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 827
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v5, "errCode"

    invoke-virtual {v0, v5}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v5

    if-eqz v5, :cond_4

    .line 828
    const-string v1, "API business error!"

    .line 829
    .restart local v1    # "description":Ljava/lang/String;
    const-string v5, "IGGService"

    invoke-static {v5, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 830
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    const-string v7, "Error: server returns json data error"

    invoke-direct {v6, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v7, 0x1f5

    invoke-static {v6, v7, v1, v0}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const/4 v7, 0x0

    invoke-interface {v5, v6, v7, v4}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 847
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v1    # "description":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 848
    .local v2, "e":Lorg/json/JSONException;
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    invoke-direct {v6, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/Throwable;)V

    invoke-static {v6, v10}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    invoke-interface {v5, v6, v9, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 834
    .end local v2    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    :cond_4
    :try_start_1
    const-string v5, "errCode"

    invoke-virtual {v0, v5}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v3

    .line 835
    .local v3, "errCode":I
    if-eqz v3, :cond_5

    .line 836
    const-string v5, "IGGService"

    const-string v6, "errStr"

    invoke-virtual {v0, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 837
    const-string v5, "errStr"

    invoke-virtual {v0, v5}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 838
    .restart local v1    # "description":Ljava/lang/String;
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v6, Ljava/lang/Exception;

    invoke-direct {v6, v1}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v6, v3, v1, v0}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const/4 v7, 0x0

    invoke-interface {v5, v6, v7, v4}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 842
    .end local v1    # "description":Ljava/lang/String;
    :cond_5
    iget-boolean v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$isFlatStruct:Z

    if-eqz v5, :cond_6

    .line 843
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const-string v7, "result"

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v7

    invoke-interface {v5, v6, v7, v4}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 845
    :cond_6
    iget-object v5, p0, Lcom/igg/sdk/service/IGGService$8;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const-string v7, "result"

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v7

    const-string v8, "0"

    invoke-virtual {v7, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v7

    invoke-interface {v5, v6, v7, v4}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
