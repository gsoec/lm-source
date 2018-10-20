.class public Lcom/igg/sdk/push/IGGGCMPushNotification;
.super Ljava/lang/Object;
.source "IGGGCMPushNotification.java"

# interfaces
.implements Lcom/igg/sdk/push/IIGGPushNotification;
.implements Lcom/igg/sdk/IGGSDKObservior;


# static fields
.field public static final BROADCAST_EXTRA_KEY:Ljava/lang/String; = "com.igg.sdk.push.NOTIFICATION_ACTION"

.field public static final GCM_PUSH_TYPE:Ljava/lang/String; = "3"

.field private static final NOTIFICATION_ACTION:Ljava/lang/String; = "com.igg.sdk.push.NOTIFICATION_ACTION"

.field private static final PROPERTY_APP_VERSION:Ljava/lang/String; = "appVersion"

.field public static final PROPERTY_REG_ID:Ljava/lang/String; = "registration_id"

.field public static final REGISTER_NOTIFY_FAIL:I = 0x3

.field public static final REGISTER_REQUEST:I = 0x2

.field private static final TAG:Ljava/lang/String; = "IGGPushNotification"

.field private static instance:Lcom/igg/sdk/push/IGGGCMPushNotification;


# instance fields
.field private context:Landroid/content/Context;

.field private gcm:Lcom/google/android/gms/gcm/GoogleCloudMessaging;

.field private hander:Landroid/os/Handler;

.field private isInitialized:Z

.field private isSupported:Z

.field private registerTask:Landroid/os/AsyncTask;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Landroid/os/AsyncTask",
            "<",
            "Ljava/lang/Void;",
            "Ljava/lang/Void;",
            "Ljava/lang/Void;",
            ">;"
        }
    .end annotation
.end field

.field private registeredMessageReceivers:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Landroid/content/BroadcastReceiver;",
            ">;"
        }
    .end annotation
.end field

.field private storage:Lcom/igg/util/LocalStorage;


# direct methods
.method private constructor <init>()V
    .locals 6

    .prologue
    const/4 v5, 0x0

    .line 85
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 55
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    .line 56
    const/4 v2, 0x1

    iput-boolean v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    .line 187
    new-instance v2, Lcom/igg/sdk/push/IGGGCMPushNotification$2;

    invoke-direct {v2, p0}, Lcom/igg/sdk/push/IGGGCMPushNotification$2;-><init>(Lcom/igg/sdk/push/IGGGCMPushNotification;)V

    iput-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->hander:Landroid/os/Handler;

    .line 87
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2, p0}, Lcom/igg/sdk/IGGSDK;->addValueObservor(Lcom/igg/sdk/IGGSDKObservior;)V

    .line 89
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    iput-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    .line 91
    iget-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-static {v2}, Lcom/google/android/gms/common/GooglePlayServicesUtil;->isGooglePlayServicesAvailable(Landroid/content/Context;)I

    move-result v1

    .line 92
    .local v1, "resultCode":I
    if-eqz v1, :cond_0

    .line 93
    const-string v2, "IGGPushNotification"

    const-string v3, "This device GCM is not supported. No valid Google Play Services APK found"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 94
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    .line 120
    :goto_0
    return-void

    .line 99
    :cond_0
    :try_start_0
    iget-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-static {v2}, Lcom/google/android/gcm/GCMRegistrar;->checkDevice(Landroid/content/Context;)V
    :try_end_0
    .catch Ljava/lang/UnsupportedOperationException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2

    .line 111
    :goto_1
    :try_start_1
    iget-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-static {v2}, Lcom/google/android/gcm/GCMRegistrar;->checkManifest(Landroid/content/Context;)V
    :try_end_1
    .catch Ljava/lang/IllegalStateException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_3

    goto :goto_0

    .line 112
    :catch_0
    move-exception v0

    .line 113
    .local v0, "e":Ljava/lang/IllegalStateException;
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GCMRegistrar checkManifest IllegalStateException:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/IllegalStateException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 114
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    goto :goto_0

    .line 100
    .end local v0    # "e":Ljava/lang/IllegalStateException;
    :catch_1
    move-exception v0

    .line 101
    .local v0, "e":Ljava/lang/UnsupportedOperationException;
    const-string v2, "IGGPushNotification"

    const-string v3, "GCM does not been supported by this device, package com.google.android.gsf not found"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 102
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    goto :goto_1

    .line 103
    .end local v0    # "e":Ljava/lang/UnsupportedOperationException;
    :catch_2
    move-exception v0

    .line 104
    .local v0, "e":Ljava/lang/Exception;
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GCMRegistrar checkDevice Exception:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 105
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    goto :goto_1

    .line 115
    .end local v0    # "e":Ljava/lang/Exception;
    :catch_3
    move-exception v0

    .line 116
    .restart local v0    # "e":Ljava/lang/Exception;
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GCMRegistrar checkManifest Exception:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 117
    iput-boolean v5, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    goto :goto_0
.end method

.method static synthetic access$000(Lcom/igg/sdk/push/IGGGCMPushNotification;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;

    .prologue
    .line 40
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->gcm:Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    return-object v0
.end method

.method static synthetic access$002(Lcom/igg/sdk/push/IGGGCMPushNotification;Lcom/google/android/gms/gcm/GoogleCloudMessaging;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;
    .param p1, "x1"    # Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    .prologue
    .line 40
    iput-object p1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->gcm:Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    return-object p1
.end method

.method static synthetic access$100(Lcom/igg/sdk/push/IGGGCMPushNotification;)Landroid/content/Context;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;

    .prologue
    .line 40
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;
    .param p1, "x1"    # Ljava/lang/String;

    .prologue
    .line 40
    invoke-direct {p0, p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->storeRegistrationId(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$300(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/push/IGGGCMPushNotification;
    .param p1, "x1"    # Ljava/lang/String;

    .prologue
    .line 40
    invoke-direct {p0, p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->sendBroadcast(Ljava/lang/String;)V

    return-void
.end method

.method private gcmRegisterDevice(Ljava/lang/String;)V
    .locals 2
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 154
    new-instance v0, Ljava/lang/Thread;

    new-instance v1, Lcom/igg/sdk/push/IGGGCMPushNotification$1;

    invoke-direct {v1, p0, p1}, Lcom/igg/sdk/push/IGGGCMPushNotification$1;-><init>(Lcom/igg/sdk/push/IGGGCMPushNotification;Ljava/lang/String;)V

    invoke-direct {v0, v1}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 181
    invoke-virtual {v0}, Ljava/lang/Thread;->start()V

    .line 182
    return-void
.end method

.method public static getAPPState(Landroid/content/Context;)Ljava/lang/String;
    .locals 3
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 369
    invoke-static {p0}, Lcom/igg/util/DeviceUtil;->isAPPRun(Landroid/content/Context;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 371
    const-string v1, "IGGPushNotification"

    const-string v2, "Received message when app is offline"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 372
    const-string v0, "2"

    .line 393
    .local v0, "messageState":Ljava/lang/String;
    :goto_0
    return-object v0

    .line 375
    .end local v0    # "messageState":Ljava/lang/String;
    :cond_0
    invoke-static {p0}, Lcom/igg/sdk/backgroundcheck/IGGSDKBackgroundUtil;->isIGGSDKAppInForeground(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 377
    const-string v1, "IGGPushNotification"

    const-string v2, "Received message when app in foreground"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 378
    const-string v0, "5"

    .restart local v0    # "messageState":Ljava/lang/String;
    goto :goto_0

    .line 381
    .end local v0    # "messageState":Ljava/lang/String;
    :cond_1
    const-string v1, "IGGPushNotification"

    const-string v2, "Received message when app in background"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 382
    const-string v0, "4"

    .restart local v0    # "messageState":Ljava/lang/String;
    goto :goto_0
.end method

.method private static getAppVersion(Landroid/content/Context;)I
    .locals 5
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    .line 436
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 437
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v1

    .line 438
    .local v1, "packageInfo":Landroid/content/pm/PackageInfo;
    iget v2, v1, Landroid/content/pm/PackageInfo;->versionCode:I
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    return v2

    .line 439
    .end local v1    # "packageInfo":Landroid/content/pm/PackageInfo;
    :catch_0
    move-exception v0

    .line 441
    .local v0, "e":Landroid/content/pm/PackageManager$NameNotFoundException;
    new-instance v2, Ljava/lang/RuntimeException;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Could not get package name: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-direct {v2, v3}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v2
.end method

.method private getRegistrationId(Landroid/content/Context;)Ljava/lang/String;
    .locals 4
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 232
    new-instance v1, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    const-string v3, "GCMInfo_file"

    invoke-direct {v1, v2, v3}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->storage:Lcom/igg/util/LocalStorage;

    .line 234
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->storage:Lcom/igg/util/LocalStorage;

    const-string v2, "registration_id"

    invoke-virtual {v1, v2}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 235
    .local v0, "registrationId":Ljava/lang/String;
    const-string v1, "IGGPushNotification"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "storage registrationId\uff1a"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 236
    return-object v0
.end method

.method public static onMessage(Landroid/content/Intent;)V
    .locals 5
    .param p0, "intent"    # Landroid/content/Intent;

    .prologue
    .line 322
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    const-string v3, "messageId"

    invoke-virtual {v2, v3}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 323
    .local v0, "messageId":Ljava/lang/String;
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    const-string v3, "messageState"

    invoke-virtual {v2, v3}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 324
    .local v1, "messageState":Ljava/lang/String;
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Received messageId: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 325
    const-string v2, "IGGPushNotification"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "State of queue to be updated to: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 326
    invoke-static {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessageRead(Ljava/lang/String;Ljava/lang/String;)V

    .line 327
    return-void
.end method

.method public static onMessageRead(Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p0, "messageId"    # Ljava/lang/String;
    .param p1, "messageType"    # Ljava/lang/String;

    .prologue
    .line 350
    new-instance v0, Lcom/igg/sdk/service/IGGMobileDeviceService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGMobileDeviceService;-><init>()V

    new-instance v1, Lcom/igg/sdk/push/IGGGCMPushNotification$4;

    invoke-direct {v1}, Lcom/igg/sdk/push/IGGGCMPushNotification$4;-><init>()V

    invoke-virtual {v0, p0, p1, v1}, Lcom/igg/sdk/service/IGGMobileDeviceService;->markMessage(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$messageMarkingListener;)V

    .line 360
    return-void
.end method

.method public static onMessageUpdateState(Landroid/content/Intent;)V
    .locals 4
    .param p0, "intent"    # Landroid/content/Intent;

    .prologue
    .line 334
    if-nez p0, :cond_1

    .line 347
    :cond_0
    :goto_0
    return-void

    .line 338
    :cond_1
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    if-eqz v2, :cond_0

    .line 342
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    const-string v3, "messageId"

    invoke-virtual {v2, v3}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 343
    .local v0, "messageId":Ljava/lang/String;
    invoke-virtual {p0}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    const-string v3, "messageState"

    invoke-virtual {v2, v3}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 344
    .local v1, "messageState":Ljava/lang/String;
    if-eqz v0, :cond_0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    if-eqz v1, :cond_0

    const-string v2, "2"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 345
    const-string v2, "4"

    invoke-static {v0, v2}, Lcom/igg/sdk/push/IGGGCMPushNotification;->onMessageRead(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method private sendBroadcast(Ljava/lang/String;)V
    .locals 4
    .param p1, "message"    # Ljava/lang/String;

    .prologue
    .line 500
    const-string v1, "IGGPushNotification"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "sendBroadcast:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 501
    new-instance v0, Landroid/content/Intent;

    const-string v1, "com.igg.sdk.push.NOTIFICATION_ACTION"

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 502
    .local v0, "intent":Landroid/content/Intent;
    const-string v1, "com.igg.sdk.push.NOTIFICATION_ACTION"

    invoke-virtual {v0, v1, p1}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    .line 503
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-virtual {v1, v0}, Landroid/content/Context;->sendBroadcast(Landroid/content/Intent;)V

    .line 504
    return-void
.end method

.method public static sharedInstance()Lcom/igg/sdk/push/IGGGCMPushNotification;
    .locals 1

    .prologue
    .line 63
    sget-object v0, Lcom/igg/sdk/push/IGGGCMPushNotification;->instance:Lcom/igg/sdk/push/IGGGCMPushNotification;

    if-nez v0, :cond_0

    .line 64
    new-instance v0, Lcom/igg/sdk/push/IGGGCMPushNotification;

    invoke-direct {v0}, Lcom/igg/sdk/push/IGGGCMPushNotification;-><init>()V

    sput-object v0, Lcom/igg/sdk/push/IGGGCMPushNotification;->instance:Lcom/igg/sdk/push/IGGGCMPushNotification;

    .line 67
    :cond_0
    sget-object v0, Lcom/igg/sdk/push/IGGGCMPushNotification;->instance:Lcom/igg/sdk/push/IGGGCMPushNotification;

    return-object v0
.end method

.method private storeRegistrationId(Ljava/lang/String;)V
    .locals 4
    .param p1, "regId"    # Ljava/lang/String;

    .prologue
    .line 245
    new-instance v1, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    const-string v3, "GCMInfo_file"

    invoke-direct {v1, v2, v3}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->storage:Lcom/igg/util/LocalStorage;

    .line 246
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-static {v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getAppVersion(Landroid/content/Context;)I

    move-result v0

    .line 247
    .local v0, "appVersion":I
    const-string v1, "IGGPushNotification"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Saving registrationId: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 248
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->storage:Lcom/igg/util/LocalStorage;

    const-string v2, "registration_id"

    invoke-virtual {v1, v2, p1}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V

    .line 249
    const-string v1, "IGGPushNotification"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Saving registrationId on app version: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 250
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->storage:Lcom/igg/util/LocalStorage;

    const-string v2, "appVersion"

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Lcom/igg/util/LocalStorage;->writeInt(Ljava/lang/String;Ljava/lang/Integer;)V

    .line 251
    return-void
.end method


# virtual methods
.method public SDKValueChanged(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "value"    # Ljava/lang/String;

    .prologue
    .line 76
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    .line 78
    const-string v0, "IGGPushNotification"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "=========== SDKValueChanged ============ value:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    invoke-static {}, Lcom/igg/sdk/push/IGGGCMPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGCMPushNotification;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 80
    invoke-static {}, Lcom/igg/sdk/push/IGGGCMPushNotification;->sharedInstance()Lcom/igg/sdk/push/IGGGCMPushNotification;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;

    .line 83
    :cond_0
    return-void
.end method

.method public initialize(Ljava/lang/String;)Lcom/igg/sdk/push/IIGGPushNotification;
    .locals 2
    .param p1, "IGGID"    # Ljava/lang/String;

    .prologue
    .line 136
    invoke-static {}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->sharedInstance()Lcom/igg/sdk/push/IGGNotificationMessageCenter;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-virtual {v0, v1}, Lcom/igg/sdk/push/IGGNotificationMessageCenter;->init(Landroid/content/Context;)V

    .line 138
    iget-boolean v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    if-nez v0, :cond_0

    .line 139
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    .line 141
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-static {v0}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->getInstance(Landroid/content/Context;)Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->gcm:Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    .line 142
    invoke-direct {p0, p1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->gcmRegisterDevice(Ljava/lang/String;)V

    .line 145
    :cond_0
    return-object p0
.end method

.method public isSupported()Z
    .locals 1

    .prologue
    .line 126
    iget-boolean v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isSupported:Z

    return v0
.end method

.method public nofifyRegisterFailMessage()V
    .locals 2

    .prologue
    .line 464
    new-instance v0, Landroid/os/Message;

    invoke-direct {v0}, Landroid/os/Message;-><init>()V

    .line 465
    .local v0, "msg":Landroid/os/Message;
    const/4 v1, 0x3

    iput v1, v0, Landroid/os/Message;->what:I

    .line 466
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->hander:Landroid/os/Handler;

    invoke-virtual {v1, v0}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    .line 467
    return-void
.end method

.method public onDestroy()V
    .locals 3

    .prologue
    .line 406
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registerTask:Landroid/os/AsyncTask;

    if-eqz v1, :cond_0

    .line 407
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registerTask:Landroid/os/AsyncTask;

    const/4 v2, 0x1

    invoke-virtual {v1, v2}, Landroid/os/AsyncTask;->cancel(Z)Z

    .line 410
    :cond_0
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    if-eqz v1, :cond_2

    .line 411
    const-string v1, "IGGPushNotification"

    const-string v2, "Destroy unregister Receiver service"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 412
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_1
    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/BroadcastReceiver;

    .line 413
    .local v0, "messageReceiver":Landroid/content/BroadcastReceiver;
    if-eqz v0, :cond_1

    .line 414
    iget-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-virtual {v2, v0}, Landroid/content/Context;->unregisterReceiver(Landroid/content/BroadcastReceiver;)V

    goto :goto_0

    .line 419
    .end local v0    # "messageReceiver":Landroid/content/BroadcastReceiver;
    :cond_2
    const/4 v1, 0x0

    iput-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    .line 421
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->gcm:Lcom/google/android/gms/gcm/GoogleCloudMessaging;

    invoke-virtual {v1}, Lcom/google/android/gms/gcm/GoogleCloudMessaging;->close()V

    .line 422
    return-void
.end method

.method public registerReceiver(Landroid/content/BroadcastReceiver;)V
    .locals 3
    .param p1, "messageReceiver"    # Landroid/content/BroadcastReceiver;

    .prologue
    .line 481
    const-string v0, "IGGPushNotification"

    const-string v1, "register BroadcastReceiver"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 482
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    new-instance v1, Landroid/content/IntentFilter;

    const-string v2, "com.igg.sdk.push.NOTIFICATION_ACTION"

    invoke-direct {v1, v2}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p1, v1}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    .line 484
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 485
    const-string v0, "IGGPushNotification"

    const-string v1, "init registeredMessageReceivers"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 486
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    .line 489
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->registeredMessageReceivers:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 490
    return-void
.end method

.method public showMsg(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "message"    # Ljava/lang/String;
    .param p2, "IGGID"    # Ljava/lang/String;
    .param p3, "adId"    # Ljava/lang/String;

    .prologue
    .line 453
    new-instance v1, Landroid/os/Message;

    invoke-direct {v1}, Landroid/os/Message;-><init>()V

    .line 454
    .local v1, "msg":Landroid/os/Message;
    const/4 v2, 0x2

    iput v2, v1, Landroid/os/Message;->what:I

    .line 455
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 456
    .local v0, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v2, "registrationId"

    invoke-virtual {v0, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 457
    const-string v2, "iggId"

    invoke-virtual {v0, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 458
    const-string v2, "adId"

    invoke-virtual {v0, v2, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 459
    iput-object v0, v1, Landroid/os/Message;->obj:Ljava/lang/Object;

    .line 460
    iget-object v2, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->hander:Landroid/os/Handler;

    invoke-virtual {v2, v1}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    .line 461
    return-void
.end method

.method public uninitialize()V
    .locals 4

    .prologue
    .line 261
    iget-boolean v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    if-eqz v1, :cond_0

    .line 262
    const-string v1, "IGGPushNotification"

    const-string v2, "Gcm start uninitialize"

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 263
    const/4 v1, 0x0

    iput-boolean v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->isInitialized:Z

    .line 265
    iget-object v1, p0, Lcom/igg/sdk/push/IGGGCMPushNotification;->context:Landroid/content/Context;

    invoke-direct {p0, v1}, Lcom/igg/sdk/push/IGGGCMPushNotification;->getRegistrationId(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    .line 266
    .local v0, "registrationId":Ljava/lang/String;
    const-string v1, "registrationId"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "uninitialize get regid:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 268
    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 269
    new-instance v1, Lcom/igg/sdk/service/IGGMobileDeviceService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGMobileDeviceService;-><init>()V

    new-instance v2, Lcom/igg/sdk/push/IGGGCMPushNotification$3;

    invoke-direct {v2, p0}, Lcom/igg/sdk/push/IGGGCMPushNotification$3;-><init>(Lcom/igg/sdk/push/IGGGCMPushNotification;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/service/IGGMobileDeviceService;->unregisterDevice(Ljava/lang/String;Lcom/igg/sdk/service/IGGMobileDeviceService$DeviceRegistrationListener;)V

    .line 308
    .end local v0    # "registrationId":Ljava/lang/String;
    :cond_0
    return-void
.end method
