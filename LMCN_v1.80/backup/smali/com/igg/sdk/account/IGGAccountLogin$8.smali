.class Lcom/igg/sdk/account/IGGAccountLogin$8;
.super Landroid/os/AsyncTask;
.source "IGGAccountLogin.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->switchAccount(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Object;",
        "Ljava/lang/Integer;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$activity:Landroid/app/Activity;

.field final synthetic val$email:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 564
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$email:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$activity:Landroid/app/Activity;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 569
    :try_start_0
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$email:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "oauth2:https://www.googleapis.com/auth/plus.me https://www.googleapis.com/auth/userinfo.profile"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$activity:Landroid/app/Activity;

    invoke-virtual {v4}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 570
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$activity:Landroid/app/Activity;

    invoke-virtual {v2}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$email:Ljava/lang/String;

    const-string v4, "oauth2:https://www.googleapis.com/auth/plus.me https://www.googleapis.com/auth/userinfo.profile"

    invoke-static {v2, v3, v4}, Lcom/google/android/gms/auth/GoogleAuthUtil;->getToken(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 571
    .local v1, "token":Ljava/lang/String;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "get google play account token: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 572
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$activity:Landroid/app/Activity;

    invoke-virtual {v2}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/google/android/gms/auth/GoogleAuthUtil;->invalidateToken(Landroid/content/Context;Ljava/lang/String;)V

    .line 573
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GoogleAuthUtil.invalidateToken "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Lcom/google/android/gms/auth/UserRecoverableAuthException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Lcom/google/android/gms/auth/GoogleAuthException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_4
    .catch Ljava/lang/SecurityException; {:try_start_0 .. :try_end_0} :catch_5
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_6

    .line 600
    .end local v1    # "token":Ljava/lang/String;
    :goto_0
    return-object v1

    .line 576
    :catch_0
    move-exception v0

    .line 578
    .local v0, "ex":Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GooglePlayServicesAvailabilityException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 599
    .end local v0    # "ex":Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;
    :goto_1
    const-string v2, "loginWithGooglePlay"

    const-string v3, "========null========"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 600
    const/4 v1, 0x0

    goto :goto_0

    .line 579
    :catch_1
    move-exception v0

    .line 581
    .local v0, "ex":Lcom/google/android/gms/auth/UserRecoverableAuthException;
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$activity:Landroid/app/Activity;

    invoke-virtual {v0}, Lcom/google/android/gms/auth/UserRecoverableAuthException;->getIntent()Landroid/content/Intent;

    move-result-object v3

    const/16 v4, 0x3e9

    invoke-virtual {v2, v3, v4}, Landroid/app/Activity;->startActivityForResult(Landroid/content/Intent;I)V

    .line 582
    const-string v1, "UserRecoverableAuthException"

    goto :goto_0

    .line 583
    .end local v0    # "ex":Lcom/google/android/gms/auth/UserRecoverableAuthException;
    :catch_2
    move-exception v0

    .line 584
    .local v0, "ex":Lcom/google/android/gms/auth/GoogleAuthException;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "GoogleAuthException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Lcom/google/android/gms/auth/GoogleAuthException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 585
    .end local v0    # "ex":Lcom/google/android/gms/auth/GoogleAuthException;
    :catch_3
    move-exception v0

    .line 587
    .local v0, "ex":Ljava/io/IOException;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "IOException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 588
    .end local v0    # "ex":Ljava/io/IOException;
    :catch_4
    move-exception v0

    .line 590
    .local v0, "ex":Ljava/lang/IllegalArgumentException;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "IllegalArgumentException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/IllegalArgumentException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 591
    .end local v0    # "ex":Ljava/lang/IllegalArgumentException;
    :catch_5
    move-exception v0

    .line 592
    .local v0, "ex":Ljava/lang/SecurityException;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "SecurityException: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/SecurityException;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 593
    invoke-virtual {v0}, Ljava/lang/SecurityException;->printStackTrace()V

    goto/16 :goto_1

    .line 594
    .end local v0    # "ex":Ljava/lang/SecurityException;
    :catch_6
    move-exception v0

    .line 595
    .local v0, "ex":Ljava/lang/Exception;
    const-string v2, "loginWithGooglePlay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Exception: "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 596
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_1
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 8
    .param p1, "token"    # Ljava/lang/Object;

    .prologue
    const/4 v7, 0x0

    const/4 v6, 0x0

    .line 606
    if-eqz p1, :cond_1

    move-object v3, p1

    .line 608
    check-cast v3, Ljava/lang/String;

    const-string v4, "UserRecoverableAuthException"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 665
    .end local p1    # "token":Ljava/lang/Object;
    :goto_0
    return-void

    .line 613
    .restart local p1    # "token":Ljava/lang/Object;
    :cond_0
    new-instance v2, Lcom/igg/sdk/bean/IGGLoginInfo;

    invoke-direct {v2}, Lcom/igg/sdk/bean/IGGLoginInfo;-><init>()V

    .line 614
    .local v2, "loginInfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    check-cast p1, Ljava/lang/String;

    .end local p1    # "token":Ljava/lang/Object;
    invoke-virtual {v2, p1}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGooglePlusToken(Ljava/lang/String;)V

    .line 615
    const-string v3, "loginWithGooglePlay"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "IGGSDK.sharedInstance().getDeviceRegisterId(): "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 616
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGuest(Ljava/lang/String;)V

    .line 617
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-virtual {v3, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKey(Ljava/lang/String;)V

    .line 618
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setGameId(Ljava/lang/String;)V

    .line 619
    sget v3, Lcom/igg/sdk/account/IGGAccountLogin;->ACCESS_KEY_EXPIRED_IN:I

    invoke-virtual {v2, v3}, Lcom/igg/sdk/bean/IGGLoginInfo;->setKeepTime(I)V

    .line 620
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountLogin;->getExpireTime()Ljava/lang/String;

    move-result-object v1

    .line 623
    .local v1, "expireTime":Ljava/lang/String;
    :try_start_0
    new-instance v3, Lcom/igg/sdk/service/IGGLoginService;

    invoke-direct {v3}, Lcom/igg/sdk/service/IGGLoginService;-><init>()V

    new-instance v4, Lcom/igg/sdk/account/IGGAccountLogin$8$1;

    invoke-direct {v4, p0, v1}, Lcom/igg/sdk/account/IGGAccountLogin$8$1;-><init>(Lcom/igg/sdk/account/IGGAccountLogin$8;Ljava/lang/String;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/service/IGGLoginService;->thirdAccountLogin(Lcom/igg/sdk/bean/IGGLoginInfo;Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 658
    :catch_0
    move-exception v0

    .line 659
    .local v0, "e":Ljava/lang/Exception;
    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    const v4, 0x30d4a

    invoke-static {v0, v4}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v4

    invoke-interface {v3, v4, v7, v6}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    .line 660
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_0

    .line 663
    .end local v0    # "e":Ljava/lang/Exception;
    .end local v1    # "expireTime":Ljava/lang/String;
    .end local v2    # "loginInfo":Lcom/igg/sdk/bean/IGGLoginInfo;
    .restart local p1    # "token":Ljava/lang/Object;
    :cond_1
    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountLogin$8;->val$listener:Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;

    new-instance v4, Ljava/lang/Exception;

    const-string v5, "google token is null"

    invoke-direct {v4, v5}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v5, 0x30d43

    invoke-static {v4, v5}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v4

    invoke-interface {v3, v4, v7, v6}, Lcom/igg/sdk/account/IGGAccountLogin$SwitchLoginListener;->onSwitchLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;Z)V

    goto/16 :goto_0
.end method
