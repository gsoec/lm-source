.class Lcom/igg/sdk/service/IGGLoginService$4;
.super Ljava/lang/Object;
.source "IGGLoginService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGLoginService;->thirdAccountBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
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
    .line 211
    iput-object p1, p0, Lcom/igg/sdk/service/IGGLoginService$4;->this$0:Lcom/igg/sdk/service/IGGLoginService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGLoginService$4;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

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
    const/4 v7, 0x0

    .line 215
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 216
    iget-object v4, p0, Lcom/igg/sdk/service/IGGLoginService$4;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v4, p1, v7}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 236
    :goto_0
    return-void

    .line 220
    :cond_0
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 222
    .local v3, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    const-string v4, "IGGLoginService"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "thirdAccountBind responseString : "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 223
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 224
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v4, "errCode"

    invoke-virtual {v0, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 225
    .local v2, "errCode":Ljava/lang/String;
    const-string v4, "errCode"

    invoke-virtual {v0, v4}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v4

    if-nez v4, :cond_1

    .line 226
    const-string v4, "success"

    const-string v5, "return"

    invoke-virtual {p2, v5}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-interface {v3, v4, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 229
    :cond_1
    const-string v4, "errCode"

    invoke-interface {v3, v4, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 231
    iget-object v4, p0, Lcom/igg/sdk/service/IGGLoginService$4;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v4, p1, v3}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 232
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errCode":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 233
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 234
    iget-object v4, p0, Lcom/igg/sdk/service/IGGLoginService$4;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    const v5, 0x30d44

    invoke-static {v1, v5}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v5

    invoke-interface {v4, v5, v7}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto :goto_0
.end method
