.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;)V
    .locals 0
    .param p1, "this$1"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    .prologue
    .line 441
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;->this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    .line 444
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;->this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->val$logger:Lcom/igg/sdk/log/IGGLogger;

    const-string v1, ""

    const-string v2, ""

    new-instance v3, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;

    invoke-direct {v3, p0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;-><init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;)V

    invoke-virtual {v0, v1, v2, v3}, Lcom/igg/sdk/log/IGGLogger;->loginLog(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/log/listener/LoggerListener;)V

    .line 459
    return-void
.end method
