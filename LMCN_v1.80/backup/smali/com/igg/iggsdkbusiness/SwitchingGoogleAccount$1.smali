.class Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;
.super Ljava/lang/Object;
.source "SwitchingGoogleAccount.java"

# interfaces
.implements Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->switchAccount(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    .prologue
    .line 80
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;
    .param p3, "isFirstAuthorize"    # Z

    .prologue
    .line 84
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v4

    if-eqz v4, :cond_0

    .line 93
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v6

    invoke-static {v6}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 136
    :goto_0
    return-void

    .line 96
    :cond_0
    if-nez p2, :cond_1

    if-nez p3, :cond_1

    .line 98
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    const-string v6, "500"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 103
    :cond_1
    if-nez p2, :cond_2

    if-eqz p3, :cond_2

    .line 104
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    const-string v6, "500"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 110
    :cond_2
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->CheckGooglePlayServicesUtil()Z

    move-result v4

    if-eqz v4, :cond_3

    .line 112
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->sharedInstance()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v4

    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v5

    invoke-interface {v4, v5}, Lcom/igg/sdk/push/IIGGPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v1

    check-cast v1, Lcom/igg/sdk/push/IGGGCMPushNotification;

    .line 113
    .local v1, "notification":Lcom/igg/sdk/push/IGGGCMPushNotification;
    invoke-virtual {v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->uninitialize()V

    .line 118
    .end local v1    # "notification":Lcom/igg/sdk/push/IGGGCMPushNotification;
    :cond_3
    const-string v4, "loginWithGooglePlay"

    const-string v5, "\u8fd4\u56de\u4e3bactivity"

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 119
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v4

    if-eqz v4, :cond_6

    .line 121
    const-string v0, ""

    .line 122
    .local v0, "email":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getLoginType()Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v4

    sget-object v5, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    if-ne v4, v5, :cond_4

    .line 123
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v4

    sget-object v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->GoolgeLoginMail:Ljava/lang/String;

    invoke-interface {v4, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    .end local v0    # "email":Ljava/lang/String;
    check-cast v0, Ljava/lang/String;

    .line 125
    .restart local v0    # "email":Ljava/lang/String;
    :cond_4
    const-string v2, "1"

    .line 126
    .local v2, "pBind":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isHasBind()Z

    move-result v4

    if-eqz v4, :cond_5

    .line 127
    const-string v2, "1"

    .line 129
    :cond_5
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ";"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ";"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ";"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 131
    .local v3, "result":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->SuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v4, v5, v3}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 132
    const-string v4, "loginWithGooglePlay"

    invoke-static {v4, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 135
    .end local v0    # "email":Ljava/lang/String;
    .end local v2    # "pBind":Ljava/lang/String;
    .end local v3    # "result":Ljava/lang/String;
    :cond_6
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    const-string v6, "500"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0
.end method
