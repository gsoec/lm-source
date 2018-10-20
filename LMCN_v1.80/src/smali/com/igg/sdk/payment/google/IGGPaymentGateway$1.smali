.class Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;
.super Ljava/lang/Object;
.source "IGGPaymentGateway.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeadersRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayGooglePlay(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

.field final synthetic val$actualAPI:Ljava/lang/String;

.field final synthetic val$gameId:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

.field final synthetic val$params:Ljava/util/HashMap;

.field final synthetic val$purchase:Lcom/google/payment/Purchase;

.field final synthetic val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    .prologue
    .line 112
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$actualAPI:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    iput-object p4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$params:Ljava/util/HashMap;

    iput-object p6, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    iput-object p7, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

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
    const/4 v6, 0x1

    const/4 v5, 0x0

    .line 116
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-nez v0, :cond_0

    if-eqz p3, :cond_0

    const-string v0, ""

    invoke-virtual {p3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 117
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$000(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    move-result v0

    if-ge v0, v6, :cond_2

    .line 118
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$008(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    .line 120
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$actualAPI:Ljava/lang/String;

    invoke-static {v0, v1, p2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$100(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/util/Map;)V

    .line 124
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-ne v0, v1, :cond_1

    .line 125
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "cafebazaar/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 130
    .local v3, "actualAPI":Ljava/lang/String;
    :goto_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {v0, v4, v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$202(Lcom/igg/sdk/payment/google/IGGPaymentGateway;J)J

    .line 131
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$params:Ljava/util/HashMap;

    iget-object v5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    iget-object v6, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayGooglePlay(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V

    .line 176
    .end local v3    # "actualAPI":Ljava/lang/String;
    :goto_1
    return-void

    .line 127
    :cond_1
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "android/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .restart local v3    # "actualAPI":Ljava/lang/String;
    goto :goto_0

    .line 134
    .end local v3    # "actualAPI":Ljava/lang/String;
    :cond_2
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    invoke-interface {v0, v5, v5, v1}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLcom/google/payment/Purchase;)V

    goto :goto_1

    .line 141
    :cond_3
    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$actualAPI:Ljava/lang/String;

    invoke-static {v0, v1, p2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$100(Lcom/igg/sdk/payment/google/IGGPaymentGateway;Ljava/lang/String;Ljava/util/Map;)V

    .line 142
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v1, "code"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 143
    .local v7, "code":Ljava/lang/String;
    const-string v0, "IGGPaymentGateway"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "code in result"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 147
    const-string v0, "0"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_4

    const-string v0, "1"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_4

    const-string v0, "2"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    .line 148
    :cond_4
    const/4 v9, 0x0

    .line 149
    .local v9, "purchaseAccepted":Z
    const-string v0, "0"

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    .line 150
    const/4 v9, 0x1

    .line 153
    :cond_5
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    const/4 v1, 0x1

    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    invoke-interface {v0, v1, v9, v2}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLcom/google/payment/Purchase;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 157
    .end local v7    # "code":Ljava/lang/String;
    .end local v9    # "purchaseAccepted":Z
    :catch_0
    move-exception v8

    .line 158
    .local v8, "e":Ljava/lang/Exception;
    const-string v0, "IGGPaymentGateway"

    const-string v1, "IOException"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 159
    invoke-virtual {v8}, Ljava/lang/Exception;->printStackTrace()V

    .line 161
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$000(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    move-result v0

    if-ge v0, v6, :cond_8

    .line 162
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {v0}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$008(Lcom/igg/sdk/payment/google/IGGPaymentGateway;)I

    .line 164
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-ne v0, v1, :cond_7

    .line 165
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "cafebazaar/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 170
    .restart local v3    # "actualAPI":Ljava/lang/String;
    :goto_2
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {v0, v4, v5}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->access$202(Lcom/igg/sdk/payment/google/IGGPaymentGateway;J)J

    .line 171
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->this$0:Lcom/igg/sdk/payment/google/IGGPaymentGateway;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$type:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    iget-object v2, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$params:Ljava/util/HashMap;

    iget-object v5, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    iget-object v6, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/payment/google/IGGPaymentGateway;->postPayGooglePlay(Lcom/igg/sdk/IGGSDKConstant$PaymentType;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/google/payment/Purchase;Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;)V

    goto/16 :goto_1

    .line 155
    .end local v3    # "actualAPI":Ljava/lang/String;
    .end local v8    # "e":Ljava/lang/Exception;
    .restart local v7    # "code":Ljava/lang/String;
    :cond_6
    :try_start_1
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    const/4 v1, 0x0

    const/4 v2, 0x0

    iget-object v4, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    invoke-interface {v0, v1, v2, v4}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLcom/google/payment/Purchase;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_1

    .line 167
    .end local v7    # "code":Ljava/lang/String;
    .restart local v8    # "e":Ljava/lang/Exception;
    :cond_7
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$PayDNS;->PAY_APP_IGG:Lcom/igg/sdk/IGGSDKConstant$PayDNS;

    const-string v2, "android/callback.php"

    invoke-static {v1, v2}, Lcom/igg/sdk/IGGURLHelper;->getPayGatewayAPI(Lcom/igg/sdk/IGGSDKConstant$PayDNS;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?gameid="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .restart local v3    # "actualAPI":Ljava/lang/String;
    goto :goto_2

    .line 173
    .end local v3    # "actualAPI":Ljava/lang/String;
    :cond_8
    iget-object v0, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$listener:Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;

    iget-object v1, p0, Lcom/igg/sdk/payment/google/IGGPaymentGateway$1;->val$purchase:Lcom/google/payment/Purchase;

    invoke-interface {v0, v5, v5, v1}, Lcom/igg/sdk/payment/google/IGGPaymentGateway$SubmittalFinishedListener;->onIGGPurchaseSubmittalFinished(ZZLcom/google/payment/Purchase;)V

    goto/16 :goto_1
.end method
