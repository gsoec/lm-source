.class Lcom/igg/sdk/service/IGGLoginService$1;
.super Ljava/lang/Object;
.source "IGGLoginService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGLoginService;->guestLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
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
    .line 87
    iput-object p1, p0, Lcom/igg/sdk/service/IGGLoginService$1;->this$0:Lcom/igg/sdk/service/IGGLoginService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGLoginService$1;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

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

    .line 90
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 92
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "guestLogin request failed: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 93
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$1;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v2, p1, v5}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 117
    :goto_0
    return-void

    .line 97
    :cond_0
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "guestLogin result: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 98
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 100
    .local v1, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    const-string v2, "IggId"

    const-string v3, "iggid"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 101
    const-string v2, "login"

    const-string v3, "login"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 102
    const-string v2, "AccessKey"

    const-string v3, "access_key"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 103
    const-string v2, "platformUid"

    const-string v3, "platformUid"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 104
    const-string v2, "hasbind"

    const-string v3, "hasbind"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 107
    const-string v2, "uuid"

    invoke-virtual {p2, v2}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_1

    .line 108
    const-string v2, "uuid"

    const-string v3, "uuid"

    invoke-virtual {p2, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 116
    :cond_1
    :goto_1
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$1;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    invoke-interface {v2, p1, v1}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    goto :goto_0

    .line 110
    :catch_0
    move-exception v0

    .line 111
    .local v0, "e":Lorg/json/JSONException;
    const-string v2, "IGGLoginService"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "guestLogin JSONException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 112
    iget-object v2, p0, Lcom/igg/sdk/service/IGGLoginService$1;->val$listener:Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;

    new-instance v3, Ljava/lang/Exception;

    invoke-direct {v3, v0}, Ljava/lang/Exception;-><init>(Ljava/lang/Throwable;)V

    const v4, 0x30d44

    invoke-static {v3, v4}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {v2, v3, v5}, Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;->onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V

    .line 113
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_1
.end method
