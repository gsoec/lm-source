.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Lcom/igg/sdk/log/listener/LoggerListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;->run()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$2:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;)V
    .locals 0
    .param p1, "this$2"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;

    .prologue
    .line 444
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;->this$2:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFinished(Lcom/igg/sdk/error/IGGError;)V
    .locals 3
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 447
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 448
    const-string v0, "LoginLog"

    const-string v1, "success"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 449
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;->this$2:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;->this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const-string v1, "LoginLogDebugLog"

    const-string v2, "success"

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 457
    :goto_0
    return-void

    .line 452
    :cond_0
    const-string v0, "LoginLog"

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v1

    .line 453
    invoke-virtual {v1}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v1

    .line 452
    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 454
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1$1;->this$2:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8$1;->this$1:Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$8;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    const-string v1, "LoginLogDebugLog"

    .line 455
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    .line 454
    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
