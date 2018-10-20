.class Lcom/igg/sdk/log/IGGLogger$2;
.super Ljava/lang/Object;
.source "IGGLogger.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/log/IGGLogger;->adLog(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/log/listener/LoggerListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/log/IGGLogger;

.field final synthetic val$listener:Lcom/igg/sdk/log/listener/LoggerListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/log/IGGLogger;Lcom/igg/sdk/log/listener/LoggerListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/log/IGGLogger;

    .prologue
    .line 94
    iput-object p1, p0, Lcom/igg/sdk/log/IGGLogger$2;->this$0:Lcom/igg/sdk/log/IGGLogger;

    iput-object p2, p0, Lcom/igg/sdk/log/IGGLogger$2;->val$listener:Lcom/igg/sdk/log/listener/LoggerListener;

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
    .line 98
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 99
    iget-object v2, p0, Lcom/igg/sdk/log/IGGLogger$2;->val$listener:Lcom/igg/sdk/log/listener/LoggerListener;

    invoke-interface {v2, p1}, Lcom/igg/sdk/log/listener/LoggerListener;->onFinished(Lcom/igg/sdk/error/IGGError;)V

    .line 115
    :goto_0
    return-void

    .line 104
    :cond_0
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 105
    .local v1, "json":Lorg/json/JSONObject;
    const-string v2, "error_no"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    if-nez v2, :cond_1

    .line 106
    iget-object v2, p0, Lcom/igg/sdk/log/IGGLogger$2;->val$listener:Lcom/igg/sdk/log/listener/LoggerListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/log/listener/LoggerListener;->onFinished(Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 110
    .end local v1    # "json":Lorg/json/JSONObject;
    :catch_0
    move-exception v0

    .line 111
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 112
    iget-object v2, p0, Lcom/igg/sdk/log/IGGLogger$2;->val$listener:Lcom/igg/sdk/log/listener/LoggerListener;

    invoke-static {v0}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/log/listener/LoggerListener;->onFinished(Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 108
    .end local v0    # "e":Lorg/json/JSONException;
    .restart local v1    # "json":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v2, p0, Lcom/igg/sdk/log/IGGLogger$2;->val$listener:Lcom/igg/sdk/log/listener/LoggerListener;

    new-instance v3, Ljava/lang/Exception;

    const-string v4, "msg"

    invoke-virtual {v1, v4}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-direct {v3, v4}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v3}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/log/listener/LoggerListener;->onFinished(Lcom/igg/sdk/error/IGGError;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
