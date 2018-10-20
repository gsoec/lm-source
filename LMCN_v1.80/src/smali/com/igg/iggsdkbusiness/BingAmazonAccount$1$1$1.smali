.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Lcom/igg/sdk/account/IGGAccountBind$BindAmazonListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;)V
    .locals 0
    .param p1, "this$2"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    .prologue
    .line 108
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "success"    # Z
    .param p2, "code"    # Ljava/lang/String;
    .param p3, "description"    # Ljava/lang/String;

    .prologue
    .line 112
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->logoutAmazon()V

    .line 113
    if-eqz p1, :cond_0

    .line 115
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->SuccessfulCallBack:Ljava/lang/String;

    const-string v2, "0"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 120
    :goto_0
    return-void

    .line 118
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1$1;->this$2:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->FailedCallBack:Ljava/lang/String;

    invoke-virtual {v0, v1, p2}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
