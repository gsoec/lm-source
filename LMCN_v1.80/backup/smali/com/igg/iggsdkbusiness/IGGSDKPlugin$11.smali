.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$11;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->GoogleAccountLogin()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 555
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$11;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 558
    invoke-static {}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->showAccount(Z)V

    .line 559
    return-void
.end method
