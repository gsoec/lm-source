.class public Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;
.super Ljava/lang/Object;
.source "FacebookHelper.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;
.implements Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;


# static fields
.field public static BindNameTag:Ljava/lang/String;

.field public static LoginMailTag:Ljava/lang/String;

.field public static OldLoginMailTag:Ljava/lang/String;

.field private static instance:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

.field static shareDialog:Lcom/facebook/share/widget/ShareDialog;


# instance fields
.field ClearFacebookSessionCallBack:Ljava/lang/String;

.field FacebookBindFailedCallBack:Ljava/lang/String;

.field FacebookBindSuccessfulCallBack:Ljava/lang/String;

.field FacebookLoginFailedCallBack:Ljava/lang/String;

.field FacebookLoginSuccessfulCallBack:Ljava/lang/String;

.field TAG:Ljava/lang/String;

.field callbackManager:Lcom/facebook/CallbackManager;

.field m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

.field m_Logger:Lcom/facebook/appevents/AppEventsLogger;

.field m_context:Landroid/content/Context;

.field mail:Ljava/lang/String;

.field name:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 65
    const-string v0, "facebook_login_name"

    sput-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    .line 66
    const-string v0, "facebook_bind_name"

    sput-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    .line 67
    const-string v0, "facebook_email"

    sput-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->OldLoginMailTag:Ljava/lang/String;

    .line 72
    const/4 v0, 0x0

    sput-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->shareDialog:Lcom/facebook/share/widget/ShareDialog;

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 58
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 59
    const-string v0, "FacebookHelper"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    .line 60
    const-string v0, "FacebookLoginSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginSuccessfulCallBack:Ljava/lang/String;

    .line 61
    const-string v0, "FacebookLoginFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginFailedCallBack:Ljava/lang/String;

    .line 62
    const-string v0, "FacebookBindSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindSuccessfulCallBack:Ljava/lang/String;

    .line 63
    const-string v0, "FacebookBindFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindFailedCallBack:Ljava/lang/String;

    .line 64
    const-string v0, "ClearFacebookSessionCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->ClearFacebookSessionCallBack:Ljava/lang/String;

    .line 69
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->None:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    .line 70
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 75
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    .line 76
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Ljava/lang/String;
    .param p4, "x4"    # Ljava/lang/String;
    .param p5, "x5"    # Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    .prologue
    .line 58
    invoke-direct/range {p0 .. p5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->handleSwitchFacebook(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V

    return-void
.end method

.method static synthetic access$100(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Ljava/lang/String;
    .param p4, "x4"    # Ljava/lang/String;
    .param p5, "x5"    # Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    .prologue
    .line 58
    invoke-direct/range {p0 .. p5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->handleThirdBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;)V

    return-void
.end method

.method private static getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 560
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method private getExpireTime()Ljava/lang/String;
    .locals 8

    .prologue
    .line 571
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd HH:mm:ss"

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v0, v1, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 572
    .local v0, "df":Ljava/text/SimpleDateFormat;
    new-instance v1, Ljava/util/Date;

    invoke-direct {v1}, Ljava/util/Date;-><init>()V

    invoke-virtual {v1}, Ljava/util/Date;->getTime()J

    move-result-wide v2

    sget v1, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    int-to-long v4, v1

    const-wide/16 v6, 0x3e8

    mul-long/2addr v4, v6

    add-long/2addr v2, v4

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/text/SimpleDateFormat;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    return-object v1
.end method

.method private handleSwitchFacebook(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
    .locals 9
    .param p1, "email"    # Ljava/lang/String;
    .param p2, "name"    # Ljava/lang/String;
    .param p3, "facebook_userID"    # Ljava/lang/String;
    .param p4, "facebook_token"    # Ljava/lang/String;
    .param p5, "listener"    # Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    .prologue
    .line 488
    const-string v0, "GetToken"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleSwitchFacebook1 facebook_userID = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 490
    new-instance v7, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v7}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 491
    .local v7, "loginInfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    invoke-virtual {v7, p3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setPlatformId(Ljava/lang/String;)V

    .line 492
    invoke-virtual {v7, p4}, Lcom/igg/sdk/bean/IGGLoginInfo;->setFacebook_token(Ljava/lang/String;)V

    .line 493
    const-string v0, "facebook"

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setType(Ljava/lang/String;)V

    .line 494
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 495
    sget v0, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v7, v0}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 496
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getExpireTime()Ljava/lang/String;

    move-result-object v4

    .line 498
    .local v4, "expireTime":Ljava/lang/String;
    :try_start_0
    const-string v0, "GetToken"

    const-string v1, "handleSwitchFacebook2"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 499
    new-instance v8, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v8}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v5, p5

    invoke-direct/range {v0 .. v5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$3;-><init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V

    invoke-virtual {v8, v7, v0}, Lcom/igg/sdk/service/IGGLoginService;->facebookLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 547
    :goto_0
    return-void

    .line 543
    :catch_0
    move-exception v6

    .line 545
    .local v6, "e":Ljava/lang/Exception;
    const-string v0, "GetToken"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "LoginByFacebook Exception "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v6}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method private handleThirdBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;)V
    .locals 3
    .param p1, "email"    # Ljava/lang/String;
    .param p2, "name"    # Ljava/lang/String;
    .param p3, "thirdType"    # Ljava/lang/String;
    .param p4, "thirdAccessKey"    # Ljava/lang/String;
    .param p5, "listener"    # Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;

    .prologue
    .line 429
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getAccesskey = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 430
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "thirdType = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 431
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "thirdAccessKey = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 432
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleThirdBind  = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 433
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "handleThirdBind  = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 435
    new-instance v0, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 436
    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    new-instance v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;

    invoke-direct {v2, p0, p5, p2, p1}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$2;-><init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;Lcom/igg/iggsdkbusiness/FBHelp/NewBindListener;Ljava/lang/String;Ljava/lang/String;)V

    .line 435
    invoke-virtual {v0, v1, p3, p4, v2}, Lcom/igg/sdk/service/IGGLoginService;->thirdAccountBind(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V

    .line 478
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;
    .locals 1

    .prologue
    .line 551
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->instance:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    if-nez v0, :cond_0

    .line 552
    new-instance v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->instance:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    .line 556
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->instance:Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    return-object v0
.end method


# virtual methods
.method public ActivateApp()V
    .locals 3

    .prologue
    .line 85
    :try_start_0
    const-string v1, "FacebookHelper"

    const-string v2, "ActivateApp begin"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->activateApp(Landroid/content/Context;)V

    .line 87
    const-string v1, "FacebookHelper"

    const-string v2, "ActivateApp end"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 93
    :goto_0
    return-void

    .line 89
    :catch_0
    move-exception v0

    .line 91
    .local v0, "ex":Ljava/lang/Exception;
    const-string v1, "FacebookHelper"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public AppLaunched()V
    .locals 2

    .prologue
    .line 115
    const-string v0, "FacebookHelper"

    const-string v1, "EVENT_NAME_ACTIVATED_APP brgin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 117
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v0}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 118
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    const-string v1, "fb_mobile_activate_app"

    invoke-virtual {v0, v1}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;)V

    .line 119
    const-string v0, "FacebookHelper"

    const-string v1, "EVENT_NAME_ACTIVATED_APP end"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 120
    return-void
.end method

.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 79
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 80
    return-void
.end method

.method public ClearFacebookSession()V
    .locals 3

    .prologue
    .line 330
    new-instance v0, Lcom/igg/sdk/account/IGGAccountSession;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountSession;-><init>()V

    .line 332
    .local v0, "session":Lcom/igg/sdk/account/IGGAccountSession;
    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->NONE:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/account/IGGAccountSession;->setLoginType(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;)V

    .line 333
    const-string v1, ""

    invoke-virtual {v0, v1}, Lcom/igg/sdk/account/IGGAccountSession;->setIGGId(Ljava/lang/String;)V

    .line 334
    const-string v1, ""

    invoke-virtual {v0, v1}, Lcom/igg/sdk/account/IGGAccountSession;->setAccesskey(Ljava/lang/String;)V

    .line 335
    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igg/sdk/account/IGGAccountSession;->setHasBind(Z)V

    .line 336
    sput-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 338
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->ClearFacebookSessionCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 339
    return-void
.end method

.method public CompleteRegistration(Ljava/lang/String;)V
    .locals 6
    .param p1, "registrationMethod"    # Ljava/lang/String;

    .prologue
    .line 123
    const-string v4, "FacebookHelper"

    const-string v5, "CompleteRegistration begin"

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 125
    :try_start_0
    new-instance v3, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    const-string v5, "facebook_event_file"

    invoke-direct {v3, v4, v5}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    .line 126
    .local v3, "storage":Lcom/igg/util/LocalStorage;
    const/4 v2, 0x0

    .line 127
    .local v2, "signUpFlag":Z
    if-eqz v3, :cond_0

    .line 128
    const-string v4, "FbSignUpFlag"

    invoke-virtual {v3, v4}, Lcom/igg/util/LocalStorage;->readBoolean(Ljava/lang/String;)Z

    move-result v2

    .line 129
    :cond_0
    if-nez v2, :cond_2

    .line 130
    if-eqz v3, :cond_1

    .line 131
    const-string v4, "FbSignUpFlag"

    const/4 v5, 0x1

    invoke-virtual {v3, v4, v5}, Lcom/igg/util/LocalStorage;->writeBoolean(Ljava/lang/String;Z)V

    .line 132
    :cond_1
    new-instance v1, Landroid/os/Bundle;

    invoke-direct {v1}, Landroid/os/Bundle;-><init>()V

    .line 133
    .local v1, "parameters":Landroid/os/Bundle;
    const-string v4, "fb_registration_method"

    invoke-virtual {v1, v4, p1}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 135
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v4}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v4

    iput-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 136
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    const-string v5, "fb_mobile_complete_registration"

    invoke-virtual {v4, v5, v1}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;Landroid/os/Bundle;)V

    .line 137
    const-string v4, "FacebookHelper"

    const-string v5, "CompleteRegistration end"

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 144
    .end local v1    # "parameters":Landroid/os/Bundle;
    .end local v2    # "signUpFlag":Z
    .end local v3    # "storage":Lcom/igg/util/LocalStorage;
    :cond_2
    :goto_0
    return-void

    .line 140
    :catch_0
    move-exception v0

    .line 141
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public CompletedTutorial()V
    .locals 3

    .prologue
    .line 148
    const-string v1, "FacebookHelper"

    const-string v2, "CompletedTutorial begin"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 149
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 150
    .local v0, "parameters":Landroid/os/Bundle;
    const-string v1, "fb_success"

    const-string v2, "success"

    invoke-virtual {v0, v1, v2}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 151
    const-string v1, "fb_content_id"

    const-string v2, "0"

    invoke-virtual {v0, v1, v2}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 153
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 154
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    const-string v2, "fb_mobile_tutorial_completion"

    invoke-virtual {v1, v2, v0}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;Landroid/os/Bundle;)V

    .line 155
    const-string v1, "FacebookHelper"

    const-string v2, "CompletedTutorial end"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 156
    return-void
.end method

.method public CustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "eventName"    # Ljava/lang/String;
    .param p2, "time"    # Ljava/lang/String;
    .param p3, "iggId"    # Ljava/lang/String;

    .prologue
    .line 202
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 203
    .local v0, "parameters":Landroid/os/Bundle;
    const-string v1, "Time"

    invoke-virtual {v0, v1, p2}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 204
    const-string v1, "IGGID"

    invoke-virtual {v0, v1, p3}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 206
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 207
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    invoke-virtual {v1, p1, v0}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;Landroid/os/Bundle;)V

    .line 208
    return-void
.end method

.method public CustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "eventName"    # Ljava/lang/String;
    .param p2, "time"    # Ljava/lang/String;
    .param p3, "iggId"    # Ljava/lang/String;
    .param p4, "key"    # Ljava/lang/String;
    .param p5, "value"    # Ljava/lang/String;

    .prologue
    .line 190
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 191
    .local v0, "parameters":Landroid/os/Bundle;
    const-string v1, "Time"

    invoke-virtual {v0, v1, p2}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 192
    const-string v1, "IGGID"

    invoke-virtual {v0, v1, p3}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 193
    invoke-virtual {v0, p4, p5}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 196
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 197
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    invoke-virtual {v1, p1, v0}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;Landroid/os/Bundle;)V

    .line 198
    return-void
.end method

.method public DeactivateApp()V
    .locals 2

    .prologue
    .line 96
    const-string v0, "FacebookHelper"

    const-string v1, "DeactivateApp begin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 97
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getActivity()Landroid/app/Activity;

    move-result-object v0

    invoke-static {v0}, Lcom/facebook/appevents/AppEventsLogger;->deactivateApp(Landroid/content/Context;)V

    .line 98
    const-string v0, "FacebookHelper"

    const-string v1, "DeactivateApp end"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 99
    return-void
.end method

.method public Flush()V
    .locals 1

    .prologue
    .line 211
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v0}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 212
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    invoke-virtual {v0}, Lcom/facebook/appevents/AppEventsLogger;->flush()V

    .line 213
    return-void
.end method

.method public GetToken()V
    .locals 5

    .prologue
    .line 298
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Bind:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    .line 299
    invoke-static {}, Lcom/facebook/AccessToken;->getCurrentAccessToken()Lcom/facebook/AccessToken;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 301
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    invoke-virtual {v0}, Lcom/facebook/login/LoginManager;->logOut()V

    .line 302
    const-string v0, "GetToken"

    const-string v1, "GetToken logOut"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 304
    :cond_0
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "email"

    aput-object v4, v2, v3

    const/4 v3, 0x1

    const-string v4, "public_profile ,email"

    aput-object v4, v2, v3

    invoke-static {v2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/facebook/login/LoginManager;->logInWithReadPermissions(Landroid/app/Activity;Ljava/util/Collection;)V

    .line 305
    const-string v0, "GetToken"

    const-string v1, "GetToken logInWithReadPermissions"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 306
    return-void
.end method

.method public Hashkey()V
    .locals 12

    .prologue
    const/4 v6, 0x0

    .line 218
    :try_start_0
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getActivity()Landroid/app/Activity;

    move-result-object v7

    invoke-virtual {v7}, Landroid/app/Activity;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v7

    const-string v8, "com.igg.android.lordsmobile_cn"

    const/16 v9, 0x40

    invoke-virtual {v7, v8, v9}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v3

    .line 220
    .local v3, "info":Landroid/content/pm/PackageInfo;
    iget-object v7, v3, Landroid/content/pm/PackageInfo;->signatures:[Landroid/content/pm/Signature;

    array-length v8, v7

    :goto_0
    if-ge v6, v8, :cond_0

    aget-object v5, v7, v6

    .line 223
    .local v5, "signature":Landroid/content/pm/Signature;
    const-string v9, "SHA"

    invoke-static {v9}, Ljava/security/MessageDigest;->getInstance(Ljava/lang/String;)Ljava/security/MessageDigest;

    move-result-object v4

    .line 224
    .local v4, "md":Ljava/security/MessageDigest;
    invoke-virtual {v5}, Landroid/content/pm/Signature;->toByteArray()[B

    move-result-object v9

    invoke-virtual {v4, v9}, Ljava/security/MessageDigest;->update([B)V

    .line 225
    new-instance v0, Ljava/lang/String;

    invoke-virtual {v4}, Ljava/security/MessageDigest;->digest()[B

    move-result-object v9

    const/4 v10, 0x0

    invoke-static {v9, v10}, Landroid/util/Base64;->encode([BI)[B

    move-result-object v9

    invoke-direct {v0, v9}, Ljava/lang/String;-><init>([B)V

    .line 226
    .local v0, "KeyResult":Ljava/lang/String;
    const-string v9, "FacebookHelper"

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "Key"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v9, v10}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2

    .line 220
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    .line 229
    .end local v0    # "KeyResult":Ljava/lang/String;
    .end local v3    # "info":Landroid/content/pm/PackageInfo;
    .end local v4    # "md":Ljava/security/MessageDigest;
    .end local v5    # "signature":Landroid/content/pm/Signature;
    :catch_0
    move-exception v2

    .local v2, "e1":Landroid/content/pm/PackageManager$NameNotFoundException;
    const-string v6, "FacebookHelper"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "name not found"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v2}, Landroid/content/pm/PackageManager$NameNotFoundException;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 232
    .end local v2    # "e1":Landroid/content/pm/PackageManager$NameNotFoundException;
    :cond_0
    :goto_1
    return-void

    .line 230
    :catch_1
    move-exception v1

    .local v1, "e":Ljava/security/NoSuchAlgorithmException;
    const-string v6, "FacebookHelper"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "no such an algorithm"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v1}, Ljava/security/NoSuchAlgorithmException;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 231
    .end local v1    # "e":Ljava/security/NoSuchAlgorithmException;
    :catch_2
    move-exception v1

    .local v1, "e":Ljava/lang/Exception;
    const-string v6, "FacebookHelper"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "exception"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method public OnActivityResult(IILandroid/content/Intent;)V
    .locals 2
    .param p1, "requestCode"    # I
    .param p2, "resultCode"    # I
    .param p3, "data"    # Landroid/content/Intent;

    .prologue
    .line 292
    const-string v0, "GetToken"

    const-string v1, "OnActivityResult"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 293
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->callbackManager:Lcom/facebook/CallbackManager;

    if-eqz v0, :cond_0

    .line 294
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->callbackManager:Lcom/facebook/CallbackManager;

    invoke-interface {v0, p1, p2, p3}, Lcom/facebook/CallbackManager;->onActivityResult(IILandroid/content/Intent;)Z

    .line 295
    :cond_0
    return-void
.end method

.method public Purchases(DLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "price"    # D
    .param p3, "num_items"    # Ljava/lang/String;
    .param p4, "content_type"    # Ljava/lang/String;
    .param p5, "content_id"    # Ljava/lang/String;
    .param p6, "currency"    # Ljava/lang/String;

    .prologue
    .line 163
    const-string v1, "FacebookHelper"

    const-string v2, "Purchases begin"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 164
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 165
    .local v0, "parameters":Landroid/os/Bundle;
    const-string v1, "fb_num_items"

    invoke-virtual {v0, v1, p3}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 166
    const-string v1, "fb_content_type"

    invoke-virtual {v0, v1, p4}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 167
    const-string v1, "fb_content_id"

    invoke-virtual {v0, v1, p5}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 168
    const-string v1, "fb_currency"

    invoke-virtual {v0, v1, p6}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 170
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 171
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    const-string v2, "fb_mobile_purchase"

    invoke-virtual {v1, v2, p1, p2, v0}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;DLandroid/os/Bundle;)V

    .line 172
    const-string v1, "FacebookHelper"

    const-string v2, "Purchases end"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 173
    return-void
.end method

.method public RegisterCallback()V
    .locals 3

    .prologue
    .line 243
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v1, "RegisterCallback"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 244
    invoke-static {}, Lcom/facebook/CallbackManager$Factory;->create()Lcom/facebook/CallbackManager;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->callbackManager:Lcom/facebook/CallbackManager;

    .line 245
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->callbackManager:Lcom/facebook/CallbackManager;

    new-instance v2, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper$1;-><init>(Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;)V

    invoke-virtual {v0, v1, v2}, Lcom/facebook/login/LoginManager;->registerCallback(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V

    .line 289
    return-void
.end method

.method public SdkInitialize(Landroid/content/Context;)V
    .locals 3
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 103
    const-string v0, "FacebookHelper"

    const-string v1, "SdkInitialize begin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 105
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    .line 106
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v0}, Lcom/facebook/FacebookSdk;->sdkInitialize(Landroid/content/Context;)V

    .line 107
    const-string v0, "FacebookHelper"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getSdkVersion = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {}, Lcom/facebook/FacebookSdk;->getSdkVersion()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 108
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v0}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 110
    const-string v0, "FacebookHelper"

    const-string v1, "SdkInitialize end"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 111
    return-void
.end method

.method public ShareOnFacebook()V
    .locals 3

    .prologue
    .line 316
    const-class v1, Lcom/facebook/share/model/ShareLinkContent;

    invoke-static {v1}, Lcom/facebook/share/widget/ShareDialog;->canShow(Ljava/lang/Class;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 317
    new-instance v1, Lcom/facebook/share/model/ShareLinkContent$Builder;

    invoke-direct {v1}, Lcom/facebook/share/model/ShareLinkContent$Builder;-><init>()V

    const-string v2, "Hello Facebook"

    .line 318
    invoke-virtual {v1, v2}, Lcom/facebook/share/model/ShareLinkContent$Builder;->setContentTitle(Ljava/lang/String;)Lcom/facebook/share/model/ShareLinkContent$Builder;

    move-result-object v1

    const-string v2, "The \'Hello Facebook\' sample  showcases simple Facebook integration"

    .line 319
    invoke-virtual {v1, v2}, Lcom/facebook/share/model/ShareLinkContent$Builder;->setContentDescription(Ljava/lang/String;)Lcom/facebook/share/model/ShareLinkContent$Builder;

    move-result-object v1

    const-string v2, "http://developers.facebook.com/android"

    .line 321
    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/facebook/share/model/ShareLinkContent$Builder;->setContentUrl(Landroid/net/Uri;)Lcom/facebook/share/model/ShareContent$Builder;

    move-result-object v1

    check-cast v1, Lcom/facebook/share/model/ShareLinkContent$Builder;

    .line 322
    invoke-virtual {v1}, Lcom/facebook/share/model/ShareLinkContent$Builder;->build()Lcom/facebook/share/model/ShareLinkContent;

    move-result-object v0

    .line 324
    .local v0, "linkContent":Lcom/facebook/share/model/ShareLinkContent;
    sget-object v1, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->shareDialog:Lcom/facebook/share/widget/ShareDialog;

    invoke-virtual {v1, v0}, Lcom/facebook/share/widget/ShareDialog;->show(Ljava/lang/Object;)V

    .line 326
    .end local v0    # "linkContent":Lcom/facebook/share/model/ShareLinkContent;
    :cond_0
    return-void
.end method

.method public ShowDebug()V
    .locals 2

    .prologue
    .line 236
    const-string v0, "FacebookHelper"

    const-string v1, "ShowDebug begin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 237
    const/4 v0, 0x1

    invoke-static {v0}, Lcom/facebook/FacebookSdk;->setIsDebugEnabled(Z)V

    .line 238
    sget-object v0, Lcom/facebook/LoggingBehavior;->APP_EVENTS:Lcom/facebook/LoggingBehavior;

    invoke-static {v0}, Lcom/facebook/FacebookSdk;->addLoggingBehavior(Lcom/facebook/LoggingBehavior;)V

    .line 239
    const-string v0, "FacebookHelper"

    const-string v1, "ShowDebug end"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 240
    return-void
.end method

.method public SpentCredits(DLjava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "value"    # D
    .param p3, "content_type"    # Ljava/lang/String;
    .param p4, "content_id"    # Ljava/lang/String;

    .prologue
    .line 178
    const-string v1, "FacebookHelper"

    const-string v2, "SpentCredits begin"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 179
    new-instance v0, Landroid/os/Bundle;

    invoke-direct {v0}, Landroid/os/Bundle;-><init>()V

    .line 180
    .local v0, "parameters":Landroid/os/Bundle;
    const-string v1, "fb_content_type"

    invoke-virtual {v0, v1, p3}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 181
    const-string v1, "fb_content_id"

    invoke-virtual {v0, v1, p4}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 183
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_context:Landroid/content/Context;

    invoke-static {v1}, Lcom/facebook/appevents/AppEventsLogger;->newLogger(Landroid/content/Context;)Lcom/facebook/appevents/AppEventsLogger;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    .line 184
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_Logger:Lcom/facebook/appevents/AppEventsLogger;

    const-string v2, "fb_mobile_spent_credits"

    invoke-virtual {v1, v2, p1, p2, v0}, Lcom/facebook/appevents/AppEventsLogger;->logEvent(Ljava/lang/String;DLandroid/os/Bundle;)V

    .line 185
    const-string v1, "FacebookHelper"

    const-string v2, "SpentCredits end"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 186
    return-void
.end method

.method public SwitchFacebook()V
    .locals 5

    .prologue
    .line 309
    sget-object v0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;->Switch:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->m_FBCallbackType:Lcom/igg/iggsdkbusiness/FBHelp/FacebookCallbackType;

    .line 310
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    invoke-virtual {v0}, Lcom/facebook/login/LoginManager;->logOut()V

    .line 311
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->getActivity()Landroid/app/Activity;

    move-result-object v1

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "email"

    aput-object v4, v2, v3

    const/4 v3, 0x1

    const-string v4, "public_profile,email"

    aput-object v4, v2, v3

    invoke-static {v2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/facebook/login/LoginManager;->logInWithReadPermissions(Landroid/app/Activity;Ljava/util/Collection;)V

    .line 312
    return-void
.end method

.method protected getLaunchActivity(Landroid/content/Context;)Ljava/lang/Class;
    .locals 3
    .param p1, "context"    # Landroid/content/Context;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            ")",
            "Ljava/lang/Class",
            "<*>;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/ClassNotFoundException;
        }
    .end annotation

    .prologue
    .line 564
    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    .line 565
    .local v1, "packageName":Ljava/lang/String;
    invoke-virtual {p1}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 566
    invoke-virtual {v2, v1}, Landroid/content/pm/PackageManager;->getLaunchIntentForPackage(Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v2

    .line 567
    invoke-virtual {v2}, Landroid/content/Intent;->getComponent()Landroid/content/ComponentName;

    move-result-object v2

    invoke-virtual {v2}, Landroid/content/ComponentName;->getClassName()Ljava/lang/String;

    move-result-object v0

    .line 568
    .local v0, "classname":Ljava/lang/String;
    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v2

    return-object v2
.end method

.method public onBindFinished(ZZZLjava/lang/String;)V
    .locals 9
    .param p1, "success"    # Z
    .param p2, "hadBeenBound"    # Z
    .param p3, "isFirstAuthorize"    # Z
    .param p4, "errorCode"    # Ljava/lang/String;

    .prologue
    .line 341
    if-eqz p1, :cond_0

    .line 342
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v7, "onBindFinished Success"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 344
    const/4 v2, 0x0

    .line 345
    .local v2, "json":Lorg/json/JSONObject;
    :try_start_0
    const-string v1, ""

    .line 346
    .local v1, "email":Ljava/lang/String;
    const-string v5, ""

    .line 347
    .local v5, "name":Ljava/lang/String;
    sget-object v6, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v6}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v6

    sget-object v7, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    invoke-interface {v6, v7}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "email":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 348
    .restart local v1    # "email":Ljava/lang/String;
    sget-object v6, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v6}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v6

    sget-object v7, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v6, v7}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    .end local v5    # "name":Ljava/lang/String;
    check-cast v5, Ljava/lang/String;

    .line 349
    .restart local v5    # "name":Ljava/lang/String;
    new-instance v4, Ljava/util/HashMap;

    invoke-direct {v4}, Ljava/util/HashMap;-><init>()V

    .line 350
    .local v4, "map":Ljava/util/Map;
    const-string v6, "name"

    invoke-interface {v4, v6, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 351
    new-instance v3, Lorg/json/JSONObject;

    invoke-direct {v3, v4}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 352
    .end local v2    # "json":Lorg/json/JSONObject;
    .local v3, "json":Lorg/json/JSONObject;
    :try_start_1
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    invoke-virtual {v3}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 353
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "onBindFinished This.name = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->mail:Ljava/lang/String;

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 354
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "onBindFinished This.name = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->name:Ljava/lang/String;

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 355
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "onBindFinished getExtra = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    sget-object v8, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v8}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 356
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v3}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {p0, v6, v7}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 380
    .end local v1    # "email":Ljava/lang/String;
    .end local v3    # "json":Lorg/json/JSONObject;
    .end local v4    # "map":Ljava/util/Map;
    .end local v5    # "name":Ljava/lang/String;
    :goto_0
    return-void

    .line 357
    .restart local v2    # "json":Lorg/json/JSONObject;
    :catch_0
    move-exception v0

    .line 358
    .local v0, "e":Ljava/lang/Exception;
    :goto_1
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "onBindFinishedException "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 359
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindSuccessfulCallBack:Ljava/lang/String;

    const-string v7, ""

    invoke-virtual {p0, v6, v7}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 363
    .end local v0    # "e":Ljava/lang/Exception;
    .end local v2    # "json":Lorg/json/JSONObject;
    :cond_0
    if-eqz p3, :cond_1

    .line 365
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v7, "onBindFinished 3"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 372
    :cond_1
    const-string v6, "GetToken"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "errorCode = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 373
    if-eqz p2, :cond_2

    .line 375
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindFailedCallBack:Ljava/lang/String;

    invoke-virtual {p0, v6, p4}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 379
    :cond_2
    iget-object v6, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookBindFailedCallBack:Ljava/lang/String;

    invoke-virtual {p0, v6, p4}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 357
    .restart local v1    # "email":Ljava/lang/String;
    .restart local v3    # "json":Lorg/json/JSONObject;
    .restart local v4    # "map":Ljava/util/Map;
    .restart local v5    # "name":Ljava/lang/String;
    :catch_1
    move-exception v0

    move-object v2, v3

    .end local v3    # "json":Lorg/json/JSONObject;
    .restart local v2    # "json":Lorg/json/JSONObject;
    goto :goto_1
.end method

.method public onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;
    .param p3, "isFirstAuthorize"    # Z

    .prologue
    .line 386
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v6, "onSwitchLoginFinished"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 388
    if-nez p2, :cond_1

    if-nez p3, :cond_1

    .line 389
    :try_start_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v6, "\u5207\u6362\u8d26\u6237\u51fa\u9519"

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 390
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginFailedCallBack:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {p0, v5, v6}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 426
    :cond_0
    :goto_0
    return-void

    .line 395
    :cond_1
    if-nez p2, :cond_2

    if-nez p3, :cond_0

    .line 398
    :cond_2
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v6, "onSwitchLoginFinished1"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 403
    invoke-static {}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->sharedInstance()Lcom/igg/iggsdkbusiness/GeTuiRegister;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->uninitialize()V

    .line 406
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    const-string v6, "onSwitchLoginFinished2"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 407
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v5

    if-eqz v5, :cond_0

    .line 408
    const-string v5, "GetToken"

    const-string v6, "onSwitchLoginFinished3"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 410
    const-string v1, ""

    .line 411
    .local v1, "email":Ljava/lang/String;
    const-string v4, ""

    .line 412
    .local v4, "name":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v5

    sget-object v6, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->LoginMailTag:Ljava/lang/String;

    invoke-interface {v5, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .end local v1    # "email":Ljava/lang/String;
    check-cast v1, Ljava/lang/String;

    .line 413
    .restart local v1    # "email":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v5

    sget-object v6, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->BindNameTag:Ljava/lang/String;

    invoke-interface {v5, v6}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    .end local v4    # "name":Ljava/lang/String;
    check-cast v4, Ljava/lang/String;

    .line 414
    .restart local v4    # "name":Ljava/lang/String;
    const/4 v2, 0x0

    .line 415
    .local v2, "json":Lorg/json/JSONObject;
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 416
    .local v3, "map":Ljava/util/Map;
    const-string v5, "name"

    invoke-interface {v3, v5, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 417
    new-instance v2, Lorg/json/JSONObject;

    .end local v2    # "json":Lorg/json/JSONObject;
    invoke-direct {v2, v3}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 418
    .restart local v2    # "json":Lorg/json/JSONObject;
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 419
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {p0, v5, v6}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 421
    .end local v1    # "email":Ljava/lang/String;
    .end local v2    # "json":Lorg/json/JSONObject;
    .end local v3    # "map":Ljava/util/Map;
    .end local v4    # "name":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 422
    .local v0, "e":Ljava/lang/Exception;
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->TAG:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 423
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->FacebookLoginFailedCallBack:Ljava/lang/String;

    const-string v6, ""

    invoke-virtual {p0, v5, v6}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
