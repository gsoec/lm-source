.class public Lcom/igg/iggsdkbusiness/IGGSDKPlugin;
.super Lcom/unity3d/player/UnityPlayerActivity;
.source "IGGSDKPlugin.java"


# static fields
.field public static final EXTRA_MESSAGE:Ljava/lang/String; = "message"

.field protected static final MANAGER_NAME:Ljava/lang/String; = "GoogleCloudMessagingManager"

.field public static final PROPERTY_GCM_SENDER_ID:Ljava/lang/String; = "sender_id"

.field public static final PROPERTY_REG_ID:Ljava/lang/String; = "registration_id"

.field public static final RESULT_OK:I = -0x1

.field private static _instance:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field private static _isAppInForeground:Z

.field private static isAppPrintLog:Z

.field public static mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;


# instance fields
.field AlertDialogStr:Ljava/lang/String;

.field BindAccountCallBack:Ljava/lang/String;

.field private MessageId:Ljava/lang/String;

.field RateUsFailedCallBack:Ljava/lang/String;

.field RateUsSuccessfulCallBack:Ljava/lang/String;

.field SwitchAccountCallBack:Ljava/lang/String;

.field TAG:Ljava/lang/String;

.field protected _unityPlayerClass:Ljava/lang/Class;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/Class",
            "<*>;"
        }
    .end annotation
.end field

.field bParseDeepLink:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 535
    const/4 v0, 0x1

    sput-boolean v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->isAppPrintLog:Z

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 65
    invoke-direct {p0}, Lcom/unity3d/player/UnityPlayerActivity;-><init>()V

    .line 79
    const-string v0, "RateUsSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateUsSuccessfulCallBack:Ljava/lang/String;

    .line 80
    const-string v0, "RateUsFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RateUsFailedCallBack:Ljava/lang/String;

    .line 81
    const-string v0, "SwitchAccountCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SwitchAccountCallBack:Ljava/lang/String;

    .line 82
    const-string v0, "BindAccountCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->BindAccountCallBack:Ljava/lang/String;

    .line 86
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->AlertDialogStr:Ljava/lang/String;

    .line 87
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->bParseDeepLink:Z

    .line 89
    const-string v0, "IGGSDKPlugin"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->TAG:Ljava/lang/String;

    .line 537
    const-string v0, "GM"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->MessageId:Ljava/lang/String;

    return-void
.end method

.method public static DebugLog(Ljava/lang/String;)V
    .locals 4
    .param p0, "pString"    # Ljava/lang/String;

    .prologue
    .line 675
    sget-boolean v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->isAppPrintLog:Z

    if-eqz v0, :cond_0

    .line 676
    const-string v0, "SopDebugLog"

    const-string v1, "GetMessage"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " -from IGGSDKPlugin log-"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->UnitySendMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 680
    :cond_0
    return-void
.end method

.method public static GetActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 148
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    return-object v0
.end method

.method private ParseDeepLink()V
    .locals 9

    .prologue
    .line 1597
    iget-boolean v7, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->bParseDeepLink:Z

    if-eqz v7, :cond_0

    .line 1614
    :goto_0
    return-void

    .line 1598
    :cond_0
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v7

    invoke-virtual {v7}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    .line 1599
    .local v3, "gameid":Ljava/lang/String;
    sget-object v7, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v7}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v5

    .line 1600
    .local v5, "signedkey":Ljava/lang/String;
    const-string v4, "etuaxaXNbBANAzvFBvH"

    .line 1601
    .local v4, "keyword":Ljava/lang/String;
    const-string v1, "lordsmobile.igg.com"

    .line 1602
    .local v1, "domain":Ljava/lang/String;
    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "from=phone&game_id="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "&signed_key="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "&char_id=0"

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 1603
    .local v2, "encTarget":Ljava/lang/String;
    invoke-static {v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getMD5EncryptedString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1604
    .local v0, "MD5":Ljava/lang/String;
    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "http://lordsmobile.igg.com/event/deep_link/?from=phone&game_id="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "&signed_key="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    const-string v8, "&char_id=0&event_sig="

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    .line 1612
    .local v6, "url":Ljava/lang/String;
    invoke-virtual {p0, v6}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 1613
    const/4 v7, 0x1

    iput-boolean v7, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->bParseDeepLink:Z

    goto :goto_0
.end method

.method private ShowExitDialog()V
    .locals 0

    .prologue
    .line 1738
    return-void
.end method

.method protected static UnitySendMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p0, "g"    # Ljava/lang/String;
    .param p1, "m"    # Ljava/lang/String;
    .param p2, "p"    # Ljava/lang/String;

    .prologue
    .line 713
    invoke-static {p0, p1, p2}, Lcom/unity3d/player/UnityPlayer;->UnitySendMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 714
    return-void
.end method

.method public static getAuthorityFromPermission(Landroid/content/Context;)Ljava/lang/String;
    .locals 5
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 886
    invoke-static {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getAuthorityFromPermissionDefault(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    .line 888
    .local v0, "authority":Ljava/lang/String;
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v3

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    .line 889
    :cond_0
    invoke-static {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getCurrentLauncherPackageName(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v1

    .line 890
    .local v1, "packageName":Ljava/lang/String;
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ".permission.READ_SETTINGS"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 891
    invoke-static {p0, v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getThirdAuthorityFromPermission(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 894
    .end local v1    # "packageName":Ljava/lang/String;
    :cond_1
    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v3

    if-eqz v3, :cond_2

    .line 895
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    .line 896
    .local v2, "sdkInt":I
    const/16 v3, 0x8

    if-ge v2, v3, :cond_3

    .line 897
    const-string v0, "com.android.launcher.settings"

    .line 907
    .end local v2    # "sdkInt":I
    :cond_2
    :goto_0
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "content://"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "/favorites?notify=true"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 908
    return-object v0

    .line 898
    .restart local v2    # "sdkInt":I
    :cond_3
    const/16 v3, 0x13

    if-ge v2, v3, :cond_4

    .line 899
    const-string v0, "com.android.launcher2.settings"

    goto :goto_0

    .line 900
    :cond_4
    const/16 v3, 0x15

    if-ge v2, v3, :cond_5

    .line 901
    const-string v0, "com.android.launcher3.settings"

    goto :goto_0

    .line 904
    :cond_5
    const-string v0, "com.android.launcher4.settings"

    goto :goto_0
.end method

.method public static getAuthorityFromPermissionDefault(Landroid/content/Context;)Ljava/lang/String;
    .locals 1
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 929
    const-string v0, "com.android.launcher.permission.READ_SETTINGS"

    invoke-static {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getThirdAuthorityFromPermission(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public static getCurrentLauncherPackageName(Landroid/content/Context;)Ljava/lang/String;
    .locals 4
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 913
    new-instance v0, Landroid/content/Intent;

    const-string v2, "android.intent.action.MAIN"

    invoke-direct {v0, v2}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 914
    .local v0, "intent":Landroid/content/Intent;
    const-string v2, "android.intent.category.HOME"

    invoke-virtual {v0, v2}, Landroid/content/Intent;->addCategory(Ljava/lang/String;)Landroid/content/Intent;

    .line 915
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    const/4 v3, 0x0

    .line 916
    invoke-virtual {v2, v0, v3}, Landroid/content/pm/PackageManager;->resolveActivity(Landroid/content/Intent;I)Landroid/content/pm/ResolveInfo;

    move-result-object v1

    .line 917
    .local v1, "res":Landroid/content/pm/ResolveInfo;
    if-eqz v1, :cond_0

    iget-object v2, v1, Landroid/content/pm/ResolveInfo;->activityInfo:Landroid/content/pm/ActivityInfo;

    if-nez v2, :cond_1

    .line 919
    :cond_0
    const-string v2, ""

    .line 924
    :goto_0
    return-object v2

    .line 921
    :cond_1
    iget-object v2, v1, Landroid/content/pm/ResolveInfo;->activityInfo:Landroid/content/pm/ActivityInfo;

    iget-object v2, v2, Landroid/content/pm/ActivityInfo;->packageName:Ljava/lang/String;

    const-string v3, "android"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2

    .line 922
    const-string v2, ""

    goto :goto_0

    .line 924
    :cond_2
    iget-object v2, v1, Landroid/content/pm/ResolveInfo;->activityInfo:Landroid/content/pm/ActivityInfo;

    iget-object v2, v2, Landroid/content/pm/ActivityInfo;->packageName:Ljava/lang/String;

    goto :goto_0
.end method

.method private static getLauncherPkgName(Landroid/content/Context;)Ljava/lang/String;
    .locals 6
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 872
    const-string v4, "activity"

    invoke-virtual {p0, v4}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/ActivityManager;

    .line 873
    .local v0, "activityManager":Landroid/app/ActivityManager;
    invoke-virtual {v0}, Landroid/app/ActivityManager;->getRunningAppProcesses()Ljava/util/List;

    move-result-object v2

    .line 874
    .local v2, "list":Ljava/util/List;, "Ljava/util/List<Landroid/app/ActivityManager$RunningAppProcessInfo;>;"
    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :cond_0
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_1

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/app/ActivityManager$RunningAppProcessInfo;

    .line 875
    .local v1, "info":Landroid/app/ActivityManager$RunningAppProcessInfo;
    iget-object v3, v1, Landroid/app/ActivityManager$RunningAppProcessInfo;->processName:Ljava/lang/String;

    .line 876
    .local v3, "pkgName":Ljava/lang/String;
    const-string v5, "launcher"

    invoke-virtual {v3, v5}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    const-string v5, "android"

    invoke-virtual {v3, v5}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 882
    .end local v1    # "info":Landroid/app/ActivityManager$RunningAppProcessInfo;
    .end local v3    # "pkgName":Ljava/lang/String;
    :goto_0
    return-object v3

    :cond_1
    const/4 v3, 0x0

    goto :goto_0
.end method

.method public static getMD5EncryptedString(Ljava/lang/String;)Ljava/lang/String;
    .locals 6
    .param p0, "encTarget"    # Ljava/lang/String;

    .prologue
    .line 1147
    const/4 v2, 0x0

    .line 1149
    .local v2, "mdEnc":Ljava/security/MessageDigest;
    :try_start_0
    const-string v3, "MD5"

    invoke-static {v3}, Ljava/security/MessageDigest;->getInstance(Ljava/lang/String;)Ljava/security/MessageDigest;
    :try_end_0
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v2

    .line 1154
    :goto_0
    invoke-virtual {p0}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    const/4 v4, 0x0

    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v5

    invoke-virtual {v2, v3, v4, v5}, Ljava/security/MessageDigest;->update([BII)V

    .line 1155
    new-instance v3, Ljava/math/BigInteger;

    const/4 v4, 0x1

    invoke-virtual {v2}, Ljava/security/MessageDigest;->digest()[B

    move-result-object v5

    invoke-direct {v3, v4, v5}, Ljava/math/BigInteger;-><init>(I[B)V

    const/16 v4, 0x10

    invoke-virtual {v3, v4}, Ljava/math/BigInteger;->toString(I)Ljava/lang/String;

    move-result-object v1

    .line 1156
    .local v1, "md5":Ljava/lang/String;
    :goto_1
    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v3

    const/16 v4, 0x20

    if-ge v3, v4, :cond_0

    .line 1157
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "0"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    goto :goto_1

    .line 1150
    .end local v1    # "md5":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 1151
    .local v0, "e":Ljava/security/NoSuchAlgorithmException;
    sget-object v3, Ljava/lang/System;->out:Ljava/io/PrintStream;

    const-string v4, "Exception while encrypting to md5"

    invoke-virtual {v3, v4}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 1152
    invoke-virtual {v0}, Ljava/security/NoSuchAlgorithmException;->printStackTrace()V

    goto :goto_0

    .line 1159
    .end local v0    # "e":Ljava/security/NoSuchAlgorithmException;
    .restart local v1    # "md5":Ljava/lang/String;
    :cond_0
    return-object v1
.end method

.method public static getThirdAuthorityFromPermission(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;
    .locals 10
    .param p0, "context"    # Landroid/content/Context;
    .param p1, "permission"    # Ljava/lang/String;

    .prologue
    .line 934
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 935
    const-string v5, ""

    .line 961
    :goto_0
    return-object v5

    .line 939
    :cond_0
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v5

    const/16 v6, 0x8

    .line 940
    invoke-virtual {v5, v6}, Landroid/content/pm/PackageManager;->getInstalledPackages(I)Ljava/util/List;

    move-result-object v2

    .line 941
    .local v2, "packs":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/PackageInfo;>;"
    if-nez v2, :cond_1

    .line 942
    const-string v5, ""

    goto :goto_0

    .line 944
    :cond_1
    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v6

    :cond_2
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_5

    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/content/pm/PackageInfo;

    .line 945
    .local v1, "pack":Landroid/content/pm/PackageInfo;
    iget-object v4, v1, Landroid/content/pm/PackageInfo;->providers:[Landroid/content/pm/ProviderInfo;

    .line 946
    .local v4, "providers":[Landroid/content/pm/ProviderInfo;
    if-eqz v4, :cond_2

    .line 947
    array-length v7, v4

    const/4 v5, 0x0

    :goto_1
    if-ge v5, v7, :cond_2

    aget-object v3, v4, v5

    .line 948
    .local v3, "provider":Landroid/content/pm/ProviderInfo;
    iget-object v8, v3, Landroid/content/pm/ProviderInfo;->readPermission:Ljava/lang/String;

    invoke-virtual {p1, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_3

    iget-object v8, v3, Landroid/content/pm/ProviderInfo;->writePermission:Ljava/lang/String;

    .line 949
    invoke-virtual {p1, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_4

    .line 950
    :cond_3
    iget-object v8, v3, Landroid/content/pm/ProviderInfo;->authority:Ljava/lang/String;

    invoke-static {v8}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v8

    if-nez v8, :cond_4

    iget-object v8, v3, Landroid/content/pm/ProviderInfo;->authority:Ljava/lang/String;

    const-string v9, ".launcher.settings"

    .line 952
    invoke-virtual {v8, v9}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v8

    if-eqz v8, :cond_4

    .line 953
    iget-object v5, v3, Landroid/content/pm/ProviderInfo;->authority:Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 947
    :cond_4
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    .line 958
    .end local v1    # "pack":Landroid/content/pm/PackageInfo;
    .end local v2    # "packs":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/PackageInfo;>;"
    .end local v3    # "provider":Landroid/content/pm/ProviderInfo;
    .end local v4    # "providers":[Landroid/content/pm/ProviderInfo;
    :catch_0
    move-exception v0

    .line 959
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 961
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_5
    const-string v5, ""

    goto :goto_0
.end method

.method public static hasShortcut(Landroid/content/Context;)Z
    .locals 14
    .param p0, "cx"    # Landroid/content/Context;

    .prologue
    .line 824
    const/4 v11, 0x0

    .line 826
    .local v11, "result":Z
    const/4 v12, 0x0

    .line 827
    .local v12, "title":Ljava/lang/String;
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "title = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 829
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v10

    .line 831
    .local v10, "pm":Landroid/content/pm/PackageManager;
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    const/16 v2, 0x80

    invoke-virtual {v10, v0, v2}, Landroid/content/pm/PackageManager;->getApplicationInfo(Ljava/lang/String;I)Landroid/content/pm/ApplicationInfo;

    move-result-object v0

    .line 830
    invoke-virtual {v10, v0}, Landroid/content/pm/PackageManager;->getApplicationLabel(Landroid/content/pm/ApplicationInfo;)Ljava/lang/CharSequence;

    move-result-object v0

    .line 832
    invoke-interface {v0}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v12

    .line 836
    .end local v10    # "pm":Landroid/content/pm/PackageManager;
    :goto_0
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "title = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 847
    invoke-static {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getAuthorityFromPermission(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v13

    .line 849
    .local v13, "uriStr":Ljava/lang/String;
    invoke-static {v13}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v1

    .line 850
    .local v1, "CONTENT_URI":Landroid/net/Uri;
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "CONTENT_URI = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 852
    invoke-virtual {p0}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v0

    const/4 v2, 0x0

    const-string v3, "title=?"

    const/4 v4, 0x1

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    aput-object v12, v4, v5

    const/4 v5, 0x0

    invoke-virtual/range {v0 .. v5}, Landroid/content/ContentResolver;->query(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v6

    .line 855
    .local v6, "c":Landroid/database/Cursor;
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Cursor = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 857
    invoke-virtual {p0}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v0

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "title"

    aput-object v4, v2, v3

    const/4 v3, 0x1

    const-string v4, "iconResource"

    aput-object v4, v2, v3

    const-string v3, "title=?"

    const/4 v4, 0x1

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    aput-object v12, v4, v5

    const/4 v5, 0x0

    invoke-virtual/range {v0 .. v5}, Landroid/content/ContentResolver;->query(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v7

    .line 859
    .local v7, "cursor2":Landroid/database/Cursor;
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "cursor2 = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 861
    invoke-virtual {p0}, Landroid/content/Context;->getContentResolver()Landroid/content/ContentResolver;

    move-result-object v0

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/String;

    const/4 v3, 0x0

    const-string v4, "title"

    aput-object v4, v2, v3

    const-string v3, "title=?"

    const/4 v4, 0x1

    new-array v4, v4, [Ljava/lang/String;

    const/4 v5, 0x0

    aput-object v12, v4, v5

    const/4 v5, 0x0

    invoke-virtual/range {v0 .. v5}, Landroid/content/ContentResolver;->query(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v8

    .line 864
    .local v8, "cursor3":Landroid/database/Cursor;
    const-string v0, "hasShortcut"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "cursor3 = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 866
    if-eqz v6, :cond_0

    invoke-interface {v6}, Landroid/database/Cursor;->getCount()I

    move-result v0

    if-lez v0, :cond_0

    .line 867
    const/4 v11, 0x1

    .line 869
    :cond_0
    return v11

    .line 833
    .end local v1    # "CONTENT_URI":Landroid/net/Uri;
    .end local v6    # "c":Landroid/database/Cursor;
    .end local v7    # "cursor2":Landroid/database/Cursor;
    .end local v8    # "cursor3":Landroid/database/Cursor;
    .end local v13    # "uriStr":Ljava/lang/String;
    :catch_0
    move-exception v9

    .line 834
    .local v9, "e":Ljava/lang/Exception;
    const-string v0, "hasShortcut"

    const-string v2, "hasShortcut Exception"

    invoke-static {v0, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0
.end method

.method public static instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;
    .locals 1

    .prologue
    .line 671
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    return-object v0
.end method

.method private setupForIGGPlatform()V
    .locals 3

    .prologue
    .line 479
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setFamily(Lcom/igg/sdk/IGGSDKConstant$IGGFamily;)V

    .line 481
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setApplication(Landroid/app/Application;)V

    .line 483
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    const-string v1, "1051019902"

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setGameId(Ljava/lang/String;)V

    .line 486
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    const-string v1, "f6239975b2faae941ec24695e4db5bba"

    .line 487
    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setSecretKey(Ljava/lang/String;)V

    .line 489
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    const-string v1, "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAp4s2WiW7VMKUewEIr+/Y3hMUO4AQQU2tbkg4irGkHYOGmdBT5SBxysco4jtJ1wbfx3bl2PfotPutU6xrTz/0+r0rmcEfv6EaKwyreNkp4Ej/yX7qvoXHHl33ISdpC3UOkFNb+8KaovSA8/TBGBA+O5TpeCTtTs0H1aoSCtR5LdYciRj9a2GkO+rcgB8OqZc+laXDIIzm8E+sn4r0oMDeQnJ+XiSmDpzAlQnbw2K7ycjlk9I/UhkyhiHz6U8KxuOvuU9im4mc1omOF3sD7EVWtd3OAr5xdJAipYoM8+0T4Jz5OOD3eClF6q5i9xtcRVoyEAqy8K+7bQOWB8/Zv57BLQIDAQAB"

    .line 490
    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setPaymentKey(Ljava/lang/String;)V

    .line 493
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    const-string v1, "489219977954"

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setGCMSenderId(Ljava/lang/String;)V

    .line 494
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getApplication()Landroid/app/Application;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/IGGSDK;->setPushMessageCustomHandle(Landroid/content/Context;Z)V

    .line 496
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 497
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$9;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$9;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->initialize(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V

    .line 501
    return-void
.end method


# virtual methods
.method public AdwordsHeroStage1_3Event()V
    .locals 1

    .prologue
    .line 1680
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->HeroStage1_3()V

    .line 1681
    return-void
.end method

.method public AdwordsInstallEvent()V
    .locals 1

    .prologue
    .line 1664
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->Install()V

    .line 1665
    return-void
.end method

.method public AdwordsJoinGuildEvent()V
    .locals 1

    .prologue
    .line 1672
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->JoinGuild()V

    .line 1673
    return-void
.end method

.method public AdwordsPayEvent()V
    .locals 1

    .prologue
    .line 1684
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->Pay()V

    .line 1685
    return-void
.end method

.method public AdwordsReachCastle5Event()V
    .locals 1

    .prologue
    .line 1676
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->ReachCastle5()V

    .line 1677
    return-void
.end method

.method public AdwordsSingUpEvent()V
    .locals 1

    .prologue
    .line 1668
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAdwordsHelper;->SingUp()V

    .line 1669
    return-void
.end method

.method public AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;

    .prologue
    .line 1655
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;

    move-result-object v0

    const-string v1, "somebody"

    invoke-virtual {v0, p1, p2, v1, p3}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1656
    return-void
.end method

.method public AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V
    .locals 7
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;
    .param p4, "isEnableAntiAddiction"    # Z
    .param p5, "amoutOfLimit"    # F

    .prologue
    .line 1659
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;

    move-result-object v0

    const-string v3, "somebody"

    move-object v1, p1

    move-object v2, p2

    move-object v4, p3

    move v5, p4

    move v6, p5

    invoke-virtual/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V

    .line 1660
    return-void
.end method

.method public AppsFlyerAdvance(Ljava/lang/String;)V
    .locals 1
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 1261
    invoke-static {}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->AdvanceEvent(Ljava/lang/String;)V

    .line 1262
    return-void
.end method

.method public AppsFlyerSignUp()V
    .locals 1

    .prologue
    .line 1245
    invoke-static {}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->AppsFlyerSignUp()V

    .line 1246
    return-void
.end method

.method public AppsFlyerTutorialCompletion()V
    .locals 1

    .prologue
    .line 1253
    invoke-static {}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->TutorialCompletion()V

    .line 1254
    return-void
.end method

.method public AutoLogin()V
    .locals 4

    .prologue
    .line 584
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 585
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$14;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$14;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 591
    return-void
.end method

.method public BindToWeChat()V
    .locals 1

    .prologue
    .line 1621
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindToWeChat()V

    .line 1622
    return-void
.end method

.method public BuyProduct(Ljava/lang/String;I)V
    .locals 2
    .param p1, "pId"    # Ljava/lang/String;
    .param p2, "serverId"    # I

    .prologue
    .line 338
    const-string v0, "ProuductGooglePay"

    const-string v1, "BuyProduct"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 340
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;

    invoke-direct {v1, p0, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;I)V

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setGameDelegate(Lcom/igg/sdk/IGGGameDelegate;)V

    .line 362
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->pay(Ljava/lang/String;)V

    .line 373
    return-void
.end method

.method public CancelNotification(I)V
    .locals 3
    .param p1, "nid"    # I

    .prologue
    .line 1272
    const-string v0, "Alarm"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "CancelLocalNotification Cancel ID ="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1273
    invoke-static {}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->Cancel(I)V

    .line 1274
    return-void
.end method

.method public CheckGoogleAPI23()Z
    .locals 6

    .prologue
    .line 1524
    const-string v3, "CheckGoogleAPI23"

    const-string v4, "CheckGoogleAPI23"

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1527
    :try_start_0
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    .line 1533
    .local v2, "version":I
    :goto_0
    new-instance v1, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v3

    invoke-direct {v1, v3}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 1534
    .local v1, "handler":Landroid/os/Handler;
    new-instance v3, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$26;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$26;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v4, 0x3e8

    invoke-virtual {v1, v3, v4, v5}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 1555
    const/16 v3, 0x17

    if-lt v2, v3, :cond_0

    const/4 v3, 0x1

    :goto_1
    return v3

    .line 1529
    .end local v1    # "handler":Landroid/os/Handler;
    .end local v2    # "version":I
    :catch_0
    move-exception v0

    .line 1530
    .local v0, "e":Ljava/lang/NumberFormatException;
    const/4 v2, 0x0

    .restart local v2    # "version":I
    goto :goto_0

    .line 1555
    .end local v0    # "e":Ljava/lang/NumberFormatException;
    .restart local v1    # "handler":Landroid/os/Handler;
    :cond_0
    const/4 v3, 0x0

    goto :goto_1
.end method

.method public CheckGooglePlayServicesUtil()Z
    .locals 4

    .prologue
    .line 1559
    const/4 v0, 0x1

    .line 1560
    .local v0, "isSupported":Z
    invoke-static {p0}, Lcom/google/android/gms/common/GooglePlayServicesUtil;->isGooglePlayServicesAvailable(Landroid/content/Context;)I

    move-result v1

    .line 1561
    .local v1, "resultCode":I
    if-eqz v1, :cond_0

    .line 1562
    const-string v2, "CheckGooglePlayServicesUtil"

    const-string v3, "No valid Google Play Services APK found"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 1563
    const/4 v0, 0x0

    .line 1569
    :goto_0
    return v0

    .line 1567
    :cond_0
    const-string v2, "CheckGooglePlayServicesUtil"

    const-string v3, "ConnectionResult.SUCCESS"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public CheckRealNameState()V
    .locals 2

    .prologue
    .line 1419
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$24;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$24;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1424
    return-void
.end method

.method public CheckWifi()Z
    .locals 7

    .prologue
    const/4 v4, 0x1

    const/4 v3, 0x0

    .line 1791
    :try_start_0
    sget-object v5, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    if-nez v5, :cond_1

    .line 1806
    :cond_0
    :goto_0
    return v3

    .line 1793
    :cond_1
    sget-object v5, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const-string v6, "connectivity"

    invoke-virtual {v5, v6}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/net/ConnectivityManager;

    .line 1794
    .local v1, "cm":Landroid/net/ConnectivityManager;
    if-eqz v1, :cond_0

    .line 1796
    invoke-virtual {v1}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v0

    .line 1797
    .local v0, "activeNetwork":Landroid/net/NetworkInfo;
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Landroid/net/NetworkInfo;->isConnectedOrConnecting()Z

    move-result v5

    if-eqz v5, :cond_0

    .line 1798
    invoke-virtual {v0}, Landroid/net/NetworkInfo;->getType()I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v5

    if-ne v5, v4, :cond_0

    move v3, v4

    .line 1799
    goto :goto_0

    .line 1804
    .end local v0    # "activeNetwork":Landroid/net/NetworkInfo;
    .end local v1    # "cm":Landroid/net/ConnectivityManager;
    :catch_0
    move-exception v2

    .line 1805
    .local v2, "e":Ljava/lang/Exception;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->TAG:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public ClearFacebookSession()V
    .locals 1

    .prologue
    .line 1353
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->ClearFacebookSession()V

    .line 1354
    return-void
.end method

.method public ClosePushNotification()V
    .locals 4

    .prologue
    .line 298
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 299
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$4;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$4;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 305
    return-void
.end method

.method public CompleteRegistration(Ljava/lang/String;)V
    .locals 1
    .param p1, "registrationMethod"    # Ljava/lang/String;

    .prologue
    .line 1312
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CompleteRegistration(Ljava/lang/String;)V

    .line 1313
    return-void
.end method

.method public ExchangeUrl()Ljava/lang/String;
    .locals 7

    .prologue
    .line 1126
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    .line 1127
    .local v2, "gamid":Ljava/lang/String;
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v3

    .line 1129
    .local v3, "signedkey":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "from=phone&game_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&signed_key="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&char_id=0etuaxaXNbBANAzvFBvH"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "lordsmobile.igg.com"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 1131
    .local v1, "encTarget":Ljava/lang/String;
    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getMD5EncryptedString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1133
    .local v0, "MD5":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "http://lordsmobile.igg.com/event/cdkey_inner/?from=phone&game_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&signed_key="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&char_id=0&event_sig="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1135
    .local v4, "url":Ljava/lang/String;
    return-object v4
.end method

.method public FacebookLike()V
    .locals 3

    .prologue
    .line 223
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetFaceBookLike()Ljava/lang/String;

    move-result-object v0

    .line 224
    .local v0, "pUrl":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 225
    const-string v1, "FacebookLikeCallBack"

    const-string v2, ""

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 226
    return-void
.end method

.method public Flush()V
    .locals 1

    .prologue
    .line 1304
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->Flush()V

    .line 1305
    return-void
.end method

.method public ForumLink()V
    .locals 5

    .prologue
    .line 250
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetForumLink()Ljava/lang/String;

    move-result-object v2

    .line 253
    .local v2, "pUrl":Ljava/lang/String;
    move-object v0, p0

    .line 254
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v4, "android.intent.action.VIEW"

    invoke-direct {v1, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 255
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v3

    .line 256
    .local v3, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v3}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 257
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 258
    return-void
.end method

.method public GetCountry()Ljava/lang/String;
    .locals 2

    .prologue
    .line 1574
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    invoke-virtual {v1}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v1

    iget-object v1, v1, Landroid/content/res/Configuration;->locale:Ljava/util/Locale;

    invoke-virtual {v1}, Ljava/util/Locale;->getCountry()Ljava/lang/String;

    move-result-object v0

    .line 1575
    .local v0, "Country":Ljava/lang/String;
    const-string v1, "GetCountry"

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1576
    return-object v0
.end method

.method public GetCountryCode()Ljava/lang/String;
    .locals 3

    .prologue
    .line 1771
    :try_start_0
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v1

    invoke-static {v1}, Lcom/igg/util/DeviceUtil;->getCountryCode(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v1

    sget-object v2, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-virtual {v1, v2}, Ljava/lang/String;->toUpperCase(Ljava/util/Locale;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 1773
    :goto_0
    return-object v1

    .line 1772
    :catch_0
    move-exception v0

    .line 1773
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, ""

    goto :goto_0
.end method

.method public GetExternalFilesDir()Ljava/lang/String;
    .locals 2

    .prologue
    .line 1689
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getExternalFilesDir(Ljava/lang/String;)Ljava/io/File;

    move-result-object v0

    invoke-virtual {v0}, Ljava/io/File;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public GetFilesDir()Ljava/lang/String;
    .locals 1

    .prologue
    .line 1693
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getFilesDir()Ljava/io/File;

    move-result-object v0

    invoke-virtual {v0}, Ljava/io/File;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public GetGoogleAccountList()[Ljava/lang/String;
    .locals 5

    .prologue
    .line 164
    sget-object v3, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .line 165
    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    .line 164
    invoke-static {v3}, Landroid/accounts/AccountManager;->get(Landroid/content/Context;)Landroid/accounts/AccountManager;

    move-result-object v3

    const-string v4, "com.google"

    .line 165
    invoke-virtual {v3, v4}, Landroid/accounts/AccountManager;->getAccountsByType(Ljava/lang/String;)[Landroid/accounts/Account;

    move-result-object v0

    .line 168
    .local v0, "accounts":[Landroid/accounts/Account;
    array-length v3, v0

    new-array v2, v3, [Ljava/lang/String;

    .line 169
    .local v2, "names":[Ljava/lang/String;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    array-length v3, v2

    if-ge v1, v3, :cond_0

    .line 170
    aget-object v3, v0, v1

    iget-object v3, v3, Landroid/accounts/Account;->name:Ljava/lang/String;

    aput-object v3, v2, v1

    .line 169
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 172
    :cond_0
    return-object v2
.end method

.method public GetID()Ljava/lang/String;
    .locals 1

    .prologue
    .line 1030
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public GetNewsUrl(Ljava/lang/String;Ljava/lang/String;I)Ljava/lang/String;
    .locals 7
    .param p1, "pUrl"    # Ljava/lang/String;
    .param p2, "key"    # Ljava/lang/String;
    .param p3, "kingdomID"    # I

    .prologue
    .line 1109
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    .line 1110
    .local v2, "gamid":Ljava/lang/String;
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v3

    .line 1113
    .local v3, "signedkey":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "game_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&signed_key="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&char_id=0&s_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 1115
    .local v1, "encTarget":Ljava/lang/String;
    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getMD5EncryptedString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1119
    .local v0, "MD5":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "game_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&signed_key="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&char_id=0&s_id="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&sig="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1121
    .local v4, "url":Ljava/lang/String;
    return-object v4
.end method

.method public GetObbDir()Ljava/lang/String;
    .locals 1

    .prologue
    .line 1697
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getObbDir()Ljava/io/File;

    move-result-object v0

    invoke-virtual {v0}, Ljava/io/File;->canWrite()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1698
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getObbDir()Ljava/io/File;

    move-result-object v0

    invoke-virtual {v0}, Ljava/io/File;->toString()Ljava/lang/String;

    move-result-object v0

    .line 1700
    :goto_0
    return-object v0

    :cond_0
    const-string v0, ""

    goto :goto_0
.end method

.method public GetPackageName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 1741
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getPackageName()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public GetProductList()V
    .locals 0

    .prologue
    .line 334
    return-void
.end method

.method public GetToken()V
    .locals 1

    .prologue
    .line 1336
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->GetToken()V

    .line 1337
    return-void
.end method

.method public GetWeChatProductList()V
    .locals 1

    .prologue
    .line 1639
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProduct()V

    .line 1640
    return-void
.end method

.method public GeustLogin()V
    .locals 4

    .prologue
    .line 574
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 575
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$13;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$13;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 581
    return-void
.end method

.method public GoToNews(Ljava/lang/String;Ljava/lang/String;I)V
    .locals 1
    .param p1, "pUrl"    # Ljava/lang/String;
    .param p2, "key"    # Ljava/lang/String;
    .param p3, "kingdomID"    # I

    .prologue
    .line 1105
    invoke-virtual {p0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->GetNewsUrl(Ljava/lang/String;Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 1106
    return-void
.end method

.method public GoogleAccountLogin()V
    .locals 4

    .prologue
    .line 554
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 555
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$11;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$11;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 562
    return-void
.end method

.method public GoogleAccountLogin(Ljava/lang/String;)V
    .locals 4
    .param p1, "pName"    # Ljava/lang/String;

    .prologue
    .line 543
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 544
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;

    invoke-direct {v1, p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 550
    return-void
.end method

.method public Guide(Ljava/lang/String;)V
    .locals 3
    .param p1, "pUrl"    # Ljava/lang/String;

    .prologue
    .line 1182
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "game_id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 1183
    .local v0, "url":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 1191
    return-void
.end method

.method public HeroStageCompletion()V
    .locals 1

    .prologue
    .line 1257
    invoke-static {}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->HeroStageCompletion()V

    .line 1258
    return-void
.end method

.method public Init(Z)V
    .locals 0
    .param p1, "pIsLogPrint"    # Z

    .prologue
    .line 683
    sput-boolean p1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->isAppPrintLog:Z

    .line 684
    return-void
.end method

.method public InitIggData()V
    .locals 0

    .prologue
    .line 528
    return-void
.end method

.method public IntentIM(Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "subject"    # Ljava/lang/String;
    .param p2, "content"    # Ljava/lang/String;

    .prologue
    .line 1778
    new-instance v0, Landroid/content/Intent;

    invoke-direct {v0}, Landroid/content/Intent;-><init>()V

    .line 1779
    .local v0, "share_intent":Landroid/content/Intent;
    const-string v1, "android.intent.action.SEND"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 1780
    const-string v1, "text/plain"

    invoke-virtual {v0, v1}, Landroid/content/Intent;->setType(Ljava/lang/String;)Landroid/content/Intent;

    .line 1781
    const-string v1, "android.intent.extra.SUBJECT"

    invoke-virtual {v0, v1, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1782
    const-string v1, "android.intent.extra.TEXT"

    invoke-virtual {v0, v1, p2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 1785
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->startActivity(Landroid/content/Intent;)V

    .line 1786
    return-void
.end method

.method public IsAppInstalled(Ljava/lang/String;)Z
    .locals 5
    .param p1, "pAppUri"    # Ljava/lang/String;

    .prologue
    .line 1035
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .line 1036
    .local v0, "context":Landroid/content/Context;
    invoke-virtual {v0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    .line 1037
    .local v3, "pm":Landroid/content/pm/PackageManager;
    const/4 v2, 0x0

    .line 1039
    .local v2, "isInstalled":Z
    const/4 v4, 0x1

    :try_start_0
    invoke-virtual {v3, p1, v4}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 1040
    const/4 v2, 0x1

    .line 1044
    :goto_0
    return v2

    .line 1041
    :catch_0
    move-exception v1

    .line 1042
    .local v1, "e":Landroid/content/pm/PackageManager$NameNotFoundException;
    const/4 v2, 0x0

    goto :goto_0
.end method

.method public IsPaymentReady()Z
    .locals 1

    .prologue
    .line 152
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->IsPaymentReady()Z

    move-result v0

    return v0
.end method

.method public LaunchEvent()V
    .locals 1

    .prologue
    .line 1249
    invoke-static {}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/AppsFlyerHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/AppsFlyerHelper;->LaunchEvent()V

    .line 1250
    return-void
.end method

.method public LinkGoogleAccount()V
    .locals 4

    .prologue
    .line 188
    const-string v1, "LinkGoogleAccount\u3002\u3002\u3002\u3002\uff01"

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 189
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 190
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$2;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 211
    return-void
.end method

.method public LinkGoogleAccount(Ljava/lang/String;)V
    .locals 4
    .param p1, "pId"    # Ljava/lang/String;

    .prologue
    .line 177
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 178
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$1;

    invoke-direct {v1, p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$1;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 185
    return-void
.end method

.method public LoadAdLog()V
    .locals 0

    .prologue
    .line 432
    return-void
.end method

.method public LoadEventConfig()V
    .locals 1

    .prologue
    .line 218
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->LoadEventConfig()V

    .line 219
    return-void
.end method

.method public LoadGameConfig()V
    .locals 1

    .prologue
    .line 214
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->LoadGameConfig()V

    .line 215
    return-void
.end method

.method public LoadWebView(Ljava/lang/String;)V
    .locals 2
    .param p1, "pUrl"    # Ljava/lang/String;

    .prologue
    .line 156
    new-instance v0, Landroid/content/Intent;

    const-class v1, Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {v0, p0, v1}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 157
    .local v0, "intent":Landroid/content/Intent;
    const-string v1, "Url"

    invoke-virtual {v0, v1, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 158
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->startActivity(Landroid/content/Intent;)V

    .line 159
    return-void
.end method

.method public LoginLog()V
    .locals 6

    .prologue
    .line 435
    new-instance v1, Lcom/igg/sdk/log/IGGLogger;

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-direct {v1, v2}, Lcom/igg/sdk/log/IGGLogger;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 437
    .local v1, "logger":Lcom/igg/sdk/log/IGGLogger;
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    invoke-direct {v0, v2}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 438
    .local v0, "handler":Landroid/os/Handler;
    new-instance v2, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    invoke-direct {v2, p0, v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Lcom/igg/sdk/log/IGGLogger;)V

    const-wide/16 v4, 0x3e8

    invoke-virtual {v0, v2, v4, v5}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 463
    return-void
.end method

.method public LoginWeChat()V
    .locals 1

    .prologue
    .line 1626
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->LoginWeChat()V

    .line 1627
    return-void
.end method

.method public NotificationUninitialize()V
    .locals 3

    .prologue
    .line 1366
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->CheckGooglePlayServicesUtil()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 1368
    invoke-static {}, Lcom/igg/sdk/push/IGGPushNotification;->sharedInstance()Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v1, v2}, Lcom/igg/sdk/push/IIGGPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    move-result-object v0

    check-cast v0, Lcom/igg/sdk/push/IGGGCMPushNotification;

    .line 1369
    .local v0, "notification":Lcom/igg/sdk/push/IGGGCMPushNotification;
    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGGCMPushNotification;->uninitialize()V

    .line 1371
    .end local v0    # "notification":Lcom/igg/sdk/push/IGGGCMPushNotification;
    :cond_0
    return-void
.end method

.method public OpenFbByUrl(Ljava/lang/String;)V
    .locals 5
    .param p1, "url"    # Ljava/lang/String;

    .prologue
    .line 1095
    move-object v0, p0

    .line 1096
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    invoke-direct {v1, v3}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1097
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {p1}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 1098
    .local v2, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 1099
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 1100
    const-string v3, "OpenFbByUrl"

    const-string v4, "OpenFbByUrl CallBack"

    invoke-static {v3, v4}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 1101
    return-void
.end method

.method public OpenGeTuiNotification()V
    .locals 4

    .prologue
    .line 309
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 310
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$5;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$5;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 317
    return-void
.end method

.method public OpenGooglePlayStoreUrl(Ljava/lang/String;Ljava/lang/String;)V
    .locals 4
    .param p1, "pString"    # Ljava/lang/String;
    .param p2, "my_package_name"    # Ljava/lang/String;

    .prologue
    .line 974
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 975
    .local v0, "handler":Landroid/os/Handler;
    const-string v1, "OpenGooglePlayStoreUrl"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "url = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ";"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "my_package_name = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 976
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;

    invoke-direct {v1, p0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$15;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;Ljava/lang/String;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 1000
    return-void
.end method

.method public OpenPushNotification()V
    .locals 4

    .prologue
    .line 282
    const-string v1, "GCM"

    const-string v2, "OpenPushNotification\u3002\u3002\u3002\u3002\uff01"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 283
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->CheckGooglePlayServicesUtil()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 285
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 286
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$3;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$3;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 295
    .end local v0    # "handler":Landroid/os/Handler;
    :goto_0
    return-void

    .line 294
    :cond_0
    const-string v1, "GCM"

    const-string v2, "CheckGooglePlayServicesUtil = False"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public OpenRealNameUrlByWebView(Ljava/lang/String;)V
    .locals 3
    .param p1, "Sync"    # Ljava/lang/String;

    .prologue
    .line 1427
    const-string v0, "RealNameVerificationHelper"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Sync ="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 1428
    const-string v0, "1"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 1429
    invoke-static {}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->OpenRealNameSync()V

    .line 1432
    :cond_0
    :goto_0
    return-void

    .line 1430
    :cond_1
    const-string v0, "2"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1431
    invoke-static {}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->OpenRealNameAsync()V

    goto :goto_0
.end method

.method public OpenRealnameVerification()V
    .locals 2

    .prologue
    .line 1410
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$23;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$23;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1416
    return-void
.end method

.method public OpenThirdPartyPayment(I)V
    .locals 5
    .param p1, "serverID"    # I

    .prologue
    .line 1581
    sget-object v3, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v3}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v1

    .line 1582
    .local v1, "signedkey":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    .line 1583
    .local v0, "gameid":Ljava/lang/String;
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "http://pay-fb.igg.com/platform_mixing/?g_id="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&s_id="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "&signed_key="

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 1584
    .local v2, "url":Ljava/lang/String;
    invoke-virtual {p0, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 1592
    return-void
.end method

.method public PrivacyPolicy()V
    .locals 2

    .prologue
    .line 271
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetPrivacyPolicy()Ljava/lang/String;

    move-result-object v0

    .line 272
    .local v0, "pUrl":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 273
    return-void
.end method

.method public RateGooglePlayApplication(Ljava/lang/String;)V
    .locals 4
    .param p1, "pString"    # Ljava/lang/String;

    .prologue
    .line 1003
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "rate googleplay application:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 1004
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 1006
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;

    invoke-direct {v1, p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$16;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 1027
    return-void
.end method

.method public RateUs()V
    .locals 6

    .prologue
    .line 378
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    invoke-direct {v0, v2}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 379
    .local v0, "handler":Landroid/os/Handler;
    const-string v1, "market://details?id=com.igg.android.lordsonline_tw"

    .line 382
    .local v1, "pString":Ljava/lang/String;
    new-instance v2, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$7;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    const-wide/16 v4, 0x3e8

    invoke-virtual {v0, v2, v4, v5}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 400
    return-void
.end method

.method public RegisterCallback()V
    .locals 2

    .prologue
    .line 1344
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$22;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$22;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1350
    return-void
.end method

.method public SendMail(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 12
    .param p1, "MailTo"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "UTCTime"    # Ljava/lang/String;
    .param p4, "GameName"    # Ljava/lang/String;
    .param p5, "GameVersion"    # Ljava/lang/String;
    .param p6, "PlayerID"    # Ljava/lang/String;
    .param p7, "Language"    # Ljava/lang/String;
    .param p8, "DeviceType"    # Ljava/lang/String;
    .param p9, "OsVersion"    # Ljava/lang/String;

    .prologue
    .line 1050
    new-instance v11, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-direct {v11, v0}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 1051
    .local v11, "handler":Landroid/os/Handler;
    new-instance v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$17;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object/from16 v4, p6

    move-object v5, p3

    move-object/from16 v6, p4

    move-object/from16 v7, p5

    move-object/from16 v8, p7

    move-object/from16 v9, p8

    move-object/from16 v10, p9

    invoke-direct/range {v0 .. v10}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$17;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v11, v0, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 1084
    return-void
.end method

.method public SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pContext"    # Ljava/lang/String;

    .prologue
    .line 667
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->MessageId:Ljava/lang/String;

    invoke-static {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->UnitySendMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 668
    return-void
.end method

.method public SendTicket()V
    .locals 2

    .prologue
    .line 261
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetSendTicket()Ljava/lang/String;

    move-result-object v0

    .line 262
    .local v0, "pUrl":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 263
    return-void
.end method

.method public SetAppsFlyerKey()V
    .locals 2

    .prologue
    .line 1233
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$18;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$18;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1242
    return-void
.end method

.method public SetFacebookCustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "eventName"    # Ljava/lang/String;
    .param p2, "time"    # Ljava/lang/String;
    .param p3, "iggId"    # Ljava/lang/String;

    .prologue
    .line 1357
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1358
    return-void
.end method

.method public SetFacebookCustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 6
    .param p1, "eventName"    # Ljava/lang/String;
    .param p2, "time"    # Ljava/lang/String;
    .param p3, "iggId"    # Ljava/lang/String;
    .param p4, "key"    # Ljava/lang/String;
    .param p5, "value"    # Ljava/lang/String;

    .prologue
    .line 1361
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    invoke-virtual/range {v0 .. v5}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CustomEvent(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1362
    return-void
.end method

.method public SetFacebookEventActivateApp()V
    .locals 2

    .prologue
    .line 1288
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$20;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$20;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1293
    return-void
.end method

.method public SetFacebookEventCompletedTutorial()V
    .locals 1

    .prologue
    .line 1316
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->CompletedTutorial()V

    .line 1317
    return-void
.end method

.method public SetFacebookEventDeactivateApp()V
    .locals 2

    .prologue
    .line 1296
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$21;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$21;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1301
    return-void
.end method

.method public SetFacebookEventLaunched()V
    .locals 1

    .prologue
    .line 1308
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->AppLaunched()V

    .line 1309
    return-void
.end method

.method public SetFacebookEventPurchases(DLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 9
    .param p1, "price"    # D
    .param p3, "num_items"    # Ljava/lang/String;
    .param p4, "content_type"    # Ljava/lang/String;
    .param p5, "content_id"    # Ljava/lang/String;
    .param p6, "currency"    # Ljava/lang/String;

    .prologue
    .line 1320
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v1

    move-wide v2, p1

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    move-object v7, p6

    invoke-virtual/range {v1 .. v7}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->Purchases(DLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1321
    return-void
.end method

.method public SetFacebookEventSpentCredits(DLjava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "value"    # D
    .param p3, "content_type"    # Ljava/lang/String;
    .param p4, "content_id"    # Ljava/lang/String;

    .prologue
    .line 1324
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3, p4}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->SpentCredits(DLjava/lang/String;Ljava/lang/String;)V

    .line 1325
    return-void
.end method

.method public SetFacebookSdkInitialize()V
    .locals 2

    .prologue
    .line 1280
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$19;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$19;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1286
    return-void
.end method

.method public SetGameID(Ljava/lang/String;)V
    .locals 1
    .param p1, "id"    # Ljava/lang/String;

    .prologue
    .line 1765
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/sdk/IGGSDK;->setGameId(Ljava/lang/String;)V

    .line 1766
    return-void
.end method

.method public SetIDC(Ljava/lang/String;)V
    .locals 2
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 1480
    const-string v0, "1051029902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1481
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 1520
    :goto_0
    return-void

    .line 1482
    :cond_0
    const-string v0, "1051039902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 1483
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1484
    :cond_1
    const-string v0, "1051019902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 1485
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1486
    :cond_2
    const-string v0, "1051059902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 1487
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1488
    :cond_3
    const-string v0, "1051049902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 1489
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1490
    :cond_4
    const-string v0, "1051069902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_5

    .line 1491
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1492
    :cond_5
    const-string v0, "1051079902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    .line 1493
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1494
    :cond_6
    const-string v0, "1051089902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_7

    .line 1495
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto :goto_0

    .line 1496
    :cond_7
    const-string v0, "1051159902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_8

    .line 1497
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1498
    :cond_8
    const-string v0, "1051169902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_9

    .line 1499
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1500
    :cond_9
    const-string v0, "1051139902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_a

    .line 1501
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1502
    :cond_a
    const-string v0, "1051149902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_b

    .line 1503
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1504
    :cond_b
    const-string v0, "1051119902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_c

    .line 1505
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1506
    :cond_c
    const-string v0, "1051129902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_d

    .line 1507
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1508
    :cond_d
    const-string v0, "1051099902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_e

    .line 1509
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1510
    :cond_e
    const-string v0, "1051109902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_f

    .line 1511
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1512
    :cond_f
    const-string v0, "1051189902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_10

    .line 1513
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1514
    :cond_10
    const-string v0, "1051199902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_11

    .line 1515
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1516
    :cond_11
    const-string v0, "1051179902"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_12

    .line 1517
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0

    .line 1519
    :cond_12
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setRegionalCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_0
.end method

.method public SetLocalNotification(ILjava/lang/String;I)V
    .locals 1
    .param p1, "nid"    # I
    .param p2, "msg"    # Ljava/lang/String;
    .param p3, "sec"    # I

    .prologue
    .line 1268
    invoke-static {}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->SetAlarm(ILjava/lang/String;I)V

    .line 1269
    return-void
.end method

.method public SetSystemUiVisibility()V
    .locals 0

    .prologue
    .line 1762
    return-void
.end method

.method public SetTragetLanguage(Ljava/lang/String;)V
    .locals 1
    .param p1, "tragetLanguage"    # Ljava/lang/String;

    .prologue
    .line 1377
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->SetTragetLanguage(Ljava/lang/String;)V

    .line 1378
    return-void
.end method

.method public SetupIGGPlatform(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 7
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "secretKey"    # Ljava/lang/String;
    .param p3, "paymentKey"    # Ljava/lang/String;
    .param p4, "SenderId"    # Ljava/lang/String;

    .prologue
    const/4 v6, 0x1

    const/4 v5, 0x0

    .line 1436
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "IGGSDK:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 1437
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    sget-object v3, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->IGG:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGSDK;->setFamily(Lcom/igg/sdk/IGGSDKConstant$IGGFamily;)V

    .line 1439
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGSDK;->setApplication(Landroid/app/Application;)V

    .line 1441
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, p1}, Lcom/igg/sdk/IGGSDK;->setGameId(Ljava/lang/String;)V

    .line 1442
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, p2}, Lcom/igg/sdk/IGGSDK;->setSecretKey(Ljava/lang/String;)V

    .line 1444
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, p3}, Lcom/igg/sdk/IGGSDK;->setPaymentKey(Ljava/lang/String;)V

    .line 1446
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, p4}, Lcom/igg/sdk/IGGSDK;->setGCMSenderId(Ljava/lang/String;)V

    .line 1448
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-virtual {v2, v3, v5}, Lcom/igg/sdk/IGGSDK;->setPushMessageCustomHandle(Landroid/content/Context;Z)V

    .line 1450
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SetIDC(Ljava/lang/String;)V

    .line 1452
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getRegionalCenter()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGSDK;->setDataCenter(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 1454
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, v6}, Lcom/igg/sdk/IGGSDK;->setChinaMainland(Z)V

    .line 1460
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, v6}, Lcom/igg/sdk/IGGSDK;->setUseExternalStorage(Z)V

    .line 1462
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, v5}, Lcom/igg/sdk/IGGSDK;->setSwitchHttps(Z)V

    .line 1464
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGSDK;->setApplication(Landroid/app/Application;)V

    .line 1465
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    new-instance v3, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$25;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$25;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V

    invoke-virtual {v2, v3}, Lcom/igg/sdk/IGGSDK;->initialize(Lcom/igg/sdk/IGGSDK$IGGSDKinitFinishListener;)V

    .line 1472
    :try_start_0
    new-instance v1, Lcom/igg/util/LocalStorage;

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v2

    invoke-virtual {v2}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v2

    const-string v3, "AuthRequestReceiver"

    invoke-direct {v1, v2, v3}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    .line 1473
    .local v1, "storage":Lcom/igg/util/LocalStorage;
    const-string v2, "IGGGameId"

    invoke-virtual {v1, v2, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 1477
    .end local v1    # "storage":Lcom/igg/util/LocalStorage;
    :goto_0
    return-void

    .line 1474
    :catch_0
    move-exception v0

    .line 1475
    .local v0, "e":Ljava/lang/Exception;
    const-string v2, "SetupIGGPlatform"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "AuthRequestReceiver storage Exception= "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public ShareOnFacebook()V
    .locals 1

    .prologue
    .line 1328
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->ShareOnFacebook()V

    .line 1329
    return-void
.end method

.method public ShowAccount(Z)V
    .locals 4
    .param p1, "bBind"    # Z

    .prologue
    .line 565
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 566
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$12;

    invoke-direct {v1, p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$12;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Z)V

    const-wide/16 v2, 0x3e8

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 572
    return-void
.end method

.method public ShowExit()V
    .locals 0

    .prologue
    .line 1721
    return-void
.end method

.method public ShowFacebookDebug()V
    .locals 1

    .prologue
    .line 1332
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->ShowDebug()V

    .line 1333
    return-void
.end method

.method public ShowInputActivity([I)V
    .locals 3
    .param p1, "unicode"    # [I

    .prologue
    .line 1747
    sget-object v0, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    .line 1748
    .local v0, "a":Landroid/app/Activity;
    sget-object v1, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    new-instance v2, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;

    invoke-direct {v2, p0, p1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;[I)V

    invoke-virtual {v1, v2}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 1755
    return-void
.end method

.method public SubmitQuestion()V
    .locals 7

    .prologue
    .line 1164
    sget-object v5, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v5}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v2

    .line 1165
    .local v2, "signedkey":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "http://goto-tw.igg.com/game/service/"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1166
    .local v4, "url":Ljava/lang/String;
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "?mobile=1"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1167
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&signed_key="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1168
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&dev_ver="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    sget-object v6, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, ";"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    sget-object v6, Landroid/os/Build$VERSION;->RELEASE:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1169
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&game_ver="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v6

    invoke-virtual {v6}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v6

    invoke-static {v6}, Lcom/igg/util/DeviceUtil;->getAppVersionName(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1170
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&l="

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v6

    invoke-virtual {v6}, Ljava/util/Locale;->getLanguage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1171
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "&login"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 1172
    move-object v0, p0

    .line 1173
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v5, "android.intent.action.VIEW"

    invoke-direct {v1, v5}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1174
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v4}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v3

    .line 1175
    .local v3, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v3}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 1176
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 1178
    return-void
.end method

.method public SupportLiveOnLogin()V
    .locals 5

    .prologue
    .line 230
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetSupportLiveOnLogin()Ljava/lang/String;

    move-result-object v2

    .line 232
    .local v2, "pUrl":Ljava/lang/String;
    move-object v0, p0

    .line 233
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v4, "android.intent.action.VIEW"

    invoke-direct {v1, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 234
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v3

    .line 235
    .local v3, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v3}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 236
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 237
    return-void
.end method

.method public SupportLiveOnLogin_GlobalEdition()V
    .locals 5

    .prologue
    .line 1203
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGURLBundle;->livechatURL()Ljava/lang/String;

    move-result-object v3

    .line 1204
    .local v3, "url":Ljava/lang/String;
    move-object v0, p0

    .line 1205
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v4, "android.intent.action.VIEW"

    invoke-direct {v1, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1206
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 1207
    .local v2, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 1208
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 1209
    return-void
.end method

.method public SupportLiveOnShop()V
    .locals 5

    .prologue
    .line 240
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetSupportLiveOnShop()Ljava/lang/String;

    move-result-object v2

    .line 242
    .local v2, "pUrl":Ljava/lang/String;
    move-object v0, p0

    .line 243
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v4, "android.intent.action.VIEW"

    invoke-direct {v1, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 244
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v2}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v3

    .line 245
    .local v3, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v3}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 246
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 247
    return-void
.end method

.method public SupportLiveOnShop_GlobalEdition()V
    .locals 5

    .prologue
    .line 1223
    invoke-static {}, Lcom/igg/sdk/IGGURLBundle;->sharedInstance()Lcom/igg/sdk/IGGURLBundle;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGURLBundle;->paymentLivechatURL()Ljava/lang/String;

    move-result-object v3

    .line 1224
    .local v3, "url":Ljava/lang/String;
    move-object v0, p0

    .line 1225
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v4, "android.intent.action.VIEW"

    invoke-direct {v1, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1226
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 1227
    .local v2, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 1228
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 1229
    return-void
.end method

.method public SwitchFacebook()V
    .locals 1

    .prologue
    .line 1340
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->SwitchFacebook()V

    .line 1341
    return-void
.end method

.method public TermsofService()V
    .locals 2

    .prologue
    .line 266
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetTermsofService()Ljava/lang/String;

    move-result-object v0

    .line 267
    .local v0, "pUrl":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 268
    return-void
.end method

.method public ThirdPartPayment()V
    .locals 2

    .prologue
    .line 277
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/IGGUrlHelper;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGUrlHelper;->GetThirdPartPayment()Ljava/lang/String;

    move-result-object v0

    .line 278
    .local v0, "pUrl":Ljava/lang/String;
    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoadWebView(Ljava/lang/String;)V

    .line 279
    return-void
.end method

.method public Translate(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1381
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate(Ljava/lang/String;)V

    .line 1382
    return-void
.end method

.method public TranslateBatch(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1385
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch(Ljava/lang/String;)V

    .line 1386
    return-void
.end method

.method public TranslateBatch_Diplomatic(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1397
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_Diplomatic(Ljava/lang/String;)V

    .line 1398
    return-void
.end method

.method public TranslateBatch_Mail(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1393
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_Mail(Ljava/lang/String;)V

    .line 1394
    return-void
.end method

.method public Translate_AA(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1405
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_AA(Ljava/lang/String;)V

    .line 1406
    return-void
.end method

.method public Translate_KA(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1401
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_KA(Ljava/lang/String;)V

    .line 1402
    return-void
.end method

.method public Translate_Mail(Ljava/lang/String;)V
    .locals 1
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 1389
    invoke-static {}, Lcom/igg/iggsdkbusiness/TranslateHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_Mail(Ljava/lang/String;)V

    .line 1390
    return-void
.end method

.method public UninitializeGeTu()V
    .locals 1

    .prologue
    .line 320
    invoke-static {}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->sharedInstance()Lcom/igg/iggsdkbusiness/GeTuiRegister;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/GeTuiRegister;->uninitialize()V

    .line 321
    return-void
.end method

.method public UseExchange()V
    .locals 4

    .prologue
    .line 1139
    move-object v0, p0

    .line 1140
    .local v0, "context":Landroid/content/Context;
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    invoke-direct {v1, v3}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 1141
    .local v1, "intent":Landroid/content/Intent;
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->ExchangeUrl()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v2

    .line 1142
    .local v2, "uri":Landroid/net/Uri;
    invoke-virtual {v1, v2}, Landroid/content/Intent;->setData(Landroid/net/Uri;)Landroid/content/Intent;

    .line 1143
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V

    .line 1144
    return-void
.end method

.method public WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;

    .prologue
    .line 1645
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;

    move-result-object v0

    invoke-virtual {v0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1646
    return-void
.end method

.method public WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V
    .locals 6
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "itemName"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;
    .param p4, "isEnableAntiAddiction"    # Z
    .param p5, "amoutOfLimit"    # F

    .prologue
    .line 1650
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductWeChat;

    move-result-object v0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move v4, p4

    move v5, p5

    invoke-virtual/range {v0 .. v5}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->WeChatPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V

    .line 1651
    return-void
.end method

.method public addShortcut(Ljava/lang/String;Ljava/lang/String;)V
    .locals 9
    .param p1, "gameName"    # Ljava/lang/String;
    .param p2, "className"    # Ljava/lang/String;

    .prologue
    .line 730
    const/4 v3, 0x1

    .line 731
    .local v3, "pForceUpdate":Z
    move-object v4, p1

    .line 732
    .local v4, "pName":Ljava/lang/String;
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "it will create shortcut!"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v3}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v6}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 740
    const-string v6, "delShortcut"

    const-string v7, "delShortcut begin"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 741
    invoke-virtual {p0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->delShortcut(Ljava/lang/String;Ljava/lang/String;)V

    .line 742
    const-string v6, "delShortcut"

    const-string v7, "delShortcut end"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 746
    if-eqz v3, :cond_0

    .line 748
    :try_start_0
    const-string v6, "delShortcut"

    const-string v7, "delShortcut begin"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 749
    invoke-virtual {p0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->delShortcut(Ljava/lang/String;Ljava/lang/String;)V

    .line 750
    const-string v6, "delShortcut"

    const-string v7, "delShortcut end"

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 757
    :cond_0
    :goto_0
    new-instance v5, Landroid/content/Intent;

    const-string v6, "com.android.launcher.action.INSTALL_SHORTCUT"

    invoke-direct {v5, v6}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 759
    .local v5, "shortcut":Landroid/content/Intent;
    const-string v6, "android.intent.extra.shortcut.NAME"

    invoke-virtual {v5, v6, v4}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 760
    const-string v6, "duplicate"

    const/4 v7, 0x0

    invoke-virtual {v5, v6, v7}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Z)Landroid/content/Intent;

    .line 762
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-virtual {v6}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v6

    const/high16 v7, 0x7f020000

    .line 761
    invoke-static {v6, v7}, Landroid/content/Intent$ShortcutIconResource;->fromContext(Landroid/content/Context;I)Landroid/content/Intent$ShortcutIconResource;

    move-result-object v1

    .line 770
    .local v1, "iconRes":Landroid/content/Intent$ShortcutIconResource;
    const-string v6, "android.intent.extra.shortcut.ICON_RESOURCE"

    invoke-virtual {v5, v6, v1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;

    .line 773
    new-instance v2, Landroid/content/Intent;

    const-string v6, "android.intent.action.MAIN"

    invoke-direct {v2, v6}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 774
    .local v2, "intent":Landroid/content/Intent;
    const/high16 v6, 0x200000

    invoke-virtual {v2, v6}, Landroid/content/Intent;->setFlags(I)Landroid/content/Intent;

    .line 775
    const/high16 v6, 0x100000

    invoke-virtual {v2, v6}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    .line 776
    const-string v6, "android.intent.category.LAUNCHER"

    invoke-virtual {v2, v6}, Landroid/content/Intent;->addCategory(Ljava/lang/String;)Landroid/content/Intent;

    .line 777
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v7

    invoke-virtual {v2, v6, v7}, Landroid/content/Intent;->setClass(Landroid/content/Context;Ljava/lang/Class;)Landroid/content/Intent;

    .line 780
    const-string v6, "android.intent.extra.shortcut.INTENT"

    invoke-virtual {v5, v6, v2}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;

    .line 782
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-virtual {v6, v5}, Landroid/app/Activity;->sendBroadcast(Landroid/content/Intent;)V

    .line 783
    return-void

    .line 751
    .end local v1    # "iconRes":Landroid/content/Intent$ShortcutIconResource;
    .end local v2    # "intent":Landroid/content/Intent;
    .end local v5    # "shortcut":Landroid/content/Intent;
    :catch_0
    move-exception v0

    .line 752
    .local v0, "e":Ljava/lang/Exception;
    const-string v6, "delShortcut"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "Exception = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method public delShortcut(Ljava/lang/String;Ljava/lang/String;)V
    .locals 8
    .param p1, "gameName"    # Ljava/lang/String;
    .param p2, "className"    # Ljava/lang/String;

    .prologue
    .line 803
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    .line 804
    .local v0, "context":Landroid/content/Context;
    move-object v3, p1

    .line 805
    .local v3, "pName":Ljava/lang/String;
    new-instance v4, Landroid/content/Intent;

    invoke-direct {v4}, Landroid/content/Intent;-><init>()V

    .line 806
    .local v4, "shortcutIntent":Landroid/content/Intent;
    const-string v5, "com.igg.android"

    invoke-virtual {v4, v5, p2}, Landroid/content/Intent;->setClassName(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 808
    const/high16 v5, 0x10000000

    invoke-virtual {v4, v5}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    .line 809
    const/high16 v5, 0x4000000

    invoke-virtual {v4, v5}, Landroid/content/Intent;->addFlags(I)Landroid/content/Intent;

    .line 811
    new-instance v2, Landroid/content/Intent;

    invoke-direct {v2}, Landroid/content/Intent;-><init>()V

    .line 813
    .local v2, "intent":Landroid/content/Intent;
    :try_start_0
    const-string v5, "android.intent.extra.shortcut.INTENT"

    const/4 v6, 0x0

    .line 814
    invoke-virtual {v4, v6}, Landroid/content/Intent;->toUri(I)Ljava/lang/String;

    move-result-object v6

    const/4 v7, 0x0

    invoke-static {v6, v7}, Landroid/content/Intent;->parseUri(Ljava/lang/String;I)Landroid/content/Intent;

    move-result-object v6

    .line 813
    invoke-virtual {v2, v5, v6}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Landroid/os/Parcelable;)Landroid/content/Intent;
    :try_end_0
    .catch Ljava/net/URISyntaxException; {:try_start_0 .. :try_end_0} :catch_0

    .line 818
    :goto_0
    const-string v5, "com.android.launcher.action.UNINSTALL_SHORTCUT"

    invoke-virtual {v2, v5}, Landroid/content/Intent;->setAction(Ljava/lang/String;)Landroid/content/Intent;

    .line 819
    invoke-virtual {v0, v2}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 821
    return-void

    .line 815
    :catch_0
    move-exception v1

    .line 816
    .local v1, "e":Ljava/net/URISyntaxException;
    invoke-virtual {v1}, Ljava/net/URISyntaxException;->printStackTrace()V

    goto :goto_0
.end method

.method public getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 709
    sget-object v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    return-object v0
.end method

.method public getDeviceName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 966
    sget-object v0, Landroid/os/Build;->MODEL:Ljava/lang/String;

    return-object v0
.end method

.method public getSdkVersion()I
    .locals 1

    .prologue
    .line 970
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    return v0
.end method

.method protected isActivityAlive()Z
    .locals 2

    .prologue
    .line 718
    :try_start_0
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    if-eqz v1, :cond_0

    .line 719
    const/4 v1, 0x1

    .line 724
    :goto_0
    return v1

    .line 721
    :catch_0
    move-exception v0

    .line 722
    .local v0, "localException":Ljava/lang/Exception;
    const-string v1, "Activity is null so we are not running currently"

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 724
    .end local v0    # "localException":Ljava/lang/Exception;
    :cond_0
    const/4 v1, 0x0

    goto :goto_0
.end method

.method public isWXAppInstalled()Z
    .locals 1

    .prologue
    .line 1617
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/WeChatHelper;->isWXAppInstalled()Z

    move-result v0

    return v0
.end method

.method public onActivityResult(IILandroid/content/Intent;)V
    .locals 5
    .param p1, "requestCode"    # I
    .param p2, "resultCode"    # I
    .param p3, "data"    # Landroid/content/Intent;

    .prologue
    const/4 v4, -0x1

    .line 594
    const-string v1, "onActivityResult"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "resultcode"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 595
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onActivityResult"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "resultcode"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->DebugLog(Ljava/lang/String;)V

    .line 608
    const/16 v1, 0x3e9

    if-ne p1, v1, :cond_0

    .line 610
    if-ne p2, v4, :cond_6

    .line 611
    invoke-static {}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    move-result-object v1

    sget-object v2, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-virtual {v1, v2}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->switchAccount(Ljava/lang/String;)V

    .line 613
    const-string v1, ""

    sput-object v1, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->lastAccount:Ljava/lang/String;

    .line 622
    :cond_0
    :goto_0
    const/16 v1, 0x3ea

    if-ne p1, v1, :cond_1

    .line 623
    if-ne p2, v4, :cond_1

    .line 624
    invoke-static {}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    move-result-object v1

    sget-object v2, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-virtual {v1, v2}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->bindingGoogle(Ljava/lang/String;)V

    .line 626
    const-string v1, ""

    sput-object v1, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    .line 631
    :cond_1
    const v1, 0xd1d2

    if-ne p1, v1, :cond_2

    .line 633
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    move-result-object v1

    invoke-virtual {v1, p1, p2, p3}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->handleResult(IILandroid/content/Intent;)V

    .line 637
    :cond_2
    const v1, 0xface

    if-ne p1, v1, :cond_3

    .line 638
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v1

    invoke-virtual {v1, p1, p2, p3}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->OnActivityResult(IILandroid/content/Intent;)V

    .line 641
    :cond_3
    const v1, 0xffff

    if-ne p1, v1, :cond_4

    if-ne p2, v4, :cond_4

    .line 645
    :try_start_0
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SwitchAccountCallBack:Ljava/lang/String;

    const-string v2, "authAccount"

    invoke-virtual {p3, v2}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 653
    :cond_4
    :goto_1
    const v1, 0xfffe

    if-ne p1, v1, :cond_5

    if-ne p2, v4, :cond_5

    .line 657
    :try_start_1
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->BindAccountCallBack:Ljava/lang/String;

    const-string v2, "authAccount"

    invoke-virtual {p3, v2}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 664
    :cond_5
    :goto_2
    return-void

    .line 615
    :cond_6
    invoke-static {}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    move-result-object v1

    .line 616
    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->SwitchingGoogleAccountCancel()V

    goto :goto_0

    .line 647
    :catch_0
    move-exception v0

    .line 649
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, "onActivityResult Exception"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 659
    .end local v0    # "e":Ljava/lang/Exception;
    :catch_1
    move-exception v0

    .line 661
    .restart local v0    # "e":Ljava/lang/Exception;
    const-string v1, "onActivityResult Exception"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_2
.end method

.method protected onCreate(Landroid/os/Bundle;)V
    .locals 2
    .param p1, "bundle"    # Landroid/os/Bundle;

    .prologue
    .line 94
    :try_start_0
    invoke-super {p0, p1}, Lcom/unity3d/player/UnityPlayerActivity;->onCreate(Landroid/os/Bundle;)V
    :try_end_0
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_0

    .line 100
    :goto_0
    sput-object p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->mContext:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .line 103
    :try_start_1
    const-string v1, "android.os.AsyncTask"

    invoke-static {v1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_2

    .line 107
    :goto_1
    :try_start_2
    const-string v1, "com.igg.util.AsyncTask"

    invoke-static {v1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_1

    .line 113
    :goto_2
    return-void

    .line 96
    :catch_0
    move-exception v0

    .line 98
    .local v0, "e":Ljava/lang/IllegalArgumentException;
    invoke-virtual {v0}, Ljava/lang/IllegalArgumentException;->printStackTrace()V

    goto :goto_0

    .line 109
    .end local v0    # "e":Ljava/lang/IllegalArgumentException;
    :catch_1
    move-exception v1

    goto :goto_2

    .line 105
    :catch_2
    move-exception v1

    goto :goto_1
.end method

.method protected onDestroy()V
    .locals 1

    .prologue
    .line 143
    invoke-super {p0}, Lcom/unity3d/player/UnityPlayerActivity;->onDestroy()V

    .line 144
    invoke-static {}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->sharedInstance()Lcom/igg/iggsdkbusiness/ProuductGooglePay;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/ProuductGooglePay;->onDestroy()V

    .line 145
    return-void
.end method

.method protected onNewIntent(Landroid/content/Intent;)V
    .locals 1
    .param p1, "intent"    # Landroid/content/Intent;

    .prologue
    .line 117
    :try_start_0
    invoke-super {p0, p1}, Lcom/unity3d/player/UnityPlayerActivity;->onNewIntent(Landroid/content/Intent;)V

    .line 118
    invoke-static {p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessageUpdateState(Landroid/content/Intent;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 122
    :goto_0
    return-void

    .line 119
    :catch_0
    move-exception v0

    .line 120
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method protected onPause()V
    .locals 0

    .prologue
    .line 137
    invoke-super {p0}, Lcom/unity3d/player/UnityPlayerActivity;->onPause()V

    .line 140
    return-void
.end method

.method protected onResume()V
    .locals 3

    .prologue
    .line 126
    :try_start_0
    invoke-super {p0}, Lcom/unity3d/player/UnityPlayerActivity;->onResume()V

    .line 127
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getIntent()Landroid/content/Intent;

    move-result-object v1

    .line 128
    .local v1, "intent":Landroid/content/Intent;
    invoke-static {v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessageUpdateState(Landroid/content/Intent;)V

    .line 129
    invoke-static {}, Lcom/igg/iggsdkbusiness/WeChatHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/WeChatHelper;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->onResume()V

    .line 130
    invoke-static {}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->OnResume()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 134
    .end local v1    # "intent":Landroid/content/Intent;
    :goto_0
    return-void

    .line 131
    :catch_0
    move-exception v0

    .line 132
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method
