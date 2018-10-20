.class Lcom/igg/sdk/account/IGGAccountBind$10;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindVKAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 750
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$10;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$10;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 16
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    .line 754
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v12

    if-eqz v12, :cond_0

    .line 755
    move-object/from16 v0, p0

    iget-object v12, v0, Lcom/igg/sdk/account/IGGAccountBind$10;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    const/4 v13, 0x0

    const-string v14, "404"

    const/4 v15, 0x0

    invoke-interface {v12, v13, v14, v15}, Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 797
    :goto_0
    return-void

    .line 760
    :cond_0
    :try_start_0
    const-string v12, "errCode"

    move-object/from16 v0, p2

    invoke-virtual {v0, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 761
    .local v6, "errCode":Ljava/lang/String;
    const-string v12, "bindVKAccount"

    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "errCode:"

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    invoke-static {v12, v13}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 762
    const-string v12, "errStr"

    move-object/from16 v0, p2

    invoke-virtual {v0, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 763
    .local v4, "codeDescription":Ljava/lang/String;
    const-string v12, "bindVKAccount"

    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "codeDescription:"

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    invoke-static {v12, v13}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 764
    invoke-static {v6}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v3

    .line 765
    .local v3, "code":I
    if-nez v3, :cond_3

    .line 766
    const-string v12, "result"

    move-object/from16 v0, p2

    invoke-virtual {v0, v12}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v10

    .line 767
    .local v10, "jsonObject":Lorg/json/JSONObject;
    const-string v12, "0"

    invoke-virtual {v10, v12}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v9

    .line 768
    .local v9, "jMessageObject":Lorg/json/JSONObject;
    const-string v12, "hasbind"

    invoke-virtual {v9, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 769
    .local v7, "hasBind":Ljava/lang/String;
    const-string v12, "iggid"

    invoke-virtual {v9, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 770
    .local v2, "bindIGGID":Ljava/lang/String;
    sget-object v12, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v12}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    .line 771
    .local v1, "IGGId":Ljava/lang/String;
    const/4 v12, 0x0

    invoke-static {v12}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v8

    .line 773
    .local v8, "isBind":Ljava/lang/Boolean;
    invoke-virtual {v2, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v12

    if-eqz v12, :cond_2

    .line 774
    if-eqz v7, :cond_1

    const-string v12, "1"

    invoke-virtual {v7, v12}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v12

    if-eqz v12, :cond_1

    .line 775
    const/4 v12, 0x1

    invoke-static {v12}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v8

    .line 776
    const-string v11, "bind successful"

    .line 786
    .local v11, "message":Ljava/lang/String;
    :goto_1
    sget-object v12, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v8}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v13

    invoke-virtual {v12, v13}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 787
    move-object/from16 v0, p0

    iget-object v12, v0, Lcom/igg/sdk/account/IGGAccountBind$10;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    invoke-virtual {v8}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v13

    invoke-interface {v12, v13, v6, v11}, Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 792
    .end local v1    # "IGGId":Ljava/lang/String;
    .end local v2    # "bindIGGID":Ljava/lang/String;
    .end local v3    # "code":I
    .end local v4    # "codeDescription":Ljava/lang/String;
    .end local v6    # "errCode":Ljava/lang/String;
    .end local v7    # "hasBind":Ljava/lang/String;
    .end local v8    # "isBind":Ljava/lang/Boolean;
    .end local v9    # "jMessageObject":Lorg/json/JSONObject;
    .end local v10    # "jsonObject":Lorg/json/JSONObject;
    .end local v11    # "message":Ljava/lang/String;
    :catch_0
    move-exception v5

    .line 793
    .local v5, "e":Lorg/json/JSONException;
    invoke-virtual {v5}, Lorg/json/JSONException;->printStackTrace()V

    .line 794
    const-string v12, "bindVKAccount"

    const-string v13, "errCode:401"

    invoke-static {v12, v13}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 795
    move-object/from16 v0, p0

    iget-object v12, v0, Lcom/igg/sdk/account/IGGAccountBind$10;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    const/4 v13, 0x0

    const-string v14, "401"

    const/4 v15, 0x0

    invoke-interface {v12, v13, v14, v15}, Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 778
    .end local v5    # "e":Lorg/json/JSONException;
    .restart local v1    # "IGGId":Ljava/lang/String;
    .restart local v2    # "bindIGGID":Ljava/lang/String;
    .restart local v3    # "code":I
    .restart local v4    # "codeDescription":Ljava/lang/String;
    .restart local v6    # "errCode":Ljava/lang/String;
    .restart local v7    # "hasBind":Ljava/lang/String;
    .restart local v8    # "isBind":Ljava/lang/Boolean;
    .restart local v9    # "jMessageObject":Lorg/json/JSONObject;
    .restart local v10    # "jsonObject":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    const-string v11, "bind failed"

    .line 779
    .restart local v11    # "message":Ljava/lang/String;
    const-string v6, "1002"

    goto :goto_1

    .line 782
    .end local v11    # "message":Ljava/lang/String;
    :cond_2
    const-string v6, "1001"

    .line 783
    const-string v11, "bind failed. VK account has Bound"

    .restart local v11    # "message":Ljava/lang/String;
    goto :goto_1

    .line 789
    .end local v1    # "IGGId":Ljava/lang/String;
    .end local v2    # "bindIGGID":Ljava/lang/String;
    .end local v7    # "hasBind":Ljava/lang/String;
    .end local v8    # "isBind":Ljava/lang/Boolean;
    .end local v9    # "jMessageObject":Lorg/json/JSONObject;
    .end local v10    # "jsonObject":Lorg/json/JSONObject;
    .end local v11    # "message":Ljava/lang/String;
    :cond_3
    move-object/from16 v0, p0

    iget-object v12, v0, Lcom/igg/sdk/account/IGGAccountBind$10;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;

    const/4 v13, 0x0

    const/4 v14, 0x0

    invoke-interface {v12, v13, v6, v14}, Lcom/igg/sdk/account/IGGAccountBind$BindVKListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
