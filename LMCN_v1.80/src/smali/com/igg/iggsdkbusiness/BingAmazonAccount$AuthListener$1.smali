.class Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$1;
.super Ljava/lang/Object;
.source "BingAmazonAccount.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;->onError(Lcom/amazon/identity/auth/device/AuthError;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;

    .prologue
    .line 216
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener$1;->this$1:Lcom/igg/iggsdkbusiness/BingAmazonAccount$AuthListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 0

    .prologue
    .line 220
    return-void
.end method
