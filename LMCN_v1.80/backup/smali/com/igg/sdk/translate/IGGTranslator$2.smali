.class Lcom/igg/sdk/translate/IGGTranslator$2;
.super Ljava/lang/Object;
.source "IGGTranslator.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/translate/IGGTranslator;->translateTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/translate/IGGTranslator;

.field final synthetic val$list:Ljava/util/List;

.field final synthetic val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/translate/IGGTranslator;Lcom/igg/sdk/translate/IGGTranslatorListener;Ljava/util/List;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 130
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslator$2;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    iput-object p3, p0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$list:Ljava/util/List;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 19
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 134
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v15

    if-eqz v15, :cond_0

    .line 135
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$list:Ljava/util/List;

    move-object/from16 v16, v0

    move-object/from16 v0, v16

    move-object/from16 v1, p1

    invoke-interface {v15, v0, v1}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    .line 174
    :goto_0
    return-void

    .line 140
    :cond_0
    :try_start_0
    new-instance v2, Lorg/json/JSONObject;

    move-object/from16 v0, p3

    invoke-direct {v2, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 141
    .local v2, "JSON":Lorg/json/JSONObject;
    const-string v15, "IGGTranslator"

    move-object/from16 v0, p3

    invoke-static {v15, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 142
    const-string v15, "error"

    invoke-virtual {v2, v15}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v15

    if-nez v15, :cond_1

    .line 143
    const-string v15, "error"

    invoke-virtual {v2, v15}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v5

    .line 144
    .local v5, "errorCode":Lorg/json/JSONObject;
    const-string v15, "message"

    invoke-virtual {v5, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v11

    .line 145
    .local v11, "message":Ljava/lang/String;
    const-string v15, "code"

    invoke-virtual {v5, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 146
    .local v3, "code":Ljava/lang/String;
    new-instance v4, Ljava/lang/Exception;

    invoke-direct {v4, v3}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    .line 147
    .local v4, "e":Ljava/lang/Exception;
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$list:Ljava/util/List;

    move-object/from16 v16, v0

    invoke-static {v3}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v17

    move/from16 v0, v17

    move-object/from16 v1, p3

    invoke-static {v4, v0, v11, v1}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v17

    invoke-interface/range {v15 .. v17}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 170
    .end local v2    # "JSON":Lorg/json/JSONObject;
    .end local v3    # "code":Ljava/lang/String;
    .end local v4    # "e":Ljava/lang/Exception;
    .end local v5    # "errorCode":Lorg/json/JSONObject;
    .end local v11    # "message":Ljava/lang/String;
    :catch_0
    move-exception v4

    .line 171
    .local v4, "e":Lorg/json/JSONException;
    invoke-virtual {v4}, Lorg/json/JSONException;->printStackTrace()V

    .line 172
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$list:Ljava/util/List;

    move-object/from16 v16, v0

    const v17, 0x186a8

    move/from16 v0, v17

    invoke-static {v4, v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v17

    invoke-interface/range {v15 .. v17}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 149
    .end local v4    # "e":Lorg/json/JSONException;
    .restart local v2    # "JSON":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    const-string v15, "data"

    invoke-virtual {v2, v15}, Lorg/json/JSONObject;->getJSONArray(Ljava/lang/String;)Lorg/json/JSONArray;

    move-result-object v7

    .line 150
    .local v7, "jsonArray":Lorg/json/JSONArray;
    new-instance v13, Ljava/util/ArrayList;

    invoke-direct {v13}, Ljava/util/ArrayList;-><init>()V

    .line 151
    .local v13, "traTextList":Ljava/util/List;, "Ljava/util/List<Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;>;"
    const/4 v6, 0x0

    .local v6, "i":I
    :goto_1
    invoke-virtual {v7}, Lorg/json/JSONArray;->length()I

    move-result v15

    if-ge v6, v15, :cond_3

    .line 152
    invoke-virtual {v7, v6}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v8

    .line 153
    .local v8, "jsonDataObject":Lorg/json/JSONObject;
    new-instance v10, Ljava/util/HashMap;

    invoke-direct {v10}, Ljava/util/HashMap;-><init>()V

    .line 154
    .local v10, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v15, "t"

    invoke-virtual {v8, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v12

    .line 155
    .local v12, "t":Ljava/lang/String;
    const-string v15, "t"

    invoke-virtual {v10, v15, v12}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 156
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    invoke-static {v15}, Lcom/igg/sdk/translate/IGGTranslator;->access$000(Lcom/igg/sdk/translate/IGGTranslator;)I

    move-result v15

    if-eqz v15, :cond_2

    .line 157
    const-string v15, "l"

    invoke-virtual {v8, v15}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    .line 158
    .local v9, "l":Ljava/lang/String;
    const-string v15, "l"

    invoke-virtual {v10, v15, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 161
    .end local v9    # "l":Ljava/lang/String;
    :cond_2
    invoke-interface {v13, v10}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 151
    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    .line 164
    .end local v8    # "jsonDataObject":Lorg/json/JSONObject;
    .end local v10    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v12    # "t":Ljava/lang/String;
    :cond_3
    new-instance v14, Lcom/igg/sdk/translate/IGGTranslationSet;

    sget-object v15, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v16, v0

    .line 165
    invoke-static/range {v16 .. v16}, Lcom/igg/sdk/translate/IGGTranslator;->access$100(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v16

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$list:Ljava/util/List;

    move-object/from16 v17, v0

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v18, v0

    invoke-static/range {v18 .. v18}, Lcom/igg/sdk/translate/IGGTranslator;->access$200(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v18

    invoke-direct/range {v14 .. v18}, Lcom/igg/sdk/translate/IGGTranslationSet;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;Ljava/lang/String;Ljava/util/List;Ljava/lang/String;)V

    .line 166
    .local v14, "translationSet":Lcom/igg/sdk/translate/IGGTranslationSet;
    invoke-virtual {v14, v13}, Lcom/igg/sdk/translate/IGGTranslationSet;->setList(Ljava/util/List;)V

    .line 167
    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$2;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    invoke-interface {v15, v14}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
