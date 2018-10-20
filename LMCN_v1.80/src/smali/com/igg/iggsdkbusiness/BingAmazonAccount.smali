.class public Lcom/igg/iggsdkbusiness/BingAmazonAccount;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;
    }
.end annotation


# static fields
.field private static final APP_SCOPES:[Ljava/lang/String;

.field private static final TAG:Ljava/lang/String;

.field private static instance:Lcom/igg/iggsdkbusiness/BingAmazonAccount;


# instance fields
.field CallBackString:Ljava/lang/String;

.field FailedCallBack:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;

.field callBack:Ljava/lang/String;

.field private mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

.field private mIsLoggedIn:Z

.field private repeatTimes:I


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    .line 33
    const-class v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->TAG:Ljava/lang/String;

    .line 34
    const/4 v0, 0x2

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, "profile"

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, "postal_code"

    aput-object v2, v0, v1

    sput-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->APP_SCOPES:[Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 6

    .prologue
    .line 53
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 26
    const-string v3, "BindingAmazonSuccessfulCallBack"

    iput-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->SuccessfulCallBack:Ljava/lang/String;

    .line 28
    const-string v3, "BindingAmazonFailedCallBack"

    iput-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->FailedCallBack:Ljava/lang/String;

    .line 30
    const-string v3, "GetGoogleAccountCallBack"

    iput-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->callBack:Ljava/lang/String;

    .line 31
    const-string v3, ""

    iput-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->CallBackString:Ljava/lang/String;

    .line 54
    const/4 v3, 0x0

    iput v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->repeatTimes:I

    .line 57
    :try_start_0
    new-instance v3, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->getActivity()Landroid/app/Activity;

    move-result-object v4

    sget-object v5, Landroid/os/Bundle;->EMPTY:Landroid/os/Bundle;

    invoke-direct {v3, v4, v5}, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;-><init>(Landroid/content/Context;Landroid/os/Bundle;)V

    iput-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_1

    .line 59
    :try_start_1
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

    invoke-virtual {v3}, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;->getClientId()Ljava/lang/String;

    move-result-object v0

    .line 60
    .local v0, "clientId":Ljava/lang/String;
    sget-object v3, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->TAG:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "clientId:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Lcom/amazon/identity/auth/device/AuthError; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_1 .. :try_end_1} :catch_1

    .line 69
    .end local v0    # "clientId":Ljava/lang/String;
    :goto_0
    return-void

    .line 61
    :catch_0
    move-exception v2

    .line 62
    .local v2, "ex":Lcom/amazon/identity/auth/device/AuthError;
    :try_start_2
    invoke-virtual {v2}, Lcom/amazon/identity/auth/device/AuthError;->printStackTrace()V
    :try_end_2
    .catch Ljava/lang/IllegalArgumentException; {:try_start_2 .. :try_end_2} :catch_1

    goto :goto_0

    .line 66
    .end local v2    # "ex":Lcom/amazon/identity/auth/device/AuthError;
    :catch_1
    move-exception v1

    .line 67
    .local v1, "e":Ljava/lang/IllegalArgumentException;
    sget-object v3, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->TAG:Ljava/lang/String;

    const-string v4, "Unable to Use Amazon Authorization Manager. APIKey is incorrect or does not exist."

    invoke-static {v3, v4, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    goto :goto_0
.end method

.method private LoginWithGetToken()V
    .locals 3

    .prologue
    .line 89
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

    sget-object v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->APP_SCOPES:[Ljava/lang/String;

    new-instance v2, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V

    invoke-virtual {v0, v1, v2}, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;->getToken([Ljava/lang/String;Lcom/amazon/identity/auth/device/shared/APIListener;)Ljava/util/concurrent/Future;

    .line 162
    return-void
.end method

.method static synthetic access$100()Ljava/lang/String;
    .locals 1

    .prologue
    .line 23
    sget-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->TAG:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)Z
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    .prologue
    .line 23
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mIsLoggedIn:Z

    return v0
.end method

.method static synthetic access$202(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Z)Z
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;
    .param p1, "x1"    # Z

    .prologue
    .line 23
    iput-boolean p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mIsLoggedIn:Z

    return p1
.end method

.method static synthetic access$300(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->repeatTimes:I

    return v0
.end method

.method static synthetic access$302(Lcom/igg/iggsdkbusiness/BingAmazonAccount;I)I
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;
    .param p1, "x1"    # I

    .prologue
    .line 23
    iput p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->repeatTimes:I

    return p1
.end method

.method static synthetic access$400(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    .prologue
    .line 23
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->LoginWithGetToken()V

    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/BingAmazonAccount;
    .locals 1

    .prologue
    .line 41
    sget-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->instance:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    if-nez v0, :cond_0

    .line 42
    new-instance v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->instance:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    .line 44
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->instance:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 49
    sget-object v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->TAG:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ":"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 50
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 51
    return-void
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 250
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public loginAmazon()V
    .locals 5

    .prologue
    .line 82
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

    sget-object v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->APP_SCOPES:[Ljava/lang/String;

    sget-object v2, Landroid/os/Bundle;->EMPTY:Landroid/os/Bundle;

    new-instance v3, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;

    const/4 v4, 0x0

    invoke-direct {v3, p0, v4}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;)V

    invoke-virtual {v0, v1, v2, v3}, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;->authorize([Ljava/lang/String;Landroid/os/Bundle;Lcom/amazon/identity/auth/device/authorization/api/AuthorizationListener;)Ljava/util/concurrent/Future;

    .line 83
    return-void
.end method

.method public logoutAmazon()V
    .locals 2

    .prologue
    .line 168
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->mAuthManager:Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;

    new-instance v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$2;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$2;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V

    invoke-virtual {v0, v1}, Lcom/amazon/identity/auth/device/authorization/api/AmazonAuthorizationManager;->clearAuthorizationState(Lcom/amazon/identity/auth/device/shared/APIListener;)Ljava/util/concurrent/Future;

    .line 180
    return-void
.end method
