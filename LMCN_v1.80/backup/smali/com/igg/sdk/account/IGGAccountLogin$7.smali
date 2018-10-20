.class Lcom/igg/sdk/account/IGGAccountLogin$7;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->loginVKAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;

.field final synthetic val$platformKey:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 502
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$7;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$listener:Lcom/igg/sdk/account/LoginListener;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$platformKey:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 17
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    .line 506
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 507
    move-object/from16 v0, p0

    iget-object v1, v0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v4

    move-object/from16 v0, p1

    invoke-interface {v1, v0, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 551
    :goto_0
    return-void

    .line 512
    :cond_0
    :try_start_0
    const-string v1, "LoginVKAccount"

    const-string v4, "===================================="

    invoke-static {v1, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 513
    const-string v1, "errCode"

    move-object/from16 v0, p2

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v11

    .line 514
    .local v11, "errCode":Ljava/lang/String;
    const-string v1, "LoginVKAccount"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "errCode:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v1, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 515
    const-string v1, "errStr"

    move-object/from16 v0, p2

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    .line 516
    .local v9, "codeDescription":Ljava/lang/String;
    const-string v1, "LoginVKAccount"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "codeDescription:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v1, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 517
    invoke-static {v11}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v8

    .line 518
    .local v8, "code":I
    if-nez v8, :cond_2

    .line 519
    const-string v1, "result"

    move-object/from16 v0, p2

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v15

    .line 520
    .local v15, "jsonObject":Lorg/json/JSONObject;
    const-string v1, "0"

    invoke-virtual {v15, v1}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v14

    .line 521
    .local v14, "jMessageObject":Lorg/json/JSONObject;
    const-string v1, "iggid"

    invoke-virtual {v14, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 522
    .local v2, "iggId":Ljava/lang/String;
    const-string v1, "platformUid"

    invoke-virtual {v14, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 523
    .local v7, "platformUid":Ljava/lang/String;
    const-string v1, "hasbind"

    invoke-virtual {v14, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v12

    .line 524
    .local v12, "hasBind":Ljava/lang/String;
    const/4 v1, 0x0

    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v13

    .line 525
    .local v13, "isBind":Ljava/lang/Boolean;
    if-eqz v12, :cond_1

    const-string v1, "1"

    invoke-virtual {v12, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 526
    const/4 v1, 0x1

    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v13

    .line 529
    :cond_1
    const-string v1, "access_key"

    invoke-virtual {v14, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 531
    .local v3, "access_key":Ljava/lang/String;
    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->VK:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    .line 535
    invoke-virtual {v13}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v4

    .line 536
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v5

    move-object/from16 v0, p0

    iget-object v6, v0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$platformKey:Ljava/lang/String;

    .line 531
    invoke-static/range {v1 .. v7}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v16

    .line 542
    .local v16, "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    sput-object v16, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 543
    move-object/from16 v0, p0

    iget-object v1, v0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$listener:Lcom/igg/sdk/account/LoginListener;

    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    move-object/from16 v0, p1

    invoke-interface {v1, v0, v4}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 547
    .end local v2    # "iggId":Ljava/lang/String;
    .end local v3    # "access_key":Ljava/lang/String;
    .end local v7    # "platformUid":Ljava/lang/String;
    .end local v8    # "code":I
    .end local v9    # "codeDescription":Ljava/lang/String;
    .end local v11    # "errCode":Ljava/lang/String;
    .end local v12    # "hasBind":Ljava/lang/String;
    .end local v13    # "isBind":Ljava/lang/Boolean;
    .end local v14    # "jMessageObject":Lorg/json/JSONObject;
    .end local v15    # "jsonObject":Lorg/json/JSONObject;
    .end local v16    # "newSession":Lcom/igg/sdk/account/IGGAccountSession;
    :catch_0
    move-exception v10

    .line 548
    .local v10, "e":Lorg/json/JSONException;
    invoke-virtual {v10}, Lorg/json/JSONException;->printStackTrace()V

    .line 549
    move-object/from16 v0, p0

    iget-object v1, v0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$listener:Lcom/igg/sdk/account/LoginListener;

    new-instance v4, Ljava/lang/Exception;

    invoke-direct {v4, v10}, Ljava/lang/Exception;-><init>(Ljava/lang/Throwable;)V

    const v5, 0x30d43

    invoke-static {v4, v5}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v4

    const/4 v5, 0x0

    invoke-interface {v1, v4, v5}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto/16 :goto_0

    .line 545
    .end local v10    # "e":Lorg/json/JSONException;
    .restart local v8    # "code":I
    .restart local v9    # "codeDescription":Ljava/lang/String;
    .restart local v11    # "errCode":Ljava/lang/String;
    :cond_2
    :try_start_1
    move-object/from16 v0, p0

    iget-object v1, v0, Lcom/igg/sdk/account/IGGAccountLogin$7;->val$listener:Lcom/igg/sdk/account/LoginListener;

    new-instance v4, Ljava/lang/Exception;

    invoke-direct {v4, v9}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v4, v8}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v4

    const/4 v5, 0x0

    invoke-interface {v1, v4, v5}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
