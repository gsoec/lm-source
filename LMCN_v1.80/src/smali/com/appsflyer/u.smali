.class final Lcom/appsflyer/u;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/u$a;
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static ˊ(Landroid/content/Context;)Z
    .locals 2

    .prologue
    .line 27
    invoke-static {p0}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;)Z

    move-result v0

    .line 28
    invoke-static {p0}, Lcom/appsflyer/u;->ˎ(Landroid/content/Context;)Z

    move-result v1

    or-int/2addr v0, v1

    .line 29
    return v0
.end method

.method static synthetic ˋ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 18
    invoke-static {p0, p1}, Lcom/appsflyer/u;->ˏ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 114
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "updateServerUninstallToken called with: "

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 116
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "afUninstallToken"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 118
    invoke-static {v0}, Lcom/appsflyer/b;->ˏ(Ljava/lang/String;)Lcom/appsflyer/b;

    move-result-object v0

    .line 121
    const-string v1, "appsflyer-data"

    invoke-virtual {p0, v1, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    .line 122
    const-string v2, "sentRegisterRequestToAF"

    invoke-interface {v1, v2, v3}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v1

    .line 124
    if-eqz v1, :cond_0

    .line 126
    invoke-virtual {v0}, Lcom/appsflyer/b;->ˎ()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 127
    invoke-virtual {v0}, Lcom/appsflyer/b;->ˎ()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1}, Lcom/appsflyer/b;->ˎ()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 134
    :goto_0
    return-void

    .line 131
    :cond_0
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "afUninstallToken"

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->set(Ljava/lang/String;Ljava/lang/String;)V

    .line 133
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v0

    invoke-virtual {p1}, Lcom/appsflyer/b;->ˎ()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, p0, v1}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;Ljava/lang/String;)V

    goto :goto_0
.end method

.method private static ˋ(Landroid/content/Context;)Z
    .locals 7

    .prologue
    const/4 v1, 0x1

    const/4 v0, 0x0

    .line 34
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    if-eqz v2, :cond_1

    .line 61
    :cond_0
    :goto_0
    return v0

    .line 39
    :cond_1
    :try_start_0
    const-string v2, "com.google.android.gms.iid.InstanceIDListenerService"

    invoke-static {v2}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    .line 40
    new-instance v2, Landroid/content/Intent;

    const-string v3, "com.google.android.gms.iid.InstanceID"

    const/4 v4, 0x0

    const-class v5, Lcom/appsflyer/GcmInstanceIdListener;

    invoke-direct {v2, v3, v4, p0, v5}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;Landroid/content/Context;Ljava/lang/Class;)V

    .line 41
    new-instance v3, Landroid/content/Intent;

    const-string v4, "com.google.android.gms.iid.InstanceID"

    const/4 v5, 0x0

    const-class v6, Lcom/google/android/gms/iid/InstanceIDListenerService;

    invoke-direct {v3, v4, v5, p0, v6}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;Landroid/content/Context;Ljava/lang/Class;)V

    .line 6028
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v4

    .line 6029
    const/4 v5, 0x0

    .line 6030
    invoke-virtual {v4, v2, v5}, Landroid/content/pm/PackageManager;->queryIntentServices(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v2

    .line 6031
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_3

    move v2, v1

    .line 42
    :goto_1
    if-nez v2, :cond_2

    .line 8028
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 8029
    const/4 v4, 0x0

    .line 8030
    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->queryIntentServices(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v2

    .line 8031
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_4

    move v2, v1

    .line 43
    :goto_2
    if-eqz v2, :cond_0

    .line 44
    :cond_2
    new-instance v2, Landroid/content/Intent;

    const-string v3, "com.google.android.c2dm.intent.RECEIVE"

    const/4 v4, 0x0

    const-string v5, "com.google.android.gms.gcm.GcmReceiver"

    invoke-static {v5}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v5

    invoke-direct {v2, v3, v4, p0, v5}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;Landroid/content/Context;Ljava/lang/Class;)V

    .line 10021
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    .line 10022
    const/4 v4, 0x0

    .line 10023
    invoke-virtual {v3, v2, v4}, Landroid/content/pm/PackageManager;->queryBroadcastReceivers(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v2

    .line 10024
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_5

    move v2, v1

    .line 45
    :goto_3
    if-eqz v2, :cond_7

    .line 46
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    .line 47
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ".permission.C2D_MESSAGE"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {p0, v2}, Lcom/appsflyer/i$b;->ˎ(Landroid/content/Context;Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_6

    move v0, v1

    .line 48
    goto :goto_0

    :cond_3
    move v2, v0

    .line 6031
    goto :goto_1

    :cond_4
    move v2, v0

    .line 8031
    goto :goto_2

    :cond_5
    move v2, v0

    .line 10024
    goto :goto_3

    .line 50
    :cond_6
    const-string v1, "Cannot verify existence of the app\'s \"permission.C2D_MESSAGE\" permission in the manifest. Please refer to documentation."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    goto/16 :goto_0

    .line 57
    :catch_0
    move-exception v1

    invoke-virtual {v1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    goto/16 :goto_0

    .line 53
    :cond_7
    :try_start_1
    const-string v1, "Cannot verify existence of GcmReceiver receiver in the manifest. Please refer to documentation."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/ClassNotFoundException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_1

    goto/16 :goto_0

    .line 58
    :catch_1
    move-exception v1

    .line 59
    const-string v2, "An error occurred while trying to verify manifest declarations: "

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto/16 :goto_0
.end method

.method private static ˎ(Landroid/content/Context;)Z
    .locals 7

    .prologue
    const/4 v1, 0x1

    const/4 v0, 0x0

    .line 66
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 84
    :goto_0
    return v0

    .line 71
    :cond_0
    :try_start_0
    const-string v2, "com.google.firebase.iid.FirebaseInstanceIdService"

    invoke-static {v2}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    .line 72
    new-instance v2, Landroid/content/Intent;

    const-string v3, "com.google.firebase.INSTANCE_ID_EVENT"

    const/4 v4, 0x0

    const-class v5, Lcom/appsflyer/FirebaseInstanceIdListener;

    invoke-direct {v2, v3, v4, p0, v5}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;Landroid/content/Context;Ljava/lang/Class;)V

    .line 73
    new-instance v3, Landroid/content/Intent;

    const-string v4, "com.google.firebase.INSTANCE_ID_EVENT"

    const/4 v5, 0x0

    const-class v6, Lcom/google/firebase/iid/FirebaseInstanceIdService;

    invoke-direct {v3, v4, v5, p0, v6}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;Landroid/content/Context;Ljava/lang/Class;)V

    .line 10028
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v4

    .line 10029
    const/4 v5, 0x0

    .line 10030
    invoke-virtual {v4, v2, v5}, Landroid/content/pm/PackageManager;->queryIntentServices(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v2

    .line 10031
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_2

    move v2, v1

    .line 74
    :goto_1
    if-nez v2, :cond_1

    .line 12028
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 12029
    const/4 v4, 0x0

    .line 12030
    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->queryIntentServices(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v2

    .line 12031
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    if-lez v2, :cond_3

    move v2, v1

    .line 75
    :goto_2
    if-eqz v2, :cond_4

    :cond_1
    move v0, v1

    .line 76
    goto :goto_0

    :cond_2
    move v2, v0

    .line 10031
    goto :goto_1

    :cond_3
    move v2, v0

    .line 12031
    goto :goto_2

    .line 78
    :cond_4
    const-string v1, "Cannot verify existence of our InstanceID Listener Service in the manifest. Please refer to documentation."

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 83
    :catch_0
    move-exception v1

    goto :goto_0

    .line 81
    :catch_1
    move-exception v1

    .line 82
    const-string v2, "An error occurred while trying to verify manifest declarations: "

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private static ˏ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;",
            "Ljava/lang/String;",
            ")",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    const/4 v1, 0x0

    .line 89
    :try_start_0
    const-string v0, "com.google.android.gms.iid.InstanceID"

    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v0

    .line 90
    const-string v2, "com.google.android.gms.gcm.GcmReceiver"

    invoke-static {v2}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    .line 91
    const-string v2, "getInstance"

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/Class;

    const/4 v4, 0x0

    const-class v5, Landroid/content/Context;

    aput-object v5, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/Class;->getDeclaredMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v2

    .line 92
    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    invoke-virtual {p0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v5

    aput-object v5, v3, v4

    invoke-virtual {v2, v0, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    .line 93
    const-string v3, "getToken"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Class;

    const/4 v5, 0x0

    const-class v6, Ljava/lang/String;

    aput-object v6, v4, v5

    const/4 v5, 0x1

    const-class v6, Ljava/lang/String;

    aput-object v6, v4, v5

    invoke-virtual {v0, v3, v4}, Ljava/lang/Class;->getDeclaredMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    .line 94
    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object p1, v3, v4

    const/4 v4, 0x1

    const-string v5, "GCM"

    aput-object v5, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 95
    if-nez v0, :cond_0

    .line 96
    const-string v0, "Couldn\'t get token using reflection."

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v1

    .line 105
    :cond_0
    :goto_0
    return-object v0

    .line 102
    :catch_0
    move-exception v0

    .line 103
    const-string v2, "Couldn\'t get token using GoogleCloudMessaging. "

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    :goto_1
    move-object v0, v1

    .line 105
    goto :goto_0

    .line 104
    :catch_1
    move-exception v0

    goto :goto_1
.end method
