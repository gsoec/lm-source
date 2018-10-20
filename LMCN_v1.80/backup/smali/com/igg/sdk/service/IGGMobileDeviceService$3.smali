.class Lcom/igg/sdk/service/IGGMobileDeviceService$3;
.super Ljava/lang/Object;
.source "IGGMobileDeviceService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGMobileDeviceService;->loadMessageTypes(Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGMobileDeviceService;Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGMobileDeviceService;

    .prologue
    .line 129
    iput-object p1, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->this$0:Lcom/igg/sdk/service/IGGMobileDeviceService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 15
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 135
    const/4 v12, 0x0

    invoke-virtual/range {p3 .. p3}, Ljava/lang/String;->length()I

    move-result v13

    add-int/lit8 v13, v13, -0x20

    move-object/from16 v0, p3

    invoke-virtual {v0, v12, v13}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v7

    .line 139
    .local v7, "rawJSON":Ljava/lang/String;
    :try_start_0
    new-instance v5, Lorg/json/JSONObject;

    invoke-direct {v5, v7}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 141
    .local v5, "jsonObject":Lorg/json/JSONObject;
    const-string v12, "errCode"

    invoke-virtual {v5, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 142
    .local v2, "errCode":Ljava/lang/String;
    if-eqz v2, :cond_0

    const-string v12, "0"

    invoke-virtual {v2, v12}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v12

    if-nez v12, :cond_1

    .line 143
    :cond_0
    iget-object v12, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    const/4 v13, 0x0

    invoke-static {v13}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v13

    const/4 v14, 0x0

    invoke-interface {v12, v13, v14}, Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;->onMessageTypesLoadFinished(Lcom/igg/sdk/error/IGGError;[Ljava/lang/String;)V

    .line 174
    .end local v2    # "errCode":Ljava/lang/String;
    .end local v5    # "jsonObject":Lorg/json/JSONObject;
    :goto_0
    return-void

    .line 147
    .restart local v2    # "errCode":Ljava/lang/String;
    .restart local v5    # "jsonObject":Lorg/json/JSONObject;
    :cond_1
    const-string v12, "result"

    invoke-virtual {v5, v12}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v9

    .line 148
    .local v9, "resultObject":Lorg/json/JSONObject;
    const-string v12, "return"

    invoke-virtual {v9, v12}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v10

    .line 150
    .local v10, "returnObject":Lorg/json/JSONObject;
    const-string v12, "success"

    invoke-virtual {v10, v12}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 151
    .local v8, "res":Ljava/lang/String;
    if-eqz v8, :cond_2

    const-string v12, "1"

    invoke-virtual {v8, v12}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v12

    if-nez v12, :cond_3

    .line 152
    :cond_2
    iget-object v12, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    const/4 v13, 0x0

    invoke-static {v13}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v13

    const/4 v14, 0x0

    invoke-interface {v12, v13, v14}, Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;->onMessageTypesLoadFinished(Lcom/igg/sdk/error/IGGError;[Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 170
    .end local v2    # "errCode":Ljava/lang/String;
    .end local v5    # "jsonObject":Lorg/json/JSONObject;
    .end local v8    # "res":Ljava/lang/String;
    .end local v9    # "resultObject":Lorg/json/JSONObject;
    .end local v10    # "returnObject":Lorg/json/JSONObject;
    :catch_0
    move-exception v1

    .line 171
    .local v1, "e":Lorg/json/JSONException;
    iget-object v12, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    invoke-static {v1}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v13

    const/4 v14, 0x0

    invoke-interface {v12, v13, v14}, Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;->onMessageTypesLoadFinished(Lcom/igg/sdk/error/IGGError;[Ljava/lang/String;)V

    .line 172
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    goto :goto_0

    .line 156
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v2    # "errCode":Ljava/lang/String;
    .restart local v5    # "jsonObject":Lorg/json/JSONObject;
    .restart local v8    # "res":Ljava/lang/String;
    .restart local v9    # "resultObject":Lorg/json/JSONObject;
    .restart local v10    # "returnObject":Lorg/json/JSONObject;
    :cond_3
    :try_start_1
    const-string v12, "types"

    invoke-virtual {v10, v12}, Lorg/json/JSONObject;->getJSONArray(Ljava/lang/String;)Lorg/json/JSONArray;

    move-result-object v4

    .line 157
    .local v4, "jsonArray":Lorg/json/JSONArray;
    if-eqz v4, :cond_4

    invoke-virtual {v4}, Lorg/json/JSONArray;->length()I

    move-result v12

    if-nez v12, :cond_5

    .line 158
    :cond_4
    iget-object v12, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    const/4 v13, 0x0

    invoke-static {v13}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;)Lcom/igg/sdk/error/IGGError;

    move-result-object v13

    const/4 v14, 0x0

    invoke-interface {v12, v13, v14}, Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;->onMessageTypesLoadFinished(Lcom/igg/sdk/error/IGGError;[Ljava/lang/String;)V

    goto :goto_0

    .line 162
    :cond_5
    invoke-virtual {v4}, Lorg/json/JSONArray;->length()I

    move-result v6

    .line 164
    .local v6, "length":I
    new-array v11, v6, [Ljava/lang/String;

    .line 165
    .local v11, "typesArray":[Ljava/lang/String;
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_1
    if-ge v3, v6, :cond_6

    .line 166
    invoke-virtual {v4, v3}, Lorg/json/JSONArray;->getString(I)Ljava/lang/String;

    move-result-object v12

    aput-object v12, v11, v3

    .line 165
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .line 169
    :cond_6
    iget-object v12, p0, Lcom/igg/sdk/service/IGGMobileDeviceService$3;->val$listener:Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;

    move-object/from16 v0, p1

    invoke-interface {v12, v0, v11}, Lcom/igg/sdk/service/IGGMobileDeviceService$MessageTypesListener;->onMessageTypesLoadFinished(Lcom/igg/sdk/error/IGGError;[Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
