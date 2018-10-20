.class public Lcom/igg/iggsdkbusiness/AuthRequestReceiver;
.super Landroid/content/BroadcastReceiver;
.source "AuthRequestReceiver.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "AuthRequestReceiver"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 28
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 9
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    const/4 v8, 0x0

    const/4 v5, 0x1

    .line 34
    const-string v0, "START_AUTH"

    invoke-virtual {p2, v0}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 36
    new-instance v7, Lcom/igg/util/LocalStorage;

    const-string v0, "igg_login_session"

    invoke-direct {v7, p1, v0}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    .line 37
    .local v7, "storage":Lcom/igg/util/LocalStorage;
    const-string v0, "IGGId"

    invoke-virtual {v7, v0}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 38
    .local v2, "IGGId":Ljava/lang/String;
    const-string v0, "accesskey"

    invoke-virtual {v7, v0}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 39
    .local v3, "accessKey":Ljava/lang/String;
    const-string v0, ""

    invoke-virtual {v2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2

    .line 42
    new-instance v6, Lcom/igg/util/LocalStorage;

    const-string v0, "AuthRequestReceiver"

    invoke-direct {v6, p1, v0}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    .line 43
    .local v6, "gameIdStorage":Lcom/igg/util/LocalStorage;
    const-string v0, "IGGGameId"

    invoke-virtual {v6, v0}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 44
    .local v1, "gameId":Ljava/lang/String;
    const-string v0, ""

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 45
    new-instance v0, Lcom/igg/sdk/wegamers/IGGIMAuthPermission;

    invoke-direct {v0}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission;-><init>()V

    const-string v4, "11"

    new-instance v5, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;

    invoke-direct {v5, p0, v1, v2}, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;-><init>(Lcom/igg/iggsdkbusiness/AuthRequestReceiver;Ljava/lang/String;Ljava/lang/String;)V

    invoke-virtual/range {v0 .. v5}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission;->getIMAuthCode(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;)V

    .line 72
    .end local v1    # "gameId":Ljava/lang/String;
    .end local v2    # "IGGId":Ljava/lang/String;
    .end local v3    # "accessKey":Ljava/lang/String;
    .end local v6    # "gameIdStorage":Lcom/igg/util/LocalStorage;
    .end local v7    # "storage":Lcom/igg/util/LocalStorage;
    :cond_0
    :goto_0
    return-void

    .line 64
    .restart local v1    # "gameId":Ljava/lang/String;
    .restart local v2    # "IGGId":Ljava/lang/String;
    .restart local v3    # "accessKey":Ljava/lang/String;
    .restart local v6    # "gameIdStorage":Lcom/igg/util/LocalStorage;
    .restart local v7    # "storage":Lcom/igg/util/LocalStorage;
    :cond_1
    const-string v0, "AuthRequestReceiver"

    const-string v4, "gameId null "

    invoke-static {v0, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 65
    invoke-static {v5, v8}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->responseAuthResult(ILcom/igg/android/wegamers/auth/AuthInfo;)V

    goto :goto_0

    .line 68
    .end local v1    # "gameId":Ljava/lang/String;
    .end local v6    # "gameIdStorage":Lcom/igg/util/LocalStorage;
    :cond_2
    const-string v0, "AuthRequestReceiver"

    const-string v4, "User not logged in"

    invoke-static {v0, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 69
    invoke-static {v5, v8}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->responseAuthResult(ILcom/igg/android/wegamers/auth/AuthInfo;)V

    goto :goto_0
.end method
