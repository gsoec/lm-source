.class Lcom/igg/sdk/service/IGGLoginService$8;
.super Ljava/lang/Object;
.source "IGGLoginService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGLoginService;->thirdWechatAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
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
    .line 482
    iput-object p1, p0, Lcom/igg/sdk/service/IGGLoginService$8;->this$0:Lcom/igg/sdk/service/IGGLoginService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGLoginService$8;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 6
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    const/4 v5, 0x0

    .line 485
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 486
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "thirdWechatAccountLogin request failed: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 487
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$8;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v2, p1, v5}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 505
    :goto_0
    return-void

    .line 491
    :cond_0
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "thirdWechatAccountLogin request: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 492
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 494
    .local v1, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    const-string v2, "IggId"

    const-string v3, "iggid"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 495
    const-string v2, "AccessKey"

    const-string v3, "access_key"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 496
    const-string v2, "platformUid"

    const-string v3, "platformUid"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 497
    const-string v2, "hasbind"

    const-string v3, "hasbind"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 498
    const-string v2, "wechat_info"

    const-string v3, "wechat_info"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 499
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$8;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v2, p1, v1}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 500
    :catch_0
    move-exception v0

    .line 501
    .local v0, "e":Lorg/json/JSONException;
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "thirdWechatAccountLogin JSONException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 502
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$8;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    const v3, 0x30d44

    invoke-static {v0, v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {v2, v3, v5}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 503
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    goto/16 :goto_0
.end method
