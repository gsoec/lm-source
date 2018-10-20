.class Lcom/igg/sdk/service/IGGPaymentService$4;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->getOrdersSerialNumber(Ljava/lang/String;IILjava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 222
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    const/4 v7, 0x0

    .line 225
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 226
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    invoke-interface {v4, p1, v7}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V

    .line 245
    :goto_0
    return-void

    .line 231
    :cond_0
    :try_start_0
    sget-object v4, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "responseString:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 232
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 233
    .local v2, "jsonObject":Lorg/json/JSONObject;
    const-string v4, "code"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 234
    .local v1, "errCode":Ljava/lang/String;
    const-string v4, "0"

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 235
    const-string v4, "sn"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 236
    .local v3, "sn":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    invoke-interface {v4, p1, v3}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 241
    .end local v1    # "errCode":Ljava/lang/String;
    .end local v2    # "jsonObject":Lorg/json/JSONObject;
    .end local v3    # "sn":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 242
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 243
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    invoke-interface {v4, p1, v7}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V

    goto :goto_0

    .line 239
    .end local v0    # "e":Ljava/lang/Exception;
    .restart local v1    # "errCode":Ljava/lang/String;
    .restart local v2    # "jsonObject":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$4;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;

    const/4 v5, 0x0

    invoke-interface {v4, p1, v5}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsOrdersSerialListener;->onPaymentItemsOrdersSerialFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
