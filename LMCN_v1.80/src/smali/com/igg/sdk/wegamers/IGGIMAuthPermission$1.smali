.class Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;
.super Ljava/lang/Object;
.source "IGGIMAuthPermission.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/wegamers/IGGIMAuthPermission;->getIMAuthCode(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/wegamers/IGGIMAuthPermission;

.field final synthetic val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/wegamers/IGGIMAuthPermission;Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/wegamers/IGGIMAuthPermission;

    .prologue
    .line 34
    iput-object p1, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->this$0:Lcom/igg/sdk/wegamers/IGGIMAuthPermission;

    iput-object p2, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    const/4 v7, 0x0

    .line 37
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 38
    const-string v4, "IGGIMAuthPermission"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "getIMAuthCode request failed: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 39
    iget-object v4, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    const-string v5, ""

    invoke-interface {v4, p1, v7, v5}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;->onGetAuthCodeFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;)V

    .line 60
    :goto_0
    return-void

    .line 43
    :cond_0
    const-string v4, "IGGIMAuthPermission"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "getIMAuthCode request: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 46
    :try_start_0
    const-string v4, "auth_code"

    invoke-virtual {p2, v4}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v4

    if-nez v4, :cond_1

    .line 47
    iget-object v4, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    const-string v5, "auth_code"

    invoke-virtual {p2, v5}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    const-string v6, ""

    invoke-interface {v4, p1, v5, v6}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;->onGetAuthCodeFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 55
    :catch_0
    move-exception v0

    .line 56
    .local v0, "e":Lorg/json/JSONException;
    const-string v4, "IGGIMAuthPermission"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "getIMAuthCode JSONException: "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v0}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 57
    iget-object v4, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    const-string v5, ""

    invoke-interface {v4, p1, v7, v5}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;->onGetAuthCodeFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;)V

    .line 58
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0

    .line 49
    .end local v0    # "e":Lorg/json/JSONException;
    :cond_1
    :try_start_1
    const-string v4, "underlying"

    invoke-virtual {p2, v4}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v2

    .line 50
    .local v2, "jsonObject":Lorg/json/JSONObject;
    const-string v4, "code"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 51
    .local v1, "errCode":Ljava/lang/String;
    const-string v4, "message"

    invoke-virtual {v2, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 52
    .local v3, "message":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;->val$listener:Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    invoke-interface {v4, p1, v1, v3}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;->onGetAuthCodeFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
