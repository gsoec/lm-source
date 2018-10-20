.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->LoginLog()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$logger:Lcom/igg/sdk/log/IGGLogger;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;Lcom/igg/sdk/log/IGGLogger;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 438
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->val$logger:Lcom/igg/sdk/log/IGGLogger;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 441
    new-instance v0, Ljava/lang/Thread;

    new-instance v1, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;)V

    invoke-direct {v0, v1}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 460
    invoke-virtual {v0}, Ljava/lang/Thread;->start()V

    .line 461
    return-void
.end method
