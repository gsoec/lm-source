.class Lcom/igg/sdk/promotion/IGGPromotionService$4;
.super Ljava/lang/Object;
.source "IGGPromotionService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/promotion/IGGPromotionService;->onDismiss(Lcom/igg/sdk/promotion/model/IGGShowcase;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

.field final synthetic val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/promotion/IGGPromotionService;

    .prologue
    .line 196
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    iput-object p2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 5
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 200
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_1

    .line 201
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    if-eqz v2, :cond_0

    .line 202
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    const-string v3, "B001"

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v2, v3, v4}, Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;->onFinished(Ljava/lang/String;Ljava/lang/String;)V

    .line 225
    :cond_0
    :goto_0
    return-void

    .line 208
    :cond_1
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 209
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v2, "error"

    invoke-virtual {v0, v2}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    if-eqz v2, :cond_2

    .line 210
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    if-eqz v2, :cond_0

    .line 211
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    const-string v3, "B002"

    const-string v4, "msg"

    invoke-virtual {v0, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-interface {v2, v3, v4}, Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;->onFinished(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 218
    .end local v0    # "JSON":Lorg/json/JSONObject;
    :catch_0
    move-exception v1

    .line 219
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 221
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    if-eqz v2, :cond_0

    .line 222
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    const-string v3, "B000"

    invoke-virtual {v1}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-interface {v2, v3, v4}, Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;->onFinished(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 214
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    :cond_2
    :try_start_1
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    if-eqz v2, :cond_0

    .line 215
    iget-object v2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$4;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;

    const-string v3, "0"

    const-string v4, ""

    invoke-interface {v2, v3, v4}, Lcom/igg/sdk/promotion/listener/IGGShowcaseOperationListener;->onFinished(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
