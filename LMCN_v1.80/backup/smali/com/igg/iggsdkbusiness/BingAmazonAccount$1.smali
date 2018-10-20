.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Lcom/amazon/identity/auth/device/shared/APIListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount;->LoginWithGetToken()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    .prologue
    .line 89
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onError(Lcom/amazon/identity/auth/device/AuthError;)V
    .locals 3
    .param p1, "ae"    # Lcom/amazon/identity/auth/device/AuthError;

    .prologue
    .line 143
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v1

    const-string v2, "AuthError during updateLoginState"

    invoke-static {v1, v2, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    .line 145
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 146
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$2;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$2;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 160
    return-void
.end method

.method public onSuccess(Landroid/os/Bundle;)V
    .locals 5
    .param p1, "response"    # Landroid/os/Bundle;

    .prologue
    .line 97
    sget-object v2, Lcom/amazon/identity/auth/device/authorization/api/AuthzConstants$BUNDLE_KEY;->TOKEN:Lcom/amazon/identity/auth/device/authorization/api/AuthzConstants$BUNDLE_KEY;

    iget-object v2, v2, Lcom/amazon/identity/auth/device/authorization/api/AuthzConstants$BUNDLE_KEY;->val:Ljava/lang/String;

    invoke-virtual {p1, v2}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 99
    .local v0, "authzToken":Ljava/lang/String;
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "getToken authzToken:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 100
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v2

    if-nez v2, :cond_0

    const/4 v2, 0x1

    :goto_0
    invoke-static {v3, v2}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$202(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Z)Z

    .line 102
    new-instance v1, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    invoke-direct {v1, v2}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 103
    .local v1, "handler":Landroid/os/Handler;
    new-instance v2, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    invoke-direct {v2, p0, v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;Ljava/lang/String;)V

    invoke-virtual {v1, v2}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 136
    return-void

    .line 100
    .end local v1    # "handler":Landroid/os/Handler;
    :cond_0
    const/4 v2, 0x0

    goto :goto_0
.end method
