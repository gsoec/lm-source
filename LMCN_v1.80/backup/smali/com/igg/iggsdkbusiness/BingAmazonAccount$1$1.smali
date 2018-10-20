.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->onSuccess(Landroid/os/Bundle;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

.field final synthetic val$authzToken:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    .prologue
    .line 103
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->val$authzToken:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    .line 106
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$200(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 108
    new-instance v0, Lcom/igg/sdk/account/IGGAccountBind;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountBind;-><init>()V

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->val$authzToken:Ljava/lang/String;

    new-instance v2, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;-><init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;)V

    invoke-virtual {v0, v1, v2}, Lcom/igg/sdk/account/IGGAccountBind;->bindToAmazonCount(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;)V

    .line 134
    :cond_0
    :goto_0
    return-void

    .line 125
    :cond_1
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v0

    const-string v1, "AuthError during getToken"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 128
    invoke-static {}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$100()Ljava/lang/String;

    move-result-object v0

    const-string v1, "log in again"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 129
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$300(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-static {v0, v1}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$302(Lcom/igg/iggsdkbusiness/BingAmazonAccount;I)I

    .line 130
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$300(Lcom/igg/iggsdkbusiness/BingAmazonAccount;)I

    move-result v0

    const/4 v1, 0x2

    if-ge v0, v1, :cond_0

    .line 131
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->loginAmazon()V

    goto :goto_0
.end method
