.class Lcom/igg/sdk/translate/IGGTranslator$1;
.super Ljava/lang/Object;
.source "IGGTranslator.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/translate/IGGTranslator;->translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/translate/IGGTranslator;

.field final synthetic val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

.field final synthetic val$translationSource:Lcom/igg/sdk/translate/IGGTranslationSource;


# direct methods
.method constructor <init>(Lcom/igg/sdk/translate/IGGTranslator;Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 70
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslator$1;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$translationSource:Lcom/igg/sdk/translate/IGGTranslationSource;

    iput-object p3, p0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 17
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 74
    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    .line 75
    .local v8, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$translationSource:Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-interface {v8, v14}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 77
    invoke-virtual/range {p1 .. p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v14

    if-eqz v14, :cond_0

    .line 78
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    move-object/from16 v0, p1

    invoke-interface {v14, v8, v0}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    .line 114
    :goto_0
    return-void

    .line 83
    :cond_0
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    move-object/from16 v0, p3

    invoke-direct {v1, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 84
    .local v1, "JSON":Lorg/json/JSONObject;
    const-string v14, "IGGTranslator"

    move-object/from16 v0, p3

    invoke-static {v14, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 85
    const-string v14, "error"

    invoke-virtual {v1, v14}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v14

    if-nez v14, :cond_1

    .line 86
    const-string v14, "error"

    invoke-virtual {v1, v14}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v4

    .line 87
    .local v4, "errorCode":Lorg/json/JSONObject;
    const-string v14, "message"

    invoke-virtual {v4, v14}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v10

    .line 88
    .local v10, "message":Ljava/lang/String;
    const-string v14, "code"

    invoke-virtual {v4, v14}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 89
    .local v2, "code":Ljava/lang/String;
    new-instance v3, Ljava/lang/Exception;

    invoke-direct {v3, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    .line 90
    .local v3, "e":Ljava/lang/Exception;
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    invoke-static {v2}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v15

    move-object/from16 v0, p3

    invoke-static {v3, v15, v10, v0}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;ILjava/lang/String;Ljava/lang/Object;)Lcom/igg/sdk/error/IGGError;

    move-result-object v15

    invoke-interface {v14, v8, v15}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 110
    .end local v1    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "code":Ljava/lang/String;
    .end local v3    # "e":Ljava/lang/Exception;
    .end local v4    # "errorCode":Lorg/json/JSONObject;
    .end local v10    # "message":Ljava/lang/String;
    :catch_0
    move-exception v3

    .line 111
    .local v3, "e":Lorg/json/JSONException;
    invoke-virtual {v3}, Lorg/json/JSONException;->printStackTrace()V

    .line 112
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    const v15, 0x186a8

    invoke-static {v3, v15}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v15

    invoke-interface {v14, v8, v15}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V

    goto :goto_0

    .line 92
    .end local v3    # "e":Lorg/json/JSONException;
    .restart local v1    # "JSON":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    const-string v14, "data"

    invoke-virtual {v1, v14}, Lorg/json/JSONObject;->getJSONArray(Ljava/lang/String;)Lorg/json/JSONArray;

    move-result-object v5

    .line 93
    .local v5, "jsonArray":Lorg/json/JSONArray;
    const/4 v14, 0x0

    invoke-virtual {v5, v14}, Lorg/json/JSONArray;->getJSONObject(I)Lorg/json/JSONObject;

    move-result-object v6

    .line 94
    .local v6, "jsonDataObject":Lorg/json/JSONObject;
    const-string v14, "t"

    invoke-virtual {v6, v14}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v11

    .line 95
    .local v11, "t":Ljava/lang/String;
    new-instance v9, Ljava/util/HashMap;

    invoke-direct {v9}, Ljava/util/HashMap;-><init>()V

    .line 96
    .local v9, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v14, "t"

    invoke-virtual {v9, v14, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 97
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    invoke-static {v14}, Lcom/igg/sdk/translate/IGGTranslator;->access$000(Lcom/igg/sdk/translate/IGGTranslator;)I

    move-result v14

    if-eqz v14, :cond_2

    .line 98
    const-string v14, "l"

    invoke-virtual {v6, v14}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 99
    .local v7, "l":Ljava/lang/String;
    const-string v14, "l"

    invoke-virtual {v9, v14, v7}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 102
    .end local v7    # "l":Ljava/lang/String;
    :cond_2
    new-instance v13, Lcom/igg/sdk/translate/IGGTranslationSet;

    sget-object v14, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    .line 103
    invoke-static {v15}, Lcom/igg/sdk/translate/IGGTranslator;->access$100(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v15

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->this$0:Lcom/igg/sdk/translate/IGGTranslator;

    move-object/from16 v16, v0

    invoke-static/range {v16 .. v16}, Lcom/igg/sdk/translate/IGGTranslator;->access$200(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;

    move-result-object v16

    move-object/from16 v0, v16

    invoke-direct {v13, v14, v15, v8, v0}, Lcom/igg/sdk/translate/IGGTranslationSet;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;Ljava/lang/String;Ljava/util/List;Ljava/lang/String;)V

    .line 104
    .local v13, "translationSet":Lcom/igg/sdk/translate/IGGTranslationSet;
    new-instance v12, Ljava/util/ArrayList;

    invoke-direct {v12}, Ljava/util/ArrayList;-><init>()V

    .line 105
    .local v12, "traTextList":Ljava/util/List;, "Ljava/util/List<Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;>;"
    invoke-interface {v12, v9}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 107
    invoke-virtual {v13, v12}, Lcom/igg/sdk/translate/IGGTranslationSet;->setList(Ljava/util/List;)V

    .line 108
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/sdk/translate/IGGTranslator$1;->val$listener:Lcom/igg/sdk/translate/IGGTranslatorListener;

    invoke-interface {v14, v13}, Lcom/igg/sdk/translate/IGGTranslatorListener;->onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
