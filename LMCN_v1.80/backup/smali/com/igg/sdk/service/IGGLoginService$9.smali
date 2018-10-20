.class Lcom/igg/sdk/service/IGGLoginService$9;
.super Ljava/lang/Object;
.source "IGGLoginService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGLoginService;->weChatAccountBind(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGLoginService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGLoginService;

    .prologue
    .line 523
    iput-object p1, p0, Lcom/igg/sdk/service/IGGLoginService$9;->this$0:Lcom/igg/sdk/service/IGGLoginService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGLoginService$9;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 526
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 527
    .local v3, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v5

    if-eqz v5, :cond_1

    .line 528
    iget-object v5, p0, Lcom/igg/sdk/service/IGGLoginService$9;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v5, p1, v3}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 556
    :cond_0
    :goto_0
    return-void

    .line 533
    :cond_1
    :try_start_0
    const-string v5, "IGGLoginService"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "thirdAccountBind request : "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 534
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v5

    if-eqz v5, :cond_0

    .line 535
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 536
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v5, "errCode"

    invoke-virtual {v0, v5}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    .line 537
    .local v2, "errCode":I
    if-nez v2, :cond_2

    .line 538
    const-string v5, "success"

    const-string v6, "return"

    invoke-virtual {p2, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v3, v5, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 539
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v4

    .line 540
    .local v4, "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v5, "wechat_info"

    invoke-virtual {p2, v5}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v5

    if-eqz v5, :cond_3

    .line 541
    const-string v5, "wechat_info"

    const-string v6, "wechat_info"

    invoke-virtual {p2, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/String;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v3, v5, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 542
    const-string v6, "wechat_info"

    const-string v5, "wechat_info"

    invoke-interface {v3, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    invoke-interface {v4, v6, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 545
    :goto_1
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5, v4}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 546
    const-string v5, "IGGLoginService"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "thirdAccountBind request  getExtra : "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    sget-object v7, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v7}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 549
    .end local v4    # "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_2
    const-string v5, "errCode"

    const-string v6, "errCode"

    invoke-virtual {v0, v6}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-interface {v3, v5, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 550
    iget-object v5, p0, Lcom/igg/sdk/service/IGGLoginService$9;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    invoke-interface {v5, v6, v3}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 552
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errCode":I
    :catch_0
    move-exception v1

    .line 553
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 554
    iget-object v5, p0, Lcom/igg/sdk/service/IGGLoginService$9;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    const v6, 0x30d44

    invoke-static {v1, v6}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v6

    const/4 v7, 0x0

    invoke-interface {v5, v6, v7}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto/16 :goto_0

    .line 544
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v2    # "errCode":I
    .restart local v4    # "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_3
    :try_start_1
    const-string v5, "wechat_info"

    const-string v6, ""

    invoke-interface {v4, v5, v6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1
.end method
