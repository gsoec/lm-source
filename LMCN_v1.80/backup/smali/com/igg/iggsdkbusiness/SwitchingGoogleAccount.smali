.class public Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;
.super Ljava/lang/Object;
.source "SwitchingGoogleAccount.java"


# static fields
.field public static AlertDialogStr:Ljava/lang/String; = null

.field public static GoolgeLoginMail:Ljava/lang/String; = null

.field public static final TAG:Ljava/lang/String; = "SwitchingGoogleAccount"

.field private static instance:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

.field public static lastAccount:Ljava/lang/String;


# instance fields
.field FailedCallBack:Ljava/lang/String;

.field StringSwitchAccountError:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;

.field SwitchingGoogleAccountCancelCallBack:Ljava/lang/String;

.field emailSelected:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 36
    const-string v0, ""

    sput-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->lastAccount:Ljava/lang/String;

    .line 37
    const-string v0, ""

    sput-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->AlertDialogStr:Ljava/lang/String;

    .line 38
    const-string v0, "email"

    sput-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->GoolgeLoginMail:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 59
    const-string v0, "SwitchingGoogleAccountSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->SuccessfulCallBack:Ljava/lang/String;

    .line 61
    const-string v0, "SwitchingGoogleAccountFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    .line 62
    const-string v0, "SwitchingGoogleAccountCancelCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->SwitchingGoogleAccountCancelCallBack:Ljava/lang/String;

    .line 64
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->emailSelected:Ljava/lang/String;

    .line 65
    const-string v0, "34109"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->StringSwitchAccountError:Ljava/lang/String;

    .line 41
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;
    .locals 1

    .prologue
    .line 44
    sget-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    if-nez v0, :cond_0

    .line 45
    new-instance v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    .line 48
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->instance:Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 68
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "log:"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ":"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 69
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 70
    return-void
.end method

.method DebugLog(Ljava/lang/String;)V
    .locals 0
    .param p1, "pMessage"    # Ljava/lang/String;

    .prologue
    .line 52
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-static {p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 53
    return-void
.end method

.method public SwitchingGoogleAccountCancel()V
    .locals 2

    .prologue
    .line 56
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->SwitchingGoogleAccountCancelCallBack:Ljava/lang/String;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->StringSwitchAccountError:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 57
    return-void
.end method

.method getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 198
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public showAccount(Z)V
    .locals 11
    .param p1, "bBind"    # Z

    .prologue
    .line 145
    const-string v0, "showAccount"

    const-string v1, "showAccount"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 178
    const v10, 0xffff

    .line 179
    .local v10, "requestCode":I
    if-eqz p1, :cond_0

    .line 180
    const v10, 0xfffe

    .line 181
    :cond_0
    const/4 v0, 0x0

    const/4 v1, 0x0

    const/4 v2, 0x1

    :try_start_0
    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "com.google"

    aput-object v4, v2, v3

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    invoke-static/range {v0 .. v7}, Lcom/google/android/gms/common/AccountPicker;->newChooseAccountIntent(Landroid/accounts/Account;Ljava/util/ArrayList;[Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;[Ljava/lang/String;Landroid/os/Bundle;)Landroid/content/Intent;

    move-result-object v9

    .line 183
    .local v9, "intent":Landroid/content/Intent;
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->getActivity()Landroid/app/Activity;

    move-result-object v0

    invoke-virtual {v0, v9, v10}, Landroid/app/Activity;->startActivityForResult(Landroid/content/Intent;I)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 191
    .end local v9    # "intent":Landroid/content/Intent;
    :goto_0
    return-void

    .line 185
    :catch_0
    move-exception v8

    .line 187
    .local v8, "e":Ljava/lang/Exception;
    const-string v0, "showAccount"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Exception = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v8}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public switchAccount(Ljava/lang/String;)V
    .locals 3
    .param p1, "account"    # Ljava/lang/String;

    .prologue
    .line 78
    sput-object p1, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->lastAccount:Ljava/lang/String;

    .line 79
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "it will switch account:"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->DebugLog(Ljava/lang/String;)V

    .line 80
    new-instance v0, Lcom/igg/sdk/account/IGGAccountLogin;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountLogin;-><init>()V

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->getActivity()Landroid/app/Activity;

    move-result-object v1

    new-instance v2, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount$1;-><init>(Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;)V

    invoke-virtual {v0, p1, v1, v2}, Lcom/igg/sdk/account/IGGAccountLogin;->switchAccount(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V

    .line 138
    return-void
.end method
