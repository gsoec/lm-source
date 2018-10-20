.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$22;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->RegisterCallback()V
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
    .line 1344
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$22;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 1346
    invoke-static {}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->sharedInstance()Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/FBHelp/FacebookHelper;->RegisterCallback()V

    .line 1347
    return-void
.end method
