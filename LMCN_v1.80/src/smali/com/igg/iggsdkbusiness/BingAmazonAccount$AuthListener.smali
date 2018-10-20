.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Lcom/amazon/identity/auth/device/authorization/api/AuthorizationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "AuthListener"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;


# direct methods
.method private constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V
    .locals 0

    .prologue
    .line 192
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method synthetic constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;)V
    .locals 0
    .param p1, "x0"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount;
    .param p2, "x1"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    .prologue
    .line 192
    invoke-direct {p0, p1}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V

    return-void
.end method


# virtual methods
.method public onCancel(Landroid/os/Bundle;)V
    .locals 3
    .param p1, "cause"    # Landroid/os/Bundle;

    .prologue
    .line 231
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v1

    const-string v2, "User cancelled authorization"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 233
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 234
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$2;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$2;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 240
    return-void
.end method

.method public onError(Lcom/amazon/identity/auth/device/AuthError;)V
    .locals 3
    .param p1, "ae"    # Lcom/amazon/identity/auth/device/AuthError;

    .prologue
    .line 213
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v1

    const-string v2, "AuthError during authorization"

    invoke-static {v1, v2, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    .line 215
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 216
    .local v0, "handler":Landroid/os/Handler;
    new-instance v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$1;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;)V

    invoke-virtual {v0, v1}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 222
    return-void
.end method

.method public onSuccess(Landroid/os/Bundle;)V
    .locals 2
    .param p1, "response"    # Landroid/os/Bundle;

    .prologue
    .line 202
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v0

    const-string v1, "AuthListener onSuccess"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 203
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$400(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)V

    .line 204
    return-void
.end method
