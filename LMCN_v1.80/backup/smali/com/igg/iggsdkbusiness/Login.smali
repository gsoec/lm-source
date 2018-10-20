.class public Lcom/igg/iggsdkbusiness/Login;
.super Ljava/lang/Object;
.source "Login.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "LoginDemo"

.field private static instance:Lcom/igg/iggsdkbusiness/Login;


# instance fields
.field AutoLoginFailedCallBack:Ljava/lang/String;

.field AutoLoginSuccessfulCallBack:Ljava/lang/String;

.field CallBackString:Ljava/lang/String;

.field GuestLoginFailedCallBack:Ljava/lang/String;

.field GuestLoginSuccessfulCallBack:Ljava/lang/String;

.field StringAutoLoginFailed:Ljava/lang/String;

.field StringAutoLoginNull:Ljava/lang/String;

.field StringGuestLoginFailed:Ljava/lang/String;

.field StringGuestLoginNull:Ljava/lang/String;


# direct methods
.method private constructor <init>()V
    .locals 1

    .prologue
    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 27
    const-string v0, "GuestLoginSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->GuestLoginSuccessfulCallBack:Ljava/lang/String;

    .line 28
    const-string v0, "GuestLoginFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->GuestLoginFailedCallBack:Ljava/lang/String;

    .line 29
    const-string v0, "AutoLoginSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->AutoLoginSuccessfulCallBack:Ljava/lang/String;

    .line 30
    const-string v0, "AutoLoginFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->AutoLoginFailedCallBack:Ljava/lang/String;

    .line 32
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->CallBackString:Ljava/lang/String;

    .line 34
    const-string v0, "34107"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->StringGuestLoginNull:Ljava/lang/String;

    .line 35
    const-string v0, "34108"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->StringGuestLoginFailed:Ljava/lang/String;

    .line 36
    const-string v0, "34109"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->StringAutoLoginNull:Ljava/lang/String;

    .line 37
    const-string v0, "34110"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/Login;->StringAutoLoginFailed:Ljava/lang/String;

    .line 64
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/Login;
    .locals 1

    .prologue
    .line 71
    sget-object v0, Lcom/igg/iggsdkbusiness/Login;->instance:Lcom/igg/iggsdkbusiness/Login;

    if-nez v0, :cond_0

    .line 72
    new-instance v0, Lcom/igg/iggsdkbusiness/Login;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/Login;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/Login;->instance:Lcom/igg/iggsdkbusiness/Login;

    .line 75
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/Login;->instance:Lcom/igg/iggsdkbusiness/Login;

    return-object v0
.end method


# virtual methods
.method public AutoLogin()V
    .locals 3

    .prologue
    .line 82
    const-string v0, "AutoLogin"

    const-string v1, "AutoLogin"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 84
    new-instance v0, Lcom/igg/sdk/account/IGGAccountLogin;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountLogin;-><init>()V

    new-instance v1, Lcom/igg/iggsdkbusiness/Login$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/Login$1;-><init>(Lcom/igg/iggsdkbusiness/Login;)V

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/account/IGGAccountLogin;->login(Lcom/igg/sdk/account/LoginListener;Lcom/igg/sdk/account/LoginDelegate;)V

    .line 208
    return-void
.end method

.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 42
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 43
    return-void
.end method

.method DebugLog(Ljava/lang/String;)V
    .locals 0
    .param p1, "pMessage"    # Ljava/lang/String;

    .prologue
    .line 46
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-static {p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 47
    return-void
.end method

.method public GuestLogin()V
    .locals 4

    .prologue
    .line 215
    :try_start_0
    new-instance v1, Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {v1}, Lcom/igg/sdk/account/IGGDeviceGuest;-><init>()V

    .line 216
    .local v1, "guest":Lcom/igg/sdk/account/IGGDeviceGuest;
    new-instance v2, Lcom/igg/sdk/account/IGGAccountLogin;

    invoke-direct {v2}, Lcom/igg/sdk/account/IGGAccountLogin;-><init>()V

    new-instance v3, Lcom/igg/iggsdkbusiness/Login$2;

    invoke-direct {v3, p0, v1}, Lcom/igg/iggsdkbusiness/Login$2;-><init>(Lcom/igg/iggsdkbusiness/Login;Lcom/igg/sdk/account/IGGDeviceGuest;)V

    invoke-virtual {v2, v1, v3}, Lcom/igg/sdk/account/IGGAccountLogin;->loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 280
    .end local v1    # "guest":Lcom/igg/sdk/account/IGGDeviceGuest;
    :goto_0
    return-void

    .line 274
    :catch_0
    move-exception v0

    .line 276
    .local v0, "e":Ljava/lang/Exception;
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Login;->GuestLoginFailedCallBack:Ljava/lang/String;

    const-string v3, "200010"

    invoke-virtual {p0, v2, v3}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 277
    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v2}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 278
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 67
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method
