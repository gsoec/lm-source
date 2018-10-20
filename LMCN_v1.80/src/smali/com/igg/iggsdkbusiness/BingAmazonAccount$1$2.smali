.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$2;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->onError(Lcom/amazon/identity/auth/device/AuthError;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    .prologue
    .line 146
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$2;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 148
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1$2;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BingAmazonAccount;

    const/4 v1, 0x0

    invoke-static {v0, v1}, Lcom/igg/iggsdkbusiness/BingAmazonAccount;->access$202(Lcom/igg/iggsdkbusiness/BingAmazonAccount;Z)Z

    .line 149
    return-void
.end method
