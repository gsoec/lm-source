.class public Lcom/igg/sdk/account/GooglePlay;
.super Ljava/lang/Object;
.source "GooglePlay.java"


# static fields
.field public static final G_PLUS_SCOPE:Ljava/lang/String; = "oauth2:https://www.googleapis.com/auth/plus.me"

.field public static final REQUEST_CODE_BIND_REAUTH:I = 0x3ea

.field public static final REQUEST_CODE_LOGIN_REAUTH:I = 0x3e9

.field public static final SCOPES:Ljava/lang/String; = "oauth2:https://www.googleapis.com/auth/plus.me https://www.googleapis.com/auth/userinfo.profile"

.field public static final USERINFO_SCOPE:Ljava/lang/String; = "https://www.googleapis.com/auth/userinfo.profile"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getLocalRegisteredEmails()[Ljava/lang/String;
    .locals 5

    .prologue
    .line 36
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-static {v3}, Landroid/accounts/AccountManager;->get(Landroid/content/Context;)Landroid/accounts/AccountManager;

    move-result-object v3

    const-string v4, "com.google"

    invoke-virtual {v3, v4}, Landroid/accounts/AccountManager;->getAccountsByType(Ljava/lang/String;)[Landroid/accounts/Account;

    move-result-object v0

    .line 38
    .local v0, "accounts":[Landroid/accounts/Account;
    array-length v3, v0

    new-array v2, v3, [Ljava/lang/String;

    .line 39
    .local v2, "names":[Ljava/lang/String;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    array-length v3, v2

    if-ge v1, v3, :cond_0

    .line 40
    aget-object v3, v0, v1

    iget-object v3, v3, Landroid/accounts/Account;->name:Ljava/lang/String;

    aput-object v3, v2, v1

    .line 39
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 43
    :cond_0
    return-object v2
.end method
