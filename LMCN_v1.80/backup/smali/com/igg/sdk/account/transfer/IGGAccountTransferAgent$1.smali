.class Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;
.super Ljava/lang/Object;
.source "IGGAccountTransferAgent.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->registerForTransfer(Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

.field final synthetic val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

.field final synthetic val$profile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    .prologue
    .line 66
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    iput-object p2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    iput-object p3, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$profile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 23
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 70
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v15

    if-eqz v15, :cond_0

    .line 71
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    const/16 v18, 0x0

    new-instance v19, Ljava/lang/Exception;

    const-string v20, "404"

    invoke-direct/range {v19 .. v20}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static/range {v19 .. v19}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v19

    move-object/from16 v0, v18

    move-object/from16 v1, v19

    invoke-interface {v15, v0, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V

    .line 102
    :goto_0
    return-void

    .line 75
    :cond_0
    const-string v15, "registerForTransfer"

    move-object/from16 v0, p3

    invoke-static {v15, v0}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 77
    const/4 v15, 0x0

    invoke-virtual/range {p3 .. p3}, Ljava/lang/String;->length()I

    move-result v18

    add-int/lit8 v18, v18, -0x20

    move-object/from16 v0, p3

    move/from16 v1, v18

    invoke-virtual {v0, v15, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v11

    .line 79
    .local v11, "result":Ljava/lang/String;
    :try_start_0
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4, v11}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 80
    .local v4, "JSON":Lorg/json/JSONObject;
    const-string v15, "errCode"

    invoke-virtual {v4, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 81
    .local v7, "errCode":Ljava/lang/String;
    const-string v15, "0"

    invoke-virtual {v7, v15}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v15

    if-eqz v15, :cond_1

    .line 82
    const-string v15, "result"

    invoke-virtual {v4, v15}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v15

    const-string v18, "0"

    move-object/from16 v0, v18

    invoke-virtual {v15, v0}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v9

    .line 83
    .local v9, "jsonObject":Lorg/json/JSONObject;
    const-string v15, "return"

    invoke-virtual {v9, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v10

    .line 84
    .local v10, "key":Ljava/lang/String;
    const-string v15, "period_of_validity"

    invoke-virtual {v9, v15}, Lorg/json/JSONObject;->getLong(Ljava/lang/String;)J

    move-result-wide v12

    .line 86
    .local v12, "periodOValidity":J
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v16

    .line 87
    .local v16, "time":J
    new-instance v5, Ljava/util/Date;

    const-wide/16 v18, 0x3e8

    mul-long v18, v18, v12

    add-long v18, v18, v16

    move-wide/from16 v0, v18

    invoke-direct {v5, v0, v1}, Ljava/util/Date;-><init>(J)V

    .line 88
    .local v5, "date":Ljava/util/Date;
    new-instance v14, Ljava/text/SimpleDateFormat;

    const-string v15, "yyyy-MM-dd HH:mm:ss"

    invoke-direct {v14, v15}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    .line 89
    .local v14, "simpleDateFormat":Ljava/text/SimpleDateFormat;
    const-string v15, "IGGAccountTransferAgent"

    new-instance v18, Ljava/lang/StringBuilder;

    invoke-direct/range {v18 .. v18}, Ljava/lang/StringBuilder;-><init>()V

    const-string v19, "registerForTransfer expire date:"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual {v14, v5}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v19

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    move-object/from16 v0, v18

    invoke-static {v15, v0}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 90
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    new-instance v18, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$profile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    move-object/from16 v19, v0

    move-object/from16 v0, v18

    move-object/from16 v1, v19

    invoke-direct {v0, v10, v5, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    move-object/from16 v0, v18

    iput-object v0, v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    .line 91
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    move-object/from16 v1, p1

    invoke-interface {v15, v0, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 97
    .end local v4    # "JSON":Lorg/json/JSONObject;
    .end local v5    # "date":Ljava/util/Date;
    .end local v7    # "errCode":Ljava/lang/String;
    .end local v9    # "jsonObject":Lorg/json/JSONObject;
    .end local v10    # "key":Ljava/lang/String;
    .end local v12    # "periodOValidity":J
    .end local v14    # "simpleDateFormat":Ljava/text/SimpleDateFormat;
    .end local v16    # "time":J
    :catch_0
    move-exception v6

    .line 98
    .local v6, "e":Lorg/json/JSONException;
    invoke-virtual {v6}, Lorg/json/JSONException;->printStackTrace()V

    .line 99
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    new-instance v18, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    const-string v19, ""

    const/16 v20, 0x0

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$profile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    move-object/from16 v21, v0

    invoke-direct/range {v18 .. v21}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    move-object/from16 v0, v18

    iput-object v0, v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    .line 100
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    move-object/from16 v1, p1

    invoke-interface {v15, v0, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V

    goto/16 :goto_0

    .line 93
    .end local v6    # "e":Lorg/json/JSONException;
    .restart local v4    # "JSON":Lorg/json/JSONObject;
    .restart local v7    # "errCode":Ljava/lang/String;
    :cond_1
    :try_start_1
    const-string v15, "errStr"

    invoke-virtual {v4, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 94
    .local v8, "errStr":Ljava/lang/String;
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    new-instance v18, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    const-string v19, ""

    const/16 v20, 0x0

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$profile:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    move-object/from16 v21, v0

    invoke-direct/range {v18 .. v21}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    move-object/from16 v0, v18

    iput-object v0, v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    .line 95
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$1;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->transferRegistration:Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v18, v0

    new-instance v19, Ljava/lang/Exception;

    move-object/from16 v0, v19

    invoke-direct {v0, v7}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {v7}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v20

    new-instance v21, Ljava/lang/StringBuilder;

    invoke-direct/range {v21 .. v21}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v21

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v21

    const-string v22, ""

    invoke-virtual/range {v21 .. v22}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v21

    invoke-virtual/range {v21 .. v21}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v21

    move-object/from16 v0, v19

    move/from16 v1, v20

    move-object/from16 v2, v21

    invoke-static {v0, v1, v8, v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v19

    move-object/from16 v0, v18

    move-object/from16 v1, v19

    invoke-interface {v15, v0, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
