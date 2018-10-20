.class Lcom/igg/sdk/account/IGGAccountBind$5;
.super Landroid/os/AsyncTask;
.source "IGGAccountBind.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindToGooglePlay(Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
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
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$activity:Landroid/app/Activity;

.field final synthetic val$email:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Ljava/lang/String;Landroid/app/Activity;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 484
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$email:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$activity:Landroid/app/Activity;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 489
    :try_start_0
    const-string v2, "IGGAccountBind"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "bindToGooglePlay email:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$email:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, " | context:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 490
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$email:Ljava/lang/String;

    const-string v4, "oauth2:https://www.googleapis.com/auth/plus.me https://www.googleapis.com/auth/userinfo.profile"

    invoke-static {v2, v3, v4}, Lcom/google/android/gms/auth/GoogleAuthUtil;->getToken(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 491
    .local v1, "token":Ljava/lang/String;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v2

    invoke-static {v2, v1}, Lcom/google/android/gms/auth/GoogleAuthUtil;->invalidateToken(Landroid/content/Context;Ljava/lang/String;)V
    :try_end_0
    .catch Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Lcom/google/android/gms/auth/UserRecoverableAuthException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Lcom/google/android/gms/auth/GoogleAuthException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/lang/IllegalArgumentException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_4

    .line 507
    .end local v1    # "token":Ljava/lang/String;
    :goto_0
    return-object v1

    .line 493
    :catch_0
    move-exception v0

    .line 494
    .local v0, "e":Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;
    invoke-virtual {v0}, Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;->printStackTrace()V

    .line 507
    .end local v0    # "e":Lcom/google/android/gms/auth/GooglePlayServicesAvailabilityException;
    :goto_1
    const/4 v1, 0x0

    goto :goto_0

    .line 495
    :catch_1
    move-exception v0

    .line 497
    .local v0, "e":Lcom/google/android/gms/auth/UserRecoverableAuthException;
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$activity:Landroid/app/Activity;

    invoke-virtual {v0}, Lcom/google/android/gms/auth/UserRecoverableAuthException;->getIntent()Landroid/content/Intent;

    move-result-object v3

    const/16 v4, 0x3ea

    invoke-virtual {v2, v3, v4}, Landroid/app/Activity;->startActivityForResult(Landroid/content/Intent;I)V

    .line 498
    const-string v1, "UserRecoverableAuthException"

    goto :goto_0

    .line 499
    .end local v0    # "e":Lcom/google/android/gms/auth/UserRecoverableAuthException;
    :catch_2
    move-exception v0

    .line 500
    .local v0, "e":Lcom/google/android/gms/auth/GoogleAuthException;
    invoke-virtual {v0}, Lcom/google/android/gms/auth/GoogleAuthException;->printStackTrace()V

    goto :goto_1

    .line 501
    .end local v0    # "e":Lcom/google/android/gms/auth/GoogleAuthException;
    :catch_3
    move-exception v0

    .line 502
    .local v0, "e":Ljava/lang/IllegalArgumentException;
    invoke-virtual {v0}, Ljava/lang/IllegalArgumentException;->printStackTrace()V

    goto :goto_1

    .line 503
    .end local v0    # "e":Ljava/lang/IllegalArgumentException;
    :catch_4
    move-exception v0

    .line 504
    .local v0, "e":Ljava/io/IOException;
    invoke-virtual {v0}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_1
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 3
    .param p1, "token"    # Ljava/lang/Object;

    .prologue
    const/4 v2, 0x0

    .line 513
    if-eqz p1, :cond_1

    move-object v0, p1

    .line 515
    check-cast v0, Ljava/lang/String;

    const-string v1, "UserRecoverableAuthException"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 516
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    const/4 v1, 0x1

    invoke-interface {v0, v2, v2, v1}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    .line 524
    .end local p1    # "token":Ljava/lang/Object;
    :goto_0
    return-void

    .line 520
    .restart local p1    # "token":Ljava/lang/Object;
    :cond_0
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    const-string v1, "googleplus"

    check-cast p1, Ljava/lang/String;

    .end local p1    # "token":Ljava/lang/Object;
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-static {v0, v1, p1, v2}, Lcom/igg/sdk/account/IGGAccountBind;->access$000(Lcom/igg/sdk/account/IGGAccountBind;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindListener;)V

    goto :goto_0

    .line 522
    .restart local p1    # "token":Ljava/lang/Object;
    :cond_1
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountBind$5;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$BindListener;

    invoke-interface {v0, v2, v2, v2}, Lcom/igg/sdk/account/IGGAccountBind$BindListener;->onBindFinished(ZZZ)V

    goto :goto_0
.end method
