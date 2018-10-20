.class Lcom/igg/sdk/service/IGGLoginService$2;
.super Ljava/lang/Object;
.source "IGGLoginService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGLoginService;->getBindState(Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$BindStateListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGLoginService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGLoginService$BindStateListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGLoginService;Lcom/igg/sdk/service/IGGLoginService$BindStateListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGLoginService;

    .prologue
    .line 130
    iput-object p1, p0, Lcom/igg/sdk/service/IGGLoginService$2;->this$0:Lcom/igg/sdk/service/IGGLoginService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGLoginService$2;->val$listener:Lcom/igg/sdk/service/IGGLoginService$BindStateListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 5
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    const/4 v4, 0x0

    .line 133
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 134
    const-string v1, "IGGLoginService"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "getBindState request failed: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 135
    iget-object v1, p0, Lcom/igg/sdk/service/IGGLoginService$2;->val$listener:Lcom/igg/sdk/service/IGGLoginService$BindStateListener;

    invoke-interface {v1, p1, v4}, Lcom/igg/sdk/service/IGGLoginService$BindStateListener;->onBindStateFinished(Lcom/igg/sdk/error/IGGError;Z)V

    .line 146
    :goto_0
    return-void

    .line 140
    :cond_0
    :try_start_0
    iget-object v1, p0, Lcom/igg/sdk/service/IGGLoginService$2;->val$listener:Lcom/igg/sdk/service/IGGLoginService$BindStateListener;

    const-string v2, "return"

    invoke-virtual {p2, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    const-string v3, "1"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    invoke-interface {v1, p1, v2}, Lcom/igg/sdk/service/IGGLoginService$BindStateListener;->onBindStateFinished(Lcom/igg/sdk/error/IGGError;Z)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 141
    :catch_0
    move-exception v0

    .line 142
    .local v0, "e":Lorg/json/JSONException;
    const-string v1, "IGGLoginService"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "guestLogin JSONException: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 143
    iget-object v1, p0, Lcom/igg/sdk/service/IGGLoginService$2;->val$listener:Lcom/igg/sdk/service/IGGLoginService$BindStateListener;

    invoke-interface {v1, p1, v4}, Lcom/igg/sdk/service/IGGLoginService$BindStateListener;->onBindStateFinished(Lcom/igg/sdk/error/IGGError;Z)V

    .line 144
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0
.end method
