.class public Lcom/appsflyer/FirebaseInstanceIdListener;
.super Lcom/google/firebase/iid/FirebaseInstanceIdService;
.source ""


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Lcom/google/firebase/iid/FirebaseInstanceIdService;-><init>()V

    return-void
.end method


# virtual methods
.method public onTokenRefresh()V
    .locals 5

    .prologue
    .line 13
    invoke-super {p0}, Lcom/google/firebase/iid/FirebaseInstanceIdService;->onTokenRefresh()V

    .line 15
    const/4 v1, 0x0

    .line 16
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 19
    :try_start_0
    invoke-static {}, Lcom/google/firebase/iid/FirebaseInstanceId;->getInstance()Lcom/google/firebase/iid/FirebaseInstanceId;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/firebase/iid/FirebaseInstanceId;->getToken()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 24
    :goto_0
    if-eqz v0, :cond_0

    .line 25
    const-string v1, "Firebase Refreshed Token = "

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 26
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v4, "afUninstallToken"

    invoke-virtual {v1, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 27
    invoke-static {v1}, Lcom/appsflyer/b;->ˏ(Ljava/lang/String;)Lcom/appsflyer/b;

    move-result-object v1

    .line 28
    new-instance v4, Lcom/appsflyer/b;

    invoke-direct {v4, v2, v3, v0}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    .line 29
    invoke-virtual {v1, v4}, Lcom/appsflyer/b;->ˎ(Lcom/appsflyer/b;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 30
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    invoke-static {v0, v4}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    .line 33
    :cond_0
    return-void

    .line 20
    :catch_0
    move-exception v0

    .line 21
    const-string v4, "Error registering for uninstall tracking"

    invoke-static {v4, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v0, v1

    goto :goto_0
.end method
