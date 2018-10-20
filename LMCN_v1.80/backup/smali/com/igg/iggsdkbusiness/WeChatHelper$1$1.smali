.class Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;
.super Ljava/lang/Object;
.source "WeChatHelper.java"

# interfaces
.implements Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/WeChatHelper$1;->onSuccess(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/WeChatHelper$1;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    .prologue
    .line 163
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    .locals 11
    .param p1, "success"    # Z
    .param p2, "code"    # Ljava/lang/String;
    .param p3, "description"    # Ljava/lang/String;

    .prologue
    .line 167
    if-eqz p1, :cond_0

    .line 168
    const/4 v4, 0x0

    .line 170
    .local v4, "json":Lorg/json/JSONObject;
    const/4 v7, 0x0

    .line 171
    .local v7, "nickName":Ljava/lang/String;
    :try_start_0
    sget-object v8, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v8}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v1

    .line 172
    .local v1, "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v8, "wechat_info"

    invoke-interface {v1, v8}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 173
    .local v3, "info":Ljava/lang/String;
    const-string v8, "WeChat"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "BindToWeChat info = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1

    .line 175
    :try_start_1
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 176
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v8, "nickname"

    invoke-virtual {v0, v8}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 177
    new-instance v6, Ljava/util/HashMap;

    invoke-direct {v6}, Ljava/util/HashMap;-><init>()V

    .line 178
    .local v6, "map":Ljava/util/Map;
    const-string v8, "name"

    invoke-interface {v6, v8, v7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 179
    new-instance v5, Lorg/json/JSONObject;

    invoke-direct {v5, v6}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    .line 180
    .end local v4    # "json":Lorg/json/JSONObject;
    .local v5, "json":Lorg/json/JSONObject;
    :try_start_2
    const-string v8, "WeChat"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "BindToWeChat json = "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v5}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 181
    iget-object v8, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v8, v8, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackSuccessful:Ljava/lang/String;

    invoke-virtual {v5}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v8, v9, v10}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2

    move-object v4, v5

    .line 194
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v1    # "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v3    # "info":Ljava/lang/String;
    .end local v5    # "json":Lorg/json/JSONObject;
    .end local v6    # "map":Ljava/util/Map;
    .end local v7    # "nickName":Ljava/lang/String;
    :goto_0
    return-void

    .line 183
    .restart local v1    # "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    .restart local v3    # "info":Ljava/lang/String;
    .restart local v4    # "json":Lorg/json/JSONObject;
    .restart local v7    # "nickName":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 184
    .local v2, "e":Ljava/lang/Exception;
    :goto_1
    :try_start_3
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 185
    iget-object v8, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v8, v8, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackSuccessful:Ljava/lang/String;

    const-string v10, ""

    invoke-virtual {v8, v9, v10}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1

    goto :goto_0

    .line 187
    .end local v1    # "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v2    # "e":Ljava/lang/Exception;
    .end local v3    # "info":Ljava/lang/String;
    :catch_1
    move-exception v2

    .line 188
    .restart local v2    # "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 189
    iget-object v8, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v8, v8, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackSuccessful:Ljava/lang/String;

    const-string v10, ""

    invoke-virtual {v8, v9, v10}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 192
    .end local v2    # "e":Ljava/lang/Exception;
    .end local v4    # "json":Lorg/json/JSONObject;
    .end local v7    # "nickName":Ljava/lang/String;
    :cond_0
    iget-object v8, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v8, v8, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$1;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v9, v9, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackFailed:Ljava/lang/String;

    invoke-virtual {v8, v9, p2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 183
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v1    # "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    .restart local v3    # "info":Ljava/lang/String;
    .restart local v5    # "json":Lorg/json/JSONObject;
    .restart local v6    # "map":Ljava/util/Map;
    .restart local v7    # "nickName":Ljava/lang/String;
    :catch_2
    move-exception v2

    move-object v4, v5

    .end local v5    # "json":Lorg/json/JSONObject;
    .restart local v4    # "json":Lorg/json/JSONObject;
    goto :goto_1
.end method
