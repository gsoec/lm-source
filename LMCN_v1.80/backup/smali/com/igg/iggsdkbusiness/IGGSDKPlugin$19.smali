.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$19;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SetFacebookSdkInitialize()V
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
    .line 1280
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$19;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 1282
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$19;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->SdkInitialize(Landroid/content/Context;)V

    .line 1283
    return-void
.end method
