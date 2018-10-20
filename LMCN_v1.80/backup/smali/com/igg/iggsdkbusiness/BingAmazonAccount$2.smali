.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$2;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Lcom/amazon/identity/auth/device/shared/APIListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount;->logoutAmazon()V
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
    .line 168
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$2;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onError(Lcom/amazon/identity/auth/device/AuthError;)V
    .locals 2
    .param p1, "authError"    # Lcom/amazon/identity/auth/device/AuthError;

    .prologue
    .line 176
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v0

    const-string v1, "Error clearing authorization state."

    invoke-static {v0, v1, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    .line 178
    return-void
.end method

.method public onSuccess(Landroid/os/Bundle;)V
    .locals 2
    .param p1, "results"    # Landroid/os/Bundle;

    .prologue
    .line 171
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$2;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$202(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Z)Z

    .line 172
    return-void
.end method
