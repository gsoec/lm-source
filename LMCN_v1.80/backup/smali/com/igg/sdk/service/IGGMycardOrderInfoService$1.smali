.class Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;
.super Ljava/lang/Object;
.source "IGGMycardOrderInfoService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMycardOrderInfoService;->loadItems(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMycardOrderInfoService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMycardOrderInfoService;Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMycardOrderInfoService;

    .prologue
    .line 46
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;->this$0:Lcom/igg/sdk/service/IGGMycardOrderInfoService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseString"    # Ljava/lang/String;

    .prologue
    const/4 v6, 0x0

    .line 49
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 50
    iget-object v4, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;

    invoke-interface {v4, p1, v6}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 69
    :goto_0
    return-void

    .line 54
    :cond_0
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 58
    .local v2, "items":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    :try_start_0
    new-instance v3, Lorg/json/JSONArray;

    invoke-direct {v3, p2}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    .line 59
    .local v3, "jsonArray":Lorg/json/JSONArray;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    invoke-virtual {v3}, Lorg/json/JSONArray;->length()I

    move-result v4

    if-ge v1, v4, :cond_1

    .line 60
    invoke-virtual {v3, v1}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/sdk/payment/bean/IGGGameItem;->createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItem;

    move-result-object v4

    invoke-virtual {v2, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 59
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 62
    .end local v1    # "i":I
    .end local v3    # "jsonArray":Lorg/json/JSONArray;
    :catch_0
    move-exception v0

    .line 63
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 64
    iget-object v4, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;

    invoke-static {v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v6}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0

    .line 68
    .end local v0    # "e":Lorg/json/JSONException;
    .restart local v1    # "i":I
    .restart local v3    # "jsonArray":Lorg/json/JSONArray;
    :cond_1
    iget-object v4, p0, Lcom/igg/sdk/service/IGGMycardOrderInfoService$1;->val$listener:Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;

    invoke-interface {v4, p1, v2}, Lcom/igg/sdk/service/IGGMycardOrderInfoService$PaymentItemsListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0
.end method
