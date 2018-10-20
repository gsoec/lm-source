.class public Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;
.super Ljava/lang/Object;
.source "RealNameVerificationHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;


# instance fields
.field IsWaitResponse:Z

.field RealNameCallBackFailed:Ljava/lang/String;

.field RealNameCheckCallBack:Ljava/lang/String;

.field TAG:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 28
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 29
    const-string v0, "RealName"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    .line 30
    const-string v0, "RealNameCheckCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    .line 31
    const-string v0, "RealNameCallBackFailed"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCallBackFailed:Ljava/lang/String;

    .line 32
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->IsWaitResponse:Z

    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;
    .locals 1

    .prologue
    .line 35
    sget-object v0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->instance:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    if-nez v0, :cond_0

    .line 36
    new-instance v0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->instance:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    .line 38
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->instance:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 41
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 42
    return-void
.end method

.method public CheckRealNameState()V
    .locals 2

    .prologue
    .line 81
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    const-string v1, "CheckRealNameState"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 82
    new-instance v0, Lcom/igg/sdk/realname/IGGRealNameVerification;

    invoke-direct {v0}, Lcom/igg/sdk/realname/IGGRealNameVerification;-><init>()V

    new-instance v1, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;-><init>(Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/realname/IGGRealNameVerification;->requestState(Lcom/igg/sdk/realname/IGGVerificationStateListener;)V

    .line 113
    return-void
.end method

.method LoadWebView(Ljava/lang/String;)V
    .locals 5
    .param p1, "pUrl"    # Ljava/lang/String;

    .prologue
    .line 48
    :try_start_0
    new-instance v1, Landroid/content/Intent;

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    const-class v3, Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {v1, v2, v3}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 49
    .local v1, "intent":Landroid/content/Intent;
    const-string v2, "Url"

    invoke-virtual {v1, v2, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 50
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-virtual {v2, v1}, Landroid/app/Activity;->startActivity(Landroid/content/Intent;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 55
    .end local v1    # "intent":Landroid/content/Intent;
    :goto_0
    return-void

    .line 51
    :catch_0
    move-exception v0

    .line 52
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 53
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Exception = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public OnResume()V
    .locals 2

    .prologue
    .line 115
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    const-string v1, "OnResume "

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 116
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->IsWaitResponse:Z

    .line 117
    return-void
.end method

.method public OpenRealNameAsync()V
    .locals 6

    .prologue
    .line 65
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 66
    .local v0, "gID":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    .line 67
    .local v2, "signedKey":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    .line 68
    .local v1, "mID":Ljava/lang/String;
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "http://passport.igg.com/cn/idcard.php?signed_key="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&m_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&g_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 69
    .local v3, "url":Ljava/lang/String;
    invoke-virtual {p0, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->LoadWebView(Ljava/lang/String;)V

    .line 70
    return-void
.end method

.method public OpenRealNameSync()V
    .locals 6

    .prologue
    .line 73
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 74
    .local v0, "gID":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    .line 75
    .local v2, "signedKey":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    .line 76
    .local v1, "mID":Ljava/lang/String;
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "http://passport.igg.com/cn/idcard_sync.php?signed_key="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&m_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&g_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 77
    .local v3, "url":Ljava/lang/String;
    invoke-virtual {p0, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->LoadWebView(Ljava/lang/String;)V

    .line 78
    return-void
.end method

.method OpenRealNameUrlByWebView()V
    .locals 6

    .prologue
    .line 57
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 58
    .local v0, "gID":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    .line 59
    .local v2, "signedKey":Ljava/lang/String;
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    .line 60
    .local v1, "mID":Ljava/lang/String;
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getRealNameVerificationURL()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "?signed_key="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&m_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&g_id="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 61
    .local v3, "url":Ljava/lang/String;
    invoke-virtual {p0, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->LoadWebView(Ljava/lang/String;)V

    .line 62
    return-void
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 44
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method
