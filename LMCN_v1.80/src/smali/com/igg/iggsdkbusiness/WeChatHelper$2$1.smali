.class Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;
.super Ljava/lang/Object;
.source "WeChatHelper.java"

# interfaces
.implements Lcom/igg/sdk/account/LoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/WeChatHelper$2;->onSuccess(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/WeChatHelper$2;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    .prologue
    .line 222
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLocalSessionExpired(ZLcom/igg/sdk/account/IGGAccountSession;)V
    .locals 0
    .param p1, "isExpired"    # Z
    .param p2, "lastLoginSession"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 269
    return-void
.end method

.method public onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V
    .locals 9
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 225
    if-nez p2, :cond_1

    .line 226
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper;->WeChatLoginCallBackFailed:Ljava/lang/String;

    const-string v8, ""

    invoke-virtual {v6, v7, v8}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 263
    :cond_0
    :goto_0
    return-void

    .line 230
    :cond_1
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v6

    if-eqz v6, :cond_2

    .line 239
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper;->WeChatLoginCallBackFailed:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v8

    invoke-static {v8}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v6, v7, v8}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 242
    :cond_2
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v6

    if-eqz v6, :cond_0

    .line 243
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v1

    .line 244
    .local v1, "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v6, "wechat_info"

    invoke-interface {v1, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 246
    .local v3, "info":Ljava/lang/String;
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 247
    .local v0, "JSON":Lorg/json/JSONObject;
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    const-string v7, "nickname"

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->email:Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 254
    .end local v0    # "JSON":Lorg/json/JSONObject;
    :goto_1
    const-string v4, "0"

    .line 255
    .local v4, "pBind":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isHasBind()Z

    move-result v6

    if-eqz v6, :cond_3

    .line 256
    const-string v4, "1"

    .line 258
    :cond_3
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, ";"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, ";"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->email:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, ";"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    .line 260
    .local v5, "result":Ljava/lang/String;
    const-string v6, "WeChat"

    invoke-static {v6, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 261
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;->this$1:Lcom/igg/iggsdkbusiness/WeChatHelper$2;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v7, v7, Lcom/igg/iggsdkbusiness/WeChatHelper;->WechatLoginCallBackSuccessful:Ljava/lang/String;

    const-string v8, ""

    invoke-virtual {v6, v7, v8}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 249
    .end local v4    # "pBind":Ljava/lang/String;
    .end local v5    # "result":Ljava/lang/String;
    :catch_0
    move-exception v2

    .line 250
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_1
.end method
