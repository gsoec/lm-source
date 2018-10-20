.class Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;
.super Ljava/lang/Object;
.source "IGGPaymentCardsLoader.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->loadItems(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

.field final synthetic val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    .prologue
    .line 36
    iput-object p1, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    iput-object p2, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    .locals 12
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseString"    # Ljava/lang/String;

    .prologue
    const/4 v11, 0x0

    .line 39
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v8

    if-eqz v8, :cond_0

    .line 40
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    invoke-interface {v8, p1, v11}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;->onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V

    .line 69
    :goto_0
    return-void

    .line 45
    :cond_0
    :try_start_0
    new-instance v6, Lorg/json/JSONObject;

    invoke-direct {v6, p2}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 46
    .local v6, "response":Lorg/json/JSONObject;
    const-string v8, "error"

    invoke-virtual {v6, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v4

    .line 47
    .local v4, "errorInfo":Lorg/json/JSONObject;
    const-string v8, "code"

    invoke-virtual {v4, v8}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    .line 48
    .local v1, "code":I
    if-eqz v1, :cond_2

    .line 49
    const/4 v7, 0x0

    .line 50
    .local v7, "retError":Lcom/igg/sdk/error/IGGError;
    const/16 v8, 0x64

    if-ge v1, v8, :cond_1

    .line 51
    const/4 v8, 0x0

    invoke-static {v8, v1}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    .line 55
    :goto_1
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v7, v9}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;->onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 64
    .end local v1    # "code":I
    .end local v4    # "errorInfo":Lorg/json/JSONObject;
    .end local v6    # "response":Lorg/json/JSONObject;
    .end local v7    # "retError":Lcom/igg/sdk/error/IGGError;
    :catch_0
    move-exception v3

    .line 65
    .local v3, "e":Ljava/lang/Exception;
    invoke-virtual {v3}, Ljava/lang/Exception;->printStackTrace()V

    .line 67
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    invoke-static {v3}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-interface {v8, v9, v11}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;->onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V

    goto :goto_0

    .line 53
    .end local v3    # "e":Ljava/lang/Exception;
    .restart local v1    # "code":I
    .restart local v4    # "errorInfo":Lorg/json/JSONObject;
    .restart local v6    # "response":Lorg/json/JSONObject;
    .restart local v7    # "retError":Lcom/igg/sdk/error/IGGError;
    :cond_1
    const/4 v8, 0x0

    :try_start_1
    invoke-static {v8, v1}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v7

    goto :goto_1

    .line 59
    .end local v7    # "retError":Lcom/igg/sdk/error/IGGError;
    :cond_2
    const-string v8, "data"

    invoke-virtual {v6, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v2

    .line 60
    .local v2, "data":Lorg/json/JSONObject;
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    invoke-static {v8, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->access$000(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lorg/json/JSONObject;)I

    move-result v5

    .line 61
    .local v5, "purchaseLimit":I
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    invoke-static {v8, v2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;->access$100(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Lorg/json/JSONObject;)Ljava/util/ArrayList;

    move-result-object v0

    .line 63
    .local v0, "cards":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    iget-object v8, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->val$listener:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;

    new-instance v9, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    iget-object v10, p0, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$1;->this$0:Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;

    invoke-direct {v9, v10, v0, v5}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;-><init>(Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader;Ljava/util/ArrayList;I)V

    invoke-interface {v8, p1, v9}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;->onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
