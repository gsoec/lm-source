.class Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;
.super Ljava/util/TimerTask;
.source "IGGAppConfigService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/service/IGGAppConfigService;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "AppConfigTask"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGAppConfigService;

.field type:I


# direct methods
.method public constructor <init>(Lcom/igg/sdk/service/IGGAppConfigService;I)V
    .locals 0
    .param p2, "type"    # I

    .prologue
    .line 71
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-direct {p0}, Ljava/util/TimerTask;-><init>()V

    .line 72
    iput p2, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->type:I

    .line 73
    return-void
.end method


# virtual methods
.method public run()V
    .locals 8

    .prologue
    const/4 v7, 0x0

    .line 77
    iget v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->type:I

    packed-switch v3, :pswitch_data_0

    .line 108
    :goto_0
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v3, v3, Lcom/igg/sdk/service/IGGAppConfigService;->configRequestTask:Lcom/igg/util/AsyncTask;

    const/4 v4, 0x1

    invoke-virtual {v3, v4}, Lcom/igg/util/AsyncTask;->cancel(Z)Z

    .line 109
    return-void

    .line 79
    :pswitch_0
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v3

    const-string v4, "LOADDEFAULT"

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 80
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, v4, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v4}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getName()Ljava/lang/String;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v5, v5, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v5}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getFormat()Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v6, v6, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v6}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getAppConfigListener()Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    move-result-object v6

    invoke-static {v3, v4, v5, v6}, Lcom/igg/sdk/service/IGGAppConfigService;->access$100(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    .line 81
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iput-object v7, v3, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    goto :goto_0

    .line 84
    :pswitch_1
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v3

    const-string v4, "LOADCDN"

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 85
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, v4, Lcom/igg/sdk/service/IGGAppConfigService;->cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v4}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getName()Ljava/lang/String;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v5, v5, Lcom/igg/sdk/service/IGGAppConfigService;->cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v5}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getFormat()Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v6, v6, Lcom/igg/sdk/service/IGGAppConfigService;->cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v6}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->getAppConfigListener()Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    move-result-object v6

    invoke-static {v3, v4, v5, v6}, Lcom/igg/sdk/service/IGGAppConfigService;->access$200(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    .line 86
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iput-object v7, v3, Lcom/igg/sdk/service/IGGAppConfigService;->cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    goto :goto_0

    .line 89
    :pswitch_2
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v3

    const-string v4, "LOADSND"

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 90
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-static {v3}, Lcom/igg/sdk/service/IGGAppConfigService;->access$300(Lcom/igg/sdk/service/IGGAppConfigService;)Lcom/igg/sdk/bean/IGGAppConfig;

    move-result-object v0

    .line 91
    .local v0, "appConfig":Lcom/igg/sdk/bean/IGGAppConfig;
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v2, v3, Lcom/igg/sdk/service/IGGAppConfigService;->sndRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    .line 92
    .local v2, "tmpListener":Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;
    new-instance v1, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v3

    invoke-direct {v1, v3}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 93
    .local v1, "handler":Landroid/os/Handler;
    new-instance v3, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;

    invoke-direct {v3, p0, v0, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask$1;-><init>(Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;Lcom/igg/sdk/bean/IGGAppConfig;Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;)V

    invoke-virtual {v1, v3}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 104
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iput-object v7, v3, Lcom/igg/sdk/service/IGGAppConfigService;->sndRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    goto/16 :goto_0

    .line 77
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method
