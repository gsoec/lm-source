.class Lcom/igg/sdk/service/IGGService$10;
.super Ljava/lang/Object;
.source "IGGService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGService;->CGIGeneralRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGService;

    .prologue
    .line 932
    iput-object p1, p0, Lcom/igg/sdk/service/IGGService$10;->this$0:Lcom/igg/sdk/service/IGGService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

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
    const/16 v7, 0x1f5

    const/4 v8, 0x0

    .line 935
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 936
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    invoke-interface {v4, p1, v8, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    .line 970
    :goto_0
    return-void

    .line 940
    :cond_0
    invoke-virtual {p2}, Ljava/lang/Integer;->intValue()I

    move-result v4

    const/16 v5, 0xc8

    if-eq v4, v5, :cond_1

    .line 941
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "The response status code is "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "but not HttpStatus.SC_OK"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 942
    .local v1, "description":Ljava/lang/String;
    const-string v4, "IGGService"

    invoke-static {v4, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 943
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v5, Ljava/lang/Exception;

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "statusCode:"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v5, v6}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v6, 0x190

    invoke-static {v5, v6}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v8, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto :goto_0

    .line 947
    .end local v1    # "description":Ljava/lang/String;
    :cond_1
    if-nez p3, :cond_2

    .line 948
    const-string v1, "Can not read response content"

    .line 949
    .restart local v1    # "description":Ljava/lang/String;
    const-string v4, "IGGService"

    invoke-static {v4, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 950
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v5, Ljava/lang/Exception;

    const-string v6, "Error: server returns data empty"

    invoke-direct {v5, v6}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v5, v7}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v8, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto :goto_0

    .line 954
    .end local v1    # "description":Ljava/lang/String;
    :cond_2
    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v4

    const/16 v5, 0x20

    if-ge v4, v5, :cond_3

    .line 955
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "The length of response content is invalid. Actual length is: "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 956
    .restart local v1    # "description":Ljava/lang/String;
    const-string v4, "IGGService"

    invoke-static {v4, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 957
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v5, Ljava/lang/Exception;

    const-string v6, "Error: server returns data error"

    invoke-direct {v5, v6}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v5, v7, p3}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v8, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 962
    .end local v1    # "description":Ljava/lang/String;
    :cond_3
    const/4 v4, 0x0

    invoke-virtual {p3}, Ljava/lang/String;->length()I

    move-result v5

    add-int/lit8 v5, v5, -0x20

    invoke-virtual {p3, v4, v5}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v3

    .line 963
    .local v3, "result":Ljava/lang/String;
    const-string v4, "IGGService"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "CGIGeneralRequest result:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 965
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 966
    .local v0, "JSON":Lorg/json/JSONObject;
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v0, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 967
    .end local v0    # "JSON":Lorg/json/JSONObject;
    :catch_0
    move-exception v2

    .line 968
    .local v2, "e":Lorg/json/JSONException;
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$10;->val$listener:Lcom/igg/sdk/service/IGGService$CGIRequestListener;

    new-instance v5, Ljava/lang/Exception;

    invoke-direct {v5, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/Throwable;)V

    invoke-static {v5, v7}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v8, p3}, Lcom/igg/sdk/service/IGGService$CGIRequestListener;->onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V

    goto/16 :goto_0
.end method
