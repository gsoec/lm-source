.class Lcom/igg/sdk/account/IGGAccountBind$1;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->checkDeviceIDBind(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$deceviceID:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 167
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$deceviceID:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 12
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    .line 171
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v8

    if-eqz v8, :cond_0

    .line 172
    iget-object v8, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    const/4 v9, 0x0

    const-string v10, "400"

    const-string v11, ""

    invoke-interface {v8, v9, v10, v11}, Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 203
    :goto_0
    return-void

    .line 177
    :cond_0
    const-string v2, ""

    .line 179
    .local v2, "codeDescription":Ljava/lang/String;
    :try_start_0
    const-string v8, "errCode"

    invoke-virtual {p2, v8}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 180
    .local v4, "errCode":Ljava/lang/String;
    const-string v8, "bindAssessKeytoDevice"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "errCode:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 181
    invoke-static {v4}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    .line 182
    .local v1, "code":I
    if-nez v1, :cond_2

    .line 183
    const-string v8, "result"

    invoke-virtual {p2, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v5

    .line 184
    .local v5, "json":Lorg/json/JSONObject;
    const-string v8, "0"

    invoke-virtual {v5, v8}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v7

    .line 185
    .local v7, "returnJson":Lorg/json/JSONObject;
    const-string v8, "return"

    invoke-virtual {v7, v8}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 186
    .local v6, "result":Ljava/lang/String;
    const-string v8, "bindAssessKeytoDevice"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "check result:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 187
    if-eqz v6, :cond_1

    const-string v8, "0"

    invoke-virtual {v6, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    .line 188
    iget-object v8, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    const/4 v9, 0x1

    const-string v10, "0"

    iget-object v11, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$deceviceID:Ljava/lang/String;

    invoke-interface {v8, v9, v10, v11}, Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 196
    .end local v1    # "code":I
    .end local v4    # "errCode":Ljava/lang/String;
    .end local v5    # "json":Lorg/json/JSONObject;
    .end local v6    # "result":Ljava/lang/String;
    .end local v7    # "returnJson":Lorg/json/JSONObject;
    :catch_0
    move-exception v3

    .line 197
    .local v3, "e":Lorg/json/JSONException;
    invoke-virtual {v3}, Lorg/json/JSONException;->printStackTrace()V

    .line 198
    const-string v8, "IGGAccountBind"

    invoke-static {v8, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 199
    const-string v0, "401"

    .line 200
    .local v0, "businessCode":Ljava/lang/String;
    const-string v2, "The errCode field is missing within the JSON object"

    .line 201
    iget-object v8, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    const/4 v9, 0x0

    invoke-interface {v8, v9, v0, v2}, Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 190
    .end local v0    # "businessCode":Ljava/lang/String;
    .end local v3    # "e":Lorg/json/JSONException;
    .restart local v1    # "code":I
    .restart local v4    # "errCode":Ljava/lang/String;
    .restart local v5    # "json":Lorg/json/JSONObject;
    .restart local v6    # "result":Ljava/lang/String;
    .restart local v7    # "returnJson":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v8, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    const/4 v9, 0x0

    const-string v10, "1"

    invoke-interface {v8, v9, v10, v6}, Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 193
    .end local v5    # "json":Lorg/json/JSONObject;
    .end local v6    # "result":Ljava/lang/String;
    .end local v7    # "returnJson":Lorg/json/JSONObject;
    :cond_2
    const-string v2, "server error"

    .line 194
    iget-object v8, p0, Lcom/igg/sdk/account/IGGAccountBind$1;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;

    const/4 v9, 0x0

    const-string v10, "401"

    invoke-interface {v8, v9, v10, v2}, Lcom/igg/sdk/account/IGGAccountBind$checkDeviceIDBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
