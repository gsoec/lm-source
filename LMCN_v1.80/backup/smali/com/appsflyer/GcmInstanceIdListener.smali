.class public Lcom/appsflyer/GcmInstanceIdListener;
.super Lcom/google/android/gms/iid/InstanceIDListenerService;
.source ""


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Lcom/google/android/gms/iid/InstanceIDListenerService;-><init>()V

    return-void
.end method


# virtual methods
.method public onTokenRefresh()V
    .locals 7

    .prologue
    const/4 v1, 0x0

    .line 14
    invoke-super {p0}, Lcom/google/android/gms/iid/InstanceIDListenerService;->onTokenRefresh()V

    .line 16
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v2, "gcmProjectNumber"

    invoke-virtual {v0, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 18
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 21
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v4

    invoke-static {v4}, Lcom/google/android/gms/iid/InstanceID;->getInstance(Landroid/content/Context;)Lcom/google/android/gms/iid/InstanceID;

    move-result-object v4

    const-string v5, "GCM"

    const/4 v6, 0x0

    invoke-virtual {v4, v0, v5, v6}, Lcom/google/android/gms/iid/InstanceID;->getToken(Ljava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 26
    :goto_0
    if-eqz v0, :cond_0

    .line 27
    const-string v1, "GCM Refreshed Token = "

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1, v4}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 28
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v4, "afUninstallToken"

    invoke-virtual {v1, v4}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 29
    invoke-static {v1}, Lcom/appsflyer/b;->ˏ(Ljava/lang/String;)Lcom/appsflyer/b;

    move-result-object v1

    .line 30
    new-instance v4, Lcom/appsflyer/b;

    invoke-direct {v4, v2, v3, v0}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    .line 31
    invoke-virtual {v1, v4}, Lcom/appsflyer/b;->ˎ(Lcom/appsflyer/b;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 32
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    invoke-static {v0, v4}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    .line 35
    :cond_0
    return-void

    .line 22
    :catch_0
    move-exception v0

    .line 23
    const-string v4, "Error registering for uninstall tracking"

    invoke-static {v4, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    move-object v0, v1

    goto :goto_0
.end method
