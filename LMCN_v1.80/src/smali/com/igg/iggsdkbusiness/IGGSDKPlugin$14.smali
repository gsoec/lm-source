.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$14;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->AutoLogin()V
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
    .line 585
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$14;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 588
    invoke-static {}, Lcom/igg/iggsdkbusiness/Login;->sharedInstance()Lcom/igg/iggsdkbusiness/Login;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/Login;->AutoLogin()V

    .line 589
    return-void
.end method
