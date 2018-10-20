.class Lcom/igg/sdk/service/IGGPaymentService$7;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->getAlipayOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 360
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 15
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 364
    const-string v10, "pay"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "responseString:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    move-object/from16 v0, p3

    invoke-virtual {v11, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 365
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v10

    if-eqz v10, :cond_0

    .line 366
    iget-object v10, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    const-string v11, ""

    const-string v12, ""

    const-string v13, ""

    move-object/from16 v0, p1

    invoke-interface {v10, v0, v11, v12, v13}, Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;->onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 402
    :goto_0
    return-void

    .line 371
    :cond_0
    :try_start_0
    new-instance v5, Lorg/json/JSONObject;

    move-object/from16 v0, p3

    invoke-direct {v5, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 372
    .local v5, "json":Lorg/json/JSONObject;
    const-string v10, "error"

    invoke-virtual {v5, v10}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 373
    .local v3, "j":Lorg/json/JSONObject;
    const-string v10, "code"

    invoke-virtual {v3, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 374
    .local v2, "errCode":Ljava/lang/String;
    if-eqz v2, :cond_1

    const-string v10, "0"

    invoke-virtual {v2, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-eqz v10, :cond_1

    .line 375
    const-string v10, "data"

    invoke-virtual {v5, v10}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v4

    .line 376
    .local v4, "jObject":Lorg/json/JSONObject;
    const-string v10, "sign"

    invoke-virtual {v4, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    .line 377
    .local v9, "sign":Ljava/lang/String;
    const-string v10, "pay"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "\u8fd4\u56de\u7b7e\u540d(JSONObject):"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 382
    :try_start_1
    const-string v10, "UTF-8"

    invoke-static {v9, v10}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    :try_end_1
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_1 .. :try_end_1} :catch_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    move-result-object v9

    .line 386
    :goto_1
    :try_start_2
    const-string v10, "orderNo"

    invoke-virtual {v4, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 387
    .local v8, "orderNo":Ljava/lang/String;
    const-string v10, "notifyUrl"

    invoke-virtual {v4, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 388
    .local v6, "notifyUrl":Ljava/lang/String;
    const-string v10, "orderInfo"

    invoke-virtual {v4, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 389
    .local v7, "od":Ljava/lang/String;
    const-string v10, "pay"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "\u8fd4\u56de\u7b7e\u540d(encode):"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 390
    const-string v10, "pay"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "\u8fd4\u56de\u8ba2\u5355\u53f7:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 391
    const-string v10, "pay"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "\u63a5\u53e3\u8fd4\u56de\u7684orderInfo:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 392
    iget-object v10, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    move-object/from16 v0, p1

    invoke-interface {v10, v0, v8, v9, v6}, Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;->onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_2
    .catch Lorg/json/JSONException; {:try_start_2 .. :try_end_2} :catch_0

    goto/16 :goto_0

    .line 397
    .end local v2    # "errCode":Ljava/lang/String;
    .end local v3    # "j":Lorg/json/JSONObject;
    .end local v4    # "jObject":Lorg/json/JSONObject;
    .end local v5    # "json":Lorg/json/JSONObject;
    .end local v6    # "notifyUrl":Ljava/lang/String;
    .end local v7    # "od":Ljava/lang/String;
    .end local v8    # "orderNo":Ljava/lang/String;
    .end local v9    # "sign":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 398
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 399
    iget-object v10, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    invoke-static {v1}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    const-string v12, ""

    const-string v13, ""

    const-string v14, ""

    invoke-interface {v10, v11, v12, v13, v14}, Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;->onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 383
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v2    # "errCode":Ljava/lang/String;
    .restart local v3    # "j":Lorg/json/JSONObject;
    .restart local v4    # "jObject":Lorg/json/JSONObject;
    .restart local v5    # "json":Lorg/json/JSONObject;
    .restart local v9    # "sign":Ljava/lang/String;
    :catch_1
    move-exception v1

    .line 384
    .local v1, "e":Ljava/io/UnsupportedEncodingException;
    :try_start_3
    invoke-virtual {v1}, Ljava/io/UnsupportedEncodingException;->printStackTrace()V

    goto :goto_1

    .line 395
    .end local v1    # "e":Ljava/io/UnsupportedEncodingException;
    .end local v4    # "jObject":Lorg/json/JSONObject;
    .end local v9    # "sign":Ljava/lang/String;
    :cond_1
    iget-object v10, p0, Lcom/igg/sdk/service/IGGPaymentService$7;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;

    const/4 v11, 0x0

    invoke-static {v11}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    const-string v12, ""

    const-string v13, ""

    const-string v14, ""

    invoke-interface {v10, v11, v12, v13, v14}, Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;->onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_3
    .catch Lorg/json/JSONException; {:try_start_3 .. :try_end_3} :catch_0

    goto/16 :goto_0
.end method
