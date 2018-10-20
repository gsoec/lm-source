.class Lcom/igg/sdk/service/IGGPaymentService$1;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->requestLimitState(Ljava/lang/String;Ljava/lang/String;IIFZLcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 74
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$1;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 16
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 77
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    if-eqz v13, :cond_0

    .line 78
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v13

    if-eqz v13, :cond_1

    .line 79
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    const/4 v14, 0x0

    move-object/from16 v0, p1

    invoke-interface {v13, v0, v14}, Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;->onPaymentLimitStateFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 141
    :cond_0
    :goto_0
    return-void

    .line 83
    :cond_1
    sget-object v13, Lcom/igg/sdk/service/IGGPaymentService;->TAG:Ljava/lang/String;

    new-instance v14, Ljava/lang/StringBuilder;

    invoke-direct {v14}, Ljava/lang/StringBuilder;-><init>()V

    const-string v15, "responseString:"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object/from16 v0, p3

    invoke-virtual {v14, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-static {v13, v14}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    :try_start_0
    new-instance v11, Lorg/json/JSONObject;

    move-object/from16 v0, p3

    invoke-direct {v11, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 87
    .local v11, "ret":Lorg/json/JSONObject;
    const-string v13, "error"

    invoke-virtual {v11, v13}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v13

    const-string v14, "code"

    invoke-virtual {v13, v14}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v3

    .line 88
    .local v3, "errorCode":I
    const-string v13, "error"

    invoke-virtual {v11, v13}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v13

    const-string v14, "message"

    invoke-virtual {v13, v14}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 90
    .local v4, "errorMessage":Ljava/lang/String;
    if-nez v3, :cond_3

    .line 91
    new-instance v10, Ljava/util/ArrayList;

    invoke-direct {v10}, Ljava/util/ArrayList;-><init>()V

    .line 93
    .local v10, "results":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;>;"
    const-string v13, "data"

    invoke-virtual {v11, v13}, Lorg/json/JSONObject;->getJSONArray(Ljava/lang/String;)Lorg/json/JSONArray;

    move-result-object v1

    .line 95
    .local v1, "data":Lorg/json/JSONArray;
    invoke-virtual {v1}, Lorg/json/JSONArray;->length()I

    move-result v7

    .line 97
    .local v7, "length":I
    const/4 v5, 0x0

    .local v5, "i":I
    :goto_1
    if-ge v5, v7, :cond_2

    .line 98
    invoke-virtual {v1, v5}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v6

    .line 99
    .local v6, "item":Lorg/json/JSONObject;
    new-instance v9, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;

    invoke-direct {v9}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;-><init>()V

    .line 101
    .local v9, "result":Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;
    const-string v13, "type"

    invoke-virtual {v6, v13}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v12

    .line 103
    .local v12, "type":I
    const/4 v8, 0x0

    .line 105
    .local v8, "limitation":Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
    sparse-switch v12, :sswitch_data_0

    .line 119
    sget-object v8, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationNone:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 124
    :goto_2
    invoke-virtual {v9, v8}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->setLimitation(Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;)V

    .line 125
    const-string v13, "limit"

    invoke-virtual {v6, v13}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v13

    invoke-virtual {v9, v13}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->setLimit(Z)V

    .line 126
    const-string v13, "message"

    invoke-virtual {v6, v13}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v13

    invoke-virtual {v9, v13}, Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;->setMessage(Ljava/lang/String;)V

    .line 128
    invoke-interface {v10, v9}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 97
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 107
    :sswitch_0
    sget-object v8, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationUser:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 108
    goto :goto_2

    .line 111
    :sswitch_1
    sget-object v8, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationRunOutOfQuota:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 112
    goto :goto_2

    .line 115
    :sswitch_2
    sget-object v8, Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;->IGGPaymentPurchaseLimitationDevice:Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;

    .line 116
    goto :goto_2

    .line 131
    .end local v6    # "item":Lorg/json/JSONObject;
    .end local v8    # "limitation":Lcom/igg/sdk/payment/IGGPaymentPurchaseLimitation;
    .end local v9    # "result":Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;
    .end local v12    # "type":I
    :cond_2
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v14

    invoke-interface {v13, v14, v10}, Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;->onPaymentLimitStateFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 136
    .end local v1    # "data":Lorg/json/JSONArray;
    .end local v3    # "errorCode":I
    .end local v4    # "errorMessage":Ljava/lang/String;
    .end local v5    # "i":I
    .end local v7    # "length":I
    .end local v10    # "results":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/payment/bean/IGGPaymentLimitStateResult;>;"
    .end local v11    # "ret":Lorg/json/JSONObject;
    :catch_0
    move-exception v2

    .line 137
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 138
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    invoke-static {v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v14

    const/4 v15, 0x0

    invoke-interface {v13, v14, v15}, Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;->onPaymentLimitStateFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto/16 :goto_0

    .line 133
    .end local v2    # "e":Ljava/lang/Exception;
    .restart local v3    # "errorCode":I
    .restart local v4    # "errorMessage":Ljava/lang/String;
    .restart local v11    # "ret":Lorg/json/JSONObject;
    :cond_3
    :try_start_1
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/igg/sdk/service/IGGPaymentService$1;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;

    const/4 v14, 0x0

    invoke-static {v14, v3, v4}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;ILjava/lang/String;)Lcom/igg/sdk/error/IGGError;

    move-result-object v14

    const/4 v15, 0x0

    invoke-interface {v13, v14, v15}, Lcom/igg/sdk/service/IGGPaymentService$IGGPaymentLimitStateListener;->onPaymentLimitStateFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0

    .line 105
    nop

    :sswitch_data_0
    .sparse-switch
        0xa -> :sswitch_0
        0xb -> :sswitch_1
        0x14 -> :sswitch_2
    .end sparse-switch
.end method
