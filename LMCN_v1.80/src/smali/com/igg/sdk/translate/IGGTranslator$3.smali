.class Lcom/igg/sdk/translate/IGGTranslator$3;
.super Ljava/lang/Object;
.source "IGGTranslator.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/translate/IGGTranslator;->translateNamedTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
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
.method constructor <init>(Lcom/igg/sdk/translate/IGGTranslator;Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 188
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslator$3;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$list:Ljava/util/List;

    iput-object p3, p0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 24
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 193
    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    .line 194
    .local v4, "IGGTranslationSourcelist":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$list:Ljava/util/List;

    move-object/from16 v21, v0

    invoke-interface/range {v21 .. v21}, Ljava/util/List;->size()I

    move-result v14

    .line 195
    .local v14, "len":I
    const/4 v9, 0x0

    .local v9, "i":I
    :goto_0
    if-ge v9, v14, :cond_0

    .line 196
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$list:Ljava/util/List;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    invoke-interface {v0, v9}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v21

    check-cast v21, Lcom/igg/sdk/translate/IGGTranslationSource;

    move-object/from16 v0, v21

    invoke-interface {v4, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 195
    add-int/lit8 v9, v9, 0x1

    goto :goto_0

    .line 199
    :cond_0
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v21

    if-eqz v21, :cond_1

    .line 200
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    move-object/from16 v1, p1

    invoke-interface {v0, v4, v1}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    .line 241
    :goto_1
    return-void

    .line 205
    :cond_1
    :try_start_0
    new-instance v5, Lorg/json/JSONObject;

    move-object/from16 v0, p3

    invoke-direct {v5, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 206
    .local v5, "JSON":Lorg/json/JSONObject;
    const-string v21, "IGGTranslator"

    move-object/from16 v0, v21

    move-object/from16 v1, p3

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 207
    const-string v21, "error"

    move-object/from16 v0, v21

    invoke-virtual {v5, v0}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v21

    if-nez v21, :cond_2

    .line 208
    const-string v21, "error"

    move-object/from16 v0, v21

    invoke-virtual {v5, v0}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v8

    .line 209
    .local v8, "errorCode":Lorg/json/JSONObject;
    const-string v21, "message"

    move-object/from16 v0, v21

    invoke-virtual {v8, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v16

    .line 210
    .local v16, "message":Ljava/lang/String;
    const-string v21, "code"

    move-object/from16 v0, v21

    invoke-virtual {v8, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 211
    .local v6, "code":Ljava/lang/String;
    new-instance v7, Ljava/lang/Exception;

    invoke-direct {v7, v6}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    .line 212
    .local v7, "e":Ljava/lang/Exception;
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v21, v0

    invoke-static {v6}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v22

    move/from16 v0, v22

    move-object/from16 v1, v16

    move-object/from16 v2, p3

    invoke-static {v7, v0, v1, v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v22

    move-object/from16 v0, v21

    move-object/from16 v1, v22

    invoke-interface {v0, v4, v1}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 237
    .end local v5    # "JSON":Lorg/json/JSONObject;
    .end local v6    # "code":Ljava/lang/String;
    .end local v7    # "e":Ljava/lang/Exception;
    .end local v8    # "errorCode":Lorg/json/JSONObject;
    .end local v16    # "message":Ljava/lang/String;
    :catch_0
    move-exception v7

    .line 238
    .local v7, "e":Lorg/json/JSONException;
    invoke-virtual {v7}, Lorg/json/JSONException;->printStackTrace()V

    .line 239
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v21, v0

    const v22, 0x186a8

    move/from16 v0, v22

    invoke-static {v7, v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v22

    move-object/from16 v0, v21

    move-object/from16 v1, v22

    invoke-interface {v0, v4, v1}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    goto :goto_1

    .line 215
    .end local v7    # "e":Lorg/json/JSONException;
    .restart local v5    # "JSON":Lorg/json/JSONObject;
    :cond_2
    :try_start_1
    new-instance v17, Ljava/util/HashMap;

    invoke-direct/range {v17 .. v17}, Ljava/util/HashMap;-><init>()V

    .line 216
    .local v17, "outerMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;>;"
    const-string v21, "data"

    move-object/from16 v0, v21

    invoke-virtual {v5, v0}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v11

    .line 217
    .local v11, "jsonObject":Lorg/json/JSONObject;
    invoke-virtual {v11}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v20

    .line 218
    .local v20, "x":Ljava/util/Iterator;
    :goto_2
    invoke-interface/range {v20 .. v20}, Ljava/util/Iterator;->hasNext()Z

    move-result v21

    if-eqz v21, :cond_4

    .line 219
    invoke-interface/range {v20 .. v20}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Ljava/lang/String;

    .line 220
    .local v12, "key":Ljava/lang/String;
    invoke-virtual {v11, v12}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v10

    .line 221
    .local v10, "jObject":Lorg/json/JSONObject;
    new-instance v15, Ljava/util/HashMap;

    invoke-direct {v15}, Ljava/util/HashMap;-><init>()V

    .line 222
    .local v15, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v21, "t"

    move-object/from16 v0, v21

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v18

    .line 223
    .local v18, "t":Ljava/lang/String;
    const-string v21, "t"

    move-object/from16 v0, v21

    move-object/from16 v1, v18

    invoke-virtual {v15, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 224
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v21, v0

    invoke-static/range {v21 .. v21}, Lcom/igg/sdk/translate/IGGTranslator;->access$000(Lcom/igg/sdk/translate/IGGTranslator;)I

    move-result v21

    if-eqz v21, :cond_3

    .line 225
    const-string v21, "l"

    move-object/from16 v0, v21

    invoke-virtual {v10, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v13

    .line 226
    .local v13, "l":Ljava/lang/String;
    const-string v21, "l"

    move-object/from16 v0, v21

    invoke-virtual {v15, v0, v13}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 229
    .end local v13    # "l":Ljava/lang/String;
    :cond_3
    move-object/from16 v0, v17

    invoke-virtual {v0, v12, v15}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_2

    .line 232
    .end local v10    # "jObject":Lorg/json/JSONObject;
    .end local v12    # "key":Ljava/lang/String;
    .end local v15    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v18    # "t":Ljava/lang/String;
    :cond_4
    new-instance v19, Lcom/igg/sdk/translate/IGGTranslationSet;

    sget-object v21, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NAME:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v22, v0

    .line 233
    invoke-static/range {v22 .. v22}, Lcom/igg/sdk/translate/IGGTranslator;->access$100(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v22

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v23, v0

    invoke-static/range {v23 .. v23}, Lcom/igg/sdk/translate/IGGTranslator;->access$200(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v23

    move-object/from16 v0, v19

    move-object/from16 v1, v21

    move-object/from16 v2, v22

    move-object/from16 v3, v23

    invoke-direct {v0, v1, v2, v4, v3}, Lcom/igg/sdk/translate/IGGTranslationSet;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;Ljava/lang/String;Ljava/util/List;Ljava/lang/String;)V

    .line 234
    .local v19, "translationSet":Lcom/igg/sdk/translate/IGGTranslationSet;
    move-object/from16 v0, v19

    move-object/from16 v1, v17

    invoke-virtual {v0, v1}, Lcom/igg/sdk/translate/IGGTranslationSet;->setMap(Ljava/util/HashMap;)V

    .line 235
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$3;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    move-object/from16 v1, v19

    invoke-interface {v0, v1}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_1
.end method
