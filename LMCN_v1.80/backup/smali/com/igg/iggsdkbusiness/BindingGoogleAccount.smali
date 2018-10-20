.class public Lcom/igg/iggsdkbusiness/BindingGoogleAccount;
.super Ljava/lang/Object;
.source "BindingGoogleAccount.java"


# static fields
.field public static BindNameTag:Ljava/lang/String; = null

.field public static final TAG:Ljava/lang/String; = "BindingGoogleAccount"

.field private static instance:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

.field public static lastAccount:Ljava/lang/String;


# instance fields
.field CallBackString:Ljava/lang/String;

.field FailedCallBack:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;

.field callBack:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 22
    const-string v0, "googleBindName"

    sput-object v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->BindNameTag:Ljava/lang/String;

    .line 24
    const-string v0, ""

    sput-object v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 27
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    const-string v0, "BindingGoogleSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->SuccessfulCallBack:Ljava/lang/String;

    .line 41
    const-string v0, "BindingGoogleFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    .line 42
    const-string v0, "GetGoogleAccountCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->callBack:Ljava/lang/String;

    .line 43
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->CallBackString:Ljava/lang/String;

    .line 28
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/BindingGoogleAccount;
    .locals 1

    .prologue
    .line 31
    sget-object v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    if-nez v0, :cond_0

    .line 32
    new-instance v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    .line 35
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 47
    const-string v0, "log:"

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

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 48
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 49
    return-void
.end method

.method public bindingGoogle(Ljava/lang/String;)V
    .locals 3
    .param p1, "account"    # Ljava/lang/String;

    .prologue
    .line 72
    sput-object p1, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    .line 73
    const-string v0, "LinkGoogleAccount"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "lastAccount = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    sget-object v2, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 74
    const-string v0, "LinkGoogleAccount"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, " new IGGAccountBind() = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    new-instance v2, Lcom/igg/sdk/account/IGGAccountBind;

    invoke-direct {v2}, Lcom/igg/sdk/account/IGGAccountBind;-><init>()V

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 75
    new-instance v0, Lcom/igg/sdk/account/IGGAccountBind;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountBind;-><init>()V

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->getActivity()Landroid/app/Activity;

    move-result-object v1

    new-instance v2, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;-><init>(Lcom/igg/iggsdkbusiness/BindingGoogleAccount;)V

    invoke-virtual {v0, p1, v1, v2}, Lcom/igg/sdk/account/IGGAccountBind;->bindToGooglePlay(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    .line 114
    return-void
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 123
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public getGoogleAccount()V
    .locals 5

    .prologue
    .line 55
    invoke-static {}, Lcom/igg/sdk/account/GooglePlay;->getLocalRegisteredEmails()[Ljava/lang/String;

    move-result-object v1

    .line 56
    .local v1, "names":[Ljava/lang/String;
    const-string v2, ""

    .line 57
    .local v2, "result":Ljava/lang/String;
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    array-length v3, v1

    if-ge v0, v3, :cond_0

    .line 58
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    aget-object v4, v1, v0

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ":"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 57
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 61
    :cond_0
    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_1

    .line 62
    const/4 v3, 0x0

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v4

    add-int/lit8 v4, v4, -0x1

    invoke-virtual {v2, v3, v4}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v2

    .line 64
    :cond_1
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->callBack:Ljava/lang/String;

    invoke-virtual {p0, v3, v2}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 65
    return-void
.end method
