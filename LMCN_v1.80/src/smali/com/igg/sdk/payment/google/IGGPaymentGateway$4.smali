.class Lcom/igg/sdk/payment/google/IGGPaymentGateway$4;
.super Ljava/lang/Object;
.source "IGGPaymentGateway.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/IGGPaymentGateway;->sendReport(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    .prologue
    .line 405
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$4;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 6
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 408
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_1

    .line 432
    :cond_0
    :goto_0
    return-void

    .line 412
    :cond_1
    invoke-static {p3}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 417
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 418
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v4, "data"

    invoke-virtual {v0, v4}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 421
    const-string v4, "error"

    invoke-virtual {v0, v4}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v3

    .line 422
    .local v3, "errorJSON":Lorg/json/JSONObject;
    const-string v4, "code"

    invoke-virtual {v3, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 423
    .local v1, "code":Ljava/lang/String;
    if-eqz v1, :cond_2

    const-string v4, "0"

    invoke-virtual {v1, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2

    .line 424
    const-string v4, "IGGPaymentGateway"

    const-string v5, "report success"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 429
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v1    # "code":Ljava/lang/String;
    .end local v3    # "errorJSON":Lorg/json/JSONObject;
    :catch_0
    move-exception v2

    .line 430
    .local v2, "e":Lorg/json/JSONException;
    invoke-virtual {v2}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0

    .line 426
    .end local v2    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v1    # "code":Ljava/lang/String;
    .restart local v3    # "errorJSON":Lorg/json/JSONObject;
    :cond_2
    :try_start_1
    const-string v4, "IGGPaymentGateway"

    const-string v5, "report fail"

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
