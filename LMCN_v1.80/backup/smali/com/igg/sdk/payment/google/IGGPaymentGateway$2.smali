.class Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;
.super Ljava/lang/Object;
.source "IGGPaymentGateway.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeadersRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayAmazon(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

.field final synthetic val$actualAPI:Ljava/lang/String;

.field final synthetic val$gameId:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

.field final synthetic val$params:Ljava/util/HashMap;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    .prologue
    .line 216
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$actualAPI:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$gameId:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    iput-object p5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onHeadersRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;)V
    .locals 10
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p3, "responseString"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .prologue
    .local p2, "headerFieldsMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    const/4 v9, 0x1

    const/4 v8, 0x0

    .line 220
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$actualAPI:Ljava/lang/String;

    invoke-static {v3, v4, p2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$100(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/util/Map;)V

    .line 223
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v3

    if-nez v3, :cond_0

    if-eqz p3, :cond_0

    const-string v3, ""

    invoke-virtual {p3, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_2

    .line 224
    :cond_0
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$000(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    move-result v3

    if-ge v3, v9, :cond_1

    .line 225
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$008(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    .line 226
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v5, "amazon_mobile/callback.php"

    invoke-static {v4, v5}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "?gameid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$gameId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 227
    .local v0, "actualAPI":Ljava/lang/String;
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {v3, v4, v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$202(Lcom/igg/sdk/payment/google/IGGPaymentGateway;J)J

    .line 228
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$gameId:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    iget-object v6, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    invoke-virtual {v3, v4, v0, v5, v6}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayAmazon(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V

    .line 260
    .end local v0    # "actualAPI":Ljava/lang/String;
    :goto_0
    return-void

    .line 231
    :cond_1
    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    const-string v5, "receipt_id"

    invoke-virtual {v3, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-interface {v4, v8, v8, v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLjava/lang/String;)V

    goto :goto_0

    .line 238
    :cond_2
    :try_start_0
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$actualAPI:Ljava/lang/String;

    invoke-static {v3, v4, p2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$100(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/util/Map;)V

    .line 240
    new-instance v3, Lorg/json/JSONObject;

    invoke-direct {v3, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v4, "code"

    invoke-virtual {v3, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 241
    .local v1, "code":Ljava/lang/String;
    const-string v3, "IGGPaymentGateway"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "code in result"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 243
    const-string v3, "0"

    invoke-virtual {v1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    .line 244
    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    const/4 v5, 0x1

    const/4 v6, 0x1

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    const-string v7, "receipt_id"

    invoke-virtual {v3, v7}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-interface {v4, v5, v6, v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLjava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 248
    .end local v1    # "code":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 249
    .local v2, "e":Ljava/lang/Exception;
    const-string v3, "IGGPaymentGateway"

    const-string v4, "IOException"

    invoke-static {v3, v4}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 250
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 251
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$000(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    move-result v3

    if-ge v3, v9, :cond_4

    .line 252
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$008(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    .line 253
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v5, "amazon_mobile/callback.php"

    invoke-static {v4, v5}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "?gameid="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$gameId:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 254
    .restart local v0    # "actualAPI":Ljava/lang/String;
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {v3, v4, v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$202(Lcom/igg/sdk/payment/google/IGGPaymentGateway;J)J

    .line 255
    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$gameId:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    iget-object v6, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    invoke-virtual {v3, v4, v0, v5, v6}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayAmazon(Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;)V

    goto/16 :goto_0

    .line 246
    .end local v0    # "actualAPI":Ljava/lang/String;
    .end local v2    # "e":Ljava/lang/Exception;
    .restart local v1    # "code":Ljava/lang/String;
    :cond_3
    :try_start_1
    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    const/4 v5, 0x0

    const/4 v6, 0x0

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    const-string v7, "receipt_id"

    invoke-virtual {v3, v7}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-interface {v4, v5, v6, v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLjava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0

    .line 257
    .end local v1    # "code":Ljava/lang/String;
    .restart local v2    # "e":Ljava/lang/Exception;
    :cond_4
    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;

    iget-object v3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$2;->val$params:Ljava/util/HashMap;

    const-string v5, "receipt_id"

    invoke-virtual {v3, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-interface {v4, v8, v8, v3}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalAmazonOfPurchaseFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLjava/lang/String;)V

    goto/16 :goto_0
.end method
