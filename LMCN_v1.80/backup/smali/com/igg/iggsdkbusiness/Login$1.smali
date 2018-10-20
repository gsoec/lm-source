.class Lcom/igg/iggsdkbusiness/Login$1;
.super Ljava/lang/Object;
.source "Login.java"

# interfaces
.implements Lcom/igg/sdk/account/LoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Login;->AutoLogin()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Login;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Login;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Login;

    .prologue
    .line 84
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLocalSessionExpired(ZLcom/igg/sdk/account/IGGAccountSession;)V
    .locals 1
    .param p1, "isExpired"    # Z
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 91
    const/4 v0, 0x1

    if-ne p1, v0, :cond_0

    .line 94
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/Login;->GuestLogin()V

    .line 96
    :cond_0
    return-void
.end method

.method public onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V
    .locals 13
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 102
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v10

    if-eqz v10, :cond_0

    .line 111
    iget-object v10, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, v11, Lcom/igg/iggsdkbusiness/Login;->AutoLoginFailedCallBack:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v12

    invoke-static {v12}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v12

    invoke-virtual {v10, v11, v12}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 205
    :goto_0
    return-void

    .line 115
    :cond_0
    if-nez p2, :cond_1

    .line 117
    iget-object v10, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, v11, Lcom/igg/iggsdkbusiness/Login;->AutoLoginFailedCallBack:Ljava/lang/String;

    iget-object v12, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v12, v12, Lcom/igg/iggsdkbusiness/Login;->StringAutoLoginNull:Ljava/lang/String;

    invoke-virtual {v10, v11, v12}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 118
    const-string v10, "AutoLogin"

    const-string v11, "AutoLoginFailedCallBack session == null"

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 124
    :cond_1
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v10

    if-eqz v10, :cond_b

    .line 136
    const-string v8, ""

    .line 137
    .local v8, "result":Ljava/lang/String;
    const-string v4, ""

    .line 138
    .local v4, "email":Ljava/lang/String;
    const-string v5, ""

    .line 139
    .local v5, "fb_name":Ljava/lang/String;
    const-string v9, ""

    .line 140
    .local v9, "wechat_name":Ljava/lang/String;
    const-string v7, "0"

    .line 141
    .local v7, "pBind":Ljava/lang/String;
    const-string v1, ""

    .line 142
    .local v1, "bindName":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isHasBind()Z

    move-result v10

    if-eqz v10, :cond_2

    .line 143
    const-string v7, "1"

    .line 144
    :cond_2
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v10

    sget-object v11, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v10, v11, :cond_3

    .line 145
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->GoolgeLoginMail:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    .end local v4    # "email":Ljava/lang/String;
    check-cast v4, Ljava/lang/String;

    .line 146
    .restart local v4    # "email":Ljava/lang/String;
    const-string v5, ""

    .line 147
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "bindName":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 148
    .restart local v1    # "bindName":Ljava/lang/String;
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v11

    invoke-virtual {v11}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 149
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 196
    :goto_1
    iget-object v10, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, v11, Lcom/igg/iggsdkbusiness/Login;->AutoLoginSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v10, v11, v8}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 197
    const-string v10, "SDK"

    invoke-static {v10, v8}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 198
    const-string v10, "SDK"

    const-string v11, "AutoLoginSuccessfulCallBack"

    invoke-static {v10, v11}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 150
    :cond_3
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v10

    sget-object v11, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->Facebook:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v10, v11, :cond_7

    .line 151
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->OldLoginMailTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    .end local v4    # "email":Ljava/lang/String;
    check-cast v4, Ljava/lang/String;

    .line 152
    .restart local v4    # "email":Ljava/lang/String;
    if-eqz v4, :cond_4

    const-string v10, ""

    invoke-virtual {v4, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_4

    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v10

    if-nez v10, :cond_6

    .line 154
    :cond_4
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    .end local v4    # "email":Ljava/lang/String;
    check-cast v4, Ljava/lang/String;

    .line 155
    .restart local v4    # "email":Ljava/lang/String;
    if-eqz v4, :cond_5

    const-string v10, ""

    invoke-virtual {v4, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_5

    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v10

    if-nez v10, :cond_6

    .line 156
    :cond_5
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    .end local v4    # "email":Ljava/lang/String;
    check-cast v4, Ljava/lang/String;

    .line 159
    .restart local v4    # "email":Ljava/lang/String;
    :cond_6
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    .end local v5    # "fb_name":Ljava/lang/String;
    check-cast v5, Ljava/lang/String;

    .line 160
    .restart local v5    # "fb_name":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "bindName":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 161
    .restart local v1    # "bindName":Ljava/lang/String;
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v11

    invoke-virtual {v11}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 162
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    goto/16 :goto_1

    .line 163
    :cond_7
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v10

    sget-object v11, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->WECHAT:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v10, v11, :cond_8

    .line 164
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v2

    .line 165
    .local v2, "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v10, "wechat_info"

    invoke-interface {v2, v10}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 167
    .local v6, "info":Ljava/lang/String;
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, v6}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 168
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v10, "nickname"

    invoke-virtual {v0, v10}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v4

    .line 173
    .end local v0    # "JSON":Lorg/json/JSONObject;
    :goto_2
    move-object v9, v4

    .line 174
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "bindName":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 179
    .restart local v1    # "bindName":Ljava/lang/String;
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 180
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 181
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v11

    invoke-virtual {v11}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 183
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 184
    goto/16 :goto_1

    .line 170
    :catch_0
    move-exception v3

    .line 171
    .local v3, "e":Ljava/lang/Exception;
    invoke-virtual {v3}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_2

    .line 187
    .end local v2    # "data":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v3    # "e":Ljava/lang/Exception;
    .end local v6    # "info":Ljava/lang/String;
    :cond_8
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "bindName":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 188
    .restart local v1    # "bindName":Ljava/lang/String;
    if-eqz v1, :cond_9

    const-string v10, ""

    invoke-virtual {v1, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_9

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v10

    if-nez v10, :cond_a

    .line 189
    :cond_9
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v10

    sget-object v11, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v10, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "bindName":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 190
    .restart local v1    # "bindName":Ljava/lang/String;
    :cond_a
    const-string v4, ""

    .line 192
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v11

    invoke-virtual {v11}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    .line 193
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v11

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, ";"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    goto/16 :goto_1

    .line 201
    .end local v1    # "bindName":Ljava/lang/String;
    .end local v4    # "email":Ljava/lang/String;
    .end local v5    # "fb_name":Ljava/lang/String;
    .end local v7    # "pBind":Ljava/lang/String;
    .end local v8    # "result":Ljava/lang/String;
    .end local v9    # "wechat_name":Ljava/lang/String;
    :cond_b
    iget-object v10, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v11, v11, Lcom/igg/iggsdkbusiness/Login;->AutoLoginFailedCallBack:Ljava/lang/String;

    iget-object v12, p0, Lcom/igg/iggsdkbusiness/Login$1;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v12, v12, Lcom/igg/iggsdkbusiness/Login;->StringAutoLoginFailed:Ljava/lang/String;

    invoke-virtual {v10, v11, v12}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0
.end method
