.class Lcom/igg/sdk/account/IGGAccountBind$2;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindAssessKeytoDevice(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 234
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$2;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$2;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 13
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    .line 238
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v9

    if-eqz v9, :cond_0

    .line 239
    iget-object v9, p0, Lcom/igg/sdk/account/IGGAccountBind$2;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;

    const/4 v10, 0x0

    const-string v11, "400"

    const-string v12, ""

    invoke-interface {v9, v10, v11, v12}, Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 327
    :goto_0
    return-void

    .line 244
    :cond_0
    const-string v2, ""

    .line 246
    .local v2, "codeDescription":Ljava/lang/String;
    :try_start_0
    const-string v9, "errCode"

    invoke-virtual {p2, v9}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 247
    .local v4, "errCode":Ljava/lang/String;
    const-string v9, "bindAssessKeytoDevice"

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "errCode:"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v9, v10}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 248
    invoke-static {v4}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    .line 249
    .local v1, "code":I
    const/4 v5, 0x0

    .line 251
    .local v5, "flag":Z
    sparse-switch v1, :sswitch_data_0

    .line 315
    invoke-static {v1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0

    .line 319
    .local v0, "businessCode":Ljava/lang/String;
    :goto_1
    iget-object v9, p0, Lcom/igg/sdk/account/IGGAccountBind$2;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;

    invoke-interface {v9, v5, v0, v2}, Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 320
    .end local v0    # "businessCode":Ljava/lang/String;
    .end local v1    # "code":I
    .end local v4    # "errCode":Ljava/lang/String;
    .end local v5    # "flag":Z
    :catch_0
    move-exception v3

    .line 321
    .local v3, "e":Lorg/json/JSONException;
    invoke-virtual {v3}, Lorg/json/JSONException;->printStackTrace()V

    .line 322
    const-string v9, "IGGAccountBind"

    invoke-static {v9, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 323
    const-string v0, "100016"

    .line 324
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "The errCode field is missing within the JSON object"

    .line 325
    iget-object v9, p0, Lcom/igg/sdk/account/IGGAccountBind$2;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;

    const/4 v10, 0x0

    invoke-interface {v9, v10, v0, v2}, Lcom/igg/sdk/account/IGGAccountBind$BindDeviceListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 253
    .end local v0    # "businessCode":Ljava/lang/String;
    .end local v3    # "e":Lorg/json/JSONException;
    .restart local v1    # "code":I
    .restart local v4    # "errCode":Ljava/lang/String;
    .restart local v5    # "flag":Z
    :sswitch_0
    :try_start_1
    const-string v9, "result"

    invoke-virtual {p2, v9}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v6

    .line 254
    .local v6, "json":Lorg/json/JSONObject;
    const-string v9, "0"

    invoke-virtual {v6, v9}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v8

    .line 255
    .local v8, "returnJson":Lorg/json/JSONObject;
    const-string v9, "return"

    invoke-virtual {v8, v9}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 256
    .local v7, "result":Ljava/lang/String;
    const-string v9, "bindAssessKeytoDevice"

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "check result:"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v9, v10}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 257
    if-eqz v7, :cond_1

    const-string v9, "1"

    invoke-virtual {v7, v9}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v9

    if-eqz v9, :cond_1

    .line 258
    const/4 v5, 0x1

    .line 259
    const-string v0, "1"

    .line 260
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "success"

    goto :goto_1

    .line 262
    .end local v0    # "businessCode":Ljava/lang/String;
    :cond_1
    const/4 v5, 0x0

    .line 263
    const-string v0, "0"

    .line 264
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "fail"

    .line 266
    goto :goto_1

    .line 269
    .end local v0    # "businessCode":Ljava/lang/String;
    .end local v6    # "json":Lorg/json/JSONObject;
    .end local v7    # "result":Ljava/lang/String;
    .end local v8    # "returnJson":Lorg/json/JSONObject;
    :sswitch_1
    const-string v0, "100001"

    .line 270
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "Error parameter:signed_key"

    .line 271
    goto :goto_1

    .line 274
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_2
    const-string v0, "100002"

    .line 275
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "Error parameter:b_key"

    .line 276
    goto :goto_1

    .line 279
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_3
    const-string v0, "100003"

    .line 280
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "Error parameter:s_type"

    .line 281
    goto :goto_1

    .line 284
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_4
    const-string v0, "100005"

    .line 285
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "The parameters are not supported"

    .line 286
    goto :goto_1

    .line 289
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_5
    const-string v0, "100006"

    .line 290
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "Error parameter:m_key"

    .line 291
    goto :goto_1

    .line 294
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_6
    const-string v0, "100007"

    .line 295
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "Error parameter:m_data"

    .line 296
    goto :goto_1

    .line 299
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_7
    const-string v0, "100008"

    .line 300
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "valid data:m_valid_key"

    .line 301
    goto :goto_1

    .line 304
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_8
    const-string v0, "100011"

    .line 305
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "get_iggid_by_key:iggid is empty"

    .line 306
    goto/16 :goto_1

    .line 309
    .end local v0    # "businessCode":Ljava/lang/String;
    :sswitch_9
    const-string v0, "100015"

    .line 310
    .restart local v0    # "businessCode":Ljava/lang/String;
    const-string v2, "GetMIDBy3rdId:Users already bind to igg"
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    .line 311
    const/4 v5, 0x1

    .line 312
    goto/16 :goto_1

    .line 251
    nop

    :sswitch_data_0
    .sparse-switch
        0x0 -> :sswitch_0
        0x186a1 -> :sswitch_1
        0x186a2 -> :sswitch_2
        0x186a3 -> :sswitch_3
        0x186a5 -> :sswitch_4
        0x186a6 -> :sswitch_5
        0x186a7 -> :sswitch_6
        0x186a8 -> :sswitch_7
        0x186ab -> :sswitch_8
        0x186af -> :sswitch_9
    .end sparse-switch
.end method
