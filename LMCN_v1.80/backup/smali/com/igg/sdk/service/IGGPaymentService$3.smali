.class Lcom/igg/sdk/service/IGGPaymentService$3;
.super Ljava/lang/Object;
.source "IGGPaymentService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGPaymentService;->loadItemsList(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGPaymentService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGPaymentService;Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGPaymentService;

    .prologue
    .line 182
    iput-object p1, p0, Lcom/igg/sdk/service/IGGPaymentService$3;->this$0:Lcom/igg/sdk/service/IGGPaymentService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGPaymentService$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;

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

    .line 185
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 186
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;

    invoke-interface {v4, p1, v6}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    .line 205
    :goto_0
    return-void

    .line 190
    :cond_0
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 194
    .local v2, "items":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    :try_start_0
    new-instance v3, Lorg/json/JSONArray;

    invoke-direct {v3, p2}, Lorg/json/JSONArray;-><init>(Ljava/lang/String;)V

    .line 195
    .local v3, "jsonArray":Lorg/json/JSONArray;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    invoke-virtual {v3}, Lorg/json/JSONArray;->length()I

    move-result v4

    if-ge v1, v4, :cond_1

    .line 196
    invoke-virtual {v3, v1}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v4

    invoke-static {v4}, Lcom/igg/sdk/payment/bean/IGGGameItem;->createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItem;

    move-result-object v4

    invoke-virtual {v2, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 195
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 198
    .end local v1    # "i":I
    .end local v3    # "jsonArray":Lorg/json/JSONArray;
    :catch_0
    move-exception v0

    .line 199
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 200
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;

    invoke-static {v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v6}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0

    .line 204
    .end local v0    # "e":Lorg/json/JSONException;
    .restart local v1    # "i":I
    .restart local v3    # "jsonArray":Lorg/json/JSONArray;
    :cond_1
    iget-object v4, p0, Lcom/igg/sdk/service/IGGPaymentService$3;->val$listener:Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;

    invoke-interface {v4, p1, v2}, Lcom/igg/sdk/service/IGGPaymentService$PaymentItemsListListener;->onPaymentItemsLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/List;)V

    goto :goto_0
.end method
