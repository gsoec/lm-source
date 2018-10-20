.class Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;
.super Ljava/lang/Object;
.source "IGGAccountTransferAgent.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;->registrationOf(Ljava/lang/String;Lcom/igg/sdk/account/transfer/IGGAccountTransferParticipator;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

.field final synthetic val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

.field final synthetic val$transferToken:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    .prologue
    .line 129
    iput-object p1, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->this$0:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent;

    iput-object p2, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    iput-object p3, p0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$transferToken:Ljava/lang/String;

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
    .line 133
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v19

    if-eqz v19, :cond_0

    .line 134
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v19, v0

    const/16 v20, 0x0

    new-instance v21, Ljava/lang/Exception;

    const-string v22, "404"

    invoke-direct/range {v21 .. v22}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static/range {v21 .. v21}, Lcom/igg/sdk/error/IGGError;->remoteError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v21

    invoke-interface/range {v19 .. v21}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V

    .line 178
    :goto_0
    return-void

    .line 138
    :cond_0
    const/16 v19, 0x0

    invoke-virtual/range {p3 .. p3}, Ljava/lang/String;->length()I

    move-result v20

    add-int/lit8 v20, v20, -0x20

    move-object/from16 v0, p3

    move/from16 v1, v19

    move/from16 v2, v20

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v16

    .line 139
    .local v16, "result":Ljava/lang/String;
    new-instance v14, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;

    invoke-direct {v14}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;-><init>()V

    .line 141
    .local v14, "profile":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;
    :try_start_0
    const-string v19, "IGGAccountTransferAgent"

    new-instance v20, Ljava/lang/StringBuilder;

    invoke-direct/range {v20 .. v20}, Ljava/lang/StringBuilder;-><init>()V

    const-string v21, "registrationOf result:"

    invoke-virtual/range {v20 .. v21}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v20

    move-object/from16 v0, v20

    move-object/from16 v1, v16

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v20

    invoke-virtual/range {v20 .. v20}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v20

    invoke-static/range {v19 .. v20}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 142
    new-instance v4, Lorg/json/JSONObject;

    move-object/from16 v0, v16

    invoke-direct {v4, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 143
    .local v4, "JSON":Lorg/json/JSONObject;
    const-string v19, "errCode"

    move-object/from16 v0, v19

    invoke-virtual {v4, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 145
    .local v6, "errCode":Ljava/lang/String;
    const-string v19, "0"

    move-object/from16 v0, v19

    invoke-virtual {v6, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v19

    if-eqz v19, :cond_2

    .line 146
    const-string v19, "result"

    move-object/from16 v0, v19

    invoke-virtual {v4, v0}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v9

    .line 147
    .local v9, "jsObject":Lorg/json/JSONObject;
    const-string v19, "m_transfer_data"

    move-object/from16 v0, v19

    invoke-virtual {v9, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v17

    .line 148
    .local v17, "str":Ljava/lang/String;
    new-instance v10, Lorg/json/JSONObject;

    move-object/from16 v0, v17

    invoke-direct {v10, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 149
    .local v10, "jsonObject":Lorg/json/JSONObject;
    const-string v19, "name"

    move-object/from16 v0, v19

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v13

    .line 150
    .local v13, "name":Ljava/lang/String;
    const-string v19, "iggid"

    move-object/from16 v0, v19

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 151
    .local v3, "IGGId":Ljava/lang/String;
    const-string v19, "version"

    move-object/from16 v0, v19

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v18

    .line 152
    .local v18, "version":I
    move/from16 v0, v18

    invoke-virtual {v14, v0}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->setVersion(I)V

    .line 153
    invoke-virtual {v14, v13}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->setName(Ljava/lang/String;)V

    .line 154
    invoke-virtual {v14, v3}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->setIGGId(Ljava/lang/String;)V

    .line 155
    new-instance v12, Ljava/util/HashMap;

    invoke-direct {v12}, Ljava/util/HashMap;-><init>()V

    .line 157
    .local v12, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v19, "extra"

    move-object/from16 v0, v19

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v8

    .line 158
    .local v8, "jObject":Lorg/json/JSONObject;
    invoke-virtual {v8}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v7

    .local v7, "iterator":Ljava/util/Iterator;, "Ljava/util/Iterator<Ljava/lang/String;>;"
    :goto_1
    invoke-interface {v7}, Ljava/util/Iterator;->hasNext()Z

    move-result v19

    if-eqz v19, :cond_1

    .line 159
    invoke-interface {v7}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Ljava/lang/String;

    .line 160
    .local v11, "key":Ljava/lang/String;
    const-string v19, "registrationOf"

    move-object/from16 v0, v19

    invoke-static {v0, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 161
    const-string v19, "registrationOf"

    invoke-virtual {v8, v11}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v20

    invoke-static/range {v19 .. v20}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 162
    invoke-virtual {v8, v11}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v19

    move-object/from16 v0, v19

    invoke-virtual {v12, v11, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 173
    .end local v3    # "IGGId":Ljava/lang/String;
    .end local v4    # "JSON":Lorg/json/JSONObject;
    .end local v6    # "errCode":Ljava/lang/String;
    .end local v7    # "iterator":Ljava/util/Iterator;, "Ljava/util/Iterator<Ljava/lang/String;>;"
    .end local v8    # "jObject":Lorg/json/JSONObject;
    .end local v9    # "jsObject":Lorg/json/JSONObject;
    .end local v10    # "jsonObject":Lorg/json/JSONObject;
    .end local v11    # "key":Ljava/lang/String;
    .end local v12    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v13    # "name":Ljava/lang/String;
    .end local v17    # "str":Ljava/lang/String;
    .end local v18    # "version":I
    :catch_0
    move-exception v5

    .line 174
    .local v5, "e":Lorg/json/JSONException;
    invoke-virtual {v5}, Lorg/json/JSONException;->printStackTrace()V

    .line 175
    new-instance v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$transferToken:Ljava/lang/String;

    move-object/from16 v19, v0

    const/16 v20, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v20

    invoke-direct {v15, v0, v1, v14}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    .line 176
    .local v15, "registration":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    move-object/from16 v1, p1

    invoke-interface {v0, v15, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V

    goto/16 :goto_0

    .line 165
    .end local v5    # "e":Lorg/json/JSONException;
    .end local v15    # "registration":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    .restart local v3    # "IGGId":Ljava/lang/String;
    .restart local v4    # "JSON":Lorg/json/JSONObject;
    .restart local v6    # "errCode":Ljava/lang/String;
    .restart local v7    # "iterator":Ljava/util/Iterator;, "Ljava/util/Iterator<Ljava/lang/String;>;"
    .restart local v8    # "jObject":Lorg/json/JSONObject;
    .restart local v9    # "jsObject":Lorg/json/JSONObject;
    .restart local v10    # "jsonObject":Lorg/json/JSONObject;
    .restart local v12    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .restart local v13    # "name":Ljava/lang/String;
    .restart local v17    # "str":Ljava/lang/String;
    .restart local v18    # "version":I
    :cond_1
    :try_start_1
    invoke-virtual {v14, v12}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;->setExtra(Ljava/util/HashMap;)V

    .line 167
    new-instance v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$transferToken:Ljava/lang/String;

    move-object/from16 v19, v0

    const/16 v20, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v20

    invoke-direct {v15, v0, v1, v14}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    .line 168
    .restart local v15    # "registration":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    move-object/from16 v1, p1

    invoke-interface {v0, v15, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V

    goto/16 :goto_0

    .line 170
    .end local v3    # "IGGId":Ljava/lang/String;
    .end local v7    # "iterator":Ljava/util/Iterator;, "Ljava/util/Iterator<Ljava/lang/String;>;"
    .end local v8    # "jObject":Lorg/json/JSONObject;
    .end local v9    # "jsObject":Lorg/json/JSONObject;
    .end local v10    # "jsonObject":Lorg/json/JSONObject;
    .end local v12    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v13    # "name":Ljava/lang/String;
    .end local v15    # "registration":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    .end local v17    # "str":Ljava/lang/String;
    .end local v18    # "version":I
    :cond_2
    new-instance v15, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$transferToken:Ljava/lang/String;

    move-object/from16 v19, v0

    const/16 v20, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v20

    invoke-direct {v15, v0, v1, v14}, Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;-><init>(Ljava/lang/String;Ljava/util/Date;Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistrationProfile;)V

    .line 171
    .restart local v15    # "registration":Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$2;->val$listener:Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    move-object/from16 v1, p1

    invoke-interface {v0, v15, v1}, Lcom/igg/sdk/account/transfer/IGGAccountTransferAgent$IGGAccountTransferRegistrationListener;->onCompleted(Lcom/igg/sdk/account/transfer/IGGAccountTransferRegistration;Lcom/igg/sdk/error/IGGError;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
