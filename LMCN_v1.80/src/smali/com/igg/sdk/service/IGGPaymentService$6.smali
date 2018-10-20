.class Lcom/igg/sdk/service/IGGPaymentService$6;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->getWeChatOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 310
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

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
    const/4 v10, 0x0

    const/4 v9, 0x0

    .line 313
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v6

    if-eqz v6, :cond_0

    .line 314
    iget-object v6, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    invoke-interface {v6, p1, v9, v10}, Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;->onPaymentLoadDataFinished(Lcom/igg/sdk/error/IGGError;ZLjava/lang/String;)V

    .line 334
    :goto_0
    return-void

    .line 319
    :cond_0
    :try_start_0
    sget-object v6, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "responseString:"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 320
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 321
    .local v4, "json":Lorg/json/JSONObject;
    const-string v6, "error"

    invoke-virtual {v4, v6}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 322
    .local v3, "j":Lorg/json/JSONObject;
    const-string v6, "code"

    invoke-virtual {v3, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 323
    .local v1, "errCode":Ljava/lang/String;
    const-string v6, "0"

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 324
    const-string v6, "data"

    invoke-virtual {v4, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 325
    .local v5, "result":Ljava/lang/String;
    iget-object v6, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    const/4 v7, 0x1

    invoke-interface {v6, p1, v7, v5}, Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;->onPaymentLoadDataFinished(Lcom/igg/sdk/error/IGGError;ZLjava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 330
    .end local v1    # "errCode":Ljava/lang/String;
    .end local v3    # "j":Lorg/json/JSONObject;
    .end local v4    # "json":Lorg/json/JSONObject;
    .end local v5    # "result":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 331
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 332
    iget-object v6, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    invoke-interface {v6, p1, v9, v10}, Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;->onPaymentLoadDataFinished(Lcom/igg/sdk/error/IGGError;ZLjava/lang/String;)V

    goto :goto_0

    .line 327
    .end local v0    # "e":Ljava/lang/Exception;
    .restart local v1    # "errCode":Ljava/lang/String;
    .restart local v3    # "j":Lorg/json/JSONObject;
    .restart local v4    # "json":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    const-string v6, "error"

    invoke-virtual {v4, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 328
    .local v2, "errorMsg":Ljava/lang/String;
    iget-object v6, p0, Lcom/igg/sdk/service/IGGPaymentService$6;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;

    const/4 v7, 0x0

    invoke-interface {v6, p1, v7, v2}, Lcom/igg/sdk/service/IGGPaymentService$PaymentAdvanceOrderDataListener;->onPaymentLoadDataFinished(Lcom/igg/sdk/error/IGGError;ZLjava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
