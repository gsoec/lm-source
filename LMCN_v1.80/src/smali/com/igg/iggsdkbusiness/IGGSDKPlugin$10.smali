.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->GoogleAccountLogin(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$pName:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 544
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;->val$pName:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 547
    invoke-static {}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->sharedInstance()Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$10;->val$pName:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/SwitchingGoogleAccount;->switchAccount(Ljava/lang/String;)V

    .line 548
    return-void
.end method
