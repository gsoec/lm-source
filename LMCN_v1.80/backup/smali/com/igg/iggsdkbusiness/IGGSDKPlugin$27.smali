.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->ShowInputActivity([I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$unicode:[I


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;[I)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 1748
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;->val$unicode:[I

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 1751
    invoke-static {}, Lcom/igg/iggsdkbusiness/InputActivity;->sharedInstance()Lcom/igg/iggsdkbusiness/InputActivity;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$27;->val$unicode:[I

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/InputActivity;->Open([I)V

    .line 1752
    return-void
.end method
