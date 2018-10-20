.class Lcom/igg/sdk/service/IGGRealNameVerificationService$1;
.super Ljava/lang/Object;
.source "IGGRealNameVerificationService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeadersRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGRealNameVerificationService;->requestState(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/realname/IGGVerificationStateListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGRealNameVerificationService;

.field final synthetic val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGRealNameVerificationService;Lcom/igg/sdk/realname/IGGVerificationStateListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGRealNameVerificationService;

    .prologue
    .line 31
    iput-object p1, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->this$0:Lcom/igg/sdk/service/IGGRealNameVerificationService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onHeadersRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;)V
    .locals 12
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p3, "responseString"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .prologue
    .local p2, "headerFieldsMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    const/4 v11, 0x0

    .line 34
    iget-object v8, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    if-eqz v8, :cond_0

    .line 35
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v8

    if-eqz v8, :cond_1

    .line 36
    iget-object v8, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    invoke-interface {v8, v11, p1}, Lcom/igg/sdk/realname/IGGVerificationStateListener;->onResult(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;Lcom/igg/sdk/error/IGGError;)V

    .line 91
    :cond_0
    :goto_0
    return-void

    .line 41
    :cond_1
    :try_start_0
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 42
    .local v4, "obj":Lorg/json/JSONObject;
    new-instance v5, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;

    invoke-direct {v5}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;-><init>()V

    .line 43
    .local v5, "result":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;
    const-string v8, "error"

    invoke-virtual {v4, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v8

    const-string v9, "code"

    invoke-virtual {v8, v9}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    .line 45
    .local v2, "errorCode":I
    if-nez v2, :cond_4

    .line 46
    const-string v8, "data"

    invoke-virtual {v4, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v0

    .line 48
    .local v0, "data":Lorg/json/JSONObject;
    const-string v8, "state"

    invoke-virtual {v0, v8}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v7

    .line 49
    .local v7, "stateValue":I
    const/4 v6, 0x0

    .line 50
    .local v6, "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    packed-switch v7, :pswitch_data_0

    .line 68
    sget-object v6, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnknow:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 71
    :goto_1
    invoke-virtual {v5, v6}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->setState(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;)V

    .line 73
    const-string v8, "is_adult"

    invoke-virtual {v0, v8}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v8

    if-eqz v8, :cond_2

    .line 74
    const-string v8, "is_adult"

    invoke-virtual {v0, v8}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v3

    .line 76
    .local v3, "isAdult":I
    if-nez v3, :cond_3

    .line 77
    const/4 v8, 0x1

    invoke-virtual {v5, v8}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->setMinor(Z)V

    .line 83
    .end local v3    # "isAdult":I
    :cond_2
    :goto_2
    iget-object v8, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-interface {v8, v5, v9}, Lcom/igg/sdk/realname/IGGVerificationStateListener;->onResult(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 87
    .end local v0    # "data":Lorg/json/JSONObject;
    .end local v2    # "errorCode":I
    .end local v4    # "obj":Lorg/json/JSONObject;
    .end local v5    # "result":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;
    .end local v6    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .end local v7    # "stateValue":I
    :catch_0
    move-exception v1

    .line 88
    .local v1, "e":Ljava/lang/Exception;
    iget-object v8, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    invoke-static {v1}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-interface {v8, v11, v9}, Lcom/igg/sdk/realname/IGGVerificationStateListener;->onResult(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 52
    .end local v1    # "e":Ljava/lang/Exception;
    .restart local v0    # "data":Lorg/json/JSONObject;
    .restart local v2    # "errorCode":I
    .restart local v4    # "obj":Lorg/json/JSONObject;
    .restart local v5    # "result":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;
    .restart local v6    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .restart local v7    # "stateValue":I
    :pswitch_0
    :try_start_1
    sget-object v6, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationSumbitted:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 53
    goto :goto_1

    .line 56
    :pswitch_1
    sget-object v6, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationAuthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 57
    goto :goto_1

    .line 60
    :pswitch_2
    sget-object v6, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationDenied:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 61
    goto :goto_1

    .line 64
    :pswitch_3
    sget-object v6, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnauthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    .line 65
    goto :goto_1

    .line 79
    .restart local v3    # "isAdult":I
    :cond_3
    const/4 v8, 0x0

    invoke-virtual {v5, v8}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->setMinor(Z)V

    goto :goto_2

    .line 85
    .end local v0    # "data":Lorg/json/JSONObject;
    .end local v3    # "isAdult":I
    .end local v6    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    .end local v7    # "stateValue":I
    :cond_4
    iget-object v8, p0, Lcom/igg/sdk/service/IGGRealNameVerificationService$1;->val$listener:Lcom/igg/sdk/realname/IGGVerificationStateListener;

    const/4 v9, 0x0

    const/4 v10, 0x0

    invoke-static {v10, v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v10

    invoke-interface {v8, v9, v10}, Lcom/igg/sdk/realname/IGGVerificationStateListener;->onResult(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;Lcom/igg/sdk/error/IGGError;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0

    .line 50
    :pswitch_data_0
    .packed-switch -0x1
        :pswitch_3
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method
